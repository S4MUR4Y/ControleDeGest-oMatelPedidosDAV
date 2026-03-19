Imports MySql.Data.MySqlClient

Public Class INCLUIR_ALTERAR_EXCLUIR
    ' Propriedades públicas
    Public Modo As String = "INCLUIR"
    Public IdRegistro As Integer = 0
    Public CodigoDAV As String = ""
    Private Sub INCLUIR_ALTERAR_EXCLUIR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Adicione isso no final do Load, após o Select Case
        Select Case Modo
            Case "INCLUIR"
                Me.Text = "➕ INCLUSÃO DE DAV"
            Case "ALTERAR"
                Me.Text = "✏️ EDIÇÃO DE DAV - " & CodigoDAV
            Case "EXCLUIR"
                Me.Text = "🗑️ EXCLUSÃO DE DAV - " & CodigoDAV
            Case "CONSULTAR"
                Me.Text = "🔍 CONSULTA DE DAV - " & CodigoDAV
        End Select

        Select Case Modo
            Case "INCLUIR"
                CarregarNumerDAV()
                CarregarData()
                CarregarClientePadrao()
                CarregarVendedorPadrao()
                ConfigurarGridProdutos()

            Case "ALTERAR", "CONSULTAR"
                CarregarDAVExistente()   ' ← carrega tudo do DAV existente

                If Modo = "CONSULTAR" Then
                    BloquearCampos()
                End If
        End Select

        ' Bloqueia campos somente leitura
        TextBoxCOD.ReadOnly = True
        TextBoxDATA.ReadOnly = True
        TextBoxNOMECLIENTE.ReadOnly = True
        TextBoxNOMEPAGAMENTO.ReadOnly = True
        TextBoxVALORITENS.ReadOnly = True

        ' Cores
        TextBoxVENDEDOR.ForeColor = SystemColors.MenuHighlight
        TextBoxVALORTOTAL.ForeColor = Color.Red

        ' ── Ordem de tabulação ──
        'TextBoxCOD.TabIndex = 0
        'TextBoxDATA.TabIndex = 1
        TextBoxCODCLIENTE.TabIndex = 0
        'TextBoxNOMECLIENTE.TabIndex = 3
        TextBoxCODVENDEDOR.TabIndex = 1
        'TextBoxVENDEDOR.TabIndex = 5
        PoisonDataGridViewPROCURAPRODUTOS.TabIndex = 2
        TextBoxCODPAGAMENTO.TabIndex = 3
        'TextBoxNOMEPAGAMENTO.TabIndex = 8
        TextBoxDESCONTOPORCENT.TabIndex = 4
        TextBoxDESCONTOREAL.TabIndex = 5
        TextBoxOBS.TabIndex = 6
        ButtonCONFIRMAR.TabIndex = 7
        ButtonCANCELAR.TabIndex = 8
        ButtonFECHAR.TabIndex = 9

    End Sub
    Private Sub BloquearCampos()
        TextBoxCODCLIENTE.ReadOnly = True
        TextBoxCODVENDEDOR.ReadOnly = True
        TextBoxCODPAGAMENTO.ReadOnly = True
        TextBoxDESCONTOPORCENT.ReadOnly = True
        TextBoxDESCONTOREAL.ReadOnly = True
        TextBoxOBS.ReadOnly = True
        PoisonDataGridViewPROCURAPRODUTOS.ReadOnly = True
        ButtonCONFIRMAR.Enabled = False
    End Sub

    Private Sub CarregarDAVExistente()
        Try
            Using conn = ModDB.AbrirConexao()
                ' Carrega o cabeçalho
                Dim sql = "SELECT * FROM dav WHERE CODIGO = @cod"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@cod", CodigoDAV)
                    Using dr = cmd.ExecuteReader()
                        If dr.Read() Then
                            TextBoxCOD.Text = dr("CODIGO").ToString()
                            TextBoxDATA.Text = Convert.ToDateTime(dr("EMISSAO")).ToString("dd/MM/yy")
                            TextBoxCODCLIENTE.Text = dr("COD_CLIENTE").ToString()
                            TextBoxNOMECLIENTE.Text = dr("NOME_CLIENTE").ToString()
                            TextBoxCODVENDEDOR.Text = dr("COD_VENDEDOR").ToString()
                            TextBoxVENDEDOR.Text = dr("NOME_VENDEDOR").ToString()
                            TextBoxCODPAGAMENTO.Text = dr("COD_PAGAMENTO").ToString()
                            TextBoxNOMEPAGAMENTO.Text = dr("NOME_PAGAMENTO").ToString()
                            TextBoxOBS.Text = dr("OBS").ToString()
                            TextBoxDESCONTOPORCENT.Text = If(IsDBNull(dr("DESC_PERC")), "0", Convert.ToDecimal(dr("DESC_PERC")).ToString("0.00", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")))
                            TextBoxDESCONTOREAL.Text = If(IsDBNull(dr("DESC_REAL")), "R$ 0,00", Convert.ToDecimal(dr("DESC_REAL")).ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")))
                        End If
                    End Using
                End Using

                ' Carrega os itens
                Dim sqlItens = "SELECT * FROM dav_itens WHERE ID_DAV = " &
                       "(SELECT ID FROM dav WHERE CODIGO = @cod)"
                Using cmd As New MySqlCommand(sqlItens, conn)
                    cmd.Parameters.AddWithValue("@cod", CodigoDAV)
                    Using dr = cmd.ExecuteReader()
                        TabelaProdutos = New DataTable()
                        TabelaProdutos.Columns.Add("CODIGO")
                        TabelaProdutos.Columns.Add("NOME")
                        TabelaProdutos.Columns.Add("REFERENCIA")
                        TabelaProdutos.Columns.Add("QTDE", GetType(Decimal))
                        TabelaProdutos.Columns.Add("UNITARIO", GetType(Decimal))
                        TabelaProdutos.Columns.Add("PERC_DESC", GetType(Decimal))
                        TabelaProdutos.Columns.Add("VALOR_DESC", GetType(Decimal))
                        TabelaProdutos.Columns.Add("TOTAL", GetType(Decimal))

                        ' ✅ AllowDBNull ANTES de popular
                        TabelaProdutos.Columns("QTDE").AllowDBNull = True
                        TabelaProdutos.Columns("UNITARIO").AllowDBNull = True
                        TabelaProdutos.Columns("PERC_DESC").AllowDBNull = True
                        TabelaProdutos.Columns("VALOR_DESC").AllowDBNull = True
                        TabelaProdutos.Columns("TOTAL").AllowDBNull = True

                        While dr.Read()
                            Dim row = TabelaProdutos.NewRow()
                            row("CODIGO") = dr("COD_PRODUTO").ToString()
                            row("NOME") = dr("NOME_PRODUTO").ToString()
                            row("REFERENCIA") = dr("REFERENCIA").ToString()
                            row("QTDE") = If(IsDBNull(dr("QTDE")), DBNull.Value, Convert.ToDecimal(dr("QTDE")))
                            row("UNITARIO") = If(IsDBNull(dr("UNITARIO")), DBNull.Value, Convert.ToDecimal(dr("UNITARIO")))
                            row("PERC_DESC") = If(IsDBNull(dr("PERC_DESC")), DBNull.Value, Convert.ToDecimal(dr("PERC_DESC")))
                            row("VALOR_DESC") = If(IsDBNull(dr("VALOR_DESC")), DBNull.Value, Convert.ToDecimal(dr("VALOR_DESC")))
                            row("TOTAL") = If(IsDBNull(dr("TOTAL")), DBNull.Value, Convert.ToDecimal(dr("TOTAL")))
                            TabelaProdutos.Rows.Add(row)
                        End While
                    End Using
                End Using

                PoisonDataGridViewPROCURAPRODUTOS.DataSource = TabelaProdutos
                AtualizarTotais()
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar DAV: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

        ' ✅ AllowDBNull ANTES do DataSource
        TabelaProdutos.Columns("QTDE").AllowDBNull = True
        TabelaProdutos.Columns("UNITARIO").AllowDBNull = True
        TabelaProdutos.Columns("PERC_DESC").AllowDBNull = True
        TabelaProdutos.Columns("VALOR_DESC").AllowDBNull = True
        TabelaProdutos.Columns("TOTAL").AllowDBNull = True

        ' ✅ DataSource DEPOIS
        PoisonDataGridViewPROCURAPRODUTOS.DataSource = TabelaProdutos

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

        ' ✅ Linha vazia no final para permitir adicionar mais produtos
        If Modo = "ALTERAR" Then
            AdicionarLinhaVazia()
        End If
    End Sub
    Private Sub AdicionarLinhaVazia()
        Dim dr = TabelaProdutos.NewRow()
        dr("CODIGO") = ""
        dr("NOME") = ""
        dr("REFERENCIA") = ""
        dr("QTDE") = DBNull.Value
        dr("UNITARIO") = DBNull.Value
        dr("PERC_DESC") = DBNull.Value
        dr("VALOR_DESC") = DBNull.Value
        dr("TOTAL") = DBNull.Value
        TabelaProdutos.Rows.Add(dr)

        Dim ultimaLinha = PoisonDataGridViewPROCURAPRODUTOS.Rows.Count - 1
        If ultimaLinha >= 0 Then
            PoisonDataGridViewPROCURAPRODUTOS.CurrentCell =
            PoisonDataGridViewPROCURAPRODUTOS.Rows(ultimaLinha).Cells(0)
        End If
    End Sub
    Private Sub PoisonDataGridViewPROCURAPRODUTOS_KeyDown(sender As Object, e As KeyEventArgs) Handles PoisonDataGridViewPROCURAPRODUTOS.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            Dim frm As New ESTOQUE()
            frm.ModoSelecao = True
            frm.ShowDialog()

            If frm.ProdutosSelecionados.Count = 0 Then Return

            ' ── Remove TODAS as linhas vazias antes de inserir ──
            Dim linhasVazias = TabelaProdutos.AsEnumerable().
            Where(Function(r) String.IsNullOrEmpty(r("CODIGO").ToString())).ToList()
            For Each lv In linhasVazias
                TabelaProdutos.Rows.Remove(lv)
            Next

            ' ── Insere os produtos selecionados ──
            For Each prod In frm.ProdutosSelecionados
                Dim dr = TabelaProdutos.NewRow()
                dr("CODIGO") = If(prod.ContainsKey("CODIGO"), prod("CODIGO"), "")
                dr("NOME") = If(prod.ContainsKey("NOME"), prod("NOME"), "")
                dr("REFERENCIA") = If(prod.ContainsKey("REFERENCIA"), prod("REFERENCIA"), "")

                Dim qtde As Decimal = 1D
                If prod.ContainsKey("QTDE") AndAlso Not String.IsNullOrEmpty(prod("QTDE")) Then
                    Decimal.TryParse(prod("QTDE").Replace(",", "."),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, qtde)
                End If

                Dim unitario As Decimal = 0D
                If prod.ContainsKey("UNITARIO") AndAlso Not String.IsNullOrEmpty(prod("UNITARIO")) Then
                    Decimal.TryParse(prod("UNITARIO"),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, unitario)
                End If

                dr("QTDE") = qtde
                dr("UNITARIO") = unitario
                dr("PERC_DESC") = 0D
                dr("VALOR_DESC") = 0D
                dr("TOTAL") = qtde * unitario  ' ✅ Decimal direto, sem string
                TabelaProdutos.Rows.Add(dr)
            Next
            AdicionarLinhaVazia()
            AtualizarTotais()
        End If
    End Sub
    Private Sub AtualizarTotais()
        Dim totalProdutos As Decimal = 0
        Dim quantItens As Integer = 0

        For Each row As DataRow In TabelaProdutos.Rows
            Dim total As Decimal = 0
            If Not IsDBNull(row("TOTAL")) Then
                total = Convert.ToDecimal(row("TOTAL"))
            End If
            If total > 0 Then
                totalProdutos += total
                quantItens += 1
            End If
        Next

        ' ✅ descPerc
        Dim descPerc As Decimal = 0
        Dim txtPerc = TextBoxDESCONTOPORCENT.Text.Trim()
        If txtPerc.Contains(",") Then
            txtPerc = txtPerc.Replace(".", "").Replace(",", ".")
        End If
        Decimal.TryParse(txtPerc, System.Globalization.NumberStyles.Any,
        System.Globalization.CultureInfo.InvariantCulture, descPerc)

        Dim valorDescPerc As Decimal = totalProdutos * (descPerc / 100)

        ' ✅ descReal
        Dim descReal As Decimal = 0
        Decimal.TryParse(TextBoxDESCONTOREAL.Text.Replace("R$", "").Trim(),
        System.Globalization.NumberStyles.Currency,
        System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), descReal)

        ' ✅ Verifica limite de 7% sobre total dos produtos
        Dim limiteDesconto As Decimal = totalProdutos * 0.07D
        Dim totalDescontos As Decimal = valorDescPerc + descReal

        If totalDescontos > limiteDesconto AndAlso totalProdutos > 0 Then
            ' Aviso visual nos campos
            TextBoxDESCONTOPORCENT.BackColor = Color.LightCoral
            TextBoxDESCONTOREAL.BackColor = Color.LightCoral
        Else
            TextBoxDESCONTOPORCENT.BackColor = Color.White
            TextBoxDESCONTOREAL.BackColor = Color.White
        End If

        ' Aplica apenas o que não ultrapassa o limite
        If totalDescontos > limiteDesconto Then
            valorDescPerc = 0
            descReal = 0
        End If

        Dim totalFinal = totalProdutos - valorDescPerc - descReal
        If totalFinal < 0 Then totalFinal = 0

        Dim ptBR = System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
        TextBoxVALORITENS.Text = quantItens.ToString()
        TextBoxVALORTOTAL.Text = totalFinal.ToString("C2", ptBR)
    End Sub

    Private Sub ButtonCONFIRMAR_Click(sender As Object, e As EventArgs) Handles ButtonCONFIRMAR.Click

        ' ── Validações ──
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

        Dim produtosValidos = TabelaProdutos.AsEnumerable().Where(
        Function(row) Not IsDBNull(row("TOTAL")) AndAlso
                      Convert.ToDecimal(row("TOTAL")) > 0).ToList()

        If produtosValidos.Count = 0 Then
            MessageBox.Show("Adicione pelo menos um produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' ── Converte os valores ──
        Dim ptBR = System.Globalization.CultureInfo.GetCultureInfo("pt-BR")

        Dim totalGeral As Decimal = 0
        Decimal.TryParse(TextBoxVALORTOTAL.Text.Replace("R$", "").Trim(),
        System.Globalization.NumberStyles.Currency, ptBR, totalGeral)

        ' ✅ descPerc — usa InvariantCulture após substituir vírgula por ponto
        Dim descPerc As Decimal = 0
        Dim txtPerc = TextBoxDESCONTOPORCENT.Text.Trim().Replace(".", "").Replace(",", ".")
        Decimal.TryParse(txtPerc,
        System.Globalization.NumberStyles.Any,
        System.Globalization.CultureInfo.InvariantCulture, descPerc)

        ' ✅ descReal — usa Currency + ptBR direto
        Dim descReal As Decimal = 0
        Decimal.TryParse(TextBoxDESCONTOREAL.Text.Replace("R$", "").Trim(),
        System.Globalization.NumberStyles.Currency, ptBR, descReal)

        ' ── Valida limite de 7% combinado ──
        Dim totalProdutosValidar As Decimal = produtosValidos.Sum(
    Function(r) If(IsDBNull(r("TOTAL")), 0D, Convert.ToDecimal(r("TOTAL"))))

        Dim limiteDesconto As Decimal = totalProdutosValidar * 0.07D
        Dim valorDescPercValidar = totalProdutosValidar * (descPerc / 100)

        If (valorDescPercValidar + descReal) > limiteDesconto Then
            Dim ptBRLimite = System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
            Dim msg = "Desconto total excede o limite de 7%!" &
              Environment.NewLine & "Total produtos: " & totalProdutosValidar.ToString("C2", ptBRLimite) &
              Environment.NewLine & "Limite permitido: " & limiteDesconto.ToString("C2", ptBRLimite) &
              Environment.NewLine & "Desconto aplicado: " & (valorDescPercValidar + descReal).ToString("C2", ptBRLimite) &
              Environment.NewLine & Environment.NewLine & "Digite a senha para liberar:"

            Dim senha = InputBox(msg, "⚠️ Limite de Desconto Excedido", "")

            ' Cancelou o InputBox
            If senha Is Nothing OrElse senha.Trim() = "" Then
                TextBoxDESCONTOPORCENT.Focus()
                Return
            End If

            ' ── Busca senha do banco ──
            Dim senhaBanco As String = ""
            Try
                Using connSenha = ModDB.AbrirConexao()
                    Dim sqlSenha = "SELECT VALOR FROM configuracoes WHERE CHAVE = 'SENHA_DESC'"
                    Using cmdSenha As New MySqlCommand(sqlSenha, connSenha)
                        Dim resultado = cmdSenha.ExecuteScalar()
                        If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                            senhaBanco = resultado.ToString().Trim()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Erro ao verificar senha: " & ex.Message, "Erro",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            ' ── Valida senha ──
            If senha.Trim() <> senhaBanco Then
                MessageBox.Show("Senha incorreta! Desconto não autorizado.",
            "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextBoxDESCONTOPORCENT.Focus()
                Return
            End If

            ' ✅ Senha correta
            MessageBox.Show("Desconto liberado com senha de supervisor!",
        "Liberado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' ── Confirma o salvamento ──
        Dim confirmar = MessageBox.Show("Deseja confirmar o DAV " & TextBoxCOD.Text & "?",
        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmar = DialogResult.No Then Return

        Try
            Using conn = ModDB.AbrirConexao()
                Dim transaction = conn.BeginTransaction()

                Try
                    Dim idDAV As Long = 0

                    If Modo = "INCLUIR" Then

                        ' ── Verifica duplicidade apenas na inclusão ──
                        Dim sqlVerifica = "SELECT COUNT(*) FROM dav WHERE CODIGO = @cod"
                        Using cmdVerifica As New MySqlCommand(sqlVerifica, conn, transaction)
                            cmdVerifica.Parameters.AddWithValue("@cod", TextBoxCOD.Text)
                            Dim jaExiste = Convert.ToInt32(cmdVerifica.ExecuteScalar()) > 0
                            If jaExiste Then
                                transaction.Rollback()
                                MessageBox.Show("O número do DAV já foi utilizado por outra máquina! Reiniciando...",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                CarregarNumerDAV()
                                Return
                            End If
                        End Using

                        ' ── INSERT cabeçalho ──
                        Dim sqlDAV = "INSERT INTO dav (CODIGO, EMISSAO, COD_CLIENTE, NOME_CLIENTE, " &
                                 "COD_VENDEDOR, NOME_VENDEDOR, COD_PAGAMENTO, NOME_PAGAMENTO, " &
                                 "TOTAL_GERAL, STATUS, OBS, DESC_PERC, DESC_REAL) " &
                                 "VALUES (@cod, @emissao, @codcli, @nomecli, @codvend, @nomevend, " &
                                 "@codpag, @nomepag, @total, @status, @obs, @descperc, @descreal)"

                        Using cmdDAV As New MySqlCommand(sqlDAV, conn, transaction)
                            cmdDAV.Parameters.AddWithValue("@cod", TextBoxCOD.Text)
                            cmdDAV.Parameters.AddWithValue("@emissao", DateTime.Now.ToString("yyyy-MM-dd"))
                            cmdDAV.Parameters.AddWithValue("@codcli", TextBoxCODCLIENTE.Text)
                            cmdDAV.Parameters.AddWithValue("@nomecli", TextBoxNOMECLIENTE.Text)
                            cmdDAV.Parameters.AddWithValue("@codvend", TextBoxCODVENDEDOR.Text)
                            cmdDAV.Parameters.AddWithValue("@nomevend", TextBoxVENDEDOR.Text)
                            cmdDAV.Parameters.AddWithValue("@codpag", TextBoxCODPAGAMENTO.Text)
                            cmdDAV.Parameters.AddWithValue("@nomepag", TextBoxNOMEPAGAMENTO.Text)
                            cmdDAV.Parameters.AddWithValue("@total", totalGeral)
                            cmdDAV.Parameters.AddWithValue("@status", "ORÇANDO")
                            cmdDAV.Parameters.AddWithValue("@obs", TextBoxOBS.Text)
                            cmdDAV.Parameters.AddWithValue("@descperc", descPerc)
                            cmdDAV.Parameters.AddWithValue("@descreal", descReal)
                            cmdDAV.ExecuteNonQuery()
                            idDAV = cmdDAV.LastInsertedId
                        End Using

                    ElseIf Modo = "ALTERAR" Then

                        ' ── UPDATE cabeçalho ──
                        Dim sqlDAV = "UPDATE dav SET COD_CLIENTE=@codcli, NOME_CLIENTE=@nomecli, " &
                                 "COD_VENDEDOR=@codvend, NOME_VENDEDOR=@nomevend, " &
                                 "COD_PAGAMENTO=@codpag, NOME_PAGAMENTO=@nomepag, " &
                                 "TOTAL_GERAL=@total, OBS=@obs, DESC_PERC=@descperc, DESC_REAL=@descreal " &
                                 "WHERE CODIGO = @cod"

                        Using cmdDAV As New MySqlCommand(sqlDAV, conn, transaction)
                            cmdDAV.Parameters.AddWithValue("@cod", TextBoxCOD.Text)
                            cmdDAV.Parameters.AddWithValue("@codcli", TextBoxCODCLIENTE.Text)
                            cmdDAV.Parameters.AddWithValue("@nomecli", TextBoxNOMECLIENTE.Text)
                            cmdDAV.Parameters.AddWithValue("@codvend", TextBoxCODVENDEDOR.Text)
                            cmdDAV.Parameters.AddWithValue("@nomevend", TextBoxVENDEDOR.Text)
                            cmdDAV.Parameters.AddWithValue("@codpag", TextBoxCODPAGAMENTO.Text)
                            cmdDAV.Parameters.AddWithValue("@nomepag", TextBoxNOMEPAGAMENTO.Text)
                            cmdDAV.Parameters.AddWithValue("@total", totalGeral)
                            cmdDAV.Parameters.AddWithValue("@obs", TextBoxOBS.Text)
                            cmdDAV.Parameters.AddWithValue("@descperc", descPerc)
                            cmdDAV.Parameters.AddWithValue("@descreal", descReal)
                            cmdDAV.ExecuteNonQuery()
                        End Using

                        ' ── Pega o ID do DAV ──
                        Dim sqlGetId = "SELECT ID FROM dav WHERE CODIGO = @cod"
                        Using cmdId As New MySqlCommand(sqlGetId, conn, transaction)
                            cmdId.Parameters.AddWithValue("@cod", TextBoxCOD.Text)
                            idDAV = Convert.ToInt64(cmdId.ExecuteScalar())
                        End Using

                        ' ── Apaga itens antigos ──
                        Dim sqlDelete = "DELETE FROM dav_itens WHERE ID_DAV = @iddav"
                        Using cmdDel As New MySqlCommand(sqlDelete, conn, transaction)
                            cmdDel.Parameters.AddWithValue("@iddav", idDAV)
                            cmdDel.ExecuteNonQuery()
                        End Using

                    End If

                    ' ── Salva os itens (INCLUIR e ALTERAR) ──
                    For Each row In produtosValidos
                        Dim sqlItem = "INSERT INTO dav_itens (ID_DAV, COD_PRODUTO, NOME_PRODUTO, " &
                                  "REFERENCIA, QTDE, UNITARIO, PERC_DESC, VALOR_DESC, TOTAL) " &
                                  "VALUES (@iddav, @cod, @nome, @ref, @qtde, @unit, @percDesc, @valDesc, @total)"

                        Using cmdItem As New MySqlCommand(sqlItem, conn, transaction)
                            cmdItem.Parameters.AddWithValue("@iddav", idDAV)
                            cmdItem.Parameters.AddWithValue("@cod", row("CODIGO").ToString())
                            cmdItem.Parameters.AddWithValue("@nome", row("NOME").ToString())
                            cmdItem.Parameters.AddWithValue("@ref", row("REFERENCIA").ToString())
                            cmdItem.Parameters.AddWithValue("@qtde", If(IsDBNull(row("QTDE")), 0D, Convert.ToDecimal(row("QTDE"))))
                            cmdItem.Parameters.AddWithValue("@unit", If(IsDBNull(row("UNITARIO")), 0D, Convert.ToDecimal(row("UNITARIO"))))
                            cmdItem.Parameters.AddWithValue("@percDesc", If(IsDBNull(row("PERC_DESC")), 0D, Convert.ToDecimal(row("PERC_DESC"))))
                            cmdItem.Parameters.AddWithValue("@valDesc", If(IsDBNull(row("VALOR_DESC")), 0D, Convert.ToDecimal(row("VALOR_DESC"))))
                            cmdItem.Parameters.AddWithValue("@total", If(IsDBNull(row("TOTAL")), 0D, Convert.ToDecimal(row("TOTAL"))))
                            cmdItem.ExecuteNonQuery()
                        End Using
                    Next

                    ' ── Confirma a transação ──
                    transaction.Commit()

                    ' ── Monta dados para impressão ──
                    Dim totalProdutos As Decimal = produtosValidos.Sum(
                    Function(r) If(IsDBNull(r("TOTAL")), 0D, Convert.ToDecimal(r("TOTAL"))))

                    Dim dadosDAV As New Dictionary(Of String, String) From {
                    {"CODIGO", TextBoxCOD.Text},
                    {"EMISSAO", TextBoxDATA.Text},
                    {"COD_CLIENTE", TextBoxCODCLIENTE.Text},
                    {"NOME_CLIENTE", TextBoxNOMECLIENTE.Text},
                    {"COD_VENDEDOR", TextBoxCODVENDEDOR.Text},
                    {"NOME_VENDEDOR", TextBoxVENDEDOR.Text},
                    {"COD_PAGAMENTO", TextBoxCODPAGAMENTO.Text},
                    {"NOME_PAGAMENTO", TextBoxNOMEPAGAMENTO.Text},
                    {"OBS", TextBoxOBS.Text},
                    {"DESC_PERC", descPerc.ToString("0.00", ptBR)},
                    {"DESC_REAL", descReal.ToString("C2", ptBR)},
                    {"TOTAL_PRODUTOS", totalProdutos.ToString("C2", ptBR)},
                    {"VALOR_DESC", (totalProdutos - totalGeral).ToString("C2", ptBR)},
                    {"TOTAL_GERAL", totalGeral.ToString("C2", ptBR)}
                }

                    Dim itensDAV As New List(Of Dictionary(Of String, String))
                    For Each row In produtosValidos
                        itensDAV.Add(New Dictionary(Of String, String) From {
                        {"CODIGO", row("CODIGO").ToString()},
                        {"NOME", row("NOME").ToString()},
                        {"REFERENCIA", row("REFERENCIA").ToString()},
                        {"QTDE", If(IsDBNull(row("QTDE")), "0", Convert.ToDecimal(row("QTDE")).ToString("0.###"))},
                        {"UNITARIO", If(IsDBNull(row("UNITARIO")), "0", Convert.ToDecimal(row("UNITARIO")).ToString("C2", ptBR))},
                        {"TOTAL", If(IsDBNull(row("TOTAL")), "0", Convert.ToDecimal(row("TOTAL")).ToString("C2", ptBR))}
                    })
                    Next

                    ' ── Pergunta se quer imprimir ──
                    Dim imprimir = MessageBox.Show(
                    "DAV " & TextBoxCOD.Text & " salvo com sucesso!" &
                    Environment.NewLine & "Deseja imprimir?",
                    "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If imprimir = DialogResult.Yes Then
                        Dim opcao = MessageBox.Show(
                        "Clique SIM para imprimir Romaneio Térmico." &
                        Environment.NewLine & "Clique NÃO para gerar PDF A4.",
                        "Tipo de Impressão", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                        If opcao = DialogResult.Yes Then
                            ModImpressao.ImprimirRomaneio(dadosDAV, itensDAV)
                        Else
                            ModImpressao.GerarDAVPDF(dadosDAV, itensDAV)
                        End If
                    End If

                    ' ── Limpa o form para novo DAV (só no INCLUIR) ──
                    If Modo = "INCLUIR" Then
                        LimparForm()
                    Else
                        Me.Close() ' No ALTERAR fecha após salvar
                    End If

                Catch ex As Exception
                    transaction.Rollback()
                    MessageBox.Show("Erro ao salvar DAV: " & ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Erro de conexão: " & ex.Message, "Erro",
            MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                TextBoxOBS.Focus()
            End If
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub INCLUIR_ALTERAR_EXCLUIR_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            PoisonDataGridViewPROCURAPRODUTOS.DataSource = Nothing
            TabelaProdutos?.Clear()
            TabelaProdutos?.Dispose()
        Catch ex As Exception
        End Try
    End Sub
End Class