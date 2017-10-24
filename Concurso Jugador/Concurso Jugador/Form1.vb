Public Class Form1
    Dim db As db
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            db = New db
            db.open()
            db.close()
        
            Dim lector As MySql.Data.MySqlClient.MySqlDataReader
            Dim eventoactivo As Int16 = db.getvalue("select id from evento where status=1")
            db.open()
            lector = db.fetch("select e.nombre from equipos as e, det_eventos_equipos as d where d.evento_id=" & eventoactivo & " and d.equipos_id=e.id")
            While lector.Read
                Me.ListBox1.Items.Add(lector.GetValue(0))
            End While
            evt = eventoactivo
            lector.Close()
        Catch ex As Exception
            DBAccess.ShowDialog()
            Me.Form1_Load(sender, e)
        End Try
    End Sub
    Dim evt As Int16
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.ListBox1.Text = "" Then
                Exit Sub
            End If
            Dim equipo As Int16
            equipo = db.getvalue("select id from equipos where nombre='" & Me.ListBox1.Text & "'")
            Dim p As New Concurso(equipo, evt)
            p.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub
End Class
