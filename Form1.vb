Imports System.Drawing
Imports System.Drawing.Imaging
Imports DrawingSomething.HeatFallout

Public Class Form1
    Dim HF As New HeatFallout
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        HF.p = e.X
        HF.q = e.Y
        HF.pb = PictureBox1
        HF.testfall()
        'Dim run As Threading.Thread = New Threading.Thread(AddressOf HF.testfall)
        'run.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
