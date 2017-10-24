Imports MySql.Data.MySqlClient
Imports System.IO
'Imports CrystalDecisions.Shared
Public Class db
    Dim cnt As MySqlConnection
    Dim cmd As MySqlCommand
    Dim reader As MySqlDataReader
    Dim sql As String
    Public Sub New()
        Dim conectionstring As String
        Dim lector As StreamReader
        lector = New StreamReader("config")
        conectionstring = (New utils).DecryptData(lector.ReadLine())
        cnt = New MySqlConnection(conectionstring)
        cmd = New MySqlCommand("", cnt)
    End Sub
    Public Sub open()
        Try
            If Me.cnt.State = ConnectionState.Closed Then
                Me.cnt.Open()
            End If
        Catch ex As Exception
            '         MsgBox("No se tiene acceso a la base de datos")
        End Try
    End Sub
    Public Sub close()
        Try
            If Me.cnt.State = ConnectionState.Open Then
                '   Me.cnt.Commit()
                Me.cnt.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function insert(ByVal tabla As String, ByVal values() As Object) As Boolean
        Try
            For a As Integer = 0 To values.Clone - 1
                values(a).ToString.ToUpper()
            Next
            sql = "insert into " & tabla & " values (" & String.Join(",", values) & ")"
            Me.execute()
        Catch ex As Exception

        End Try
    End Function
    Public Sub execute()
         Me.open()
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        Me.close()
    End Sub
    Public Function getvalue(ByVal sql As String) As Object
        Dim p As Object
        cmd.CommandText = sql
        Me.open()
        reader = cmd.ExecuteReader
        reader.Read()
        Dim value = reader.GetValue(0)
        reader.Close()
        Me.close()
        Return value
    End Function
    Public Function fetch() As MySqlDataReader
        cmd.CommandText = sql
        Return cmd.ExecuteReader
    End Function
    Public Function fetch(ByVal sql As String) As MySqlDataReader
        cmd.CommandText = sql
        Return cmd.ExecuteReader
    End Function
    Public Sub find(ByVal tabla As String, ByVal valor As String)
        sql = "Desc " & tabla
        Dim campos() As String
        Me.open()
        cmd.CommandText = sql
        Me.reader = cmd.ExecuteReader
        While Me.reader.Read
            If campos Is Nothing Then
                ReDim campos(0)
            Else
                ReDim Preserve campos(campos.Length)
            End If
            campos(campos.Length - 1) = Me.reader.GetValue(0)
        End While
        sql = "select * from " & tabla & " where "
        For a As Integer = 0 To campos.Length - 1
            If a = campos.Length - 1 Then
                sql &= campos(a) & " like '%" & valor & "%'"
            Else
                sql &= campos(a) & " like '%" & valor & "%' or "
            End If
        Next
    End Sub
    Public Sub find(ByVal tabla As String, ByVal campo As String, ByVal value As String)
        sql = "select * from " & tabla & " where " & campo & " like '%" & value & "%'"
    End Sub
    Public Sub find(ByVal tabla As String, ByVal expresion As Object)
        sql = "Select * from " & tabla & " where " & expresion
    End Sub
    Public Sub find(ByVal tabla As String, ByVal campos() As String, ByVal values As String)
        sql = "Select " & String.Join(",", campos) & " from " & tabla
        For a As Integer = 0 To campos.Length - 1
            If a = campos.Length - 1 Then
                sql &= campos(a) & " like '%" & values & "%'"
            Else
                sql &= campos(a) & " like '%" & values & "%' or "
            End If
        Next
    End Sub
    Public Sub insert(ByVal tabla As String, ByVal campos() As String, ByVal values() As String)
        sql = "insert into " & tabla & " (" & String.Join(",", campos) & ") values ('" & String.Join("','", values) & "')"
        Me.execute()
    End Sub
    Public Sub find(ByVal tabla As String, ByVal campos() As String, ByVal valor As String, ByVal camporeferente As String)
        sql = "Select " & String.Join(",", campos) & "from " & tabla & " where " & camporeferente & " like '%" & valor & "%"
    End Sub
    Public Sub update(ByVal tabla As String, ByVal campos() As String, ByVal values() As String, ByVal condition As String)
        sql = "update " & tabla & " set "
        For a As Integer = 0 To campos.Length - 1
            If a = campos.Length - 1 Then
                sql &= campos(a) & "=" & values(a)
            Else
                sql &= campos(a) & "=" & values(a) & ","
            End If
        Next
        sql &= " where " & condition
        Me.execute()
    End Sub
    Public Sub update(ByVal tabla As String, ByVal campo As String, ByVal value As String, ByVal condition As String)
        sql = "update " & tabla & " set "
        sql &= campo & "=" & value
        sql &= " where " & condition
        Me.execute()
    End Sub

    Public Sub query(ByVal sql As String)
        Me.sql = sql
        Me.execute()
    End Sub
End Class



