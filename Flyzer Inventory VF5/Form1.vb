Imports System.Windows

Public Class Form1
    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click



        Me.Close()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        If My.Settings.Registred = True Then
            Form2.Show()
            Me.Close()





        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click




        If Guna2TextBox1.Text = "magasin" Then
            My.Settings.Registred = True

            Form5.Show()
            Me.Hide()
        Else
            Form3.Show()
        End If





    End Sub
End Class
