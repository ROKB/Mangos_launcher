Imports System.IO

Public Class Form2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Directory.Exists(My.Computer.FileSystem.CurrentDirectory & "/Cache") Then
            REM This tells the launcher to check its current directory for a folder named "Cache"
            Dim Cache As String = (My.Computer.FileSystem.CurrentDirectory & "/Cache")
            REM This tells the launcher to turn the directory location of the cache folder into a string.
            Select Case MsgBox("Do you want to delete the Cache folder?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "WARNING")
                REM This tells the launcher to display a message box with a yes and no button
                Case MsgBoxResult.Yes
                    REM What happens when you press the yes button
                    Directory.Delete(Cache, True)
                    REM Deletes the cache folder
                Case MsgBoxResult.No
                    REM Tells the launcher to do nothing if the no button is pressed
            End Select
        End If

        If Not Directory.Exists(My.Computer.FileSystem.CurrentDirectory & "/Cache") Then
            If Directory.Exists(My.Computer.FileSystem.CurrentDirectory & "/WDB") Then
                REM This tells the launcher to check its current directory for a folder named "Cache"
                Dim WDB As String = (My.Computer.FileSystem.CurrentDirectory & "/WDB")
                REM This tells the launcher to turn the directory location of the cache folder into a string.
                Select Case MsgBox("Do you want to delete the WDB folder?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "WARNING")
                    REM This tells the launcher to display a message box with a yes and no button
                    Case MsgBoxResult.Yes
                        REM What happens when you press the yes button
                        Directory.Delete(WDB, True)
                        REM Deletes the cache folder
                    Case MsgBoxResult.No
                        REM Tells the launcher to do nothing if the no button is pressed
                End Select
            End If



        End If

    End Sub
End Class