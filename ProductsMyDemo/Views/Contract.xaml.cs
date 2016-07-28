﻿using System;
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

namespace ProductsMyDemo.Views
{
    /// <summary>
    /// Contract.xaml 的交互逻辑
    /// </summary>
    public partial class Contract : UserControl
    {
        public Contract()
        {
            InitializeComponent();
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            CounterGuatantee cg = new CounterGuatantee();
            cg.DataContext = new VM.CounterGuatanteeViewModel();
            cg.ShowDialog();
        }
    }
}
