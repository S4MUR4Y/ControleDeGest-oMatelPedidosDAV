<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LOGIN
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LOGIN))
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PoisonTextBoxLOGIN = New ReaLTaiizor.Controls.PoisonTextBox()
        PoisonButtonACESSAR = New ReaLTaiizor.Controls.PoisonButton()
        PoisonProgressBarPROGRESSO = New ReaLTaiizor.Controls.PoisonProgressBar()
        PoisonTextBoxSENHA = New ReaLTaiizor.Controls.PoisonTextBox()
        PictureBox3 = New PictureBox()
        LabelPROGRESSO = New Label()
        ButtonTESTESERVER = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(34, 104)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(35, 35)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(34, 145)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(35, 35)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 2
        PictureBox2.TabStop = False
        ' 
        ' PoisonTextBoxLOGIN
        ' 
        PoisonTextBoxLOGIN.Cursor = Cursors.IBeam
        ' 
        ' 
        ' 
        PoisonTextBoxLOGIN.CustomButton.Image = Nothing
        PoisonTextBoxLOGIN.CustomButton.Location = New Point(164, 1)
        PoisonTextBoxLOGIN.CustomButton.Name = ""
        PoisonTextBoxLOGIN.CustomButton.Size = New Size(33, 33)
        PoisonTextBoxLOGIN.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue
        PoisonTextBoxLOGIN.CustomButton.TabIndex = 1
        PoisonTextBoxLOGIN.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light
        PoisonTextBoxLOGIN.CustomButton.UseSelectable = True
        PoisonTextBoxLOGIN.CustomButton.Visible = False
        PoisonTextBoxLOGIN.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Pixel)
        PoisonTextBoxLOGIN.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Tall
        PoisonTextBoxLOGIN.FontWeight = ReaLTaiizor.Extension.Poison.PoisonTextBoxWeight.Bold
        PoisonTextBoxLOGIN.Location = New Point(75, 104)
        PoisonTextBoxLOGIN.MaxLength = 32767
        PoisonTextBoxLOGIN.Name = "PoisonTextBoxLOGIN"
        PoisonTextBoxLOGIN.PasswordChar = ChrW(0)
        PoisonTextBoxLOGIN.ScrollBars = ScrollBars.None
        PoisonTextBoxLOGIN.SelectedText = ""
        PoisonTextBoxLOGIN.SelectionLength = 0
        PoisonTextBoxLOGIN.SelectionStart = 0
        PoisonTextBoxLOGIN.ShortcutsEnabled = True
        PoisonTextBoxLOGIN.Size = New Size(198, 35)
        PoisonTextBoxLOGIN.TabIndex = 0
        PoisonTextBoxLOGIN.UseSelectable = True
        PoisonTextBoxLOGIN.WaterMarkColor = Color.FromArgb(CByte(109), CByte(109), CByte(109))
        PoisonTextBoxLOGIN.WaterMarkFont = New Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel)
        ' 
        ' PoisonButtonACESSAR
        ' 
        PoisonButtonACESSAR.Cursor = Cursors.Hand
        PoisonButtonACESSAR.FlatAppearance.BorderColor = Color.Black
        PoisonButtonACESSAR.FlatAppearance.BorderSize = 3
        PoisonButtonACESSAR.FlatAppearance.MouseDownBackColor = SystemColors.MenuHighlight
        PoisonButtonACESSAR.FlatAppearance.MouseOverBackColor = SystemColors.MenuHighlight
        PoisonButtonACESSAR.FlatStyle = FlatStyle.Flat
        PoisonButtonACESSAR.Font = New Font("Bahnschrift", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        PoisonButtonACESSAR.ForeColor = Color.Black
        PoisonButtonACESSAR.Location = New Point(34, 193)
        PoisonButtonACESSAR.Name = "PoisonButtonACESSAR"
        PoisonButtonACESSAR.Size = New Size(239, 28)
        PoisonButtonACESSAR.TabIndex = 2
        PoisonButtonACESSAR.Text = "ACESSAR"
        PoisonButtonACESSAR.UseCustomBackColor = True
        PoisonButtonACESSAR.UseCustomFont = True
        PoisonButtonACESSAR.UseSelectable = True
        PoisonButtonACESSAR.UseStyleColors = True
        PoisonButtonACESSAR.UseVisualStyleBackColor = True
        PoisonButtonACESSAR.UseWaitCursor = True
        ' 
        ' PoisonProgressBarPROGRESSO
        ' 
        PoisonProgressBarPROGRESSO.Location = New Point(0, 247)
        PoisonProgressBarPROGRESSO.Name = "PoisonProgressBarPROGRESSO"
        PoisonProgressBarPROGRESSO.Size = New Size(307, 10)
        PoisonProgressBarPROGRESSO.TabIndex = 5
        ' 
        ' PoisonTextBoxSENHA
        ' 
        PoisonTextBoxSENHA.Cursor = Cursors.IBeam
        ' 
        ' 
        ' 
        PoisonTextBoxSENHA.CustomButton.Image = Nothing
        PoisonTextBoxSENHA.CustomButton.Location = New Point(164, 1)
        PoisonTextBoxSENHA.CustomButton.Name = ""
        PoisonTextBoxSENHA.CustomButton.Size = New Size(33, 33)
        PoisonTextBoxSENHA.CustomButton.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue
        PoisonTextBoxSENHA.CustomButton.TabIndex = 1
        PoisonTextBoxSENHA.CustomButton.Theme = ReaLTaiizor.Enum.Poison.ThemeStyle.Light
        PoisonTextBoxSENHA.CustomButton.UseSelectable = True
        PoisonTextBoxSENHA.CustomButton.Visible = False
        PoisonTextBoxSENHA.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Pixel)
        PoisonTextBoxSENHA.FontSize = ReaLTaiizor.Extension.Poison.PoisonTextBoxSize.Tall
        PoisonTextBoxSENHA.FontWeight = ReaLTaiizor.Extension.Poison.PoisonTextBoxWeight.Bold
        PoisonTextBoxSENHA.Location = New Point(75, 145)
        PoisonTextBoxSENHA.MaxLength = 32767
        PoisonTextBoxSENHA.Name = "PoisonTextBoxSENHA"
        PoisonTextBoxSENHA.PasswordChar = "#"c
        PoisonTextBoxSENHA.ScrollBars = ScrollBars.None
        PoisonTextBoxSENHA.SelectedText = ""
        PoisonTextBoxSENHA.SelectionLength = 0
        PoisonTextBoxSENHA.SelectionStart = 0
        PoisonTextBoxSENHA.ShortcutsEnabled = True
        PoisonTextBoxSENHA.Size = New Size(198, 35)
        PoisonTextBoxSENHA.TabIndex = 1
        PoisonTextBoxSENHA.UseSelectable = True
        PoisonTextBoxSENHA.WaterMarkColor = Color.FromArgb(CByte(109), CByte(109), CByte(109))
        PoisonTextBoxSENHA.WaterMarkFont = New Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Pixel)
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(0, 0)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(307, 98)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 7
        PictureBox3.TabStop = False
        ' 
        ' LabelPROGRESSO
        ' 
        LabelPROGRESSO.FlatStyle = FlatStyle.Flat
        LabelPROGRESSO.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelPROGRESSO.Location = New Point(0, 227)
        LabelPROGRESSO.Name = "LabelPROGRESSO"
        LabelPROGRESSO.Size = New Size(307, 18)
        LabelPROGRESSO.TabIndex = 8
        LabelPROGRESSO.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ButtonTESTESERVER
        ' 
        ButtonTESTESERVER.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonTESTESERVER.BackColor = Color.Transparent
        ButtonTESTESERVER.Cursor = Cursors.Hand
        ButtonTESTESERVER.FlatAppearance.BorderColor = Color.White
        ButtonTESTESERVER.FlatAppearance.BorderSize = 0
        ButtonTESTESERVER.FlatAppearance.MouseDownBackColor = Color.White
        ButtonTESTESERVER.FlatAppearance.MouseOverBackColor = Color.White
        ButtonTESTESERVER.FlatStyle = FlatStyle.Flat
        ButtonTESTESERVER.ForeColor = Color.White
        ButtonTESTESERVER.Image = CType(resources.GetObject("ButtonTESTESERVER.Image"), Image)
        ButtonTESTESERVER.Location = New Point(277, 193)
        ButtonTESTESERVER.Name = "ButtonTESTESERVER"
        ButtonTESTESERVER.Size = New Size(28, 28)
        ButtonTESTESERVER.TabIndex = 9
        ButtonTESTESERVER.UseVisualStyleBackColor = False
        ' 
        ' LOGIN
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = SystemColors.Window
        ClientSize = New Size(307, 258)
        Controls.Add(ButtonTESTESERVER)
        Controls.Add(LabelPROGRESSO)
        Controls.Add(PictureBox3)
        Controls.Add(PoisonTextBoxSENHA)
        Controls.Add(PoisonProgressBarPROGRESSO)
        Controls.Add(PoisonButtonACESSAR)
        Controls.Add(PoisonTextBoxLOGIN)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "LOGIN"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SAYTECH | LOGIN"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PoisonTextBoxLOGIN As ReaLTaiizor.Controls.PoisonTextBox
    Friend WithEvents PoisonButtonACESSAR As ReaLTaiizor.Controls.PoisonButton
    Friend WithEvents PoisonProgressBarPROGRESSO As ReaLTaiizor.Controls.PoisonProgressBar
    Friend WithEvents PoisonTextBoxSENHA As ReaLTaiizor.Controls.PoisonTextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents LabelPROGRESSO As Label
    Friend WithEvents ButtonTESTESERVER As Button

End Class
