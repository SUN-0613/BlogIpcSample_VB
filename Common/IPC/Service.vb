Namespace IPC

    ''' <summary>IPC通信にて使用するメソッド用クラス</summary>
    Public Module Service

        ''' <summary>アドレス取得</summary>
        Public Function GetAddress() As String
            Return My.Resources.BaseAddress & "/" & My.Resources.Endpoint
        End Function

        ''' <summary>ベースアドレス取得</summary>
        Public Function GetBaseAddress() As String
            Return My.Resources.BaseAddress
        End Function

        ''' <summary>エンドポイント取得</summary>
        Public Function GetEndpoint() As String
            Return My.Resources.Endpoint
        End Function

    End Module

End Namespace