Module Avgdraw


    ''' <summary>
    ''' 画坐标
    ''' </summary>
    Private Sub Crosshair()
        Dim mypen As Pen = New Pen(Brushes.LightGray, 2)
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.TranslateTransform(0, 1920)
        g.ScaleTransform(1, -1)
        g.DrawLine(mypen, 0, 0, 100, 0) : g.DrawLine(mypen, 0, 0, 0, 100)
    End Sub
    Private Sub Arithmetic()
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.TranslateTransform(0, 1920)
        g.ScaleTransform(1, -1)
        Dim mypen As Pen = New Pen(Brushes.White, 1)
        For a = 0 To 1920 Step 1
            For b = 1 To 2160 Step 60
                Dim y As Decimal = (a + b) / 2
                g.DrawEllipse(mypen, a, y, 1, 1)
            Next
            g.Save()
        Next
    End Sub

    Private Sub Geometric()
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.TranslateTransform(0, 1920)
        g.ScaleTransform(1, -1)
        Dim mypen As Pen = New Pen(Brushes.Cyan, 1)
        For a = 0 To 1920 Step 1
            For b = 1 To 2160 Step 60
                Dim y As Decimal = Math.Sqrt(a * b)
                g.DrawEllipse(mypen, a, y, 1, 1)
            Next
            g.Save()
        Next
    End Sub

    Private Sub Harmonic()
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.TranslateTransform(0, 1920)
        g.ScaleTransform(1, -1)
        Dim mypen As Pen = New Pen(Brushes.Magenta, 1)
        For a = 0 To 1920 Step 1
            For b = 1 To 2160 Step 60
                Dim y As Decimal = 2 / ((1 / a) + (1 / b))
                g.DrawEllipse(mypen, a, y, 1, 1)
            Next
            g.Save()
        Next
    End Sub

    Private Sub Quadratic()
        Dim g As Graphics = PictureBox1.CreateGraphics
        g.TranslateTransform(0, 1920)
        g.ScaleTransform(1, -1)
        Dim mypen As Pen = New Pen(Brushes.Yellow, 1)
        For a = 0 To 1920 Step 1
            For b = 1 To 2160 Step 60
                Dim y As Decimal = Math.Sqrt((a ^ 2 + b ^ 2) / 2)
                g.DrawEllipse(mypen, a, y, 1, 1)
            Next
        Next
        g.Save()
    End Sub

    Private Sub MutiDraw()
        Dim d1 As Threading.Thread = New Threading.Thread(AddressOf Arithmetic) '我知道，带参数可以放到类里，但是这里就免了吧
        Dim d2 As Threading.Thread = New Threading.Thread(AddressOf Geometric)
        Dim d3 As Threading.Thread = New Threading.Thread(AddressOf Harmonic)
        Dim d4 As Threading.Thread = New Threading.Thread(AddressOf Quadratic)
        d1.Start()
        d2.Start()
        d3.Start()
        d4.Start()
    End Sub

End Module
