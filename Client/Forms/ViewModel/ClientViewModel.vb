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

#End Region

        ''' <summary>クライアント.ViewModel</summary>
        Public Sub New()

            _Model = New Model.ClientModel()

            ExecuteCommand = New DelegateCommand(
                Sub()

                    ' プロセス間通信でサーバに指示を出し、結果を受け取る
                    Result = _Model.ExecuteServerSide()
                    CallPropertyChanged(NameOf(Result))

                End Sub,
                Function()
                    Return True
                End Function)

        End Sub

    End Class

End Namespace