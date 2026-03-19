<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class INCLUIR_ALTERAR_EXCLUIR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(INCLUIR_ALTERAR_EXCLUIR))
        Label1 = New Label()
        TextBoxCOD = New TextBox()
        TextBoxDATA = New TextBox()
        Label2 = New Label()
        TextBoxCODCLIENTE = New TextBox()
        Label3 = New Label()
        TextBoxNOMECLIENTE = New TextBox()
        TextBoxVENDEDOR = New TextBox()
        TextBoxCODVENDEDOR = New TextBox()
        Label4 = New Label()
        PanelCABECALHO = New Panel()
        PoisonDataGridViewPROCURAPRODUTOS = New ReaLTaiizor.Controls.PoisonDataGridView()
        PanelDESCONTO = New Panel()
        TextBoxDESCONTOREAL = New TextBox()
        Label6 = New Label()
        TextBoxDESCONTOPORCENT = New TextBox()
        Label5 = New Label()
        PanelVALORTOTAL = New Panel()
        TextBoxVALORTOTAL = New TextBox()
        Label9 = New Label()
        TextBoxVALORITENS = New TextBox()
        Label7 = New Label()
        PanelPAGAMENTO = New Panel()
        TextBoxNOMEPAGAMENTO = New TextBox()
        TextBoxCODPAGAMENTO = New TextBox()
        Label11 = New Label()
        ButtonCONFIRMAR = New Button()
        ButtonCANCELAR = New Button()
        ButtonFECHAR = New Button()
        TextBoxOBS = New TextBox()
        Label12 = New Label()
        PanelCABECALHO.SuspendLayout()
        CType(PoisonDataGridViewPROCURAPRODUTOS, ComponentModel.ISupportInitialize).BeginInit()
        PanelDESCONTO.SuspendLayout()
        PanelVALORTOTAL.SuspendLayout()
        PanelPAGAMENTO.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top
        Label1.BackColor = SystemColors.Menu
        Label1.FlatStyle = FlatStyle.Flat
        Label1.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(100, 23)
        Label1.TabIndex = 0
        Label1.Text = "CÓDIGO"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxCOD
        ' 
        TextBoxCOD.Anchor = AnchorStyles.Top
        TextBoxCOD.BorderStyle = BorderStyle.FixedSingle
        TextBoxCOD.Cursor = Cursors.IBeam
        TextBoxCOD.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxCOD.Location = New Point(12, 35)
        TextBoxCOD.Name = "TextBoxCOD"
        TextBoxCOD.Size = New Size(100, 23)
        TextBoxCOD.TabIndex = 99
        TextBoxCOD.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBoxDATA
        ' 
        TextBoxDATA.Anchor = AnchorStyles.Top
        TextBoxDATA.BorderStyle = BorderStyle.FixedSingle
        TextBoxDATA.Cursor = Cursors.IBeam
        TextBoxDATA.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxDATA.Location = New Point(118, 35)
        TextBoxDATA.Name = "TextBoxDATA"
        TextBoxDATA.Size = New Size(100, 23)
        TextBoxDATA.TabIndex = 98
        TextBoxDATA.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.Top
        Label2.BackColor = SystemColors.Menu
        Label2.FlatStyle = FlatStyle.Flat
        Label2.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(118, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(100, 23)
        Label2.TabIndex = 2
        Label2.Text = "EMISSÃO"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxCODCLIENTE
        ' 
        TextBoxCODCLIENTE.Anchor = AnchorStyles.Top
        TextBoxCODCLIENTE.BorderStyle = BorderStyle.FixedSingle
        TextBoxCODCLIENTE.Cursor = Cursors.IBeam
        TextBoxCODCLIENTE.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxCODCLIENTE.Location = New Point(224, 35)
        TextBoxCODCLIENTE.Name = "TextBoxCODCLIENTE"
        TextBoxCODCLIENTE.Size = New Size(49, 23)
        TextBoxCODCLIENTE.TabIndex = 0
        TextBoxCODCLIENTE.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.Top
        Label3.BackColor = SystemColors.Menu
        Label3.FlatStyle = FlatStyle.Flat
        Label3.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(224, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(313, 23)
        Label3.TabIndex = 4
        Label3.Text = "NOME DO CLIENTE"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxNOMECLIENTE
        ' 
        TextBoxNOMECLIENTE.Anchor = AnchorStyles.Top
        TextBoxNOMECLIENTE.BorderStyle = BorderStyle.FixedSingle
        TextBoxNOMECLIENTE.Cursor = Cursors.IBeam
        TextBoxNOMECLIENTE.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxNOMECLIENTE.Location = New Point(274, 35)
        TextBoxNOMECLIENTE.Name = "TextBoxNOMECLIENTE"
        TextBoxNOMECLIENTE.Size = New Size(263, 23)
        TextBoxNOMECLIENTE.TabIndex = 97
        TextBoxNOMECLIENTE.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBoxVENDEDOR
        ' 
        TextBoxVENDEDOR.Anchor = AnchorStyles.Top
        TextBoxVENDEDOR.BorderStyle = BorderStyle.FixedSingle
        TextBoxVENDEDOR.Cursor = Cursors.IBeam
        TextBoxVENDEDOR.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxVENDEDOR.ForeColor = SystemColors.MenuHighlight
        TextBoxVENDEDOR.Location = New Point(593, 35)
        TextBoxVENDEDOR.Name = "TextBoxVENDEDOR"
        TextBoxVENDEDOR.Size = New Size(132, 23)
        TextBoxVENDEDOR.TabIndex = 96
        TextBoxVENDEDOR.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBoxCODVENDEDOR
        ' 
        TextBoxCODVENDEDOR.Anchor = AnchorStyles.Top
        TextBoxCODVENDEDOR.BorderStyle = BorderStyle.FixedSingle
        TextBoxCODVENDEDOR.Cursor = Cursors.IBeam
        TextBoxCODVENDEDOR.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxCODVENDEDOR.Location = New Point(543, 35)
        TextBoxCODVENDEDOR.Name = "TextBoxCODVENDEDOR"
        TextBoxCODVENDEDOR.Size = New Size(49, 23)
        TextBoxCODVENDEDOR.TabIndex = 1
        TextBoxCODVENDEDOR.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top
        Label4.BackColor = SystemColors.Menu
        Label4.FlatStyle = FlatStyle.Flat
        Label4.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(543, 9)
        Label4.Name = "Label4"
        Label4.Size = New Size(182, 23)
        Label4.TabIndex = 7
        Label4.Text = "VENDEDOR"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PanelCABECALHO
        ' 
        PanelCABECALHO.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        PanelCABECALHO.BackColor = SystemColors.Menu
        PanelCABECALHO.Controls.Add(Label1)
        PanelCABECALHO.Controls.Add(Label2)
        PanelCABECALHO.Controls.Add(Label3)
        PanelCABECALHO.Controls.Add(Label4)
        PanelCABECALHO.Location = New Point(0, 0)
        PanelCABECALHO.Name = "PanelCABECALHO"
        PanelCABECALHO.Size = New Size(733, 62)
        PanelCABECALHO.TabIndex = 100
        ' 
        ' PoisonDataGridViewPROCURAPRODUTOS
        ' 
        PoisonDataGridViewPROCURAPRODUTOS.AllowUserToOrderColumns = True
        PoisonDataGridViewPROCURAPRODUTOS.AllowUserToResizeRows = False
        PoisonDataGridViewPROCURAPRODUTOS.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PoisonDataGridViewPROCURAPRODUTOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        PoisonDataGridViewPROCURAPRODUTOS.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        PoisonDataGridViewPROCURAPRODUTOS.BackgroundColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewPROCURAPRODUTOS.BorderStyle = BorderStyle.None
        PoisonDataGridViewPROCURAPRODUTOS.CellBorderStyle = DataGridViewCellBorderStyle.None
        PoisonDataGridViewPROCURAPRODUTOS.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = SystemColors.Menu
        DataGridViewCellStyle1.Font = New Font("Bahnschrift SemiBold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.Black
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.ActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = Color.Black
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewPROCURAPRODUTOS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        PoisonDataGridViewPROCURAPRODUTOS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.Black
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.ScrollBar
        DataGridViewCellStyle2.SelectionForeColor = Color.Red
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        PoisonDataGridViewPROCURAPRODUTOS.DefaultCellStyle = DataGridViewCellStyle2
        PoisonDataGridViewPROCURAPRODUTOS.EnableHeadersVisualStyles = False
        PoisonDataGridViewPROCURAPRODUTOS.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        PoisonDataGridViewPROCURAPRODUTOS.GridColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        PoisonDataGridViewPROCURAPRODUTOS.Location = New Point(0, 68)
        PoisonDataGridViewPROCURAPRODUTOS.Name = "PoisonDataGridViewPROCURAPRODUTOS"
        PoisonDataGridViewPROCURAPRODUTOS.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(0), CByte(174), CByte(219))
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(0), CByte(198), CByte(247))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(17), CByte(17), CByte(17))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        PoisonDataGridViewPROCURAPRODUTOS.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        PoisonDataGridViewPROCURAPRODUTOS.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        PoisonDataGridViewPROCURAPRODUTOS.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        PoisonDataGridViewPROCURAPRODUTOS.Size = New Size(733, 200)
        PoisonDataGridViewPROCURAPRODUTOS.TabIndex = 2
        ' 
        ' PanelDESCONTO
        ' 
        PanelDESCONTO.Anchor = AnchorStyles.Bottom
        PanelDESCONTO.BackColor = SystemColors.Menu
        PanelDESCONTO.Controls.Add(TextBoxDESCONTOREAL)
        PanelDESCONTO.Controls.Add(Label6)
        PanelDESCONTO.Controls.Add(TextBoxDESCONTOPORCENT)
        PanelDESCONTO.Controls.Add(Label5)
        PanelDESCONTO.Location = New Point(0, 274)
        PanelDESCONTO.Name = "PanelDESCONTO"
        PanelDESCONTO.Size = New Size(212, 54)
        PanelDESCONTO.TabIndex = 3
        ' 
        ' TextBoxDESCONTOREAL
        ' 
        TextBoxDESCONTOREAL.Anchor = AnchorStyles.Bottom
        TextBoxDESCONTOREAL.BorderStyle = BorderStyle.FixedSingle
        TextBoxDESCONTOREAL.Cursor = Cursors.IBeam
        TextBoxDESCONTOREAL.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxDESCONTOREAL.Location = New Point(109, 27)
        TextBoxDESCONTOREAL.Name = "TextBoxDESCONTOREAL"
        TextBoxDESCONTOREAL.Size = New Size(100, 23)
        TextBoxDESCONTOREAL.TabIndex = 4
        TextBoxDESCONTOREAL.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Bottom
        Label6.BackColor = SystemColors.Menu
        Label6.FlatStyle = FlatStyle.Flat
        Label6.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(109, 1)
        Label6.Name = "Label6"
        Label6.Size = New Size(100, 23)
        Label6.TabIndex = 14
        Label6.Text = "DESC ($)"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxDESCONTOPORCENT
        ' 
        TextBoxDESCONTOPORCENT.Anchor = AnchorStyles.Bottom
        TextBoxDESCONTOPORCENT.BorderStyle = BorderStyle.FixedSingle
        TextBoxDESCONTOPORCENT.Cursor = Cursors.IBeam
        TextBoxDESCONTOPORCENT.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxDESCONTOPORCENT.Location = New Point(3, 27)
        TextBoxDESCONTOPORCENT.Name = "TextBoxDESCONTOPORCENT"
        TextBoxDESCONTOPORCENT.Size = New Size(100, 23)
        TextBoxDESCONTOPORCENT.TabIndex = 3
        TextBoxDESCONTOPORCENT.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.Bottom
        Label5.BackColor = SystemColors.Menu
        Label5.FlatStyle = FlatStyle.Flat
        Label5.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(3, 1)
        Label5.Name = "Label5"
        Label5.Size = New Size(100, 23)
        Label5.TabIndex = 12
        Label5.Text = "DESC (%)"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PanelVALORTOTAL
        ' 
        PanelVALORTOTAL.Anchor = AnchorStyles.Bottom
        PanelVALORTOTAL.BackColor = SystemColors.Menu
        PanelVALORTOTAL.Controls.Add(TextBoxVALORTOTAL)
        PanelVALORTOTAL.Controls.Add(Label9)
        PanelVALORTOTAL.Controls.Add(TextBoxVALORITENS)
        PanelVALORTOTAL.Controls.Add(Label7)
        PanelVALORTOTAL.Location = New Point(455, 274)
        PanelVALORTOTAL.Name = "PanelVALORTOTAL"
        PanelVALORTOTAL.Size = New Size(278, 54)
        PanelVALORTOTAL.TabIndex = 5
        ' 
        ' TextBoxVALORTOTAL
        ' 
        TextBoxVALORTOTAL.Anchor = AnchorStyles.Bottom
        TextBoxVALORTOTAL.BorderStyle = BorderStyle.FixedSingle
        TextBoxVALORTOTAL.Cursor = Cursors.IBeam
        TextBoxVALORTOTAL.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxVALORTOTAL.ForeColor = Color.Red
        TextBoxVALORTOTAL.Location = New Point(142, 28)
        TextBoxVALORTOTAL.Name = "TextBoxVALORTOTAL"
        TextBoxVALORTOTAL.Size = New Size(132, 23)
        TextBoxVALORTOTAL.TabIndex = 93
        TextBoxVALORTOTAL.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.Bottom
        Label9.BackColor = SystemColors.Menu
        Label9.FlatStyle = FlatStyle.Flat
        Label9.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(143, 2)
        Label9.Name = "Label9"
        Label9.Size = New Size(132, 23)
        Label9.TabIndex = 16
        Label9.Text = "TOTAL GERAL"
        Label9.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxVALORITENS
        ' 
        TextBoxVALORITENS.Anchor = AnchorStyles.Bottom
        TextBoxVALORITENS.BorderStyle = BorderStyle.FixedSingle
        TextBoxVALORITENS.Cursor = Cursors.IBeam
        TextBoxVALORITENS.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxVALORITENS.Location = New Point(4, 28)
        TextBoxVALORITENS.Name = "TextBoxVALORITENS"
        TextBoxVALORITENS.Size = New Size(132, 23)
        TextBoxVALORITENS.TabIndex = 94
        TextBoxVALORITENS.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.Bottom
        Label7.BackColor = SystemColors.Menu
        Label7.FlatStyle = FlatStyle.Flat
        Label7.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(5, 2)
        Label7.Name = "Label7"
        Label7.Size = New Size(132, 23)
        Label7.TabIndex = 14
        Label7.Text = "TOTAL DOS ITENS"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PanelPAGAMENTO
        ' 
        PanelPAGAMENTO.Anchor = AnchorStyles.Bottom
        PanelPAGAMENTO.BackColor = SystemColors.Menu
        PanelPAGAMENTO.Controls.Add(TextBoxNOMEPAGAMENTO)
        PanelPAGAMENTO.Controls.Add(TextBoxCODPAGAMENTO)
        PanelPAGAMENTO.Controls.Add(Label11)
        PanelPAGAMENTO.Location = New Point(215, 274)
        PanelPAGAMENTO.Name = "PanelPAGAMENTO"
        PanelPAGAMENTO.Size = New Size(238, 54)
        PanelPAGAMENTO.TabIndex = 4
        ' 
        ' TextBoxNOMEPAGAMENTO
        ' 
        TextBoxNOMEPAGAMENTO.Anchor = AnchorStyles.Bottom
        TextBoxNOMEPAGAMENTO.BorderStyle = BorderStyle.FixedSingle
        TextBoxNOMEPAGAMENTO.Cursor = Cursors.IBeam
        TextBoxNOMEPAGAMENTO.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxNOMEPAGAMENTO.Location = New Point(44, 27)
        TextBoxNOMEPAGAMENTO.Name = "TextBoxNOMEPAGAMENTO"
        TextBoxNOMEPAGAMENTO.Size = New Size(190, 23)
        TextBoxNOMEPAGAMENTO.TabIndex = 95
        TextBoxNOMEPAGAMENTO.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBoxCODPAGAMENTO
        ' 
        TextBoxCODPAGAMENTO.Anchor = AnchorStyles.Bottom
        TextBoxCODPAGAMENTO.BorderStyle = BorderStyle.FixedSingle
        TextBoxCODPAGAMENTO.Cursor = Cursors.IBeam
        TextBoxCODPAGAMENTO.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxCODPAGAMENTO.Location = New Point(3, 27)
        TextBoxCODPAGAMENTO.Name = "TextBoxCODPAGAMENTO"
        TextBoxCODPAGAMENTO.Size = New Size(39, 23)
        TextBoxCODPAGAMENTO.TabIndex = 5
        TextBoxCODPAGAMENTO.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label11
        ' 
        Label11.Anchor = AnchorStyles.Bottom
        Label11.BackColor = SystemColors.Menu
        Label11.FlatStyle = FlatStyle.Flat
        Label11.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(3, 2)
        Label11.Name = "Label11"
        Label11.Size = New Size(231, 22)
        Label11.TabIndex = 0
        Label11.Text = "CONDIÇÃO DE PAG."
        Label11.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ButtonCONFIRMAR
        ' 
        ButtonCONFIRMAR.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonCONFIRMAR.Cursor = Cursors.Hand
        ButtonCONFIRMAR.FlatAppearance.BorderColor = SystemColors.MenuHighlight
        ButtonCONFIRMAR.FlatAppearance.BorderSize = 2
        ButtonCONFIRMAR.FlatAppearance.MouseDownBackColor = SystemColors.Menu
        ButtonCONFIRMAR.FlatAppearance.MouseOverBackColor = SystemColors.Menu
        ButtonCONFIRMAR.FlatStyle = FlatStyle.Flat
        ButtonCONFIRMAR.Font = New Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonCONFIRMAR.Location = New Point(369, 334)
        ButtonCONFIRMAR.Name = "ButtonCONFIRMAR"
        ButtonCONFIRMAR.Size = New Size(113, 36)
        ButtonCONFIRMAR.TabIndex = 7
        ButtonCONFIRMAR.Text = "CONFIRMAR"
        ButtonCONFIRMAR.UseVisualStyleBackColor = True
        ' 
        ' ButtonCANCELAR
        ' 
        ButtonCANCELAR.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonCANCELAR.Cursor = Cursors.Hand
        ButtonCANCELAR.FlatAppearance.BorderColor = Color.Red
        ButtonCANCELAR.FlatAppearance.BorderSize = 2
        ButtonCANCELAR.FlatAppearance.MouseDownBackColor = SystemColors.Menu
        ButtonCANCELAR.FlatAppearance.MouseOverBackColor = SystemColors.Menu
        ButtonCANCELAR.FlatStyle = FlatStyle.Flat
        ButtonCANCELAR.Font = New Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonCANCELAR.Location = New Point(488, 334)
        ButtonCANCELAR.Name = "ButtonCANCELAR"
        ButtonCANCELAR.Size = New Size(113, 36)
        ButtonCANCELAR.TabIndex = 8
        ButtonCANCELAR.Text = "CANCELAR"
        ButtonCANCELAR.UseVisualStyleBackColor = True
        ' 
        ' ButtonFECHAR
        ' 
        ButtonFECHAR.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ButtonFECHAR.Cursor = Cursors.Hand
        ButtonFECHAR.FlatAppearance.BorderColor = SystemColors.ScrollBar
        ButtonFECHAR.FlatAppearance.BorderSize = 2
        ButtonFECHAR.FlatAppearance.MouseDownBackColor = SystemColors.Menu
        ButtonFECHAR.FlatAppearance.MouseOverBackColor = SystemColors.Menu
        ButtonFECHAR.FlatStyle = FlatStyle.Flat
        ButtonFECHAR.Font = New Font("Bahnschrift", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonFECHAR.Location = New Point(607, 334)
        ButtonFECHAR.Name = "ButtonFECHAR"
        ButtonFECHAR.Size = New Size(113, 36)
        ButtonFECHAR.TabIndex = 9
        ButtonFECHAR.Text = "FECHAR"
        ButtonFECHAR.UseVisualStyleBackColor = True
        ' 
        ' TextBoxOBS
        ' 
        TextBoxOBS.Anchor = AnchorStyles.Bottom
        TextBoxOBS.BorderStyle = BorderStyle.FixedSingle
        TextBoxOBS.Cursor = Cursors.IBeam
        TextBoxOBS.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxOBS.Location = New Point(3, 347)
        TextBoxOBS.Name = "TextBoxOBS"
        TextBoxOBS.Size = New Size(360, 23)
        TextBoxOBS.TabIndex = 6
        TextBoxOBS.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label12
        ' 
        Label12.Anchor = AnchorStyles.Bottom
        Label12.BackColor = SystemColors.Window
        Label12.FlatStyle = FlatStyle.Flat
        Label12.Font = New Font("Bahnschrift", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(3, 334)
        Label12.Name = "Label12"
        Label12.Size = New Size(360, 13)
        Label12.TabIndex = 12
        Label12.Text = "OBSERVAÇÃO!"
        Label12.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' INCLUIR_ALTERAR_EXCLUIR
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = SystemColors.Window
        ClientSize = New Size(733, 375)
        Controls.Add(TextBoxOBS)
        Controls.Add(ButtonFECHAR)
        Controls.Add(Label12)
        Controls.Add(ButtonCANCELAR)
        Controls.Add(ButtonCONFIRMAR)
        Controls.Add(PanelPAGAMENTO)
        Controls.Add(PanelVALORTOTAL)
        Controls.Add(PanelDESCONTO)
        Controls.Add(PoisonDataGridViewPROCURAPRODUTOS)
        Controls.Add(TextBoxVENDEDOR)
        Controls.Add(TextBoxCODVENDEDOR)
        Controls.Add(TextBoxNOMECLIENTE)
        Controls.Add(TextBoxCODCLIENTE)
        Controls.Add(TextBoxDATA)
        Controls.Add(TextBoxCOD)
        Controls.Add(PanelCABECALHO)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "INCLUIR_ALTERAR_EXCLUIR"
        StartPosition = FormStartPosition.CenterParent
        Text = "0"
        PanelCABECALHO.ResumeLayout(False)
        CType(PoisonDataGridViewPROCURAPRODUTOS, ComponentModel.ISupportInitialize).EndInit()
        PanelDESCONTO.ResumeLayout(False)
        PanelDESCONTO.PerformLayout()
        PanelVALORTOTAL.ResumeLayout(False)
        PanelVALORTOTAL.PerformLayout()
        PanelPAGAMENTO.ResumeLayout(False)
        PanelPAGAMENTO.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxCOD As TextBox
    Friend WithEvents TextBoxDATA As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxCODCLIENTE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxNOMECLIENTE As TextBox
    Friend WithEvents TextBoxVENDEDOR As TextBox
    Friend WithEvents TextBoxCODVENDEDOR As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents PanelCABECALHO As Panel
    Friend WithEvents PoisonDataGridViewPROCURAPRODUTOS As ReaLTaiizor.Controls.PoisonDataGridView
    Friend WithEvents PanelDESCONTO As Panel
    Friend WithEvents TextBoxDESCONTOREAL As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxDESCONTOPORCENT As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PanelVALORTOTAL As Panel
    Friend WithEvents TextBoxVALORITENS As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBoxVALORTOTAL As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents PanelPAGAMENTO As Panel
    Friend WithEvents TextBoxNOMEPAGAMENTO As TextBox
    Friend WithEvents TextBoxCODPAGAMENTO As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ButtonCONFIRMAR As Button
    Friend WithEvents ButtonCANCELAR As Button
    Friend WithEvents ButtonFECHAR As Button
    Friend WithEvents TextBoxOBS As TextBox
    Friend WithEvents Label12 As Label
End Class
