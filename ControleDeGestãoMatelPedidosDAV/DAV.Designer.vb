<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DAV
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DAV))
        Panel1 = New Panel()
        ButtonCONSULTAR = New Button()
        ButtonEXCLUIR = New Button()
        ButtonALTERAR = New Button()
        ButtonINCLUIR = New Button()
        PoisonDataGridViewDADOS = New ReaLTaiizor.Controls.PoisonDataGridView()
        Panel1.SuspendLayout()
        CType(PoisonDataGridViewDADOS, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.BackColor = SystemColors.Menu
        Panel1.Controls.Add(ButtonCONSULTAR)
        Panel1.Controls.Add(ButtonEXCLUIR)
        Panel1.Controls.Add(ButtonALTERAR)
        Panel1.Controls.Add(ButtonINCLUIR)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(744, 39)
        Panel1.TabIndex = 0
        ' 
        ' ButtonCONSULTAR
        ' 
        ButtonCONSULTAR.BackColor = SystemColors.Menu
        ButtonCONSULTAR.Cursor = Cursors.Hand
        ButtonCONSULTAR.FlatAppearance.BorderColor = SystemColors.MenuHighlight
        ButtonCONSULTAR.FlatAppearance.BorderSize = 2
        ButtonCONSULTAR.FlatAppearance.MouseDownBackColor = SystemColors.MenuHighlight
        ButtonCONSULTAR.FlatAppearance.MouseOverBackColor = SystemColors.MenuHighlight
        ButtonCONSULTAR.FlatStyle = FlatStyle.Flat
        ButtonCONSULTAR.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonCONSULTAR.Location = New Point(366, 4)
        ButtonCONSULTAR.Name = "ButtonCONSULTAR"
        ButtonCONSULTAR.Size = New Size(115, 31)
        ButtonCONSULTAR.TabIndex = 4
        ButtonCONSULTAR.Text = "CONSULTAR"
        ButtonCONSULTAR.UseVisualStyleBackColor = False
        ' 
        ' ButtonEXCLUIR
        ' 
        ButtonEXCLUIR.BackColor = SystemColors.Menu
        ButtonEXCLUIR.Cursor = Cursors.Hand
        ButtonEXCLUIR.FlatAppearance.BorderColor = SystemColors.MenuHighlight
        ButtonEXCLUIR.FlatAppearance.BorderSize = 2
        ButtonEXCLUIR.FlatAppearance.MouseDownBackColor = SystemColors.MenuHighlight
        ButtonEXCLUIR.FlatAppearance.MouseOverBackColor = SystemColors.MenuHighlight
        ButtonEXCLUIR.FlatStyle = FlatStyle.Flat
        ButtonEXCLUIR.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonEXCLUIR.Location = New Point(245, 4)
        ButtonEXCLUIR.Name = "ButtonEXCLUIR"
        ButtonEXCLUIR.Size = New Size(115, 31)
        ButtonEXCLUIR.TabIndex = 3
        ButtonEXCLUIR.Text = "EXCLUIR"
        ButtonEXCLUIR.UseVisualStyleBackColor = False
        ' 
        ' ButtonALTERAR
        ' 
        ButtonALTERAR.BackColor = SystemColors.Menu
        ButtonALTERAR.Cursor = Cursors.Hand
        ButtonALTERAR.FlatAppearance.BorderColor = SystemColors.MenuHighlight
        ButtonALTERAR.FlatAppearance.BorderSize = 2
        ButtonALTERAR.FlatAppearance.MouseDownBackColor = SystemColors.MenuHighlight
        ButtonALTERAR.FlatAppearance.MouseOverBackColor = SystemColors.MenuHighlight
        ButtonALTERAR.FlatStyle = FlatStyle.Flat
        ButtonALTERAR.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonALTERAR.Location = New Point(124, 4)
        ButtonALTERAR.Name = "ButtonALTERAR"
        ButtonALTERAR.Size = New Size(115, 31)
        ButtonALTERAR.TabIndex = 2
        ButtonALTERAR.Text = "ALTERAR"
        ButtonALTERAR.UseVisualStyleBackColor = False
        ' 
        ' ButtonINCLUIR
        ' 
        ButtonINCLUIR.BackColor = SystemColors.Menu
        ButtonINCLUIR.Cursor = Cursors.Hand
        ButtonINCLUIR.FlatAppearance.BorderColor = SystemColors.MenuHighlight
        ButtonINCLUIR.FlatAppearance.BorderSize = 2
        ButtonINCLUIR.FlatAppearance.MouseDownBackColor = SystemColors.MenuHighlight
        ButtonINCLUIR.FlatAppearance.MouseOverBackColor = SystemColors.MenuHighlight
        ButtonINCLUIR.FlatStyle = FlatStyle.Flat
        ButtonINCLUIR.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonINCLUIR.Location = New Point(3, 4)
        ButtonINCLUIR.Name = "ButtonINCLUIR"
        ButtonINCLUIR.Size = New Size(115, 31)
        ButtonINCLUIR.TabIndex = 1
        ButtonINCLUIR.Text = "INCLUIR"
        ButtonINCLUIR.UseVisualStyleBackColor = False
        ' 
        ' PoisonDataGridViewDADOS
        ' 
        PoisonDataGridViewDADOS.AllowUserToResizeRows = False
        PoisonDataGridViewDADOS.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PoisonDataGridViewDADOS.BackgroundColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewDADOS.CellBorderStyle = DataGridViewCellBorderStyle.None
        PoisonDataGridViewDADOS.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewDADOS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        PoisonDataGridViewDADOS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(136), CByte(136), CByte(136))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        PoisonDataGridViewDADOS.DefaultCellStyle = DataGridViewCellStyle2
        PoisonDataGridViewDADOS.EnableHeadersVisualStyles = False
        PoisonDataGridViewDADOS.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        PoisonDataGridViewDADOS.GridColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewDADOS.Location = New Point(0, 41)
        PoisonDataGridViewDADOS.Name = "PoisonDataGridViewDADOS"
        PoisonDataGridViewDADOS.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewDADOS.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        PoisonDataGridViewDADOS.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        PoisonDataGridViewDADOS.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        PoisonDataGridViewDADOS.Size = New Size(744, 325)
        PoisonDataGridViewDADOS.TabIndex = 1
        ' 
        ' DAV
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = SystemColors.Window
        ClientSize = New Size(744, 444)
        Controls.Add(PoisonDataGridViewDADOS)
        Controls.Add(Panel1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "DAV"
        StartPosition = FormStartPosition.CenterScreen
        Text = "SAYTECH | CONTROLE DE DAV"
        Panel1.ResumeLayout(False)
        CType(PoisonDataGridViewDADOS, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButtonINCLUIR As Button
    Friend WithEvents ButtonCONSULTAR As Button
    Friend WithEvents ButtonEXCLUIR As Button
    Friend WithEvents ButtonALTERAR As Button
    Friend WithEvents PoisonDataGridViewDADOS As ReaLTaiizor.Controls.PoisonDataGridView
End Class
