Public Class DAV

    Private Sub ButtonINCLUIR_Click(sender As Object, e As EventArgs) Handles ButtonINCLUIR.Click
        Dim frm As New INCLUIR_ALTERAR_EXCLUIR()
        frm.Modo = "INCLUIR"
        frm.ShowDialog()
    End Sub

    Private Sub ButtonALTERAR_Click(sender As Object, e As EventArgs) Handles ButtonALTERAR.Click
        Dim frm As New INCLUIR_ALTERAR_EXCLUIR()
        frm.Modo = "ALTERAR"
        ' frm.IdRegistro = DataGridView1.CurrentRow.Cells("Id").Value ' passa o ID se precisar
        frm.ShowDialog()
    End Sub

    Private Sub ButtonEXCLUIR_Click(sender As Object, e As EventArgs) Handles ButtonEXCLUIR.Click
        Dim frm As New INCLUIR_ALTERAR_EXCLUIR()
        frm.Modo = "EXCLUIR"
        ' frm.IdRegistro = DataGridView1.CurrentRow.Cells("Id").Value
        frm.ShowDialog()
    End Sub

End Class
