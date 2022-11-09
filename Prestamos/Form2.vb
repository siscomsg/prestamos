Imports System.Data.SqlClient
Imports System.IO

Public Class Form2
    Public ds As New DataSet

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call GuardarImagen(PictureBox1, DateTimePicker1)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            'Me.TextBox1.Text = CStr(Form1.DataGridView1.SelectedCells(0).Value)
            'El MemoryStream nos permite crear un almacen de memoria
            Dim ms As New MemoryStream(ExtraerImagen(CInt(id)))
            Me.PictureBox1.Image = Image.FromStream(ms)
            Button4.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call guardarimagenpc(guarda, PictureBox1, abre)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call abririmagen(abre, PictureBox1)
        
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Today()
        Call Posicion(Me)
        'MsgBox(id)
    End Sub

   
End Class