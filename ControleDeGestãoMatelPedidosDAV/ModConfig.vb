Public Module ModConfig

    ' Caminho base do servidor
    Public ReadOnly CaminhoServidor As String = "\\srv\Arquivos totais\SayTech_Matel"
    Public ReadOnly CaminhoEstoque As String = CaminhoServidor & "\ESTOQUE_MATEL.xlsx"
    Public ReadOnly CaminhoCredentials As String = CaminhoServidor & "\credentials.json"
    Public ReadOnly CaminhoToken As String = "C:\SayTech_Matel\token"

    ' Conexão MariaDB
    Public ReadOnly StringConexao As String = "Server=192.168.3.33;Port=3306;Database=controle_matel;Uid=root;Pwd=92737148;"

End Module