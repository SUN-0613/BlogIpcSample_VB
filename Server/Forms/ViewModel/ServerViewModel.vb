Imports Common.MVVM

Namespace Forms.ViewModel

    ''' <summary>サーバ.ViewModel</summary>
    Public Class ServerViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>サーバ.Model</summary>
        Private _Model As Model.ServerModel

#End Region

#Region "Property"

        ''' <summary>現在値</summary>
        Public Property PresentValue As Integer

        ''' <summary>通信コマンド</summary>
        Public Property ConnectCommand As DelegateCommand(Of String)

        ''' <summary>ボタン操作許可</summary>
        Public Property IsButtonEnabled As Boolean = True

        ''' <summary>接続ボタン操作許可</summary>
        Public Property IsOpenEnabled As Boolean = True

        ''' <summary>切断ボタン操作許可</summary>
        Public Property IsCloseEnabled As Boolean = False

#End Region

        ''' <summary>サーバ.ViewModel</summary>
        Public Sub New()

            _Model = New Model.ServerModel(AddressOf UpdateProperty, AddressOf UpdateButtonEnabled)

            ConnectCommand = New DelegateCommand(Of String)(
                Sub(parameter As String)

                    Select Case parameter

                        Case "open"

                            _Model.Open()
                            UpdateConnectEnabled(True)

                        Case "close"

                            _Model.Close()
                            UpdateConnectEnabled(False)

                    End Select

                End Sub,
                Function()
                    Return True
                End Function)

        End Sub

        ''' <summary>プロパティ更新</summary>
        ''' <param name="value">更新値</param>
        Private Sub UpdateProperty(value As Integer)

            PresentValue = value
            CallPropertyChanged(NameOf(PresentValue))

        End Sub

        ''' <summary>通信許可プロパティ更新</summary>
        ''' <param name="value">
        ''' True :通信開始
        ''' False:通信終了
        ''' </param>
        Private Sub UpdateConnectEnabled(value As Boolean)

            IsOpenEnabled = Not value
            CallPropertyChanged(NameOf(IsOpenEnabled))

            IsCloseEnabled = value
            CallPropertyChanged(NameOf(IsCloseEnabled))

        End Sub

        ''' <summary>ボタン操作許可プロパティ更新</summary>
        ''' <param name="value">更新値</param>
        Private Sub UpdateButtonEnabled(value As Boolean)

            IsButtonEnabled = value
            CallPropertyChanged(NameOf(IsButtonEnabled))

        End Sub

    End Class

End Namespace