<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADDFORMPAGAMENTO
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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADDFORMPAGAMENTO))
        ButtonSELECIONAR = New Button()
        PoisonDataGridViewPAGAMENTOS = New ReaLTaiizor.Controls.PoisonDataGridView()
        PictureBox1 = New PictureBox()
        TextBoxPESQUISA = New TextBox()
        CType(PoisonDataGridViewPAGAMENTOS, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' ButtonSELECIONAR
        ' 
        ButtonSELECIONAR.Location = New Point(207, 281)
        ButtonSELECIONAR.Name = "ButtonSELECIONAR"
        ButtonSELECIONAR.Size = New Size(109, 28)
        ButtonSELECIONAR.TabIndex = 7
        ButtonSELECIONAR.Text = "SELECIONAR"
        ButtonSELECIONAR.UseVisualStyleBackColor = True
        ' 
        ' PoisonDataGridViewPAGAMENTOS
        ' 
        PoisonDataGridViewPAGAMENTOS.AllowUserToResizeRows = False
        PoisonDataGridViewPAGAMENTOS.BackgroundColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewPAGAMENTOS.CellBorderStyle = DataGridViewCellBorderStyle.None
        PoisonDataGridViewPAGAMENTOS.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle4.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewPAGAMENTOS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        PoisonDataGridViewPAGAMENTOS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle5.ForeColor = Color.FromArgb(CByte(136), CByte(136), CByte(136))
        DataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.False
        PoisonDataGridViewPAGAMENTOS.DefaultCellStyle = DataGridViewCellStyle5
        PoisonDataGridViewPAGAMENTOS.EnableHeadersVisualStyles = False
        PoisonDataGridViewPAGAMENTOS.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        PoisonDataGridViewPAGAMENTOS.GridColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewPAGAMENTOS.Location = New Point(3, 41)
        PoisonDataGridViewPAGAMENTOS.Name = "PoisonDataGridViewPAGAMENTOS"
        PoisonDataGridViewPAGAMENTOS.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle6.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewPAGAMENTOS.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        PoisonDataGridViewPAGAMENTOS.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        PoisonDataGridViewPAGAMENTOS.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        PoisonDataGridViewPAGAMENTOS.Size = New Size(313, 234)
        PoisonDataGridViewPAGAMENTOS.TabIndex = 6
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(3, 2)
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
        TextBoxPESQUISA.Location = New Point(44, 12)
        TextBoxPESQUISA.Name = "TextBoxPESQUISA"
        TextBoxPESQUISA.Size = New Size(272, 23)
        TextBoxPESQUISA.TabIndex = 4
        ' 
        ' ADDFORMPAGAMENTO
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(321, 316)
        Controls.Add(ButtonSELECIONAR)
        Controls.Add(PoisonDataGridViewPAGAMENTOS)
        Controls.Add(PictureBox1)
        Controls.Add(TextBoxPESQUISA)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "ADDFORMPAGAMENTO"
        Text = "SAYTECH | ADDFORMPAGAMENTO"
        CType(PoisonDataGridViewPAGAMENTOS, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ButtonSELECIONAR As Button
    Friend WithEvents PoisonDataGridViewPAGAMENTOS As ReaLTaiizor.Controls.PoisonDataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBoxPESQUISA As TextBox
End Class
