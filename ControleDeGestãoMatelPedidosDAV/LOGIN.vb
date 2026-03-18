Imports System.Threading.Tasks

Public Class LOGIN
    Private Sub LOGIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carrega usuário e senha salvos
        If Not String.IsNullOrEmpty(My.Settings.UsuarioSalvo) Then
            PoisonTextBoxLOGIN.Text = My.Settings.UsuarioSalvo
            PoisonTextBoxSENHA.Text = My.Settings.SenhaSalva
        End If
    End Sub
    Private Async Sub PoisonButtonACESSAR_Click(sender As Object, e As EventArgs) Handles PoisonButtonACESSAR.Click

        Dim login As String = PoisonTextBoxLOGIN.Text.Trim().ToUpper()
        Dim senha As String = PoisonTextBoxSENHA.Text.Trim()

        ' Validação básica
        If String.IsNullOrEmpty(login) OrElse String.IsNullOrEmpty(senha) Then
            LabelPROGRESSO.Text = "Preencha login e senha!"
            Return
        End If

        ' Desabilita o botão durante a verificação
        PoisonButtonACESSAR.Enabled = False
        LabelPROGRESSO.Text = "Conectando ao servidor..."
        PoisonProgressBarPROGRESSO.Value = 10

        Try
            ' Roda em background para não travar a UI
            Dim resultado = Await Task.Run(Function() VerificarLogin(login, senha))

            Select Case resultado
                Case "OK"

                    ' Salva usuário e senha na máquina
                    My.Settings.UsuarioSalvo = PoisonTextBoxLOGIN.Text
                    My.Settings.SenhaSalva = PoisonTextBoxSENHA.Text
                    My.Settings.Save()

                    PoisonProgressBarPROGRESSO.Value = 80
                    LabelPROGRESSO.Text = "Carregando sistema..."
                    Await Task.Delay(800) ' Pequena pausa visual
                    PoisonProgressBarPROGRESSO.Value = 100
                    Me.Hide()
                    Dim menu As New MENU()
                    menu.Show()

                Case "SENHA_ERRADA"
                    PoisonProgressBarPROGRESSO.Value = 0
                    LabelPROGRESSO.Text = "Senha incorreta! Tente novamente."

                Case "LOGIN_NAO_ENCONTRADO"
                    PoisonProgressBarPROGRESSO.Value = 0
                    LabelPROGRESSO.Text = "Usuário não encontrado!"

                Case "EMPRESA_INATIVA"
                    PoisonProgressBarPROGRESSO.Value = 0
                    LabelPROGRESSO.Text = "Sistema inativo. Contate o suporte."

                Case Else
                    PoisonProgressBarPROGRESSO.Value = 0
                    LabelPROGRESSO.Text = "Erro ao conectar. Verifique a internet."
            End Select

        Catch ex As Exception
            PoisonProgressBarPROGRESSO.Value = 0
            LabelPROGRESSO.Text = "Erro: " & ex.Message
        Finally
            PoisonButtonACESSAR.Enabled = True
        End Try

    End Sub

    ''' <summary>Verifica login na planilha e retorna código de resultado</summary>
    Private Function VerificarLogin(login As String, senha As String) As String

        ' ── 1. Verifica se a empresa está ativa ──
        Dim dadosEmpresa = ModGoogleSheets.LerPlanilha("EMPRESA!A2:B2")
        If dadosEmpresa Is Nothing OrElse dadosEmpresa.Count = 0 Then
            Return "ERRO_EMPRESA"
        End If

        Dim status = dadosEmpresa(0)(1).ToString().Trim().ToUpper()
        If status <> "ATIVA" Then
            Return "EMPRESA_INATIVA"
        End If

        ' ── 2. Busca usuários e valida login/senha ──
        Dim dadosUsuarios = ModGoogleSheets.LerPlanilha("USUARIOS!A2:B100")
        If dadosUsuarios Is Nothing OrElse dadosUsuarios.Count = 0 Then
            Return "LOGIN_NAO_ENCONTRADO"
        End If

        For Each linha In dadosUsuarios
            If linha.Count >= 2 Then
                Dim loginPlanilha = linha(0).ToString().Trim().ToUpper()
                Dim senhaPlanilha = linha(1).ToString().Trim()

                If loginPlanilha = login Then
                    If senhaPlanilha = senha Then
                        Return "OK"
                    Else
                        Return "SENHA_ERRADA"
                    End If
                End If
            End If
        Next

        Return "LOGIN_NAO_ENCONTRADO"
    End Function
    Private Async Function AnimarProgresso(ate As Integer) As Task
        Dim atual = PoisonProgressBarPROGRESSO.Value
        Dim passo = If(ate > atual, 1, -1)
        While atual <> ate
            atual += passo
            PoisonProgressBarPROGRESSO.Value = atual
            Await Task.Delay(10)
        End While
    End Function
    Private Sub PoisonTextBoxLOGIN_TextChanged(sender As Object, e As EventArgs) Handles PoisonTextBoxLOGIN.TextChanged
        Dim pos = PoisonTextBoxLOGIN.SelectionStart
        PoisonTextBoxLOGIN.Text = PoisonTextBoxLOGIN.Text.ToUpper()
        PoisonTextBoxLOGIN.SelectionStart = pos
    End Sub

    Private Sub ButtonTESTESERVER_Click(sender As Object, e As EventArgs) Handles ButtonTESTESERVER.Click
        Dim senha = InputBox("Digite a senha de acesso:", "Autenticação", "")

        If String.IsNullOrEmpty(senha) Then Return

        If senha <> "92737148" Then
            MessageBox.Show("Senha incorreta!", "Acesso Negado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim conn = ModDB.AbrirConexao()
            MessageBox.Show("Servidor conectado com sucesso!" & Environment.NewLine &
            "IP: 192.168.3.33" & Environment.NewLine &
            "Banco: controle_matel" & Environment.NewLine &
            "Status: Online ✔",
            "Conexão OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Falha na conexão!" & Environment.NewLine &
            "Erro: " & ex.Message,
            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
