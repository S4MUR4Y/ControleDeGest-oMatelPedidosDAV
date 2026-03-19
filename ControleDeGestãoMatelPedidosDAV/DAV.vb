Imports MySql.Data.MySqlClient

Public Class DAV

    Private Sub DAV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarDAVsDoDia()
    End Sub

    Private Sub CarregarDAVsDoDia()
        Try
            Using conn = ModDB.AbrirConexao()
                Dim sql = "SELECT CODIGO, EMISSAO, NOME_CLIENTE, NOME_VENDEDOR, " &
                          "NOME_PAGAMENTO, TOTAL_GERAL, STATUS " &
                          "FROM dav WHERE DATE(EMISSAO) = CURDATE() " &
                          "ORDER BY ID DESC"

                Dim da As New MySqlDataAdapter(sql, conn)
                Dim tabela As New DataTable()
                da.Fill(tabela)

                ' Renomeia as colunas para exibição
                tabela.Columns("CODIGO").ColumnName = "Nº DAV"
                tabela.Columns("EMISSAO").ColumnName = "Emissão"
                tabela.Columns("NOME_CLIENTE").ColumnName = "Cliente"
                tabela.Columns("NOME_VENDEDOR").ColumnName = "Vendedor"
                tabela.Columns("NOME_PAGAMENTO").ColumnName = "Pagamento"
                tabela.Columns("TOTAL_GERAL").ColumnName = "Total"
                tabela.Columns("STATUS").ColumnName = "Status"

                PoisonDataGridViewDADOS.DataSource = tabela
                PoisonDataGridViewDADOS.ReadOnly = True

                ' Formata coluna Total como moeda
                PoisonDataGridViewDADOS.Columns("Total").DefaultCellStyle.Format = "C2"
                PoisonDataGridViewDADOS.Columns("Total").DefaultCellStyle.FormatProvider =
                    System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
                PoisonDataGridViewDADOS.Columns("Total").DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleRight

            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar DAVs: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonINCLUIR_Click(sender As Object, e As EventArgs) Handles ButtonINCLUIR.Click
        Dim frm As New INCLUIR_ALTERAR_EXCLUIR()
        frm.Modo = "INCLUIR"
        frm.ShowDialog()
        CarregarDAVsDoDia()
    End Sub

    Private Sub ButtonALTERAR_Click(sender As Object, e As EventArgs) Handles ButtonALTERAR.Click
        If PoisonDataGridViewDADOS.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione um DAV para alterar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim codigoDAV = PoisonDataGridViewDADOS.CurrentRow.Cells("Nº DAV").Value.ToString()
        Dim frm As New INCLUIR_ALTERAR_EXCLUIR()
        frm.Modo = "ALTERAR"
        frm.CodigoDAV = codigoDAV
        frm.ShowDialog()
        CarregarDAVsDoDia()
    End Sub

    Private Sub ButtonEXCLUIR_Click(sender As Object, e As EventArgs) Handles ButtonEXCLUIR.Click
        If PoisonDataGridViewDADOS.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione um DAV para excluir!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim codigoDAV = PoisonDataGridViewDADOS.CurrentRow.Cells("Nº DAV").Value.ToString()
        Dim confirmar = MessageBox.Show("Deseja excluir o DAV " & codigoDAV & "?",
            "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmar = DialogResult.No Then Return

        Try
            Using conn = ModDB.AbrirConexao()
                ' Busca o ID do DAV pelo CODIGO
                Dim sqlId = "SELECT ID FROM dav WHERE CODIGO = @cod"
                Dim idDAV As Integer
                Using cmd As New MySqlCommand(sqlId, conn)
                    cmd.Parameters.AddWithValue("@cod", codigoDAV)
                    idDAV = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' Exclui os itens e o DAV (CASCADE já faz isso mas por segurança)
                Dim sqlDel = "DELETE FROM dav WHERE ID = @id"
                Using cmd As New MySqlCommand(sqlDel, conn)
                    cmd.Parameters.AddWithValue("@id", idDAV)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("DAV " & codigoDAV & " excluído com sucesso!",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                CarregarDAVsDoDia()
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao excluir: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonCONSULTAR_Click(sender As Object, e As EventArgs) Handles ButtonCONSULTAR.Click
        If PoisonDataGridViewDADOS.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione um DAV para consultar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim codigoDAV = PoisonDataGridViewDADOS.CurrentRow.Cells("Nº DAV").Value.ToString()
        Dim frm As New INCLUIR_ALTERAR_EXCLUIR()
        frm.Modo = "CONSULTAR"
        frm.CodigoDAV = codigoDAV
        frm.ShowDialog()
    End Sub
    Private Sub DAV_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            PoisonDataGridViewDADOS.DataSource = Nothing
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ButtonIMPRIMIR_Click(sender As Object, e As EventArgs) Handles ButtonIMPRIMIR.Click
        If PoisonDataGridViewDADOS.CurrentRow Is Nothing Then
            MessageBox.Show("Selecione um DAV para imprimir!", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim codigoDAV = PoisonDataGridViewDADOS.CurrentRow.Cells("Nº DAV").Value.ToString()

        Try
            Using conn = ModDB.AbrirConexao()
                Dim ptBR = System.Globalization.CultureInfo.GetCultureInfo("pt-BR")

                ' ── Carrega cabeçalho do DAV ──
                Dim dadosDAV As New Dictionary(Of String, String)
                Dim sql = "SELECT * FROM dav WHERE CODIGO = @cod"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@cod", codigoDAV)
                    Using dr = cmd.ExecuteReader()
                        If dr.Read() Then
                            Dim totalGeral = Convert.ToDecimal(dr("TOTAL_GERAL"))
                            Dim descReal = If(IsDBNull(dr("DESC_REAL")), 0D, Convert.ToDecimal(dr("DESC_REAL")))
                            Dim totalProdutos = totalGeral + descReal

                            dadosDAV = New Dictionary(Of String, String) From {
                                {"CODIGO", dr("CODIGO").ToString()},
                                {"EMISSAO", Convert.ToDateTime(dr("EMISSAO")).ToString("dd/MM/yy")},
                                {"COD_CLIENTE", dr("COD_CLIENTE").ToString()},
                                {"NOME_CLIENTE", dr("NOME_CLIENTE").ToString()},
                                {"COD_VENDEDOR", dr("COD_VENDEDOR").ToString()},
                                {"NOME_VENDEDOR", dr("NOME_VENDEDOR").ToString()},
                                {"COD_PAGAMENTO", dr("COD_PAGAMENTO").ToString()},
                                {"NOME_PAGAMENTO", dr("NOME_PAGAMENTO").ToString()},
                                {"OBS", dr("OBS").ToString()},
                                {"DESC_PERC", If(IsDBNull(dr("DESC_PERC")), "0,00", Convert.ToDecimal(dr("DESC_PERC")).ToString("0.00", ptBR))},
                                {"DESC_REAL", descReal.ToString("C2", ptBR)},
                                {"TOTAL_PRODUTOS", totalProdutos.ToString("C2", ptBR)},
                                {"VALOR_DESC", descReal.ToString("C2", ptBR)},
                                {"TOTAL_GERAL", totalGeral.ToString("C2", ptBR)}
                            }
                        Else
                            MessageBox.Show("DAV não encontrado!", "Atenção",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using
                End Using

                ' ── Carrega itens do DAV ──
                Dim itensDAV As New List(Of Dictionary(Of String, String))
                Dim sqlItens = "SELECT * FROM dav_itens WHERE ID_DAV = " &
                               "(SELECT ID FROM dav WHERE CODIGO = @cod)"
                Using cmd As New MySqlCommand(sqlItens, conn)
                    cmd.Parameters.AddWithValue("@cod", codigoDAV)
                    Using dr = cmd.ExecuteReader()
                        While dr.Read()
                            itensDAV.Add(New Dictionary(Of String, String) From {
                                {"CODIGO", dr("COD_PRODUTO").ToString()},
                                {"NOME", dr("NOME_PRODUTO").ToString()},
                                {"REFERENCIA", dr("REFERENCIA").ToString()},
                                {"QTDE", Convert.ToDecimal(dr("QTDE")).ToString("0.###")},
                                {"UNITARIO", Convert.ToDecimal(dr("UNITARIO")).ToString("C2", ptBR)},
                                {"TOTAL", Convert.ToDecimal(dr("TOTAL")).ToString("C2", ptBR)}
                            })
                        End While
                    End Using
                End Using

                If itensDAV.Count = 0 Then
                    MessageBox.Show("Este DAV não possui itens para imprimir!", "Atenção",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' ── Pergunta o tipo de impressão ──
                Dim opcao = MessageBox.Show(
                    "Clique SIM para imprimir Romaneio Térmico." &
                    Environment.NewLine & "Clique NÃO para gerar PDF A4.",
                    "Tipo de Impressão", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If opcao = DialogResult.Yes Then
                    ModImpressao.ImprimirRomaneio(dadosDAV, itensDAV)
                Else
                    ModImpressao.GerarDAVPDF(dadosDAV, itensDAV)
                End If

            End Using

        Catch ex As Exception
            MessageBox.Show("Erro ao imprimir DAV: " & ex.Message, "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class