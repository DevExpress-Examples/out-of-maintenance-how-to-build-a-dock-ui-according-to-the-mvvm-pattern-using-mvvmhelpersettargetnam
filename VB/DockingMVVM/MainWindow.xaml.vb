Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Docking

Namespace DXDockingMVVM
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Private dockLayoutManagerViewModel As DockLayoutManagerViewModel

        Public Sub New()
            InitializeComponent()
            dockLayoutManagerViewModel = New DockLayoutManagerViewModel()
            DataContext = dockLayoutManagerViewModel
        End Sub


        Private Sub AddPanel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim panelViewModel1 As New PanelViewModel()
            panelViewModel1.Content = "Panel View Model"
            panelViewModel1.DisplayName = "Panel View Model"
            dockLayoutManagerViewModel.Workspaces.Add(panelViewModel1)
        End Sub

        Private Sub AddDocument_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim documentViewModel1 As New DocumentViewModel()
            documentViewModel1.Content = "Document View Model"
            documentViewModel1.DisplayName = "Document View Model"
            dockLayoutManagerViewModel.Workspaces.Add(documentViewModel1)
        End Sub
    End Class
End Namespace
