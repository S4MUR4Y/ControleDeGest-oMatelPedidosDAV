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

    Private Sub PictureBoxFECHAR_Click(sender As Object, e As EventArgs) Handles PictureBoxFECHAR.Click
        Dim resultado = MessageBox.Show("Deseja realmente sair?", "Sair",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resultado = DialogResult.Yes Then
            Environment.Exit(0)
        End If
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or &H200
            Return cp
        End Get
    End Property

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