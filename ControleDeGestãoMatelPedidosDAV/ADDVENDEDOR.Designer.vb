<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADDVENDEDOR
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADDVENDEDOR))
        ButtonSELECIONAR = New Button()
        PoisonDataGridViewVENDEDORES = New ReaLTaiizor.Controls.PoisonDataGridView()
        PictureBox1 = New PictureBox()
        TextBoxPESQUISA = New TextBox()
        CType(PoisonDataGridViewVENDEDORES, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ButtonSELECIONAR
        ' 
        ButtonSELECIONAR.Location = New Point(216, 291)
        ButtonSELECIONAR.Name = "ButtonSELECIONAR"
        ButtonSELECIONAR.Size = New Size(109, 28)
        ButtonSELECIONAR.TabIndex = 7
        ButtonSELECIONAR.Text = "SELECIONAR"
        ButtonSELECIONAR.UseVisualStyleBackColor = True
        ' 
        ' PoisonDataGridViewVENDEDORES
        ' 
        PoisonDataGridViewVENDEDORES.AllowUserToResizeRows = False
        PoisonDataGridViewVENDEDORES.BackgroundColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewVENDEDORES.CellBorderStyle = DataGridViewCellBorderStyle.None
        PoisonDataGridViewVENDEDORES.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewVENDEDORES.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        PoisonDataGridViewVENDEDORES.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(136), CByte(136), CByte(136))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        PoisonDataGridViewVENDEDORES.DefaultCellStyle = DataGridViewCellStyle2
        PoisonDataGridViewVENDEDORES.EnableHeadersVisualStyles = False
        PoisonDataGridViewVENDEDORES.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        PoisonDataGridViewVENDEDORES.GridColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewVENDEDORES.Location = New Point(12, 51)
        PoisonDataGridViewVENDEDORES.Name = "PoisonDataGridViewVENDEDORES"
        PoisonDataGridViewVENDEDORES.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewVENDEDORES.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        PoisonDataGridViewVENDEDORES.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        PoisonDataGridViewVENDEDORES.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        PoisonDataGridViewVENDEDORES.Size = New Size(313, 234)
        PoisonDataGridViewVENDEDORES.TabIndex = 6
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(35, 33)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' TextBoxPESQUISA
        ' 
        TextBoxPESQUISA.BorderStyle = BorderStyle.FixedSingle
        TextBoxPESQUISA.Cursor = Cursors.IBeam
        TextBoxPESQUISA.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxPESQUISA.Location = New Point(53, 22)
        TextBoxPESQUISA.Name = "TextBoxPESQUISA"
        TextBoxPESQUISA.Size = New Size(272, 23)
        TextBoxPESQUISA.TabIndex = 4
        ' 
        ' ADDVENDEDOR
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Window
        ClientSize = New Size(331, 326)
        Controls.Add(ButtonSELECIONAR)
        Controls.Add(PoisonDataGridViewVENDEDORES)
        Controls.Add(PictureBox1)
        Controls.Add(TextBoxPESQUISA)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "ADDVENDEDOR"
        Text = "SAYTECH | ADDVENDEDOR"
        CType(PoisonDataGridViewVENDEDORES, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ButtonSELECIONAR As Button
    Friend WithEvents PoisonDataGridViewVENDEDORES As ReaLTaiizor.Controls.PoisonDataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBoxPESQUISA As TextBox
End Class
