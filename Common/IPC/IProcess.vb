Imports System.ServiceModel

Namespace IPC

    ''' <summary>プロセス間通信インターフェース</summary>
    <ServiceContract>
    Public Interface IProcess

        ''' <summary>サーバー側でメソッドを実行し、戻り値をクライアントに渡す</summary>
        ''' <param name="sec">処理秒数</param>
        <OperationContract>
        Function Execute(sec As Integer) As Integer

    End Interface

End Namespace