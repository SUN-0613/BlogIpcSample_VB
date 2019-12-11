Imports Common.IPC
Imports System.ServiceModel
Imports System.Threading.Tasks

Namespace Forms.Model

    ''' <summary>クライアント.Model</summary>
    Public Class ClientModel

        ''' <summary>サーバ処理実行</summary>
        Private _Server As IProcess

        ''' <summary>クライアント.Model</summary>
        Public Sub New()

            _Server = New ChannelFactory(Of IProcess)(
                        New NetNamedPipeBinding(),
                        New EndpointAddress(Service.GetAddress)
                        ).CreateChannel()

        End Sub

        ''' <summary>プロセス間通信実行</summary>
        Public Async Function ExecuteServerSideAsync() As Task(Of Integer)
            Return Await _Server.ExecuteAsync(5)
        End Function

    End Class

End Namespace