Imports ClosedXML.Excel
Imports System.IO

Public Class ESTOQUE

    Private TabelaCompleta As DataTable

    Private Async Sub ESTOQUE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxOPCAO.Items.Clear()
        ComboBoxOPCAO.Items.Add("Nome do Produto")
        ComboBoxOPCAO.Items.Add("Código")
        ComboBoxOPCAO.Items.Add("Referência")
        ComboBoxOPCAO.SelectedIndex = 0

        TextBoxPESQUISA.Enabled = False
        ComboBoxOPCAO.Enabled = False

        LabelCARREGAMENTOESTOQUE.Visible = True
        PoisonProgressBarCARREGAMENTOESTOQUE.Visible = True
        PoisonProgressBarCARREGAMENTOESTOQUE.Value = 0

        LabelCARREGAMENTOESTOQUE.Text = "Abrindo arquivo..."
        PoisonProgressBarCARREGAMENTOESTOQUE.Value = 10
        Await Task.Delay(400)

        LabelCARREGAMENTOESTOQUE.Text = "Lendo produtos..."
        PoisonProgressBarCARREGAMENTOESTOQUE.Value = 30
        Await Task.Delay(400)

        Await Task.Run(Sub() CarregarExcel())

        LabelCARREGAMENTOESTOQUE.Text = "Organizando dados..."
        PoisonProgressBarCARREGAMENTOESTOQUE.Value = 70
        Await Task.Delay(400)

        LabelCARREGAMENTOESTOQUE.Text = "Concluído!"
        PoisonProgressBarCARREGAMENTOESTOQUE.Value = 100
        Await Task.Delay(600)

        LabelCARREGAMENTOESTOQUE.Visible = False
        PoisonProgressBarCARREGAMENTOESTOQUE.Visible = False

        TextBoxPESQUISA.Enabled = True
        ComboBoxOPCAO.Enabled = True
        TextBoxPESQUISA.Focus()
    End Sub

    Private Sub CarregarExcel()
        Try
            If Not File.Exists(ModConfig.CaminhoEstoque) Then
                Me.Invoke(Sub() MessageBox.Show("Arquivo não encontrado: " & ModConfig.CaminhoEstoque, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error))
                Return
            End If

            Dim tabela As New DataTable()
            tabela.Columns.Add("Código")
            tabela.Columns.Add("Nome do Produto")
            tabela.Columns.Add("Referência")
            tabela.Columns.Add("R$ Custo", GetType(Decimal))

            Using wb As New XLWorkbook(ModConfig.CaminhoEstoque)
                Dim ws = wb.Worksheet(1)
                For Each row In ws.RowsUsed().Skip(1)
                    Dim dr = tabela.NewRow()
                    dr("Código") = row.Cell(1).GetString().Trim()
                    dr("Nome do Produto") = row.Cell(2).GetString().Trim()
                    dr("Referência") = row.Cell(3).GetString().Trim()

                    Dim valor As Decimal
                    Dim celula = row.Cell(4).GetString().Trim().Replace("R$", "").Replace(".", "").Replace(",", ".").Trim()
                    If Decimal.TryParse(celula, System.Globalization.NumberStyles.Any,
                                    System.Globalization.CultureInfo.InvariantCulture, valor) Then
                        dr("R$ Custo") = valor
                    Else
                        dr("R$ Custo") = 0D
                    End If

                    tabela.Rows.Add(dr)
                Next
            End Using

            TabelaCompleta = tabela

        Catch ex As Exception
            ' MessageBox sempre via Invoke pois estamos em outra thread
            Me.Invoke(Sub() MessageBox.Show("Erro ao carregar estoque: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error))
        End Try
    End Sub

    Private Sub Pesquisar()
        If TabelaCompleta Is Nothing Then Return

        Dim texto As String = TextBoxPESQUISA.Text.Trim().ToUpper()
        Dim coluna As String = ComboBoxOPCAO.SelectedItem.ToString()

        If String.IsNullOrEmpty(texto) Then
            PoisonDataGridViewESTOQUE.DataSource = TabelaCompleta
        Else
            Dim resultado = TabelaCompleta.AsEnumerable().Where(
            Function(row) row(coluna).ToString().ToUpper().Contains(texto)
        ).ToList()

            If resultado.Count = 0 Then
                PoisonDataGridViewESTOQUE.DataSource = Nothing
                MessageBox.Show("Nenhum produto encontrado!", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            PoisonDataGridViewESTOQUE.DataSource = resultado.CopyToDataTable()
        End If

        ' Formata DEPOIS de atribuir o DataSource
        With PoisonDataGridViewESTOQUE.Columns("R$ Custo")
            .DefaultCellStyle.Format = "C2"
            .DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

    End Sub

    Private Sub TextBoxPESQUISA_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPESQUISA.KeyDown
        If e.KeyCode = Keys.Enter Then
            Pesquisar()
            TextBoxPESQUISA.Clear() ' Limpa após pesquisar
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TextBoxPESQUISA_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPESQUISA.TextChanged
        Dim pos = TextBoxPESQUISA.SelectionStart
        TextBoxPESQUISA.Text = TextBoxPESQUISA.Text.ToUpper()
        TextBoxPESQUISA.SelectionStart = pos
    End Sub
    Private Sub PoisonDataGridViewESTOQUE_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles PoisonDataGridViewESTOQUE.DataBindingComplete
        ' Bloqueia edição
        PoisonDataGridViewESTOQUE.ReadOnly = True

        ' Corrige o cabeçalho para não quebrar linha
        PoisonDataGridViewESTOQUE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        PoisonDataGridViewESTOQUE.ColumnHeadersHeight = 30

        PoisonDataGridViewESTOQUE.Columns("Nome do Produto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        ' R$ Custo em negrito, Bahnschrift 12pt, centralizado
        With PoisonDataGridViewESTOQUE.Columns("R$ Custo")
            .HeaderText = "R$ Custo"
            .DefaultCellStyle.Font = New Font("Bahnschrift", 12, FontStyle.Bold)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Width = 100 ' Largura suficiente para não quebrar

        End With
    End Sub
    ' Ao entrar no grid com o mouse, garante o foco para o scroll funcionar
    Private Sub PoisonDataGridViewESTOQUE_MouseEnter(sender As Object, e As EventArgs) Handles PoisonDataGridViewESTOQUE.MouseEnter
        PoisonDataGridViewESTOQUE.Focus()
    End Sub

    ' Scroll move a seleção e não a barra lateral
    Private Sub PoisonDataGridViewESTOQUE_MouseWheel(sender As Object, e As MouseEventArgs) Handles PoisonDataGridViewESTOQUE.MouseWheel
        If PoisonDataGridViewESTOQUE.Rows.Count = 0 Then Return

        Dim linhaAtual As Integer = 0
        If PoisonDataGridViewESTOQUE.CurrentCell IsNot Nothing Then
            linhaAtual = PoisonDataGridViewESTOQUE.CurrentCell.RowIndex
        End If

        Dim novaLinha As Integer
        If e.Delta > 0 Then
            novaLinha = Math.Max(0, linhaAtual - 1)
        Else
            novaLinha = Math.Min(PoisonDataGridViewESTOQUE.Rows.Count - 1, linhaAtual + 1)
        End If

        PoisonDataGridViewESTOQUE.ClearSelection()
        PoisonDataGridViewESTOQUE.Rows(novaLinha).Selected = True
        PoisonDataGridViewESTOQUE.CurrentCell = PoisonDataGridViewESTOQUE.Rows(novaLinha).Cells(0)
        PoisonDataGridViewESTOQUE.FirstDisplayedScrollingRowIndex = novaLinha

        CType(e, HandledMouseEventArgs).Handled = True
    End Sub
End Class