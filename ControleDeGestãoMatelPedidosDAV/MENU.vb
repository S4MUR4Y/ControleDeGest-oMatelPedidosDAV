Public Class MENU

    Private Sub AbrirFormNoPanel(frm As Form)
        For Each ctrl As Control In PanelMDIPAI.Controls
            If TypeOf ctrl Is Form Then
                CType(ctrl, Form).Close()
            End If
        Next
        frm.TopLevel = False
        frm.Size = New Size(
            Math.Min(frm.Width, PanelMDIPAI.Width),
            Math.Min(frm.Height, PanelMDIPAI.Height)
        )
        frm.Location = New Point(
            (PanelMDIPAI.Width - frm.Width) \ 2,
            (PanelMDIPAI.Height - frm.Height) \ 2
        )
        PanelMDIPAI.Controls.Add(frm)
        PanelMDIPAI.Tag = frm
        frm.Show()
    End Sub

    Private Sub MENU_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim resposta = MessageBox.Show("Deseja sair do sistema?", "Confirmar Saída",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resposta = DialogResult.No Then
            e.Cancel = True  ' Cancela o fechamento
        End If
    End Sub

    Private Sub ButtonDAV_Click(sender As Object, e As EventArgs) Handles ButtonDAV.Click
        AbrirFormNoPanel(New DAV())
    End Sub

    Private Sub ButtonPEDIDOS_Click(sender As Object, e As EventArgs) Handles ButtonPEDIDOS.Click
        AbrirFormNoPanel(New PEDIDOS())
    End Sub

    Private Sub ButtonESTOQUE_Click(sender As Object, e As EventArgs) Handles ButtonESTOQUE.Click
        AbrirFormNoPanel(New ESTOQUE())
    End Sub

End Class