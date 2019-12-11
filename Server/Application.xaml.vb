Class Application

    ''' <summary>処理開始</summary>
    ''' <param name="e">引数</param>
    Protected Overrides Sub OnStartup(e As StartupEventArgs)

        MyBase.OnStartup(e)

        Dim form As New Forms.View.ServerView()

        form.ShowDialog()

    End Sub

End Class
