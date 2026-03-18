Imports ClosedXML.Excel
Imports System.IO

Public Class ESTOQUE

    Public ProdutoSelecionado As DataRow
    Private TabelaCompleta As DataTable
    Public ModoSelecao As Boolean = False
    Public ProdutosSelecionados As New List(Of Dictionary(Of String, String))

    Private Async Sub ESTOQUE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ativa ou desativa conforme o modo
        ListViewSELECIONADOS.Visible = ModoSelecao
        ButtonCONFIRMAR.Visible = ModoSelecao

        ComboBoxOPCAO.Items.Clear()
        ComboBoxOPCAO.Items.Add("Nome do Produto")
        ComboBoxOPCAO.Items.Add("Código")
        ComboBoxOPCAO.Items.Add("Referência")
        ComboBoxOPCAO.SelectedIndex = 0

        TextBoxPESQUISA.Enabled = False
        ComboBoxOPCAO.Enabled = False
        LabelCARREGAMENTOESTOQUE.Visible = True
        LabelCARREGAMENTOESTOQUE.Text = "Carregando..."
        PoisonProgressBarCARREGAMENTOESTOQUE.Visible = True
        PoisonProgressBarCARREGAMENTOESTOQUE.Value = 0

        ' Carrega direto sem delays
        Await Task.Run(Sub() CarregarExcel())

        LabelCARREGAMENTOESTOQUE.Visible = False
        PoisonProgressBarCARREGAMENTOESTOQUE.Visible = False
        TextBoxPESQUISA.Enabled = True
        ComboBoxOPCAO.Enabled = True
        TextBoxPESQUISA.Focus()
        ConfigurarListView()
        ListViewSELECIONADOS.Visible = ModoSelecao
        ButtonCONFIRMAR.Visible = ModoSelecao
    End Sub

    ' Configura o ListView no Load
    Private Sub ConfigurarListView()
        ListViewSELECIONADOS.View = View.Details
        ListViewSELECIONADOS.FullRowSelect = True
        ListViewSELECIONADOS.GridLines = True
        ListViewSELECIONADOS.Columns.Clear()
        ListViewSELECIONADOS.Columns.Add("Código", 80)
        ListViewSELECIONADOS.Columns.Add("Nome", 250)
        ListViewSELECIONADOS.Columns.Add("Qtde", 60)
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
                    Dim valor As Decimal = 0D
                    Try
                        If Not String.IsNullOrEmpty(row.Cell(4).GetString()) Then
                            Dim celula = row.Cell(4).GetString().Trim()
                            celula = celula.Replace("R$", "").Replace(" ", "").Trim()
                            If celula.Contains(",") AndAlso celula.Contains(".") Then
                                celula = celula.Replace(".", "").Replace(",", ".")
                            ElseIf celula.Contains(",") Then
                                celula = celula.Replace(",", ".")
                            End If
                            Decimal.TryParse(celula, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, valor)
                        End If
                    Catch
                        valor = 0D
                    End Try
                    dr("R$ Custo") = valor
                    tabela.Rows.Add(dr) ' ← Faltava essa linha!
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
    Private Sub PoisonDataGridViewESTOQUE_KeyDown(sender As Object, e As KeyEventArgs) Handles PoisonDataGridViewESTOQUE.KeyDown
        ' Setas — navega normalmente
        If e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down Then
            Return
        End If

        ' Modo consulta — Enter fecha e retorna produto único
        If e.KeyCode = Keys.Enter AndAlso Not ModoSelecao Then
            If PoisonDataGridViewESTOQUE.CurrentRow IsNot Nothing Then
                ProdutoSelecionado = CType(PoisonDataGridViewESTOQUE.DataSource, DataTable).Rows(
                PoisonDataGridViewESTOQUE.CurrentRow.Index)
                Me.Close()
            End If
            e.SuppressKeyPress = True
            Return
        End If

        ' Modo seleção — Espaço pergunta qtde e adiciona no ListView
        If e.KeyCode = Keys.Space AndAlso ModoSelecao Then
            If PoisonDataGridViewESTOQUE.CurrentRow Is Nothing Then Return

            Dim tbl = CType(PoisonDataGridViewESTOQUE.DataSource, DataTable)
            Dim row = tbl.Rows(PoisonDataGridViewESTOQUE.CurrentRow.Index)

            ' Pergunta a quantidade
            Dim qtdeStr = InputBox("Quantidade para:" & Environment.NewLine &
            row("Nome do Produto").ToString(), "Quantidade", "1")
            If String.IsNullOrEmpty(qtdeStr) Then Return

            Dim qtde As Decimal = 1D
            Decimal.TryParse(qtdeStr.Replace(",", "."),
                         System.Globalization.NumberStyles.Any,
                         System.Globalization.CultureInfo.InvariantCulture, qtde)
            If qtde <= 0 Then
                MessageBox.Show("Quantidade inválida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Pega o unitário com segurança
            Dim unitario As Decimal = 0D
            Dim rawCusto = row("R$ Custo")
            If Not IsDBNull(rawCusto) Then
                Try
                    unitario = Convert.ToDecimal(rawCusto)
                Catch
                    unitario = 0D
                End Try
            End If

            ' Adiciona no ListView
            Dim item As New ListViewItem(row("Código").ToString())
            item.SubItems.Add(row("Nome do Produto").ToString())
            item.SubItems.Add(qtde.ToString("0.###"))
            ListViewSELECIONADOS.Items.Add(item)

            ' Adiciona na lista de retorno com unitário já como string InvariantCulture
            ProdutosSelecionados.Add(New Dictionary(Of String, String) From {
            {"CODIGO", row("Código").ToString()},
            {"NOME", row("Nome do Produto").ToString()},
            {"REFERENCIA", If(IsDBNull(row("Referência")), "", row("Referência").ToString())},
            {"QTDE", qtde.ToString(System.Globalization.CultureInfo.InvariantCulture)},
            {"UNITARIO", unitario.ToString(System.Globalization.CultureInfo.InvariantCulture)}
        })

            e.SuppressKeyPress = True
            Return
        End If

        ' Modo seleção — Enter confirma e fecha
        If e.KeyCode = Keys.Enter AndAlso ModoSelecao Then
            If ProdutosSelecionados.Count = 0 Then
                MessageBox.Show("Selecione pelo menos um produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Me.Close()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub ButtonCONFIRMAR_Click(sender As Object, e As EventArgs) Handles ButtonCONFIRMAR.Click
        If ProdutosSelecionados.Count = 0 Then
            MessageBox.Show("Selecione pelo menos um produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Me.Close()
    End Sub
End Class