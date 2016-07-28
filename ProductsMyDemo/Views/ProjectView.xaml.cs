using DevExpress.Xpf.Grid;
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

namespace ProductsMyDemo.Views
{
    /// <summary>
    /// ProjectView.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectView : UserControl
    {
        public ProjectView()
        {
            InitializeComponent();
            //VM.ProjectVM vm = new VM.ProjectVM();
            //DataContext = vm;
            //vm.PropertyChanged += Vm_PropertyChanged;
            ((TableView)grid.View).WaitIndicatorType = WaitIndicatorType.Panel;
            grid.CurrentColumnChanged += Grid_CurrentColumnChanged;
           // grid.View.column.ColumnAutoWidth = false;
        }

        private void Grid_CurrentColumnChanged(object sender, CurrentColumnChangedEventArgs e)
        {
            var asd = "asd";
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }

        private void TableView_CellValueChanging(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            e.Source.PostEditor();
        }

        private void grid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            var asd = "asd";
        }

        private void grid_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            var asd = "asd";
            var sssssss = grid.View.TopRowIndex;
        }

        private void grid_LayoutUpdated(object sender, EventArgs e)
        {
            var asd = "dasd";
        }

        private void plingSource_DismissEnumerable(object sender, DevExpress.Xpf.Core.ServerMode.GetEnumerableEventArgs e)
        {
            var asd = "ads";
        }

        private void plingSource_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var asd = "ads";
        }

        private void plingSource_GetEnumerable(object sender, DevExpress.Xpf.Core.ServerMode.GetEnumerableEventArgs e)
        {
            var asd = "ads";
        }

        private void grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ContractWin win = new ContractWin();
            var data = (ProductsMyDemo.ServiceReference2.ProjectDataObject)grid.SelectedItem;
            win.DataContext = new VM.ContractVM(data.ID);
            win.Title = data.ID;
            win.Show();
        }
    }
}
