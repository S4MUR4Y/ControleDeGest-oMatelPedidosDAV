Imports MySql.Data.MySqlClient

Public Class ADDVENDEDOR

    Public VendedorSelecionado As DataRow
    Private TabelaVendedores As DataTable

    Private Sub ADDVENDEDOR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarVendedores()
    End Sub

    Private Sub CarregarVendedores()
        Try
            Using conn = ModDB.AbrirConexao()
                Dim sql = "SELECT CODIGO, NOME FROM vendedores ORDER BY NOME"
                Dim da As New MySqlDataAdapter(sql, conn)
                TabelaVendedores = New DataTable()
                da.Fill(TabelaVendedores)
                PoisonDataGridViewVENDEDORES.DataSource = TabelaVendedores
                PoisonDataGridViewVENDEDORES.ReadOnly = True
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao carregar vendedores: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBoxPESQUISA_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPESQUISA.TextChanged
        Dim texto = TextBoxPESQUISA.Text.Trim().ToUpper()
        TextBoxPESQUISA.Text = texto
        TextBoxPESQUISA.SelectionStart = texto.Length

        If String.IsNullOrEmpty(texto) Then
            PoisonDataGridViewVENDEDORES.DataSource = TabelaVendedores
            Return
        End If

        Dim resultado = TabelaVendedores.AsEnumerable().Where(
            Function(row) row("NOME").ToString().ToUpper().Contains(texto) OrElse
                          row("CODIGO").ToString().ToUpper().Contains(texto)
        ).ToList()

        If resultado.Count > 0 Then
            PoisonDataGridViewVENDEDORES.DataSource = resultado.CopyToDataTable()
        End If
    End Sub

    Private Sub PoisonDataGridViewVENDEDORES_DoubleClick(sender As Object, e As EventArgs) Handles PoisonDataGridViewVENDEDORES.DoubleClick
        SelecionarVendedor()
    End Sub

    Private Sub PoisonDataGridViewVENDEDORES_KeyDown(sender As Object, e As KeyEventArgs) Handles PoisonDataGridViewVENDEDORES.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelecionarVendedor()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ButtonSELECIONAR_Click(sender As Object, e As EventArgs) Handles ButtonSELECIONAR.Click
        SelecionarVendedor()
    End Sub

    Private Sub SelecionarVendedor()
        If PoisonDataGridViewVENDEDORES.CurrentRow IsNot Nothing Then
            VendedorSelecionado = CType(PoisonDataGridViewVENDEDORES.DataSource, DataTable).Rows(
                PoisonDataGridViewVENDEDORES.CurrentRow.Index)
            Me.Close()
        End If
    End Sub

End Class