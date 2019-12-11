Imports Common.IPC
Imports System
Imports System.ServiceModel
Imports System.Threading
Imports System.Threading.Tasks

Namespace Forms.Model

    ''' <summary>サーバ.Model</summary>
    <ServiceBehavior(InstanceContextMode:=InstanceContextMode.Single)>
    Public Class ServerModel
        Implements IProcess
        Implements IDisposable

        ''' <summary>プロパティ更新デリゲート</summary>
        ''' <param name="value">表示データ</param>
        Public Delegate Sub UpdatePropertyDelegate(value As Integer)

        ''' <summary>ボタン操作許可プロパティ更新デリゲート</summary>
        ''' <param name="value">更新値</param>
        Public Delegate Sub UpdateEnabledDelegate(value As Boolean)

        ''' <summary>IPC通信サービス</summary>
        Private _Host As ServiceHost

        ''' <summary>プロパティ更新メソッド</summary>
        Private _UpdateProperty As UpdatePropertyDelegate

        ''' <summary>ボタン操作許可プロパティ更新</summary>
        Private _UpdateEnabled As UpdateEnabledDelegate

        ''' <summary>IPC通信サービスを開始したか</summary>
        Private _IsOpen As Boolean = False

        ''' <summary>サーバ.Model</summary>
        Public Sub New(updateProperty As UpdatePropertyDelegate, updateEnabled As UpdateEnabledDelegate)

            _UpdateProperty = updateProperty
            _UpdateEnabled = updateEnabled

        End Sub

        ''' <summary>IPC通信サービス開始</summary>
        Public Sub Open()

            ' IPC通信サービス開始
            _Host = New ServiceHost(Me, New Uri(Service.GetBaseAddress()))
            _Host.AddServiceEndpoint(GetType(IProcess), New NetNamedPipeBinding(), Service.GetEndpoint())
            _Host.Open()
            _IsOpen = True

        End Sub

        ''' <summary>IPC通信サービス終了</summary>
        Public Sub Close()

            If _IsOpen Then

                _Host.Close()
                _IsOpen = False

            End If

        End Sub

        ''' <summary>解放処理</summary>
        Public Sub Dispose() Implements IDisposable.Dispose

            _UpdateProperty = Nothing
            _UpdateEnabled = Nothing

            Close()

        End Sub

        ''' <summary>IPC通信処理実行</summary>
        ''' <param name="sec">処理秒数</param>
        Public Function ExecuteAsync(sec As Integer) As Task(Of Integer) Implements IProcess.ExecuteAsync

            Dim value As Integer = -1
            Dim random As New Random()

            Return Task.Run(
                Function()


                    ' ボタン操作不許可
                    _UpdateEnabled(False)

                    ' 何か重たい処理
                    For i As Integer = 0 To sec - 1

                        Thread.Sleep(1000)
                        value = random.Next()

                        ' ViewModelのプロパティ更新
                        _UpdateProperty(value)

                    Next

                    ' ボタン操作許可
                    _UpdateEnabled(True)

                    Return value

                End Function)

        End Function

    End Class

End Namespace