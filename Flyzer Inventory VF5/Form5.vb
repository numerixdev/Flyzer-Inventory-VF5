Public Class Form5
    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel1.Paint

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click
        Me.Hide()

    End Sub

    Private Sub Guna2ToggleSwitch2_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2ToggleSwitch2.CheckedChanged
        If Guna2ToggleSwitch2.Checked = True Then
            Form2.BackColor = Color.White
        End If

        If Guna2ToggleSwitch2.Checked = False Then



        End If
    End Sub

    Private Sub Guna2ToggleSwitch3_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2ToggleSwitch3.CheckedChanged

    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class