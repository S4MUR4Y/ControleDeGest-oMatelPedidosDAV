<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MENU
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MENU))
        Panel1 = New Panel()
        ButtonESTOQUE = New Button()
        ButtonPEDIDOS = New Button()
        ButtonDAV = New Button()
        PanelMDIPAI = New Panel()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = SystemColors.Menu
        Panel1.Controls.Add(ButtonESTOQUE)
        Panel1.Controls.Add(ButtonPEDIDOS)
        Panel1.Controls.Add(ButtonDAV)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1124, 39)
        Panel1.TabIndex = 0
        ' 
        ' ButtonESTOQUE
        ' 
        ButtonESTOQUE.BackColor = SystemColors.Menu
        ButtonESTOQUE.Cursor = Cursors.Hand
        ButtonESTOQUE.FlatAppearance.BorderColor = SystemColors.MenuHighlight
        ButtonESTOQUE.FlatAppearance.BorderSize = 2
        ButtonESTOQUE.FlatAppearance.MouseDownBackColor = SystemColors.MenuHighlight
        ButtonESTOQUE.FlatAppearance.MouseOverBackColor = SystemColors.MenuHighlight
        ButtonESTOQUE.FlatStyle = FlatStyle.Flat
        ButtonESTOQUE.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonESTOQUE.Location = New Point(3, 4)
        ButtonESTOQUE.Name = "ButtonESTOQUE"
        ButtonESTOQUE.Size = New Size(115, 31)
        ButtonESTOQUE.TabIndex = 0
        ButtonESTOQUE.Text = "ESTOQUE"
        ButtonESTOQUE.UseVisualStyleBackColor = False
        ' 
        ' ButtonPEDIDOS
        ' 
        ButtonPEDIDOS.BackColor = SystemColors.Menu
        ButtonPEDIDOS.Cursor = Cursors.Hand
        ButtonPEDIDOS.FlatAppearance.BorderColor = SystemColors.MenuHighlight
        ButtonPEDIDOS.FlatAppearance.BorderSize = 2
        ButtonPEDIDOS.FlatAppearance.MouseDownBackColor = SystemColors.MenuHighlight
        ButtonPEDIDOS.FlatAppearance.MouseOverBackColor = SystemColors.MenuHighlight
        ButtonPEDIDOS.FlatStyle = FlatStyle.Flat
        ButtonPEDIDOS.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonPEDIDOS.Location = New Point(245, 4)
        ButtonPEDIDOS.Name = "ButtonPEDIDOS"
        ButtonPEDIDOS.Size = New Size(115, 31)
        ButtonPEDIDOS.TabIndex = 2
        ButtonPEDIDOS.Text = "PEDIDOS"
        ButtonPEDIDOS.UseVisualStyleBackColor = False
        ' 
        ' ButtonDAV
        ' 
        ButtonDAV.BackColor = SystemColors.Menu
        ButtonDAV.Cursor = Cursors.Hand
        ButtonDAV.FlatAppearance.BorderColor = SystemColors.MenuHighlight
        ButtonDAV.FlatAppearance.BorderSize = 2
        ButtonDAV.FlatAppearance.MouseDownBackColor = SystemColors.MenuHighlight
        ButtonDAV.FlatAppearance.MouseOverBackColor = SystemColors.MenuHighlight
        ButtonDAV.FlatStyle = FlatStyle.Flat
        ButtonDAV.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonDAV.Location = New Point(124, 4)
        ButtonDAV.Name = "ButtonDAV"
        ButtonDAV.Size = New Size(115, 31)
        ButtonDAV.TabIndex = 1
        ButtonDAV.Text = "DAV"
        ButtonDAV.UseVisualStyleBackColor = False
        ' 
        ' PanelMDIPAI
        ' 
        PanelMDIPAI.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PanelMDIPAI.BackColor = SystemColors.Window
        PanelMDIPAI.Location = New Point(0, 41)
        PanelMDIPAI.Name = "PanelMDIPAI"
        PanelMDIPAI.Size = New Size(1124, 563)
        PanelMDIPAI.TabIndex = 1
        ' 
        ' MENU
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.White
        ClientSize = New Size(1124, 604)
        Controls.Add(PanelMDIPAI)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "MENU"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SAYTECH | MENU"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelMDIPAI As Panel
    Friend WithEvents ButtonPEDIDOS As Button
    Friend WithEvents ButtonDAV As Button
    Friend WithEvents ButtonESTOQUE As Button
End Class
