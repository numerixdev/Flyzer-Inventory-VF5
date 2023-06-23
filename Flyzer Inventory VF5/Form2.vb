Imports System.Data.Sql
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Data.SQLite

Public Class Form2

    Private dbcommand As String = ""
    Private bindingSrc As BindingSource

    Private dbName As String = "login.db;"
    Private dbPath As String = Application.StartupPath & "\" & dbName
    Private conString As String = "Data Source=" & dbPath & "Version=3;New=False;Compress=True;"

    Private connection As New SQLiteConnection(conString)
    Private command As New SQLiteCommand("", connection)

    Private sql As String = ""

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        connection.Open()

        UpdateDataBiding()

        connection.Close()



        Guna2DateTimePicker1.Format = DateTimePickerFormat.Custom
        Guna2DateTimePicker1.CustomFormat = "dd/MM/yy"



        If Guna2DateTimePicker1.Value = Guna2TextBox4.Text Then


        End If























    End Sub

    Private Sub UpdateDataBiding(Optional cmd As SQLiteCommand = Nothing)

        Try

            If cmd Is Nothing Then
                command.CommandText = "SELECT * FROM login ORDER BY AutoID ASC"

            Else
                command = cmd
            End If

            Dim adapter As New SQLiteDataAdapter(command)
            Dim dataSt As New DataSet()
            adapter.Fill(dataSt, "login")

            bindingSrc = New BindingSource
            bindingSrc.DataSource = dataSt.Tables("login")

            Dim tb As TextBox
            For Each ctr As Control In Guna2GroupBox1.Controls
                If TypeOf ctr Is TextBox Then
                    tb = CType(ctr, TextBox)
                    tb.DataBindings.Clear()
                    tb.Text = ""
                End If
            Next

            Me.Guna2TextBox1.DataBindings.Clear()
            Guna2TextBox1.DataBindings.Add(New Binding("Text", bindingSrc, "AutoID"))
            Me.Guna2TextBox2.DataBindings.Clear()
            Guna2TextBox2.DataBindings.Add(New Binding("Text", bindingSrc, "fournisseur"))
            Me.Guna2TextBox3.DataBindings.Clear()
            Guna2TextBox3.DataBindings.Add(New Binding("Text", bindingSrc, "Numerodelot"))
            Me.Guna2TextBox4.DataBindings.Clear()
            Guna2TextBox4.DataBindings.Add(New Binding("Text", bindingSrc, "dlc"))
            Me.Guna2TextBox5.DataBindings.Clear()
            Guna2TextBox5.DataBindings.Add(New Binding("Text", bindingSrc, "nom"))



            Guna2DataGridView1.Enabled = True

            Guna2DataGridView1.DataSource = bindingSrc


            Guna2DataGridView1.AutoResizeColumns(CType(DataGridViewAutoSizeColumnsMode.AllCells, DataGridViewAutoSizeColumnsMode))
            Guna2DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect


            Guna2DataGridView1.Columns(0).Width = 60

            DisplayPosition()




        Catch ex As Exception
            MessageBox.Show("Data Binding Error : " & ex.Message.ToString())

        End Try
    End Sub

    Private Sub DisplayPosition()
        PositionLabel.Text = "Position: " & bindingSrc.Position + 1 & "/" & bindingSrc.Count
    End Sub


    Private Sub Guna2PictureBox4_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox4.Click
        Me.Close()



    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs)
        Form4.Show()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click



        Form1.Show()


    End Sub

    Private Sub Guna2PictureBox2_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox2.Click
        Form4.Show()

    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        bindingSrc.MoveFirst()
        DisplayPosition()

    End Sub

    Private Sub Guna2CircleButton2_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton2.Click
        bindingSrc.MovePrevious()
        DisplayPosition()

    End Sub

    Private Sub Guna2CircleButton3_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton3.Click
        bindingSrc.MoveNext()
        DisplayPosition()

    End Sub

    Private Sub Guna2CircleButton4_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton4.Click
        bindingSrc.MoveLast()
        DisplayPosition()
    End Sub

    Private Sub Guna2DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Guna2DataGridView1.CellMouseClick

        Try
            DisplayPosition()
        Catch ex As Exception

        End Try
















    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click

        If Guna2Button2.Text = "Annuler" Then
            Exit Sub
        End If


        UpdateDataBiding()

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        With Guna2Button2

            If .Text = "Ajouter" Then
                .Text = "Annuler"
                Guna2DataGridView1.ClearSelection()
                Guna2DataGridView1.Enabled = False
            Else
                .Text = "Ajouter"
                UpdateDataBiding()
                Exit Sub
            End If
        End With


        Guna2TextBox1.Clear()
        Guna2TextBox2.Clear()
        Guna2TextBox3.Clear()
        Guna2TextBox4.Clear()
        Guna2TextBox5.Clear()



    End Sub


    Private Sub AddCmdParameters()

        command.Parameters.Clear()
        command.CommandText = sql

        command.Parameters.AddWithValue("AutoID", Guna2TextBox1.Text.Trim())
        command.Parameters.AddWithValue("fournisseur", Guna2TextBox2.Text.Trim())
        command.Parameters.AddWithValue("Numerodelot", Guna2TextBox3.Text.Trim())
        command.Parameters.AddWithValue("dlc", Guna2TextBox4.Text.Trim())
        command.Parameters.AddWithValue("nom", Guna2TextBox5.Text.Trim())

        If dbcommand.ToUpper() = "UPDATE" Then

            command.Parameters.AddWithValue("AutoID", Guna2TextBox1.Text.Trim())

        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        If String.IsNullOrEmpty(Guna2TextBox2.Text.Trim()) Or
            String.IsNullOrEmpty(Guna2TextBox3.Text.Trim()) Or
            String.IsNullOrEmpty(Guna2TextBox4.Text.Trim()) Then
            String.IsNullOrEmpty(Guna2TextBox5.Text.Trim())

            MessageBox.Show("Merci de compléter les élémenets manquants.",
                            "Add new record : Théophile GARCIA in Messenger.",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)


            Exit Sub

        End If


        If connection.State = ConnectionState.Closed Then
            connection.Open()

        End If

        Try


            If Guna2Button2.Text = "Ajouter" Then
                If Guna2TextBox1.Text.Trim() = "" Or
                        String.IsNullOrEmpty(Guna2TextBox1.Text.Trim()) Then
                    MsgBox("Merci de selectionner une ligne.")
                    Return
                End If

                If MessageBox.Show("ID: " & Guna2TextBox1.Text.Trim() &
                        "-> Etes vous sur de vouloir modifier la ligne ?",
                                   "Select record",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub

                End If



                dbcommand = "UPDATE"


                sql = "UPDATE login SET fournisseur = @fournisseur, nom = @nom, Numerodelot = @Numerodelot, dlc = @dlc WHERE AutoID = @AutoID"

                AddCmdParameters()





            ElseIf Guna2Button2.Text.Equals("Annuler") Then

                Dim result As DialogResult
                result = MessageBox.Show("Voulez vous ajouter ce nouveau numero de lot ? (Y/N)",
                                             "INSERT A NEW NUMBER",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question)


                If result = DialogResult.Yes Then


                    dbcommand = "INSERT"

                    sql = "INSERT INTO login(fournisseur, nom, Numerodelot, dlc) " &
                            "VALUES(@fournisseur, @nom, @Numerodelot, @dlc)"
                    AddCmdParameters()

                Else
                    Exit Sub
                End If





            End If


            Dim execute As Integer = command.ExecuteNonQuery()

            If execute = -1 Then
                MessageBox.Show("Les donnés n'ont pas pu etre enregistrés", "Error saving",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop)


            Else
                MessageBox.Show("Your SQL " & dbcommand & "QUERY a été enregistré avec succès",
                                "SUCCESS SAVING",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

                UpdateDataBiding()

                Guna2Button2.Text = "Ajouter"
            End If


        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message.ToString(), "Save Data : Théophile GARCIA in Messenger",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            dbcommand = ""
            connection.Close()

        End Try


    End Sub

    Private Sub Guna2Button1_Click_1(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If Guna2Button2.Text = "Annuler" Then

            Exit Sub

        End If

        If Guna2TextBox1.Text.Trim() = "" Or
                String.IsNullOrEmpty(Guna2TextBox1.Text.Trim()) Then
            MsgBox("Merci de selectionner la ligne a supprimer",
            MsgBoxStyle.OkOnly Or MsgBoxStyle.Information,
            "DELETE PAGE")


            Return



        End If

        If connection.State = ConnectionState.Closed Then
            connection.Open()

        End If


        Try

            If MessageBox.Show("ID: " & Guna2TextBox1.Text.Trim() &
                    "Voulez vous supprimer la ligne selectionnée ?",
                               "DELETE CONF",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub

            End If

            dbcommand = "DELETE"
            sql = "DELETE FROM login WHERE AutoID = @AutoID"

            command.Parameters.Clear()
            command.CommandText = sql
            command.Parameters.AddWithValue("AutoID", Guna2TextBox1.Text.Trim())

            Dim execute As Integer = command.ExecuteNonQuery()

            If execute = 1 Then

                MessageBox.Show("Your SQL " & dbcommand & "QUERY à correctement été supprimé",
                                "DELETE SUCCESS",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

                UpdateDataBiding()
            End If




        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message.ToString(),
                            "Error message ",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)



        Finally
            dbcommand = ""
            connection.Close()
        End Try







    End Sub

    Private Sub Guna2GroupBox1_Click(sender As Object, e As EventArgs) Handles Guna2GroupBox1.Click

    End Sub

    Private Sub Guna2PictureBox5_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox5.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub Guna2TextBox6_TextChanged(sender As Object, e As EventArgs)




    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2PictureBox7_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox7.Click
        Form6.Show()
    End Sub

    Private Sub Guna2Button4_Click_1(sender As Object, e As EventArgs)




    End Sub
End Class