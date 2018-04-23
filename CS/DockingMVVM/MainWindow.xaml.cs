using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Docking;

namespace DXDockingMVVM {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        DockLayoutManagerViewModel dockLayoutManagerViewModel;

        public MainWindow() {
            InitializeComponent();
            dockLayoutManagerViewModel = new DockLayoutManagerViewModel();
            DataContext = dockLayoutManagerViewModel;
        }
        

        private void AddPanel_Click(object sender, RoutedEventArgs e) {
            PanelViewModel panelViewModel1 = new PanelViewModel();
            panelViewModel1.Content = "Panel View Model";
            panelViewModel1.DisplayName = "Panel View Model";
            dockLayoutManagerViewModel.Workspaces.Add(panelViewModel1);
        }

        private void AddDocument_Click(object sender, RoutedEventArgs e) {
            DocumentViewModel documentViewModel1 = new DocumentViewModel();
            documentViewModel1.Content = "Document View Model";
            documentViewModel1.DisplayName = "Document View Model";
            dockLayoutManagerViewModel.Workspaces.Add(documentViewModel1);
        }
    }
}
