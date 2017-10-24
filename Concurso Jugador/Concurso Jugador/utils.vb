Imports System.Security.Cryptography

Public Class utils
    Private TripleDes As New System.Security.Cryptography.DESCryptoServiceProvider
    Public Function EncryptData(ByVal plaintext As String) As String
        Dim plaintextBytes() As Byte = _
            System.Text.Encoding.Unicode.GetBytes(plaintext)
        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream.
        Dim key(7) As Byte
        key(0) = 233
        key(1) = 211
        key(2) = 158
        key(3) = 159
        key(4) = 82
        key(5) = 57
        key(6) = 240
        key(7) = 130
        Dim iv(7) As Byte
        iv(0) = 67
        iv(1) = 91
        iv(2) = 49
        iv(3) = 85
        iv(4) = 248
        iv(5) = 81
        iv(6) = 190
        iv(7) = 24
        Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(key, iv), CryptoStreamMode.Write)
        'Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(semilla, contra), CryptoStreamMode.Write)
        '   System.Security.Cryptography.CryptoStreamMode.Write)
        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray)
    End Function
    Public Function DecryptData( _
    ByVal encryptedtext As String) _
    As String
        Dim key(7) As Byte
        key(0) = 233
        key(1) = 211
        key(2) = 158
        key(3) = 159
        key(4) = 82
        key(5) = 57
        key(6) = 240
        key(7) = 130
        Dim iv(7) As Byte
        iv(0) = 67
        iv(1) = 91
        iv(2) = 49
        iv(3) = 85
        iv(4) = 248
        iv(5) = 81
        iv(6) = 190
        iv(7) = 24
        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(key, iv), CryptoStreamMode.Write)
        '  TripleDes.CreateDecryptor(), _
        ' System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function

    Public Function nletras(ByVal p As Double) As String
        Dim f As Double, l As Double
        Select Case p
            Case 0
                Return "cero"
            Case 1
                Return "uno"
            Case 2
                Return "dos"
            Case 3
                Return "tres"
            Case 4
                Return "cuatro"
            Case 5
                Return "cinco"
            Case 6
                Return "seis"
            Case 7
                Return "siete"
            Case 8
                Return "ocho"
            Case 9
                Return "nueve"
            Case 10
                Return "diez"
            Case 11
                Return "once"
            Case 12
                Return "doce"
            Case 13
                Return "trece"
            Case 14
                Return "catorce"
            Case 15
                Return "quince"
            Case 16 To 19
                Return "diez y " & Me.nletras(p Mod 10)
            Case 20
                Return "veinte"
            Case 21 To 29
                Return "veinti" & Me.nletras(p Mod 10)
            Case 30
                Return "treinta"
            Case 31 To 39
                Return "treinta y " & Me.nletras(p Mod 10)
            Case 40
                Return "cuarenta"
            Case 41 To 49
                Return "cuarenta y " & Me.nletras(p Mod 10)
            Case 50
                Return "Cincuenta"
            Case 51 To 59
                Return "Cincuenta y " & Me.nletras(p Mod 10)
            Case 60
                Return "sesenta"
            Case 61 To 69
                Return "sesenta y " & Me.nletras(p Mod 10)
            Case 70
                Return "setenta"
            Case 71 To 79
                Return "setenta y " & Me.nletras(p Mod 10)
            Case 80
                Return "ochenta"
            Case 81 To 89
                Return "ochenta y " & Me.nletras(p Mod 10)
            Case 90
                Return "noventa"
            Case 91 To 99
                Return "noventa y " & Me.nletras(p Mod 10)
            Case 100
                Return "cien"
            Case 100 To 199
                Return "ciento " & Me.nletras(p Mod 100)
            Case 200
                Return "docientos"
            Case 201 To 299
                Return "doscientos " & Me.nletras(p Mod 100)
            Case 300
                Return "trescientos"
            Case 301 To 399
                Return "trescientos " & Me.nletras(p Mod 100)
            Case 400
                Return "cuatrocientos"
            Case 401 To 499
                Return "cuatrocientos " & Me.nletras(p Mod 100)
            Case 500
                Return "quinientos"
            Case 501 To 599
                Return "quinientos " & Me.nletras(p Mod 100)
            Case 600
                Return "seiscientos"
            Case 601 To 699
                Return "seiscientos " & Me.nletras(p Mod 100)
            Case 700
                Return "setecientos"
            Case 701 To 799
                Return "setecientos " & Me.nletras(p Mod 100)
            Case 800
                Return "ochocientos"
            Case 801 To 899
                Return "ochocientos " & Me.nletras(p Mod 100)
            Case 900
                Return "novecientos"
            Case 901 To 999
                Return "novecientos " & Me.nletras(p Mod 100)
            Case 1000
                Return "mil"
            Case 1001 To 1999
                Return "mil " & Me.nletras(p Mod 1000)
            Case 2000 To 999999
                f = Convert.ToInt64(p / 1000)
                Dim s As String
                s = nletras(f) & " mil "
                l = p Mod 1000
                If l <> 0 Then
                    Return s & Me.nletras(l)
                Else
                    Return s
                End If
            Case 1000000
                Return "un millon"
            Case 1000001 To 1999999
                Return "un millon " & Me.nletras(p Mod 1000000)
            Case 2000000 To 999999999999
                f = Convert.ToInt64(p / 1000000)
                Dim s As String
                s = nletras(f) & " mil "
                l = p Mod 1000000
                If l <> 0 Then
                    Return s & Me.nletras(l)
                Else
                    Return s
                End If
        End Select
        Return ""

    End Function
    Public Sub setfoto(ByVal filename As String, ByVal img As PictureBox)
        Try
            img.Image = System.Drawing.Image.FromFile(filename)
        Catch ex As Exception
        End Try
    End Sub
    Public Function numerickeypress(ByVal e As System.Windows.Forms.KeyEventArgs, ByVal sender As Object) As Boolean
        Dim asc As Integer
        asc = e.KeyCode
        Select Case asc
            Case 48 To 57, 8
                Return False
            Case Else
                Return True
        End Select
    End Function
End Class
