Imports System.Windows
Imports DevExpress.Xpf.Docking
Imports System.Collections.ObjectModel
Imports System.Windows.Input
Imports DevExpress.Mvvm

Namespace DXDockingMVVM

    Public Class DockLayoutManagerViewModel
        Inherits DependencyObject

        Private _workspaces As ObservableCollection(Of PanelViewModel)

        Public ReadOnly Property Workspaces As ObservableCollection(Of PanelViewModel)
            Get
                If _workspaces Is Nothing Then
                    _workspaces = New ObservableCollection(Of PanelViewModel)()
                End If

                Return _workspaces
            End Get
        End Property

        Private addPanelCommandField As ICommand

        Public ReadOnly Property AddPanelCommand As ICommand
            Get
                If addPanelCommandField Is Nothing Then
                    addPanelCommandField = New DelegateCommand(AddressOf AddPanel)
                End If

                Return addPanelCommandField
            End Get
        End Property

        Private Sub AddPanel()
            Dim panelViewModel1 As PanelViewModel = New PanelViewModel()
            panelViewModel1.Content = "Panel View Model"
            panelViewModel1.DisplayName = "Panel View Model"
            Workspaces.Add(panelViewModel1)
        End Sub

        Private addDocumentCommandField As ICommand

        Public ReadOnly Property AddDocumentCommand As ICommand
            Get
                If addDocumentCommandField Is Nothing Then
                    addDocumentCommandField = New DelegateCommand(AddressOf AddDocument)
                End If

                Return addDocumentCommandField
            End Get
        End Property

        Private Sub AddDocument()
            Dim documentViewModel1 As DocumentViewModel = New DocumentViewModel()
            documentViewModel1.Content = "Document View Model"
            documentViewModel1.DisplayName = "Document View Model"
            Workspaces.Add(documentViewModel1)
        End Sub
    End Class

    Public Class PanelViewModel
        Inherits DependencyObject

        Public Shared ReadOnly DisplayNameProperty As DependencyProperty = DependencyProperty.Register("DisplayName", GetType(String), GetType(PanelViewModel), Nothing)

        Public Shared ReadOnly ContentProperty As DependencyProperty = DependencyProperty.Register("Content", GetType(Object), GetType(PanelViewModel), Nothing)

        Public Sub New()
            MVVMHelper.SetTargetName(Me, "PanelHost")
        End Sub

        Public Property DisplayName As String
            Get
                Return CStr(GetValue(DisplayNameProperty))
            End Get

            Set(ByVal value As String)
                SetValue(DisplayNameProperty, value)
            End Set
        End Property

        Public Property Content As Object
            Get
                Return CObj(GetValue(ContentProperty))
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
