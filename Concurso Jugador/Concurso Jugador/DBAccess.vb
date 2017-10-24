Imports System.IO
Imports MySql.Data.MySqlClient
Public Class DBAccess

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sql As String = "server=" & Me.TextBox1.Text & ";user id=root;database=concurso"
        Try
            Dim cnt As MySqlConnection
            cnt = New MySqlConnection(sql)
            cnt.Open()
        Catch ex As Exception
            MsgBox("no se puede realizar la conexion verifique sus datos o su servidor")
            Exit Sub
        End Try
        sql = (New utils).EncryptData(sql)
        Dim writer As StreamWriter
        writer = New StreamWriter("config")
        writer.Write(sql)
        writer.Close()
        MsgBox("Se ha podido completar la operacion")
        Me.Close()
    End Sub
End Class