Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports DevExpress.Xpf.Docking
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports DevExpress.Xpf.Mvvm

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


        Private addPanelCommand_Renamed As ICommand
        Public ReadOnly Property AddPanelCommand() As ICommand
            Get
                If addPanelCommand_Renamed Is Nothing Then
                    addPanelCommand_Renamed = New DelegateCommand(AddressOf AddPanel)
                End If
                Return addPanelCommand_Renamed
            End Get
        End Property

        Private Sub AddPanel()
            Dim panelViewModel1 As New PanelViewModel()
            panelViewModel1.Content = "Panel View Model"
            panelViewModel1.DisplayName = "Panel View Model"
            Me.Workspaces.Add(panelViewModel1)
        End Sub



        Private addDocumentCommand_Renamed As ICommand
        Public ReadOnly Property AddDocumentCommand() As ICommand
            Get
                If addDocumentCommand_Renamed Is Nothing Then
                    addDocumentCommand_Renamed = New DelegateCommand(AddressOf AddDocument)
                End If
                Return addDocumentCommand_Renamed
            End Get
        End Property

        Private Sub AddDocument()
            Dim documentViewModel1 As New DocumentViewModel()
            documentViewModel1.Content = "Document View Model"
            documentViewModel1.DisplayName = "Document View Model"
            Me.Workspaces.Add(documentViewModel1)
        End Sub

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
