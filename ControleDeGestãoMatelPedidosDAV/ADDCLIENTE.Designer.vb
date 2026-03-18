<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADDCLIENTE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADDCLIENTE))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        TextBoxPESQUISA = New TextBox()
        PictureBox1 = New PictureBox()
        PoisonDataGridViewCLIENTES = New ReaLTaiizor.Controls.PoisonDataGridView()
        ButtonSELECIONAR = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PoisonDataGridViewCLIENTES, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TextBoxPESQUISA
        ' 
        TextBoxPESQUISA.BorderStyle = BorderStyle.FixedSingle
        TextBoxPESQUISA.Cursor = Cursors.IBeam
        TextBoxPESQUISA.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxPESQUISA.Location = New Point(46, 16)
        TextBoxPESQUISA.Name = "TextBoxPESQUISA"
        TextBoxPESQUISA.Size = New Size(272, 23)
        TextBoxPESQUISA.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(5, 6)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(35, 33)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' PoisonDataGridViewCLIENTES
        ' 
        PoisonDataGridViewCLIENTES.AllowUserToResizeRows = False
        PoisonDataGridViewCLIENTES.BackgroundColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewCLIENTES.CellBorderStyle = DataGridViewCellBorderStyle.None
        PoisonDataGridViewCLIENTES.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewCLIENTES.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        PoisonDataGridViewCLIENTES.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(136), CByte(136), CByte(136))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        PoisonDataGridViewCLIENTES.DefaultCellStyle = DataGridViewCellStyle2
        PoisonDataGridViewCLIENTES.EnableHeadersVisualStyles = False
        PoisonDataGridViewCLIENTES.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        PoisonDataGridViewCLIENTES.GridColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewCLIENTES.Location = New Point(5, 45)
        PoisonDataGridViewCLIENTES.Name = "PoisonDataGridViewCLIENTES"
        PoisonDataGridViewCLIENTES.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewCLIENTES.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        PoisonDataGridViewCLIENTES.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        PoisonDataGridViewCLIENTES.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        PoisonDataGridViewCLIENTES.Size = New Size(313, 234)
        PoisonDataGridViewCLIENTES.TabIndex = 2
        ' 
        ' ButtonSELECIONAR
        ' 
        ButtonSELECIONAR.Location = New Point(209, 285)
        ButtonSELECIONAR.Name = "ButtonSELECIONAR"
        ButtonSELECIONAR.Size = New Size(109, 28)
        ButtonSELECIONAR.TabIndex = 3
        ButtonSELECIONAR.Text = "SELECIONAR"
        ButtonSELECIONAR.UseVisualStyleBackColor = True
        ' 
        ' ADDCLIENTE
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = SystemColors.Window
        ClientSize = New Size(323, 319)
        Controls.Add(ButtonSELECIONAR)
        Controls.Add(PoisonDataGridViewCLIENTES)
        Controls.Add(PictureBox1)
        Controls.Add(TextBoxPESQUISA)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "ADDCLIENTE"
        Text = "SAYTECH | ADDCLIENTE"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PoisonDataGridViewCLIENTES, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TextBoxPESQUISA As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PoisonDataGridViewCLIENTES As ReaLTaiizor.Controls.PoisonDataGridView
    Friend WithEvents ButtonSELECIONAR As Button
End Class
