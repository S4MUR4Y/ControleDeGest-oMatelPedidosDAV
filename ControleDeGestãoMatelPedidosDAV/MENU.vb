Public Class MENU
    Private Sub AbrirFormNoPanel(frm As Form)
        ' Fecha qualquer form que já estiver aberto no panel
        For Each ctrl As Control In PanelMDIPAI.Controls
            If TypeOf ctrl Is Form Then
                CType(ctrl, Form).Close()
            End If
        Next

        ' Configura o form para dentro do panel
        frm.TopLevel = False
        'frm.FormBorderStyle = FormBorderStyle.None
        'frm.Dock = DockStyle.Fill

        ' Centraliza no panel
        frm.Size = New Size(
        Math.Min(frm.Width, PanelMDIPAI.Width),
        Math.Min(frm.Height, PanelMDIPAI.Height)
    )
        frm.Location = New Point(
        (PanelMDIPAI.Width - frm.Width) \ 2,
        (PanelMDIPAI.Height - frm.Height) \ 2
    )

        ' Adiciona e exibe dentro do panel
        PanelMDIPAI.Controls.Add(frm)
        PanelMDIPAI.Tag = frm
        frm.Show()
    End Sub
    ' Botão DAV
    Private Sub ButtonDAV_Click(sender As Object, e As EventArgs) Handles ButtonDAV.Click
        AbrirFormNoPanel(New DAV())
    End Sub

    ' Botão PEDIDOS
    Private Sub ButtonPEDIDOS_Click(sender As Object, e As EventArgs) Handles ButtonPEDIDOS.Click
        AbrirFormNoPanel(New PEDIDOS())
    End Sub

    Private Sub ButtonESTOQUE_Click(sender As Object, e As EventArgs) Handles ButtonESTOQUE.Click
        AbrirFormNoPanel(New ESTOQUE())
    End Sub
End Class