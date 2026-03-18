Imports MySql.Data.MySqlClient

Public Class ADDCLIENTE

    Public ClienteSelecionado As DataRow

    Private TabelaClientes As DataTable

    Private Sub ADDCLIENTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarClientes()
    End Sub

    Private Sub CarregarClientes()
        Try
            Using conn = ModDB.AbrirConexao()
                Dim sql = "SELECT CODIGO, NOME FROM clientes ORDER BY NOME"
                Dim da As New MySqlDataAdapter(sql, conn)
                TabelaClientes = New DataTable()
                da.Fill(TabelaClientes)
                PoisonDataGridViewCLIENTES.DataSource = TabelaClientes
                PoisonDataGridViewCLIENTES.ReadOnly = True
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar clientes: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBoxPESQUISA_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPESQUISA.TextChanged
        Dim texto = TextBoxPESQUISA.Text.Trim().ToUpper()
        TextBoxPESQUISA.Text = texto
        TextBoxPESQUISA.SelectionStart = texto.Length

        If String.IsNullOrEmpty(texto) Then
            PoisonDataGridViewCLIENTES.DataSource = TabelaClientes
            Return
        End If

        Dim resultado = TabelaClientes.AsEnumerable().Where(
            Function(row) row("NOME").ToString().ToUpper().Contains(texto) OrElse
                          row("CODIGO").ToString().ToUpper().Contains(texto)
        ).ToList()

        If resultado.Count > 0 Then
            PoisonDataGridViewCLIENTES.DataSource = resultado.CopyToDataTable()
        End If
    End Sub

    ' Duplo clique ou Enter seleciona o cliente
    Private Sub PoisonDataGridViewCLIENTES_DoubleClick(sender As Object, e As EventArgs) Handles PoisonDataGridViewCLIENTES.DoubleClick
        SelecionarCliente()
    End Sub

    Private Sub PoisonDataGridViewCLIENTES_KeyDown(sender As Object, e As KeyEventArgs) Handles PoisonDataGridViewCLIENTES.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelecionarCliente()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ButtonSELECIONAR_Click(sender As Object, e As EventArgs) Handles ButtonSELECIONAR.Click
        SelecionarCliente()
    End Sub

    Private Sub SelecionarCliente()
        If PoisonDataGridViewCLIENTES.CurrentRow IsNot Nothing Then
            ClienteSelecionado = CType(PoisonDataGridViewCLIENTES.DataSource, DataTable).Rows(
                PoisonDataGridViewCLIENTES.CurrentRow.Index)
            Me.Close()
        End If
    End Sub

End Class