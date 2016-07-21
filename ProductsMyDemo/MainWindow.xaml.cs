using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.WindowsUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductsMyDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : DXRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NavigationPaneView_NavPaneExpandedChanged(object sender, DevExpress.Xpf.NavBar.NavPaneExpandedChangedEventArgs e)
        {
            layoutPanel.ItemWidth = GridLength.Auto;
        }

        private void NavigationPaneView_NavPaneExpandedChanging(object sender, DevExpress.Xpf.NavBar.NavPaneExpandedChangingEventArgs e)
        {
            navPanelView.Expander.MaxWidth = e.IsExpanded ? Double.PositiveInfinity : navPanelView.Expander.ActualWidth;
        }

        private void NavigationFrame_Navigating(object sender, DevExpress.Xpf.WindowsUI.Navigation.NavigatingEventArgs e)
        {
            if (e.Cancel) return;
            NavigationFrame frame = (NavigationFrame)sender;
            FrameworkElement oldContent = (FrameworkElement)frame.Content;
            if (oldContent != null)
            {
                RibbonMergingHelper.SetMergeWith(oldContent, null);
                RibbonMergingHelper.SetMergeStatusBarWith(oldContent, null);
            }
        }

        private void NavigationFrame_Navigated(object sender, DevExpress.Xpf.WindowsUI.Navigation.NavigationEventArgs e)
        {
            FrameworkElement newContent = (FrameworkElement)e.Content;
            if (newContent != null)
            {
               // RibbonMergingHelper.SetMergeWith(newContent, ribbon);
               // RibbonMergingHelper.SetMergeStatusBarWith(newContent, statusBar);
            }
        }
    }
}
