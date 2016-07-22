using DevExpress.Xpf.Core;
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
using System.Windows.Shapes;

namespace ProductsMyDemo.SplashScreens
{
    /// <summary>
    /// SplashScreenWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SplashScreenWindow : Window,ISplashScreen
    {
        public SplashScreenWindow()
        {
            Copyright = AssemblyInfo.AssemblyCopyright;
            InitializeComponent();
            this.board.Completed += OnAnimationCompleted;
        }

        public string Copyright { get; set; }

        #region ISplashScreen
        void ISplashScreen.Progress(double value)
        {
            progressBar.Value = value;
        }
        void ISplashScreen.CloseSplashScreen()
        {
            this.board.Begin(this);
        }
        void ISplashScreen.SetProgressState(bool isIndeterminate)
        {
            progressBar.IsIndeterminate = isIndeterminate;
        }
        #endregion

        #region Event Handlers
        void OnAnimationCompleted(object sender, EventArgs e)
        {
            this.board.Completed -= OnAnimationCompleted;
            this.Close();
        }
        #endregion
    }
}

