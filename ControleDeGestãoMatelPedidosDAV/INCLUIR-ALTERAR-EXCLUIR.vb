Imports MySql.Data.MySqlClient

Public Class INCLUIR_ALTERAR_EXCLUIR
    ' Propriedades públicas
    Public Modo As String = "INCLUIR"
    Public IdRegistro As Integer = 0
    Private Sub INCLUIR_ALTERAR_EXCLUIR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarNumerDAV()
        CarregarData()
        CarregarClientePadrao()
        ConfigurarGridProdutos()
        CarregarVendedorPadrao()

        ' Bloqueia campos somente leitura
        TextBoxCOD.ReadOnly = True
        TextBoxDATA.ReadOnly = True
        TextBoxNOMECLIENTE.ReadOnly = True
        'TextBoxVENDEDOR.ReadOnly = True
        TextBoxNOMEPAGAMENTO.ReadOnly = True
        TextBoxVALORITENS.ReadOnly = True
        'TextBoxVALORTOTAL.ReadOnly = True

        ' Cores dos campos bloqueados
        TextBoxVENDEDOR.ForeColor = SystemColors.MenuHighlight
        TextBoxVALORTOTAL.ForeColor = Color.Red

    End Sub


    ' ── Gera o próximo número do DAV sem duplicar ──
    Private Sub CarregarNumerDAV()
        Try
            Using conn = ModDB.AbrirConexao()
                Dim sql = "SELECT IFNULL(MAX(CAST(CODIGO AS UNSIGNED)), 0) + 1 FROM dav"
                Using cmd As New MySqlCommand(sql, conn)
                    Dim proximo = Convert.ToInt32(cmd.ExecuteScalar())

                    ' Verifica se o número já existe (segurança para múltiplas máquinas)
                    Dim existe = True
                    While existe
                        Dim sqlVerifica = "SELECT COUNT(*) FROM dav WHERE CODIGO = @cod"
                        Using cmdVerifica As New MySqlCommand(sqlVerifica, conn)
                            cmdVerifica.Parameters.AddWithValue("@cod", proximo.ToString("D5"))
                            existe = Convert.ToInt32(cmdVerifica.ExecuteScalar()) > 0
                            If existe Then
                                proximo += 1
                                MessageBox.Show("O novo número do DAV é " & proximo.ToString("D5"),
                                    "Número atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End Using
                    End While

                    TextBoxCOD.Text = proximo.ToString("D5") ' Formato 00001
                    TextBoxCOD.ReadOnly = True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao gerar código DAV: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Carrega a data de hoje ──
    Private Sub CarregarData()
        TextBoxDATA.Text = DateTime.Now.ToString("dd/MM/yy")
        TextBoxDATA.ReadOnly = True
    End Sub

    ' ── Carrega cliente padrão 00001 - CONSUMIDOR FINAL ──
    Private Sub CarregarClientePadrao()
        Try
            Using conn = ModDB.AbrirConexao()
                Dim sql = "SELECT CODIGO, NOME FROM clientes WHERE CODIGO = '00001'"
                Using cmd As New MySqlCommand(sql, conn)
                    Using dr = cmd.ExecuteReader()
                        If dr.Read() Then
                            TextBoxCODCLIENTE.Text = dr("CODIGO").ToString()
                            TextBoxNOMECLIENTE.Text = dr("NOME").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar cliente: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    ' ── Enter no cliente abre o form ADDCLIENTE ──
    Private Sub TextBoxCODCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxCODCLIENTE.KeyDown
        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrEmpty(TextBoxCODCLIENTE.Text.Trim()) Then
                ' Vazio — abre o form
                Dim frm As New ADDCLIENTE()
                frm.ShowDialog()
                If frm.ClienteSelecionado IsNot Nothing Then
                    TextBoxCODCLIENTE.Text = frm.ClienteSelecionado("CODIGO").ToString()
                    TextBoxNOMECLIENTE.Text = frm.ClienteSelecionado("NOME").ToString()
                End If
            ElseIf Not String.IsNullOrEmpty(TextBoxNOMECLIENTE.Text.Trim()) Then
                ' Tem nome carregado — pula para o próximo
                TextBoxCODCLIENTE.Text = TextBoxCODCLIENTE.Text.Trim().PadLeft(5, "0"c) ' Formata o código
                TextBoxCODVENDEDOR.Focus()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    ' ── Enter no vendedor abre o form ADDVENDEDOR ──
    Private Sub TextBoxCODVENDEDOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxCODVENDEDOR.KeyDown
        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrEmpty(TextBoxCODVENDEDOR.Text.Trim()) Then
                ' Vazio — abre o form
                Dim frm As New ADDVENDEDOR()
                frm.ShowDialog()
                If frm.VendedorSelecionado IsNot Nothing Then
                    TextBoxCODVENDEDOR.Text = frm.VendedorSelecionado("CODIGO").ToString()
                    TextBoxVENDEDOR.Text = frm.VendedorSelecionado("NOME").ToString()
                End If
            ElseIf Not String.IsNullOrEmpty(TextBoxVENDEDOR.Text.Trim()) Then
                TextBoxCODVENDEDOR.Text = TextBoxCODVENDEDOR.Text.Trim().PadLeft(5, "0"c)
                PoisonDataGridViewPROCURAPRODUTOS.Focus()
                ' Seleciona a primeira linha e primeira coluna
                If PoisonDataGridViewPROCURAPRODUTOS.Rows.Count > 0 Then
                    PoisonDataGridViewPROCURAPRODUTOS.CurrentCell = PoisonDataGridViewPROCURAPRODUTOS.Rows(0).Cells(0)
                End If
            End If
            e.SuppressKeyPress = True
        End If
    End Sub

    Private TabelaProdutos As New DataTable()

    Private Sub ConfigurarGridProdutos()
        TabelaProdutos = New DataTable()
        TabelaProdutos.Columns.Add("CODIGO")
        TabelaProdutos.Columns.Add("NOME")
        TabelaProdutos.Columns.Add("REFERENCIA")
        TabelaProdutos.Columns.Add("QTDE", GetType(Decimal))
        TabelaProdutos.Columns.Add("UNITARIO", GetType(Decimal))
        TabelaProdutos.Columns.Add("PERC_DESC", GetType(Decimal))
        TabelaProdutos.Columns.Add("VALOR_DESC", GetType(Decimal))
        TabelaProdutos.Columns.Add("TOTAL", GetType(Decimal))

        PoisonDataGridViewPROCURAPRODUTOS.DataSource = TabelaProdutos

        ' Formata colunas
        With PoisonDataGridViewPROCURAPRODUTOS
            .Columns("CODIGO").HeaderText = "Código"
            .Columns("CODIGO").Width = 80
            .Columns("NOME").HeaderText = "Nome do Produto"
            .Columns("NOME").Width = 250
            .Columns("REFERENCIA").HeaderText = "Referência"
            .Columns("REFERENCIA").Width = 100
            .Columns("QTDE").HeaderText = "Qtde"
            .Columns("QTDE").Width = 60
            .Columns("UNITARIO").HeaderText = "Unitário"
            .Columns("UNITARIO").Width = 80
            .Columns("UNITARIO").DefaultCellStyle.Format = "C2"
            .Columns("UNITARIO").DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
            .Columns("PERC_DESC").HeaderText = "% Desc"
            .Columns("PERC_DESC").Width = 60
            .Columns("VALOR_DESC").HeaderText = "R$ Desc"
            .Columns("VALOR_DESC").Width = 80
            .Columns("VALOR_DESC").DefaultCellStyle.Format = "C2"
            .Columns("VALOR_DESC").DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
            .Columns("TOTAL").HeaderText = "Total"
            .Columns("TOTAL").Width = 80
            .Columns("TOTAL").DefaultCellStyle.Format = "C2"
            .Columns("TOTAL").DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
        End With

        ' Adiciona uma linha vazia para começar
        AdicionarLinhaVazia()
    End Sub

    Private Sub AdicionarLinhaVazia()
        Dim dr = TabelaProdutos.NewRow()
        dr("CODIGO") = ""
        dr("NOME") = ""
        dr("REFERENCIA") = ""
        dr("QTDE") = 1D
        dr("UNITARIO") = 0D
        dr("PERC_DESC") = 0D
        dr("VALOR_DESC") = 0D
        dr("TOTAL") = 0D
        TabelaProdutos.Rows.Add(dr)

        ' Posiciona o cursor na última linha
        Dim ultimaLinha = PoisonDataGridViewPROCURAPRODUTOS.Rows.Count - 1
        PoisonDataGridViewPROCURAPRODUTOS.CurrentCell = PoisonDataGridViewPROCURAPRODUTOS.Rows(ultimaLinha).Cells(0)
    End Sub
    Private Sub PoisonDataGridViewPROCURAPRODUTOS_KeyDown(sender As Object, e As KeyEventArgs) Handles PoisonDataGridViewPROCURAPRODUTOS.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim linhaAtual As Integer = PoisonDataGridViewPROCURAPRODUTOS.CurrentRow?.Index

            Dim frm As New ESTOQUE()
            frm.ModoSelecao = True
            frm.ShowDialog()

            If frm.ProdutosSelecionados.Count > 0 Then
                For Each prod In frm.ProdutosSelecionados

                    ' Garante que a linha atual existe
                    If linhaAtual >= TabelaProdutos.Rows.Count Then
                        AdicionarLinhaVazia()
                    End If

                    Dim dr = TabelaProdutos.Rows(linhaAtual)

                    ' Se a linha já tem produto adiciona uma nova abaixo
                    If Not String.IsNullOrEmpty(dr("CODIGO").ToString()) Then
                        AdicionarLinhaVazia()
                        linhaAtual = TabelaProdutos.Rows.Count - 1
                        dr = TabelaProdutos.Rows(linhaAtual)
                    End If

                    ' ── Aqui é a correção ──
                    dr("CODIGO") = If(prod("CODIGO") IsNot Nothing, prod("CODIGO"), "")
                    dr("NOME") = If(prod("NOME") IsNot Nothing, prod("NOME"), "")
                    dr("REFERENCIA") = If(prod("REFERENCIA") IsNot Nothing, prod("REFERENCIA"), "")

                    Dim qtde As Decimal = 1D
                    If prod.ContainsKey("QTDE") AndAlso Not String.IsNullOrEmpty(prod("QTDE")) Then
                        Decimal.TryParse(prod("QTDE").Replace(",", "."),
                         System.Globalization.NumberStyles.Any,
                         System.Globalization.CultureInfo.InvariantCulture, qtde)
                    End If
                    dr("QTDE") = qtde

                    Dim unitario As Decimal = 0D
                    If prod.ContainsKey("UNITARIO") AndAlso Not String.IsNullOrEmpty(prod("UNITARIO")) Then
                        Decimal.TryParse(prod("UNITARIO"),
                     System.Globalization.NumberStyles.Any,
                     System.Globalization.CultureInfo.InvariantCulture, unitario)
                    End If
                    dr("UNITARIO") = unitario
                    dr("TOTAL") = qtde * unitario

                    linhaAtual += 1
                Next

                ' Garante linha vazia no final
                Dim ultimaDr = TabelaProdutos.Rows(TabelaProdutos.Rows.Count - 1)
                If Not String.IsNullOrEmpty(ultimaDr("CODIGO").ToString()) Then
                    AdicionarLinhaVazia()
                End If

                AtualizarTotais()
            End If

            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub AtualizarTotais()
        Dim totalProdutos As Decimal = 0
        Dim quantItens As Integer = 0

        For Each row As DataRow In TabelaProdutos.Rows
            Dim total = Convert.ToDecimal(row("TOTAL"))
            If total > 0 Then
                totalProdutos += total
                quantItens += 1
            End If
        Next

        ' Desconto em porcentagem
        Dim descPerc As Decimal = 0
        Decimal.TryParse(TextBoxDESCONTOPORCENT.Text.Trim().Replace(",", "."),
                     System.Globalization.NumberStyles.Any,
                     System.Globalization.CultureInfo.InvariantCulture, descPerc)
        Dim valorDescPerc = totalProdutos * (descPerc / 100)

        ' Desconto em real
        Dim descReal As Decimal = 0
        Decimal.TryParse(TextBoxDESCONTOREAL.Text.Replace("R$", "").Replace(".", "").Replace(",", ".").Trim(),
                     System.Globalization.NumberStyles.Any,
                     System.Globalization.CultureInfo.InvariantCulture, descReal)

        ' Garante que os descontos não ultrapassam o total
        If valorDescPerc > totalProdutos Then valorDescPerc = 0
        If descReal > totalProdutos Then descReal = 0

        Dim totalFinal = totalProdutos - valorDescPerc - descReal

        ' Garante que não fica negativo
        If totalFinal < 0 Then totalFinal = 0

        Dim ptBR = System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
        TextBoxVALORITENS.Text = quantItens.ToString()
        TextBoxVALORTOTAL.Text = totalFinal.ToString("C2", ptBR)
    End Sub

    Private Sub ButtonCONFIRMAR_Click(sender As Object, e As EventArgs) Handles ButtonCONFIRMAR.Click
        ' ── Validações antes de salvar ──
        If String.IsNullOrEmpty(TextBoxCODCLIENTE.Text) Then
            MessageBox.Show("Selecione um cliente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrEmpty(TextBoxCODVENDEDOR.Text) Then
            MessageBox.Show("Selecione um vendedor!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrEmpty(TextBoxCODPAGAMENTO.Text) Then
            MessageBox.Show("Selecione uma forma de pagamento!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Verifica se tem pelo menos um produto
        Dim produtosValidos = TabelaProdutos.AsEnumerable().Where(
            Function(row) Convert.ToDecimal(row("TOTAL")) > 0).ToList()

        If produtosValidos.Count = 0 Then
            MessageBox.Show("Adicione pelo menos um produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' ── Confirma o salvamento ──
        Dim confirmar = MessageBox.Show("Deseja confirmar o DAV " & TextBoxCOD.Text & "?",
            "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmar = DialogResult.No Then Return

        Try
            Using conn = ModDB.AbrirConexao()
                Dim transaction = conn.BeginTransaction()

                Try
                    ' ── Converte os valores ──
                    Dim totalGeral As Decimal
                    Decimal.TryParse(TextBoxVALORTOTAL.Text.Replace("R$", "").Replace(".", "").Replace(",", ".").Trim(), totalGeral)

                    Dim descPerc As Decimal
                    Decimal.TryParse(TextBoxDESCONTOPORCENT.Text.Replace(",", "."), descPerc)

                    Dim descReal As Decimal
                    Decimal.TryParse(TextBoxDESCONTOREAL.Text.Replace("R$", "").Replace(".", "").Replace(",", ".").Trim(), descReal)

                    ' ── Verifica novamente se o código já existe (segurança multimáquina) ──
                    Dim sqlVerifica = "SELECT COUNT(*) FROM dav WHERE CODIGO = @cod"
                    Using cmdVerifica As New MySqlCommand(sqlVerifica, conn, transaction)
                        cmdVerifica.Parameters.AddWithValue("@cod", TextBoxCOD.Text)
                        Dim jaExiste = Convert.ToInt32(cmdVerifica.ExecuteScalar()) > 0
                        If jaExiste Then
                            transaction.Rollback()
                            MessageBox.Show("O número do DAV já foi utilizado por outra máquina! Reiniciando...",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            CarregarNumerDAV() ' Recarrega o próximo número
                            Return
                        End If
                    End Using

                    ' ── Salva o cabeçalho do DAV ──
                    Dim sqlDAV = "INSERT INTO dav (CODIGO, EMISSAO, COD_CLIENTE, NOME_CLIENTE, " &
                                 "COD_VENDEDOR, NOME_VENDEDOR, TOTAL_GERAL, STATUS) " &
                                 "VALUES (@cod, @emissao, @codcli, @nomecli, @codvend, @nomevend, @total, @status)"

                    Dim idDAV As Long
                    Using cmdDAV As New MySqlCommand(sqlDAV, conn, transaction)
                        cmdDAV.Parameters.AddWithValue("@cod", TextBoxCOD.Text)
                        cmdDAV.Parameters.AddWithValue("@emissao", DateTime.Now.ToString("yyyy-MM-dd"))
                        cmdDAV.Parameters.AddWithValue("@codcli", TextBoxCODCLIENTE.Text)
                        cmdDAV.Parameters.AddWithValue("@nomecli", TextBoxNOMECLIENTE.Text)
                        cmdDAV.Parameters.AddWithValue("@codvend", TextBoxCODVENDEDOR.Text)
                        cmdDAV.Parameters.AddWithValue("@nomevend", TextBoxVENDEDOR.Text)
                        cmdDAV.Parameters.AddWithValue("@total", totalGeral)
                        cmdDAV.Parameters.AddWithValue("@status", "ORÇANDO")
                        cmdDAV.ExecuteNonQuery()
                        idDAV = cmdDAV.LastInsertedId
                    End Using

                    ' ── Salva os itens do DAV ──
                    For Each row In produtosValidos
                        Dim sqlItem = "INSERT INTO dav_itens (ID_DAV, COD_PRODUTO, NOME_PRODUTO, " &
                                      "REFERENCIA, QTDE, UNITARIO, PERC_DESC, VALOR_DESC, TOTAL) " &
                                      "VALUES (@iddav, @cod, @nome, @ref, @qtde, @unit, @percDesc, @valDesc, @total)"

                        Using cmdItem As New MySqlCommand(sqlItem, conn, transaction)
                            cmdItem.Parameters.AddWithValue("@iddav", idDAV)
                            cmdItem.Parameters.AddWithValue("@cod", row("CODIGO").ToString())
                            cmdItem.Parameters.AddWithValue("@nome", row("NOME").ToString())
                            cmdItem.Parameters.AddWithValue("@ref", row("REFERENCIA").ToString())
                            cmdItem.Parameters.AddWithValue("@qtde", Convert.ToDecimal(row("QTDE")))
                            cmdItem.Parameters.AddWithValue("@unit", Convert.ToDecimal(row("UNITARIO")))
                            cmdItem.Parameters.AddWithValue("@percDesc", Convert.ToDecimal(row("PERC_DESC")))
                            cmdItem.Parameters.AddWithValue("@valDesc", Convert.ToDecimal(row("VALOR_DESC")))
                            cmdItem.Parameters.AddWithValue("@total", Convert.ToDecimal(row("TOTAL")))
                            cmdItem.ExecuteNonQuery()
                        End Using
                    Next

                    ' ── Confirma a transação ──
                    transaction.Commit()

                    ' ── Pergunta se quer imprimir ──
                    Dim imprimir = MessageBox.Show("DAV " & TextBoxCOD.Text & " salvo com sucesso!" &
                        Environment.NewLine & "Deseja imprimir?",
                        "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If imprimir = DialogResult.Yes Then
                        ImprimirDAV()
                    End If

                    ' ── Limpa o form para novo DAV ──
                    LimparForm()

                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("Erro ao salvar DAV: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Erro de conexão: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ── Limpa o form e prepara para novo DAV ──
    Private Sub LimparForm()
        CarregarNumerDAV()
        CarregarData()
        CarregarClientePadrao()
        TextBoxCODVENDEDOR.Text = ""
        TextBoxVENDEDOR.Text = ""
        TextBoxCODPAGAMENTO.Text = ""
        TextBoxNOMEPAGAMENTO.Text = ""
        TextBoxDESCONTOPORCENT.Text = "0"
        TextBoxDESCONTOREAL.Text = "0"
        TextBoxVALORITENS.Text = "0"
        TextBoxVALORTOTAL.Text = "R$ 0,00"
        TextBoxOBS.Text = ""
        ConfigurarGridProdutos()
    End Sub

    ' ── Botão CANCELAR ──
    Private Sub ButtonCANCELAR_Click(sender As Object, e As EventArgs) Handles ButtonCANCELAR.Click
        Dim confirmar = MessageBox.Show("Deseja cancelar e limpar tudo?",
            "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmar = DialogResult.Yes Then
            LimparForm()
        End If
    End Sub

    ' ── Botão FECHAR ──
    Private Sub ButtonFECHAR_Click(sender As Object, e As EventArgs) Handles ButtonFECHAR.Click
        Dim confirmar = MessageBox.Show("Deseja fechar sem salvar?",
            "Fechar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmar = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    ' ── Impressão ── (stub por enquanto, implemente depois)
    Private Sub ImprimirDAV()
        MessageBox.Show("Aqui vai a impressão na Elgin i9!" & Environment.NewLine &
            "Me mande o modelo quando estiver pronto!",
            "Impressão", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ── OBS somente maiúsculo ──
    Private Sub TextBoxOBS_TextChanged(sender As Object, e As EventArgs) Handles TextBoxOBS.TextChanged
        Dim pos = TextBoxOBS.SelectionStart
        TextBoxOBS.Text = TextBoxOBS.Text.ToUpper()
        TextBoxOBS.SelectionStart = pos
    End Sub
    ' ── Carrega vendedor padrão 02564 - PADRAO ──
    Private Sub CarregarVendedorPadrao()
        Try
            Using conn = ModDB.AbrirConexao()
                Dim sql = "SELECT CODIGO, NOME FROM vendedores WHERE CODIGO = '02564'"
                Using cmd As New MySqlCommand(sql, conn)
                    Using dr = cmd.ExecuteReader()
                        If dr.Read() Then
                            TextBoxCODVENDEDOR.Text = dr("CODIGO").ToString()
                            TextBoxVENDEDOR.Text = dr("NOME").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar vendedor: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TextBoxCODCLIENTE_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCODCLIENTE.TextChanged
        Dim cod = TextBoxCODCLIENTE.Text.Trim().PadLeft(5, "0"c) ' Completa com zeros à esquerda
        Try
            Using conn = ModDB.AbrirConexao()
                Dim sql = "SELECT CODIGO, NOME FROM clientes WHERE CODIGO = @cod"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@cod", cod)
                    Using dr = cmd.ExecuteReader()
                        If dr.Read() Then
                            TextBoxNOMECLIENTE.Text = dr("NOME").ToString()
                        Else
                            TextBoxNOMECLIENTE.Text = ""
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TextBoxCODVENDEDOR_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCODVENDEDOR.TextChanged
        Dim cod = TextBoxCODVENDEDOR.Text.Trim().PadLeft(5, "0"c) ' Completa com zeros à esquerda
        Try
            Using conn = ModDB.AbrirConexao()
                Dim sql = "SELECT CODIGO, NOME FROM vendedores WHERE CODIGO = @cod"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@cod", cod)
                    Using dr = cmd.ExecuteReader()
                        If dr.Read() Then
                            TextBoxVENDEDOR.Text = dr("NOME").ToString()
                        Else
                            TextBoxVENDEDOR.Text = ""
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TextBoxDESCONTOPORCENT_Enter(sender As Object, e As EventArgs) Handles TextBoxDESCONTOPORCENT.Enter
        TextBoxDESCONTOPORCENT.Text = ""
    End Sub

    Private Sub TextBoxDESCONTOPORCENT_Leave(sender As Object, e As EventArgs) Handles TextBoxDESCONTOPORCENT.Leave
        Dim valor As Decimal
        Dim txt = TextBoxDESCONTOPORCENT.Text.Trim().Replace(",", ".")
        If Decimal.TryParse(txt, System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, valor) Then
            TextBoxDESCONTOPORCENT.Text = valor.ToString("0.00").Replace(".", ",")
        Else
            TextBoxDESCONTOPORCENT.Text = "0"
        End If
        AtualizarTotais()
    End Sub

    Private Sub TextBoxDESCONTOPORCENT_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxDESCONTOPORCENT.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBoxDESCONTOREAL.Focus() ' Pula para o próximo
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub TextBoxDESCONTOREAL_Enter(sender As Object, e As EventArgs) Handles TextBoxDESCONTOREAL.Enter
        ' Remove o R$ para digitar limpo
        TextBoxDESCONTOREAL.Text = ""
    End Sub

    Private Sub TextBoxDESCONTOREAL_Leave(sender As Object, e As EventArgs) Handles TextBoxDESCONTOREAL.Leave
        Dim valor As Decimal
        Dim txt = TextBoxDESCONTOREAL.Text.Trim().Replace("R$", "").Replace(".", "").Replace(",", ".").Trim()
        If Decimal.TryParse(txt, System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, valor) Then
            TextBoxDESCONTOREAL.Text = valor.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"))
        Else
            TextBoxDESCONTOREAL.Text = "R$ 0,00"
        End If
        AtualizarTotais()
    End Sub

    Private Sub TextBoxDESCONTOREAL_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxDESCONTOREAL.KeyDown
        If e.KeyCode = Keys.Enter Then
            TextBoxCODPAGAMENTO.Focus() ' Pula para o próximo
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub TextBoxVENDEDOR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxVENDEDOR.KeyPress
        e.Handled = True
    End Sub

    Private Sub TextBoxVALORTOTAL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxVALORTOTAL.KeyPress
        e.Handled = True
    End Sub
    Private Sub TextBoxCODPAGAMENTO_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCODPAGAMENTO.TextChanged
        Dim cod = TextBoxCODPAGAMENTO.Text.Trim().PadLeft(3, "0"c)
        Try
            Using conn = ModDB.AbrirConexao()
                Dim sql = "SELECT CODIGO, NOME FROM formas_pagamento WHERE CODIGO = @cod"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@cod", cod)
                    Using dr = cmd.ExecuteReader()
                        If dr.Read() Then
                            TextBoxNOMEPAGAMENTO.Text = dr("NOME").ToString()
                        Else
                            TextBoxNOMEPAGAMENTO.Text = ""
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBoxCODPAGAMENTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxCODPAGAMENTO.KeyDown
        If e.KeyCode = Keys.Enter Then
            If String.IsNullOrEmpty(TextBoxCODPAGAMENTO.Text.Trim()) Then
                ' Vazio — abre o form
                Dim frm As New ADDFORMPAGAMENTO()
                frm.ShowDialog()
                If frm.PagamentoSelecionado IsNot Nothing Then
                    TextBoxCODPAGAMENTO.Text = frm.PagamentoSelecionado("CODIGO").ToString()
                    TextBoxNOMEPAGAMENTO.Text = frm.PagamentoSelecionado("NOME").ToString()
                End If
            ElseIf Not String.IsNullOrEmpty(TextBoxNOMEPAGAMENTO.Text.Trim()) Then
                ' Tem nome carregado — formata e pula para o próximo
                TextBoxCODPAGAMENTO.Text = TextBoxCODPAGAMENTO.Text.Trim().PadLeft(3, "0"c)
                TextBoxDESCONTOPORCENT.Focus()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
End Class