<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DBAccess
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtDB = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUser = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(301, 12)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(117, 20)
        Me.txtDB.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(221, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "base de datos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(243, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Clave"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(301, 41)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(117, 20)
        Me.txtPassword.TabIndex = 14
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(98, 41)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(117, 20)
        Me.txtUser.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Usuario"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(98, 12)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(117, 20)
        Me.txtServer.TabIndex = 11
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(321, 86)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Probar Conexion"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Servidor mysql"
        '
        'DBAccess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 124)
        Me.Controls.Add(Me.txtDB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Name = "DBAccess"
        Me.Text = "DBAccess"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDB As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
