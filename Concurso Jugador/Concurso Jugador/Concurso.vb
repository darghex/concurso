Public Class Concurso
    Private equipo As Int16
    Private evento As Int16
    Dim db As New db
    Public Sub New(ByVal e As Int16, ByVal ev As Int16)

        Me.InitializeComponent()
        Me.equipo = e
        Me.evento = ev
    End Sub
    Dim preguntaactiva As Int64
    Private Sub Concurso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Olimpiadas Saber. Equipo : " & db.getvalue("select nombre from equipos where id=" & equipo)


        Me.Button4.Enabled = False
        Me.Button3.Enabled = False
        Me.Button2.Enabled = False
        Me.Button1.Enabled = False
    End Sub
    Dim reloj As Int16

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click
        Me.reloj = 60 - Me.reloj
        Me.Button4.Enabled = False
        Me.Button3.Enabled = False
        Me.Button2.Enabled = False
        Me.Button1.Enabled = False
        Dim op As Char
        op = DirectCast(sender, Button).Text
        Dim cnt As Int16 = db.getvalue("select count(*) from preguntas where rpt='" & op & "' and id=" & Me.preguntaactiva)
        Dim campos(1) As String
        Dim values(1) As String
        campos(0) = "Correctas"
        campos(1) = "tiempo"
        values(0) = "correctas + " & cnt
        values(1) = " tiempo + " & Me.reloj
        db.update("det_eventos_equipos", campos, values, "equipos_id=" & Me.equipo & " and evento_id=" & Me.evento)
        Me.reloj = 60
        Me.Timer2.Enabled = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim y As Int64
            Try
                y = (New db).getvalue("select id from preguntas where status=2")
            Catch ex As Exception
                Me.Button4.Enabled = False
                Me.Button3.Enabled = False
                Me.Button2.Enabled = False
                Me.Button1.Enabled = False
                Me.Timer2.Enabled = False
                Me.reloj = 60
                Exit Sub
            End Try
            Try
                If y <> Me.preguntaactiva Then
                    Me.Button4.Enabled = True
                    Me.Button3.Enabled = True
                    Me.Button2.Enabled = True
                    Me.Button1.Enabled = True
                    Me.Timer2.Enabled = True
                    Me.preguntaactiva = y
                    Me.reloj = 60
                End If
                db.open()
                Dim lector As MySql.Data.MySqlClient.MySqlDataReader
                lector = db.fetch("Select pregunta,op1,op2,op3,op4 from preguntas where status=2")
                While lector.Read
                    Me.TextBox1.Text = (New utils).DecryptData(lector.GetValue(1))
                    Me.TextBox2.Text = (New utils).DecryptData(lector.GetValue(2))
                    Me.TextBox3.Text = (New utils).DecryptData(lector.GetValue(3))
                    Me.TextBox4.Text = (New utils).DecryptData(lector.GetValue(4))
                    Me.TextBox5.Text = (New utils).DecryptData(lector.GetValue(0))
                End While
                lector.Close()
                db.close()
            Catch ex As Exception
            End Try

            Catch ex As Exception

            End Try

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try

            Me.Label1.Text = " Tiempo Restante  " & Me.reloj & " Segundos"
         
            Me.reloj -= 1
            If reloj < 0 Then
                Me.Timer2.Enabled = False
                Me.Button4.Enabled = False
                Me.Button3.Enabled = False
                Me.Button2.Enabled = False
                Me.Button1.Enabled = False
                Dim campos(0) As String
                Dim values(0) As String
                '  campos(0) = "Correctas"
                campos(0) = "tiempo"
                '  values(1) = "correctas + " & cnt
                values(0) = " tiempo + " & 60
                db.update("det_eventos_equipos", campos, values, "equipos_id=" & Me.equipo & " and evento_id=" & Me.evento)
                Timer2.Enabled = False
                Me.reloj = 60
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class