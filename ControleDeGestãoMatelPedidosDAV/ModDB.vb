Imports MySql.Data.MySqlClient

Public Module ModDB

    Public Function AbrirConexao() As MySqlConnection
        Dim conn As New MySqlConnection(ModConfig.StringConexao)
        conn.Open()
        Return conn
    End Function

End Module