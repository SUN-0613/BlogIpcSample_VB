Imports Common.MVVM

Namespace Forms.ViewModel

    ''' <summary>サーバ.ViewModel</summary>
    Public Class ServerViewModel
        Inherits ViewModelBase

#Region "Model"

        ''' <summary>サーバ.Model</summary>
        Private _Model As Model.ServerModel

#End Region

        ''' <summary>サーバ.ViewModel</summary>
        Public Sub New()

            _Model = New Model.ServerModel()

        End Sub

    End Class

End Namespace