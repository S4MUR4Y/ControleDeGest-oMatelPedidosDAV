Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Sheets.v4
Imports Google.Apis.Sheets.v4.Data
Imports Google.Apis.Services
Imports Google.Apis.Util.Store
Imports System.IO
Imports System.Threading

Public Module ModGoogleSheets

    Private _service As SheetsService
    Public ReadOnly SpreadsheetId As String = "1h1JUIiISE83jCOK1Y3n93EQ0zAIRQCSwzIphpKTLy9o"

    Public Function GetSheetsService() As SheetsService
        If _service IsNot Nothing Then Return _service

        Dim credential As UserCredential
        Dim scopes As String() = {SheetsService.Scope.SpreadsheetsReadonly}

        Dim caminho As String = "C:\SayTech_Matel\credentials.json"

        If Not File.Exists(caminho) Then
            Throw New FileNotFoundException("Arquivo credentials.json não encontrado em: " & caminho)
        End If

        Using stream As New FileStream(caminho, FileMode.Open, FileAccess.Read)
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                scopes,
                "user",
                CancellationToken.None,
                New FileDataStore("C:\SayTech_Matel\token", True)
            ).Result
        End Using

        _service = New SheetsService(New BaseClientService.Initializer() With {
            .HttpClientInitializer = credential,
            .ApplicationName = "MATEL_MATERIAIS_ELETRICOS"
        })

        Return _service
    End Function

    ''' <summary>Lê um range da planilha e retorna lista de linhas</summary>
    Public Function LerPlanilha(range As String) As IList(Of IList(Of Object))
        Dim service = GetSheetsService()
        Dim request = service.Spreadsheets.Values.Get(SpreadsheetId, range)
        Dim response = request.Execute()
        Return response.Values
    End Function

End Module
