Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class Form1

    Dim Apache As New TcpClient
    Dim World As New TcpClient
    Dim Newpoint As New System.Drawing.Point
    Dim X, Y As Integer

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick

        Dim Realmlist As New IO.StreamWriter("realmlist.wtf", False)
        Realmlist.WriteLine("logon.nssgaming.com")
        Realmlist.Close()
        REM This will change the realm list

        PictureBox1.Image = My.Resources.PlayClick
        If File.Exists(My.Computer.FileSystem.CurrentDirectory & "/Wow.exe") Then
            REM This tells the launcher to check the current directory for Wow.exe
            Shell(My.Computer.FileSystem.CurrentDirectory & "/Wow.exe")
            REM If Wow.exe is found this tells the launcher to start Wow.exe
            Me.Close()
            REM This tells the launcher to close after it start Wow.exe
        Else
            MsgBox("Could not start Wow.exe", MsgBoxStyle.Critical, "Application Not Found")
            REM If Wow.exe is not found this tells the launcher to show an error message
        End If

    End Sub

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter

        PictureBox1.Image = My.Resources.PlayEnter
        REM This tells the PictureBox image to change to PlayEnter.png

    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave

        PictureBox1.Image = My.Resources.PlayLeave
        REM This tells the PictureBox image to change to PlayLeave.png

    End Sub

    Private Sub PictureBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseClick

        PictureBox2.Image = My.Resources.SupportClick
        REM This tells the PictureBox2 image to change to SupportClick.png
        Process.Start("http://wow.nssgaming.com/")
        REM This tells the launcher to open your servers website

    End Sub

    Private Sub PictureBox2_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox2.MouseEnter

        PictureBox2.Image = My.Resources.SupportEnter
        REM This tells the PictureBox2 image to change to SupportEnter.png

    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave

        PictureBox2.Image = My.Resources.SupportLeave
        REM This tells the PictureBox2 image to change to SupportLeave.png

    End Sub

    Private Sub PictureBox3_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox3.MouseClick

        PictureBox3.Image = My.Resources.OptionsClick
        REM This tells the PictureBox3 image to change to OptionsClick.png
        Form2.Show()

    End Sub

    Private Sub PictureBox3_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox3.MouseEnter

        PictureBox3.Image = My.Resources.OptionsEnter
        REM This tells the PictureBox3 image to change to OptionsEnter.png

    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave

        PictureBox3.Image = My.Resources.OptionsLeave
        REM This tells the PictureBox3 image to change to OptionsLeave.png

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            REM Tells the launcher to try to do the following
            Apache.Connect("logon.nssgaming.com", (80))
            REM Tells the launcher to connect to your servers IP address on port 80
        Catch ex As Exception
            REM Tells the launcher what to do if a connection is not made
            Label1.Visible = True
            REM Tells the launcher to make label1 visible
        End Try
        REM Tells the launcher to stop trying the above
        Try
            REM Tell the launcher to try the following
            World.Connect("logon.nssgaming.com", (8085))
            REM Tells the launcher to connect to your server IP address on port 8085
        Catch ex As Exception
            REM Tells the launcher what to do if a connection is not made
            Label3.Text = "OFFLINE"
            REM Tells the launcher to set label3's text to "OFFLINE'
            Label3.ForeColor = Color.Red
            REM Tells the launcher to set label3's forecolor to red
        End Try
        REM Tells the launcher to stop trying the above

        If Apache.Connected Then
            REM Checks if Apache is connected
            WebBrowser1.Visible = True
            REM Makes the web browser visible if Apache is connected
            WebBrowser1.Navigate("http://wow.nssgaming.com/")
            REM Navigates the web browser to http://Your Website Here/launcher/news.html
            Label1.Hide()
            REM Hides label1 from view
            Apache.Close()
            REM Closes the socket Apache was using *ALWAYS CLOSE YOUR SOCKETS
        End If
        REM Ends the above IF statement

        If World.Connected Then
            REM Checks if World is connected
            Label3.Text = "ONLINE"
            REM Changes lebel3's text to "ONLINE" if World is connected
            Label3.ForeColor = Color.Green
            REM Changes label3's fore color to green if World is connected
            World.Close()
            REM Closes the socket World was using *ALWAYS CLOSE YOUR SOCKETS
        End If
        REM Ends the above if statement

    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown

        X = Control.MousePosition.X - Me.Location.X
        Y = Control.MousePosition.Y - Me.Location.Y
        REM This will make a formbord for the top

    End Sub


    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove

        If e.Button = Windows.Forms.MouseButtons.Left Then
            Newpoint = Control.MousePosition
            Newpoint.X -= (X)
            Newpoint.Y -= (Y)
            Me.Location = Newpoint
        End If
        REM this will allow you to move the Launcer

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        Me.Close()
        REM This Close The Launcher

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

        WindowState = FormWindowState.Minimized
        REM This will minimize the launcher

    End Sub

    
End Class