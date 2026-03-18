<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ESTOQUE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ESTOQUE))
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel1 = New Panel()
        LabelCARREGAMENTOESTOQUE = New Label()
        PoisonProgressBarCARREGAMENTOESTOQUE = New ReaLTaiizor.Controls.PoisonProgressBar()
        ComboBoxOPCAO = New ComboBox()
        TextBoxPESQUISA = New TextBox()
        PictureBox1 = New PictureBox()
        PoisonDataGridViewESTOQUE = New ReaLTaiizor.Controls.PoisonDataGridView()
        ListViewSELECIONADOS = New ListView()
        ButtonCONFIRMAR = New Button()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PoisonDataGridViewESTOQUE, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = SystemColors.Menu
        Panel1.Controls.Add(LabelCARREGAMENTOESTOQUE)
        Panel1.Controls.Add(PoisonProgressBarCARREGAMENTOESTOQUE)
        Panel1.Controls.Add(ComboBoxOPCAO)
        Panel1.Controls.Add(TextBoxPESQUISA)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1176, 39)
        Panel1.TabIndex = 1
        ' 
        ' LabelCARREGAMENTOESTOQUE
        ' 
        LabelCARREGAMENTOESTOQUE.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LabelCARREGAMENTOESTOQUE.FlatStyle = FlatStyle.Flat
        LabelCARREGAMENTOESTOQUE.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelCARREGAMENTOESTOQUE.Location = New Point(977, 3)
        LabelCARREGAMENTOESTOQUE.Name = "LabelCARREGAMENTOESTOQUE"
        LabelCARREGAMENTOESTOQUE.Size = New Size(196, 17)
        LabelCARREGAMENTOESTOQUE.TabIndex = 6
        LabelCARREGAMENTOESTOQUE.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PoisonProgressBarCARREGAMENTOESTOQUE
        ' 
        PoisonProgressBarCARREGAMENTOESTOQUE.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PoisonProgressBarCARREGAMENTOESTOQUE.Location = New Point(977, 23)
        PoisonProgressBarCARREGAMENTOESTOQUE.Name = "PoisonProgressBarCARREGAMENTOESTOQUE"
        PoisonProgressBarCARREGAMENTOESTOQUE.Size = New Size(196, 13)
        PoisonProgressBarCARREGAMENTOESTOQUE.TabIndex = 5
        ' 
        ' ComboBoxOPCAO
        ' 
        ComboBoxOPCAO.FormattingEnabled = True
        ComboBoxOPCAO.Location = New Point(448, 13)
        ComboBoxOPCAO.Name = "ComboBoxOPCAO"
        ComboBoxOPCAO.Size = New Size(143, 23)
        ComboBoxOPCAO.TabIndex = 1
        ' 
        ' TextBoxPESQUISA
        ' 
        TextBoxPESQUISA.BorderStyle = BorderStyle.FixedSingle
        TextBoxPESQUISA.Cursor = Cursors.IBeam
        TextBoxPESQUISA.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxPESQUISA.Location = New Point(44, 13)
        TextBoxPESQUISA.Name = "TextBoxPESQUISA"
        TextBoxPESQUISA.Size = New Size(398, 23)
        TextBoxPESQUISA.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(3, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(35, 33)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' PoisonDataGridViewESTOQUE
        ' 
        PoisonDataGridViewESTOQUE.AllowUserToAddRows = False
        PoisonDataGridViewESTOQUE.AllowUserToDeleteRows = False
        PoisonDataGridViewESTOQUE.AllowUserToOrderColumns = True
        PoisonDataGridViewESTOQUE.AllowUserToResizeRows = False
        PoisonDataGridViewESTOQUE.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PoisonDataGridViewESTOQUE.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        PoisonDataGridViewESTOQUE.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        PoisonDataGridViewESTOQUE.BackgroundColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewESTOQUE.BorderStyle = BorderStyle.Fixed3D
        PoisonDataGridViewESTOQUE.CellBorderStyle = DataGridViewCellBorderStyle.None
        PoisonDataGridViewESTOQUE.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle4.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle4.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewESTOQUE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        PoisonDataGridViewESTOQUE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle5.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle5.ForeColor = Color.Black
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.False
        PoisonDataGridViewESTOQUE.DefaultCellStyle = DataGridViewCellStyle5
        PoisonDataGridViewESTOQUE.EnableHeadersVisualStyles = False
        PoisonDataGridViewESTOQUE.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        PoisonDataGridViewESTOQUE.GridColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewESTOQUE.Location = New Point(3, 42)
        PoisonDataGridViewESTOQUE.Name = "PoisonDataGridViewESTOQUE"
        PoisonDataGridViewESTOQUE.ReadOnly = True
        PoisonDataGridViewESTOQUE.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle6.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewESTOQUE.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        PoisonDataGridViewESTOQUE.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        PoisonDataGridViewESTOQUE.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        PoisonDataGridViewESTOQUE.Size = New Size(791, 481)
        PoisonDataGridViewESTOQUE.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue
        PoisonDataGridViewESTOQUE.TabIndex = 0
        ' 
        ' ListViewSELECIONADOS
        ' 
        ListViewSELECIONADOS.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        ListViewSELECIONADOS.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListViewSELECIONADOS.Location = New Point(800, 42)
        ListViewSELECIONADOS.Name = "ListViewSELECIONADOS"
        ListViewSELECIONADOS.Size = New Size(376, 444)
        ListViewSELECIONADOS.TabIndex = 2
        ListViewSELECIONADOS.UseCompatibleStateImageBehavior = False
        ' 
        ' ButtonCONFIRMAR
        ' 
        ButtonCONFIRMAR.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonCONFIRMAR.FlatAppearance.BorderColor = SystemColors.MenuHighlight
        ButtonCONFIRMAR.FlatAppearance.BorderSize = 2
        ButtonCONFIRMAR.FlatAppearance.MouseDownBackColor = SystemColors.Menu
        ButtonCONFIRMAR.FlatAppearance.MouseOverBackColor = SystemColors.Menu
        ButtonCONFIRMAR.FlatStyle = FlatStyle.Flat
        ButtonCONFIRMAR.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonCONFIRMAR.Location = New Point(800, 492)
        ButtonCONFIRMAR.Name = "ButtonCONFIRMAR"
        ButtonCONFIRMAR.Size = New Size(376, 31)
        ButtonCONFIRMAR.TabIndex = 3
        ButtonCONFIRMAR.Text = "CONFIRMAR PRODUTOS"
        ButtonCONFIRMAR.UseVisualStyleBackColor = True
        ' 
        ' ESTOQUE
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = SystemColors.Window
        ClientSize = New Size(1177, 528)
        Controls.Add(ButtonCONFIRMAR)
        Controls.Add(ListViewSELECIONADOS)
        Controls.Add(PoisonDataGridViewESTOQUE)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "ESTOQUE"
        StartPosition = FormStartPosition.CenterParent
        Text = "ESTOQUE"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PoisonDataGridViewESTOQUE, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBoxPESQUISA As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PoisonDataGridViewESTOQUE As ReaLTaiizor.Controls.PoisonDataGridView
    Friend WithEvents ComboBoxOPCAO As ComboBox
    Friend WithEvents LabelCARREGAMENTOESTOQUE As Label
    Friend WithEvents PoisonProgressBarCARREGAMENTOESTOQUE As ReaLTaiizor.Controls.PoisonProgressBar
    Friend WithEvents ListViewSELECIONADOS As ListView
    Friend WithEvents ButtonCONFIRMAR As Button
End Class
