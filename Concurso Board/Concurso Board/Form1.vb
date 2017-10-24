Imports MySql.Data.MySqlClient
Public Class Form1
    Dim db As db
    Dim rpt As String
    Dim preguntaactiva As Int64

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Timer1.Enabled = True
        Try
            db = New db()
            db.open()
            db.close()
        Catch ex As Exception
            Dim p As New DBAccess
            p.ShowDialog()
            Me.Form1_Load(sender, e)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim y As Int64
        Try
            Try
                y = db.getvalue("Select id from preguntas where status=2")
            Catch ex As Exception
                Exit Sub
            End Try
            If y <> preguntaactiva Then
                Me.preguntaactiva = y
                Dim lector As MySqlDataReader
                db.open()
                lector = db.fetch("Select pregunta,op1,op2,op3,op4,rpt from preguntas where status=2")
                While lector.Read
                    Me.rpt = lector.GetValue(5)
                    Me.TextBox1.Text = (New utils).DecryptData(lector.GetValue(0))
                    Me.TextBox2.Text = (New utils).DecryptData(lector.GetValue(1))
                    Me.TextBox3.Text = (New utils).DecryptData(lector.GetValue(2))
                    Me.TextBox4.Text = (New utils).DecryptData(lector.GetValue(3))
                    Me.TextBox5.Text = (New utils).DecryptData(lector.GetValue(4))
                End While
                lector.Close()
                db.close()
            End If
            Try
                Dim eventoactivo As Int16 = db.getvalue("select id from evento where status=1")
                Me.ListBox1.Items.Clear()
                db.open()
                Dim lector As MySql.Data.MySqlClient.MySqlDataReader
                lector = db.fetch("select e.nombre,d.correctas,d.tiempo from det_eventos_equipos as d, equipos as e where d.evento_id=" & eventoactivo & " and e.id=d.equipos_id order by correctas desc,tiempo asc")
                Me.ListBox1.Items.Add("EQUIPO".PadRight(15) & "CORRECTAS".PadLeft(5) & " TIEMPO(s)".PadLeft(5))
                While lector.Read
                    Me.ListBox1.Items.Add(lector.GetValue(0).ToString.PadRight(23) & lector.GetValue(1).ToString.PadRight(5) & lector.GetValue(2).ToString.PadRight(5))
                End While
                lector.Close()
                db.close()
            Catch ex As Exception

            End Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(Me.rpt)
    End Sub
End Class
