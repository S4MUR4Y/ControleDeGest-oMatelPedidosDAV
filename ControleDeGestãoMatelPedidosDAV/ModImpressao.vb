Imports System.Drawing
Imports System.Drawing.Printing
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports Rectangle = iTextSharp.text.Rectangle
Public Module ModImpressao

    Private _dadosDAV As Dictionary(Of String, String)
    Private _itensDAV As List(Of Dictionary(Of String, String))


    ' ══════════════════════════════════════
    ' HELPERS PDF
    ' ══════════════════════════════════════
    Private Function CriarCelula(texto As String, fonte As iTextSharp.text.Font,
                                  Optional colspan As Integer = 1,
                                  Optional alinhamento As Integer = Element.ALIGN_LEFT) As PdfPCell
        Dim cell As New PdfPCell(New Phrase(texto, fonte)) With {
            .Border = Rectangle.BOX,
            .Colspan = colspan,
            .HorizontalAlignment = alinhamento,
            .Padding = 3
        }
        Return cell
    End Function

    Private Function CriarCelulaTotais(texto As String, fonte As iTextSharp.text.Font) As PdfPCell
        Dim cell As New PdfPCell(New Phrase(texto, fonte)) With {
            .Border = Rectangle.NO_BORDER,
            .HorizontalAlignment = Element.ALIGN_RIGHT,
            .Padding = 2
        }
        Return cell
    End Function

    ' ══════════════════════════════════════
    ' ROMANEIO TÉRMICO
    ' ══════════════════════════════════════
    Public Sub ImprimirRomaneio(dadosDAV As Dictionary(Of String, String),
                                itensDAV As List(Of Dictionary(Of String, String)))
        _dadosDAV = dadosDAV
        _itensDAV = itensDAV

        Dim pd As New PrintDocument()
        pd.PrinterSettings.PrinterName = "ELGIN I8"
        pd.DefaultPageSettings.PaperSize = New PaperSize("Custom", 315, 1000)
        pd.DefaultPageSettings.Margins = New Margins(10, 10, 10, 10)

        AddHandler pd.PrintPage, AddressOf DesenharRomaneio
        pd.Print()
    End Sub

    Private Sub DesenharRomaneio(sender As Object, e As PrintPageEventArgs)
        Dim g = e.Graphics
        Dim x = 10
        Dim y = 10
        Dim largura = 295

        Dim fntNormal = New System.Drawing.Font("Courier New", 8, FontStyle.Regular)
        Dim fntBold = New System.Drawing.Font("Courier New", 8, FontStyle.Bold)
        Dim fntGrande = New System.Drawing.Font("Courier New", 11, FontStyle.Bold)
        Dim fntPequena = New System.Drawing.Font("Courier New", 7, FontStyle.Regular)
        Dim brush = Brushes.Black
        Dim sf = New StringFormat() With {.Alignment = StringAlignment.Center}
        Dim sfDir = New StringFormat() With {.Alignment = StringAlignment.Near}

        g.DrawString(DateTime.Now.ToString("dd/MM/yy HH:mm:ss"), fntNormal, brush,
            New RectangleF(x, y, largura, 20), sf)
        y += 20

        g.DrawString("ROMANEIO DE VENDA", fntBold, brush,
            New RectangleF(x, y, largura, 20), sf)
        y += 25

        g.DrawString(New String("-"c, 42), fntPequena, brush,
            New RectangleF(x, y, largura, 15), sf)
        y += 15

        g.DrawString("DAV N° " & _dadosDAV("CODIGO"), fntGrande, brush,
            New RectangleF(x, y, largura, 25), sf)
        y += 30

        g.DrawString("Valor Total " & _dadosDAV("TOTAL_GERAL"), fntGrande, brush,
            New RectangleF(x, y, largura, 25), sf)
        y += 30

        g.DrawString("VENDEDOR: " & _dadosDAV("NOME_VENDEDOR"), fntBold, brush,
            New RectangleF(x, y, largura, 20), sf)
        y += 25

        g.DrawString(New String("-"c, 42), fntPequena, brush,
            New RectangleF(x, y, largura, 15), sf)
        y += 15

        g.DrawString("Condição de Pagamento", fntNormal, brush,
            New RectangleF(x, y, largura, 20), sf)
        y += 20

        g.DrawString(_dadosDAV("NOME_PAGAMENTO"), fntBold, brush,
            New RectangleF(x, y, largura, 20), sf)
        y += 30

        g.DrawString("Obs: " & New String("_"c, 28), fntNormal, brush,
            New RectangleF(x, y, largura, 20), sfDir)

        e.HasMorePages = False
    End Sub

    ' ══════════════════════════════════════
    ' DAV EM PDF
    ' ══════════════════════════════════════
    Public Sub GerarDAVPDF(dadosDAV As Dictionary(Of String, String),
                            itensDAV As List(Of Dictionary(Of String, String)))
        Try
            Dim tempPath = Path.Combine(Path.GetTempPath(), "DAV_" & dadosDAV("CODIGO") & ".pdf")
            Dim logoPath = "\\srv\Arquivos totais\SayTech_Matel\LOGO MATEL\LOGOMATEL.png"

            Dim doc As New Document(PageSize.A4, 20, 20, 20, 20)
            Dim writer = PdfWriter.GetInstance(doc, New FileStream(tempPath, FileMode.Create))
            doc.Open()

            Dim fntNormal = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL)
            Dim fntBold = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD)
            Dim fntGrande = New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD)

            ' ── Cabeçalho ──
            Dim tblCabecalho As New PdfPTable(3)
            tblCabecalho.WidthPercentage = 100
            tblCabecalho.SetWidths(New Single() {15, 60, 25})

            If File.Exists(logoPath) Then
                Dim logo = iTextSharp.text.Image.GetInstance(logoPath)
                logo.ScaleToFit(80, 40)
                Dim cellLogo As New PdfPCell(logo) With {
                    .Border = Rectangle.BOX,
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .VerticalAlignment = Element.ALIGN_MIDDLE,
                    .Padding = 3
                }
                tblCabecalho.AddCell(cellLogo)
            Else
                tblCabecalho.AddCell(New PdfPCell(New Phrase("", fntNormal)))
            End If

            Dim empresaPhrase As New Phrase()
            empresaPhrase.Add(New Chunk("MATEL MATERIAIS ELETRICOS EIRELI ME" & Chr(10), fntBold))
            empresaPhrase.Add(New Chunk("TeleFax: (OX28)3532-2325" & Chr(10), fntNormal))
            empresaPhrase.Add(New Chunk("00.309.988/0001-75", fntNormal))
            Dim cellEmpresa As New PdfPCell(empresaPhrase) With {
                .Border = Rectangle.BOX,
                .HorizontalAlignment = Element.ALIGN_LEFT,
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .Padding = 4
            }
            tblCabecalho.AddCell(cellEmpresa)

            Dim orcPhrase As New Phrase()
            orcPhrase.Add(New Chunk("Orçamento" & Chr(10), fntNormal))
            orcPhrase.Add(New Chunk("N° " & dadosDAV("CODIGO") & Chr(10), fntBold))
            orcPhrase.Add(New Chunk(dadosDAV("EMISSAO"), fntNormal))
            Dim cellOrc As New PdfPCell(orcPhrase) With {
                .Border = Rectangle.BOX,
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .VerticalAlignment = Element.ALIGN_MIDDLE,
                .Padding = 4
            }
            tblCabecalho.AddCell(cellOrc)
            doc.Add(tblCabecalho)

            ' ── Dados do Cliente ──
            Dim tblCliente As New PdfPTable(3)
            tblCliente.WidthPercentage = 100
            tblCliente.SpacingBefore = 2
            tblCliente.SetWidths(New Single() {40, 30, 30})

            tblCliente.AddCell(CriarCelula("Cliente: " & dadosDAV("COD_CLIENTE") & "-" & dadosDAV("NOME_CLIENTE"), fntNormal, 2))
            tblCliente.AddCell(CriarCelula("Bairro:", fntNormal))
            tblCliente.AddCell(CriarCelula("Endereço:", fntNormal, 2))
            tblCliente.AddCell(CriarCelula("CEP: 00.000-000", fntNormal))
            tblCliente.AddCell(CriarCelula("Cidade: MARATAIZES-ES", fntNormal))
            tblCliente.AddCell(CriarCelula("Fone: (0XX0)0000-0000", fntNormal))
            tblCliente.AddCell(CriarCelula("F.Pgto: " & dadosDAV("NOME_PAGAMENTO"), fntNormal))
            tblCliente.AddCell(CriarCelula("CNPJ/CPF:", fntNormal))
            tblCliente.AddCell(CriarCelula("Condição: A VISTA " & dadosDAV("NOME_PAGAMENTO"), fntNormal))
            tblCliente.AddCell(CriarCelula("", fntNormal))
            tblCliente.AddCell(CriarCelula("Inscrição: ISENTO", fntNormal))
            tblCliente.AddCell(CriarCelula("Contato:", fntNormal))
            tblCliente.AddCell(CriarCelula("", fntNormal))
            tblCliente.AddCell(CriarCelula("Vendedor: " & dadosDAV("COD_VENDEDOR") & "-" & dadosDAV("NOME_VENDEDOR"), fntNormal, 3))
            doc.Add(tblCliente)

            ' ── Observação ──
            Dim tblObs As New PdfPTable(1)
            tblObs.WidthPercentage = 100
            tblObs.SpacingBefore = 2
            tblObs.AddCell(CriarCelula("Observação: " & dadosDAV("OBS"), fntNormal))
            doc.Add(tblObs)

            ' ── Mensagem ──
            Dim tblMsg As New PdfPTable(1)
            tblMsg.WidthPercentage = 100
            tblMsg.SpacingBefore = 2
            tblMsg.AddCell(CriarCelula("Mensagem: ATENCAO! VALIDADE DA PROPOSTA 3 DIAS", fntBold))
            doc.Add(tblMsg)

            ' ── Itens ──
            Dim tblItens As New PdfPTable(5)
            tblItens.WidthPercentage = 100
            tblItens.SpacingBefore = 2
            tblItens.SetWidths(New Single() {12, 18, 50, 10, 10})

            For Each h In {"Código", "Referência", "Descrição", "Un.", "Quant."}
                Dim cellH As New PdfPCell(New Phrase(h, fntBold)) With {
                    .BackgroundColor = New BaseColor(240, 240, 240),
                    .Border = Rectangle.BOX,
                    .Padding = 3,
                    .HorizontalAlignment = Element.ALIGN_CENTER
                }
                tblItens.AddCell(cellH)
            Next

            For Each item In itensDAV
                tblItens.AddCell(CriarCelula(item("CODIGO"), fntNormal))
                tblItens.AddCell(CriarCelula(item("REFERENCIA"), fntNormal))
                tblItens.AddCell(CriarCelula(item("NOME"), fntNormal))
                tblItens.AddCell(CriarCelula("UN", fntNormal, 1, Element.ALIGN_CENTER))
                tblItens.AddCell(CriarCelula(item("QTDE"), fntNormal, 1, Element.ALIGN_CENTER))
            Next
            doc.Add(tblItens)

            ' ── Totais ──
            Dim tblTotais As New PdfPTable(2)
            tblTotais.WidthPercentage = 50
            tblTotais.HorizontalAlignment = Element.ALIGN_RIGHT
            tblTotais.SpacingBefore = 4
            tblTotais.SetWidths(New Single() {60, 40})

            tblTotais.AddCell(CriarCelulaTotais("Total Produtos ==>", fntNormal))
            tblTotais.AddCell(CriarCelulaTotais(dadosDAV("TOTAL_PRODUTOS"), fntNormal))
            tblTotais.AddCell(CriarCelulaTotais("Desc($) ==>", fntNormal))
            tblTotais.AddCell(CriarCelulaTotais(dadosDAV("VALOR_DESC"), fntNormal))
            tblTotais.AddCell(CriarCelulaTotais("Total Geral ==>", fntBold))
            tblTotais.AddCell(CriarCelulaTotais(dadosDAV("TOTAL_GERAL"), fntBold))
            doc.Add(tblTotais)

            ' ── Assinatura ──
            Dim tblAssinatura As New PdfPTable(1)
            tblAssinatura.WidthPercentage = 40
            tblAssinatura.HorizontalAlignment = Element.ALIGN_LEFT
            tblAssinatura.SpacingBefore = 30
            Dim cellAssin As New PdfPCell(New Phrase("Assinatura Cliente", fntNormal)) With {
                .Border = Rectangle.TOP_BORDER,
                .HorizontalAlignment = Element.ALIGN_CENTER,
                .Padding = 4
            }
            tblAssinatura.AddCell(cellAssin)
            doc.Add(tblAssinatura)

            doc.Close()

            Process.Start(New ProcessStartInfo(tempPath) With {.UseShellExecute = True})

        Catch ex As Exception
            MessageBox.Show("Erro ao gerar PDF: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module