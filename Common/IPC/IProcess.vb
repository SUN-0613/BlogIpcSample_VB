Imports System.ServiceModel
Imports System.Threading.Tasks

Namespace IPC

    ''' <summary>プロセス間通信インターフェース</summary>
    <ServiceContract>
    Public Interface IProcess

        ''' <summary>サーバー側でメソッドを実行し、戻り値をクライアントに渡す</summary>
        ''' <param name="sec">処理秒数</param>
        <OperationContract>
        Function ExecuteAsync(sec As Integer) As Task(Of Integer)

    End Interface

End Namespace