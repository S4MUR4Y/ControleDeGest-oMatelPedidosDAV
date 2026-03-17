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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel1 = New Panel()
        LabelCARREGAMENTOESTOQUE = New Label()
        PoisonProgressBarCARREGAMENTOESTOQUE = New ReaLTaiizor.Controls.PoisonProgressBar()
        ComboBoxOPCAO = New ComboBox()
        TextBoxPESQUISA = New TextBox()
        PictureBox1 = New PictureBox()
        PoisonDataGridViewESTOQUE = New ReaLTaiizor.Controls.PoisonDataGridView()
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
        Panel1.Size = New Size(894, 39)
        Panel1.TabIndex = 1
        ' 
        ' LabelCARREGAMENTOESTOQUE
        ' 
        LabelCARREGAMENTOESTOQUE.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LabelCARREGAMENTOESTOQUE.FlatStyle = FlatStyle.Flat
        LabelCARREGAMENTOESTOQUE.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelCARREGAMENTOESTOQUE.Location = New Point(695, 3)
        LabelCARREGAMENTOESTOQUE.Name = "LabelCARREGAMENTOESTOQUE"
        LabelCARREGAMENTOESTOQUE.Size = New Size(196, 17)
        LabelCARREGAMENTOESTOQUE.TabIndex = 6
        LabelCARREGAMENTOESTOQUE.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PoisonProgressBarCARREGAMENTOESTOQUE
        ' 
        PoisonProgressBarCARREGAMENTOESTOQUE.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PoisonProgressBarCARREGAMENTOESTOQUE.Location = New Point(695, 23)
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
        PoisonDataGridViewESTOQUE.BorderStyle = BorderStyle.None
        PoisonDataGridViewESTOQUE.CellBorderStyle = DataGridViewCellBorderStyle.None
        PoisonDataGridViewESTOQUE.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle1.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewESTOQUE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        PoisonDataGridViewESTOQUE.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.Black
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        PoisonDataGridViewESTOQUE.DefaultCellStyle = DataGridViewCellStyle2
        PoisonDataGridViewESTOQUE.EnableHeadersVisualStyles = False
        PoisonDataGridViewESTOQUE.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        PoisonDataGridViewESTOQUE.GridColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewESTOQUE.Location = New Point(0, 42)
        PoisonDataGridViewESTOQUE.Name = "PoisonDataGridViewESTOQUE"
        PoisonDataGridViewESTOQUE.ReadOnly = True
        PoisonDataGridViewESTOQUE.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle3.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewESTOQUE.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        PoisonDataGridViewESTOQUE.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        PoisonDataGridViewESTOQUE.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        PoisonDataGridViewESTOQUE.Size = New Size(894, 481)
        PoisonDataGridViewESTOQUE.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Blue
        PoisonDataGridViewESTOQUE.TabIndex = 0
        ' 
        ' ESTOQUE
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = SystemColors.Window
        ClientSize = New Size(895, 524)
        Controls.Add(PoisonDataGridViewESTOQUE)
        Controls.Add(Panel1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
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
End Class
