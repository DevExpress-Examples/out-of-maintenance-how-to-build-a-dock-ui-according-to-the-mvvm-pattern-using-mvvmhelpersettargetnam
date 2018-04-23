using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using DevExpress.Xpf.Docking;
using System.Collections.ObjectModel;

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
