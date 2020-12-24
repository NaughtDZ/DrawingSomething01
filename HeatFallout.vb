Public Class HeatFallout
    Friend bmp As Bitmap = New Drawing.Bitmap(512, 512)
    Friend g As Graphics = Graphics.FromImage(bmp)
    Friend pb As PictureBox
    Friend p As Integer, q As Integer
    Public Sub testfall()
        g.Clear(Color.Black) '清空画布
        '----------------第一热源（自定义）
        Dim ch As New ComputeH '定义新的计算类，目的是为了调用多线程
        Dim h1(512, 512) As Integer '一号热，由鼠标点击决定
        'Dim com1 As Threading.Thread = New Threading.Thread(AddressOf ch.HeatCompute)
        Dim com1 As Task = New Task(AddressOf ch.HeatCompute) '换线程改为task
        ch.p = p : ch.q = q : ch._3times = 0 '传递到ConputeH
        com1.Start()
        '----------------第二热源（给定）
        Dim ch2 As New ComputeH '定义新的计算类，目的是为了调用多线程
        Dim h2(512, 512) As Integer '一号热，由鼠标点击决定
        'Dim com2 As Threading.Thread = New Threading.Thread(AddressOf ch.HeatCompute)
        Dim com2 As Task = New Task(AddressOf ch2.HeatCompute)
        ch2.p = 16 : ch2.q = 16 : ch2._3times = 0 '传递到ConputeH
        com2.Start()
        '----------------第三热源（给定）
        Dim ch3 As New ComputeH '定义新的计算类，目的是为了调用多线程
        Dim h3(512, 512) As Integer '一号热，由鼠标点击决定
        'Dim com3 As Threading.Thread = New Threading.Thread(AddressOf ch.HeatCompute)
        Dim com3 As Task = New Task(AddressOf ch3.HeatCompute)
        ch3.p = 500 : ch3.q = 500 : ch3._3times = 0 '传递到ConputeH
        com3.Start()
        Dim alltask() As Task = {com1, com2, com3}
        Task.WaitAll(alltask)
        h1 = ch.result : h2 = ch2.result : h3 = ch3.result
        ResultDraw(h1, h2, h3)
    End Sub

    Public Function Vertxmod(m As Integer, n As Integer, p As Integer, q As Integer) As Single
        Return Math.Sqrt((p - m) ^ 2 + (q - n) ^ 2) '计算平面点与热源的距离
    End Function

    Private Sub ResultDraw(h1, h2, h3)
        Dim plus As Integer
        For m As Integer = 0 To 511
            For n As Integer = 0 To 511
                plus = h1(m, n) + h2(m, n) + h3(m, n)
                Select Case plus
                    Case <= 255
                        bmp.SetPixel(m, n, Color.FromArgb(255, 0, 0, plus))
                    Case <= 510
                        bmp.SetPixel(m, n, Color.FromArgb(255, 0, plus - 255, 510 - plus))
                    Case <= 765
                        bmp.SetPixel(m, n, Color.FromArgb(255, plus - 510, 765 - plus, 0))
                End Select
            Next
        Next
        pb.Image = bmp
    End Sub
    Private Class ComputeH
        Dim vhf As New HeatFallout
        Public p As Integer, q As Integer '热源坐标
        Public result(512, 512) As Integer '结果缓存参数
        Public _3times As Integer

        Public Function HeatCompute()
            Dim heatsource(512, 512) As Integer
            Dim heat As Integer '最终热量
            Dim md As Single '中间值
            For m As Integer = 0 To 511
                For n As Integer = 0 To 511
                    md = -255 * (vhf.Vertxmod(m, n, p, q) / vhf.Vertxmod(0, 0, 256, 256)) + 255
                    If md <= 0 Then
                        heat = 0
                    Else
                        heat = md
                    End If
                    heatsource(m, n) = heat
                Next
            Next
            result = heatsource
            _3times = 1
            Return _3times
            Debug.WriteLine(_3times)
            MsgBox("完成")
        End Function
    End Class
End Class
