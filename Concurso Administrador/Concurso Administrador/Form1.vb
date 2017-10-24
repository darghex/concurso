Imports System.IO
Public Class Form1
    Dim db As db
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            db = New db
        Catch ex As Exception
            MsgBox("Archivo config no encontrado por favor configure su conexion")
            Dim p As New DBAccess
            p.ShowDialog()
            '    DBAccess.ShowDialog()
            'Me.Form1_Load(sender, e)
            Exit Sub
        End Try
        Me.fillpreguntas()
        Me.fillequipos()
        Try
            eventoactivo = db.getvalue("select id from evento where status=1")
        Catch ex As Exception
        End Try
        Try
            Me.Label1.Text = db.getvalue("select nombre from evento where status=1")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            MsgBox("Los archivos deben estar en formato .csv separados por ; , el orden es el siguiente: 1 pregunta,2 opcion 1,3 opcion 2 ,4 opcion 3, 5 opcion 5,6 repuestas (a,b,c,d)")
            Dim files As New OpenFileDialog
            Dim file As String
            files.ShowDialog()
            file = files.FileName
            db.query("delete from preguntas")
            db.query("ALTER TABLE `preguntas`  AUTO_INCREMENT =1")

            Dim lector As StreamReader
            lector = New StreamReader(file)
            Dim cad As String = lector.ReadLine.ToUpper
            While cad <> ""
                Dim values() As String = cad.Split(";")
                For a As Integer = 0 To values.Length - 2
                    values(a) = (New utils).EncryptData(values(a))
                Next
                Dim campos(5) As String
                campos(0) = "Pregunta"
                campos(1) = "op1"
                campos(2) = "op2"
                campos(3) = "op3"
                campos(4) = "op4"
                campos(5) = "rpt"
                Try
                    db.insert("preguntas", campos, values)
                Catch ex As Exception
                End Try
                Try
                    cad = lector.ReadLine.ToUpper
                Catch ex As Exception
                    Exit While
                End Try
            End While
            lector.Close()
            fillpreguntas()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub fillpreguntas()
        Try
            Me.DataGridView1.Rows.Clear()
            Dim lector As MySql.Data.MySqlClient.MySqlDataReader
            db.open()
            lector = db.fetch("select pregunta,op1,op2,op3,op4 from preguntas where status=1")
            While lector.Read
                Dim y(4) As Object
                For a As Integer = 0 To 4
                    y(a) = (New utils).DecryptData(lector.GetValue(a))
                Next
                Me.DataGridView1.Rows.Add(y)
            End While
            lector.Close()
            db.close()

        Catch ex As Exception

        End Try
           End Sub
    Public Sub fillequipos()
        Try
            Me.ListBox1.Items.Clear()
            Me.CheckedListBox1.Items.Clear()
            Me.DataGridView2.Rows.Clear()
            db.open()
            Dim lector As MySql.Data.MySqlClient.MySqlDataReader
            lector = db.fetch("select nombre from equipos")
            While lector.Read
                Dim y(0) As Object
                y(0) = lector.GetValue(0)
                Me.CheckedListBox1.Items.Add(y(0))
                Me.DataGridView2.Rows.Add(y)
            End While
            lector.Close()
            db.close()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim a As Integer
            Try
                a = Convert.ToInt16(InputBox("Digite la cantidad de grupos a participar"))
            Catch ex As Exception
            End Try
            db.query("delete from equipos")
            db.query("ALTER TABLE `equipos`  AUTO_INCREMENT =1")
            For b As Integer = 1 To a
                Dim nombre As String = InputBox("Digite el nombre para el grupo #" & b)
                db.query("insert into equipos (nombre) values ('" & nombre & "')")
            Next
            Me.fillequipos()
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        db.query("update evento set status=2")
        Dim nombre As String = InputBox("Digite el nombre del evento").ToUpper
        db.query("insert into evento (nombre,status) values ('" & nombre & "','1')")
        Me.Label1.Text = nombre
    End Sub
    Public Sub setevento()
        Me.Label1.Text = db.getvalue("select nombre from evento where status=1")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            db.query("delete from det_eventos_equipos")
            eventoactivo = db.getvalue("select id from evento where status=1")
            Dim campos(1) As String, values(1) As String
            campos(1) = "equipos_id"
            campos(0) = "evento_id"
            Try
                For a As Int16 = 0 To Me.CheckedListBox1.CheckedItems.Count - 1
                    Dim p As Int16 = Me.CheckedListBox1.CheckedIndices(a)
                    values(0) = eventoactivo
                    values(1) = p + 1
                    db.insert("det_eventos_equipos", campos, values)
                Next
            Catch ex As Exception
            End Try
            Me.Timer1.Enabled = True
        Catch ex As Exception
        End Try
    End Sub
    Dim eventoactivo As Int16
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            eventoactivo = db.getvalue("select id from evento where status=1")
            Me.ListBox1.Items.Clear()
            db.open()
            Dim lector As MySql.Data.MySqlClient.MySqlDataReader
            lector = db.fetch("select e.nombre,d.correctas,d.tiempo from det_eventos_equipos as d, equipos as e where d.evento_id=" & eventoactivo & " and e.id=d.equipos_id order by correctas desc,tiempo asc")
            While lector.Read
                Me.ListBox1.Items.Add(lector.GetValue(0) & " - " & lector.GetValue(1) & " - " & lector.GetValue(2))
            End While
            lector.Close()
            db.close()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim lector As MySql.Data.MySqlClient.MySqlDataReader
            db.query("update preguntas set status=3 where status=2")
            db.open()
            lector = db.fetch("select id from preguntas where status=1")
            Dim vars() As Int64
            While lector.Read
                Dim c As Int16 = 0
                If vars Is Nothing Then
                    ReDim vars(c)
                Else
                    c = vars.Length
                    ReDim Preserve vars(c)
                End If
                vars(c) = lector.GetValue(0)
            End While
            lector.Close()
            Dim sel As Int64
            Dim u As New Random
            Randomize()
            sel = u.Next(0, vars.Length - 1)
            db.query("update preguntas set status=2 where id=" & vars(sel))
            Me.fillpreguntas()
            reloj = 0
            activarreloj()
        Catch ex As Exception

        End Try
        
    End Sub
    Dim reloj As Int16
    Private Sub activarreloj()
        Try
            reloj = 0
            Me.Timer2.Enabled = True
            db.open()
            Dim lector As MySql.Data.MySqlClient.MySqlDataReader
            lector = db.fetch("select pregunta,op1,op2,op3,op4 from preguntas where status=2")
            While lector.Read
                Me.TextBox1.Text = (New utils).DecryptData(lector.GetValue(0))
                Me.TextBox2.Text = (New utils).DecryptData(lector.GetValue(1))
                Me.TextBox3.Text = (New utils).DecryptData(lector.GetValue(2))
                Me.TextBox4.Text = (New utils).DecryptData(lector.GetValue(3))
                Me.TextBox5.Text = (New utils).DecryptData(lector.GetValue(4))
            End While
            lector.Close()
            db.close()
        Catch ex As Exception

        End Try
        
    End Sub
    '   Public Sub activarreloj()

    '  End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.Label9.Text = " Tiempo Transcurrido " & reloj & " segundos"
        Me.reloj += 1
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        db.query("update preguntas set status=3 where status=2")
        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.TextBox3.Clear()
        Me.TextBox4.Clear()
        Me.TextBox5.Clear()
        Me.reloj = 0
        Me.Timer2.Enabled = False
    End Sub
End Class
