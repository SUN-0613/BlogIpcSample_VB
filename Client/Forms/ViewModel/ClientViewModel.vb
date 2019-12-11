Imports Common.MVVM

Namespace Forms.ViewModel

    ''' <summary>クライアント.ViewModel</summary>
    Public Class ClientViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>クライアント.Model</summary>
        Private _Model As Model.ClientModel

#End Region

#Region "Property"

        ''' <summary>実行コマンド</summary>
        Public Property ExecuteCommand As DelegateCommand

        ''' <summary>サーバ側処理の実行結果</summary>
        Public Property Result As Integer

        ''' <summary>ボタン操作許可</summary>
        Public Property IsEnabled As Boolean
            Get
                Return _IsEnabled
            End Get
            Set(value As Boolean)
                _IsEnabled = value
                CallPropertyChanged()
            End Set
        End Property

        ''' <summary>通信エラーメッセージ</summary>
        Public Property ErrorMessage As String
            Get
                Return _ErrorMessage
            End Get
            Set(value As String)
                _ErrorMessage = value
                CallPropertyChanged()
            End Set
        End Property

#End Region

        ''' <summary>ボタン操作許可</summary>
        Private _IsEnabled As Boolean = True

        ''' <summary>通信エラーメッセージ</summary>
        Private _ErrorMessage As String = ""

        ''' <summary>クライアント.ViewModel</summary>
        Public Sub New()

            _Model = New Model.ClientModel()

            ExecuteCommand = New DelegateCommand(
                Async Sub()

                    IsEnabled = False
                    ErrorMessage = ""

                    Try

                        ' プロセス間通信でサーバに指示を出し、結果を受け取る
                        Result = Await _Model.ExecuteServerSideAsync()
                        CallPropertyChanged(NameOf(Result))

                    Catch
                        ErrorMessage = "通信エラー発生"
                    Finally
                        IsEnabled = True
                    End Try

                End Sub,
                Function()
                    Return True
                End Function)

        End Sub

    End Class

End Namespace