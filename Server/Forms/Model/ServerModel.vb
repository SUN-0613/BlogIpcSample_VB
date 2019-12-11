Imports Common.IPC
Imports System
Imports System.ServiceModel
Imports System.Threading

Namespace Forms.Model

    ''' <summary>サーバ.Model</summary>
    <ServiceBehavior(InstanceContextMode:=InstanceContextMode.Single)>
    Public Class ServerModel
        Implements IProcess
        Implements IDisposable

        ''' <summary>IPC通信サービス</summary>
        Private _Host As ServiceHost

        ''' <summary>サーバ.Model</summary>
        Public Sub New()

            ' IPC通信サービス開始
            _Host = New ServiceHost(Me, New Uri(Service.GetBaseAddress()))
            _Host.AddServiceEndpoint(GetType(IProcess), New NetNamedPipeBinding(), Service.GetEndpoint())
            _Host.Open()

        End Sub

        ''' <summary>解放処理</summary>
        Public Sub Dispose() Implements IDisposable.Dispose

            ' IPC通信サービス終了
            _Host.Close()

        End Sub

        ''' <summary>IPC通信処理実行</summary>
        ''' <param name="sec">処理秒数</param>
        Public Function Execute(sec As Integer) As Integer Implements IProcess.Execute

            Dim value As Integer = -1
            Dim random As New Random()

            ' 何か重たい処理
            For i As Integer = 0 To sec - 1

                Thread.Sleep(1000)
                value = random.Next()

            Next

            Return value

        End Function

    End Class

End Namespace