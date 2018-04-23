using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using DevExpress.Xpf.Docking;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DevExpress.Xpf.Mvvm;

namespace DXDockingMVVM {
    public class DockLayoutManagerViewModel : DependencyObject {
        ObservableCollection<PanelViewModel> _workspaces;
        public ObservableCollection<PanelViewModel> Workspaces {
            get {
                if(_workspaces == null) {
                    _workspaces = new ObservableCollection<PanelViewModel>();
                }
                return _workspaces;
            }
        }

        ICommand addPanelCommand;
        public ICommand AddPanelCommand {
            get {
                if (addPanelCommand == null) {
                    addPanelCommand = new DelegateCommand(AddPanel);
                }
                return addPanelCommand;
            }
        }

        void AddPanel() {
            PanelViewModel panelViewModel1 = new PanelViewModel();
            panelViewModel1.Content = "Panel View Model";
            panelViewModel1.DisplayName = "Panel View Model";
            this.Workspaces.Add(panelViewModel1);
        }


        ICommand addDocumentCommand;
        public ICommand AddDocumentCommand {
            get {
                if (addDocumentCommand == null) {
                    addDocumentCommand = new DelegateCommand(AddDocument);
                }
                return addDocumentCommand;
            }
        }

        void AddDocument() {
            DocumentViewModel documentViewModel1 = new DocumentViewModel();
            documentViewModel1.Content = "Document View Model";
            documentViewModel1.DisplayName = "Document View Model";
            this.Workspaces.Add(documentViewModel1);
        }

    }
    public class PanelViewModel : DependencyObject {
        public static readonly DependencyProperty DisplayNameProperty =
            DependencyProperty.Register("DisplayName", typeof(string), typeof(PanelViewModel), null);
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(PanelViewModel), null);
        public PanelViewModel() {
            MVVMHelper.SetTargetName(this, "PanelHost");
        }
        public string DisplayName {
            get { return (string)GetValue(DisplayNameProperty); }
            set { SetValue(DisplayNameProperty, value); }
        }
        public object Content {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
    }
    public class DocumentViewModel : PanelViewModel {
        public DocumentViewModel() {
            MVVMHelper.SetTargetName(this, "DocumentHost");
        }
    }
}
