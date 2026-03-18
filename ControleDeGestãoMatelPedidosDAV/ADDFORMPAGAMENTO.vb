Imports MySql.Data.MySqlClient

Public Class ADDFORMPAGAMENTO

    Public PagamentoSelecionado As DataRow
    Private TabelaPagamentos As DataTable

    Private Sub ADDFORMPAGAMENTO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarFormasPagamento()
    End Sub

    Private Sub CarregarFormasPagamento()
        Try
            Using conn = ModDB.AbrirConexao()
                Dim sql = "SELECT CODIGO, NOME FROM formas_pagamento ORDER BY NOME"
                Dim da As New MySqlDataAdapter(sql, conn)
                TabelaPagamentos = New DataTable()
                da.Fill(TabelaPagamentos)
                PoisonDataGridViewPAGAMENTOS.DataSource = TabelaPagamentos
                PoisonDataGridViewPAGAMENTOS.ReadOnly = True
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar formas de pagamento: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBoxPESQUISA_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPESQUISA.TextChanged
        Dim texto = TextBoxPESQUISA.Text.Trim().ToUpper()
        TextBoxPESQUISA.Text = texto
        TextBoxPESQUISA.SelectionStart = texto.Length

        If String.IsNullOrEmpty(texto) Then
            PoisonDataGridViewPAGAMENTOS.DataSource = TabelaPagamentos
            Return
        End If

        Dim resultado = TabelaPagamentos.AsEnumerable().Where(
            Function(row) row("NOME").ToString().ToUpper().Contains(texto) OrElse
                          row("CODIGO").ToString().ToUpper().Contains(texto)
        ).ToList()

        If resultado.Count > 0 Then
            PoisonDataGridViewPAGAMENTOS.DataSource = resultado.CopyToDataTable()
        End If
    End Sub

    Private Sub PoisonDataGridViewPAGAMENTOS_DoubleClick(sender As Object, e As EventArgs) Handles PoisonDataGridViewPAGAMENTOS.DoubleClick
        SelecionarPagamento()
    End Sub

    Private Sub PoisonDataGridViewPAGAMENTOS_KeyDown(sender As Object, e As KeyEventArgs) Handles PoisonDataGridViewPAGAMENTOS.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelecionarPagamento()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ButtonSELECIONAR_Click(sender As Object, e As EventArgs) Handles ButtonSELECIONAR.Click
        SelecionarPagamento()
    End Sub

    Private Sub SelecionarPagamento()
        If PoisonDataGridViewPAGAMENTOS.CurrentRow IsNot Nothing Then
            PagamentoSelecionado = CType(PoisonDataGridViewPAGAMENTOS.DataSource, DataTable).Rows(
                PoisonDataGridViewPAGAMENTOS.CurrentRow.Index)
            Me.Close()
        End If
    End Sub

End Class