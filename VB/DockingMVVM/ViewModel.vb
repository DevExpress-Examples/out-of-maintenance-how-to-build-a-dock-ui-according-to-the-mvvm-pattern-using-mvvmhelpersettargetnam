Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports DevExpress.Xpf.Docking
Imports System.Collections.ObjectModel

Namespace DXDockingMVVM
    Public Class DockLayoutManagerViewModel
        Inherits DependencyObject

        Private _workspaces As ObservableCollection(Of PanelViewModel)
        Public ReadOnly Property Workspaces() As ObservableCollection(Of PanelViewModel)
            Get
                If _workspaces Is Nothing Then
                    _workspaces = New ObservableCollection(Of PanelViewModel)()
                End If
                Return _workspaces
            End Get
        End Property
    End Class
    Public Class PanelViewModel
        Inherits DependencyObject

        Public Shared ReadOnly DisplayNameProperty As DependencyProperty = DependencyProperty.Register("DisplayName", GetType(String), GetType(PanelViewModel), Nothing)
        Public Shared ReadOnly ContentProperty As DependencyProperty = DependencyProperty.Register("Content", GetType(Object), GetType(PanelViewModel), Nothing)
        Public Sub New()
            MVVMHelper.SetTargetName(Me, "PanelHost")
        End Sub
        Public Property DisplayName() As String
            Get
                Return DirectCast(GetValue(DisplayNameProperty), String)
            End Get
            Set(ByVal value As String)
                SetValue(DisplayNameProperty, value)
            End Set
        End Property
        Public Property Content() As Object
            Get
                Return DirectCast(GetValue(ContentProperty), Object)
            End Get
            Set(ByVal value As Object)
                SetValue(ContentProperty, value)
            End Set
        End Property
    End Class
    Public Class DocumentViewModel
        Inherits PanelViewModel

        Public Sub New()
            MVVMHelper.SetTargetName(Me, "DocumentHost")
        End Sub
    End Class
End Namespace
