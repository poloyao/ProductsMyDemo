using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using DevExpress.Images;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.UI;
using DevExpress.Utils;
using System.ComponentModel.DataAnnotations;
using ProductsMyDemo.VM;
using ProductsMyDemo.Loading;
using System.Threading.Tasks;
using ProductsMyDemo.Controls;
using ProductsMyDemo.SplashScreens;

namespace ProductsMyDemo
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            SplashScreenType = typeof(SplashScreenWindow);
            List<ModuleInfo> modules = new List<ModuleInfo>() {
                ViewModelSource.Create(() => new ModuleInfo("ProjectView", this, "合同管理")).SetIcon("GridTasks"),
                ViewModelSource.Create(() => new ModuleInfo("Contract", this, "项目放款")).SetIcon("GridContacts"),
                ViewModelSource.Create(() => new ModuleInfo("SpreadsheetModule", this, "追/代偿")).SetIcon("Spreadsheet"),
                ViewModelSource.Create(() => new ModuleInfo("RichEditModule", this, "保费管理")).SetIcon("WordProcessing"),
                ViewModelSource.Create(() => new ModuleInfo("ReportsModule", this, "设置")).SetIcon("BandedReports")
            };

            ModuleGroups = new ModuleGroup[] { new ModuleGroup("菜单", modules) };
        }
        /// <summary>
        /// 模块列表
        /// </summary>
        public virtual IEnumerable<ModuleGroup> ModuleGroups { get; protected set; }
        /// <summary>
        /// 当前选中的模块
        /// </summary>
        public virtual ModuleInfo SelectedModuleInfo { get; set; }

        /// <summary>
        /// 加载过场界面
        /// </summary>
        public virtual Type SplashScreenType { get; set; }
        public virtual int DefaultBackstatgeIndex { get; set; }
        public virtual bool HasPrinting { get; set; }
        public virtual bool IsBackstageOpen { get; set; }

        [Required]
        protected virtual ICurrentWindowService CurrentWindowService { get { return null; } }
        [Required]
        protected virtual IApplicationJumpListService ApplicationJumpListService { get { return null; } }

        [Required]
        protected virtual INavigationService NavigationService { get { return null; } }
        protected virtual void OnSelectedModuleInfoChanged()
        {
            //PrintingService.PreviewModelAction = null;
        }
        protected virtual void OnIsBackstageOpenChanged()
        {
            //HasPrinting = PrintingService.HasPrinting;
            //if (!HasPrinting && DefaultBackstatgeIndex == 1)
            //    DefaultBackstatgeIndex = 0;
        }

        BitmapImage NewTaskIcon
        {
            get { return new BitmapImage(AssemblyHelper.GetResourceUri(typeof(DXImages).Assembly, "Images/Analytics.png")); }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void Exit()
        {
            CurrentWindowService.Close();
        }
        /// <summary>
        /// 模块初始化
        /// </summary>
        public void OnModulesLoaded()
        {
            if (SelectedModuleInfo == null)
            {
                SelectedModuleInfo = ModuleGroups.First().ModuleInfos.First();
                SelectedModuleInfo.IsSelected = true;
                SelectedModuleInfo.Show();
            }

            SplashScreenType = typeof(ProgressWindow);
            //ApplicationJumpListService.Items.AddOrReplace("")
            //ApplicationJumpListService.Items.AddOrReplace("New Task", NewTaskIcon, ShowGridTasksModuleNewItemWindow);
            //ApplicationJumpListService.Apply();
        }

        /// <summary>
        /// 注入界面
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="moduleType"></param>
        void ShowGridModuleNewItemWindow<T>(string moduleType) where T : class
        {
            if (Application.Current.Windows.Count != 1)
                return;
            GridViewModelBase<T> viewModel = ViewHelper.GetViewModelFromView(NavigationService.Current) as GridViewModelBase<T>;
            if (viewModel != null)
                viewModel.ShowNewItemWindow();
            else
                ModuleGroups.SelectMany(g => g.ModuleInfos).Where(m => m.Type == moduleType).First().Show(GridModuleNavigationParameter.NewItem);
        }
        void ShowGridTasksModuleNewItemWindow()
        {
            ShowGridModuleNewItemWindow<Task>("GridTasksModule");
        }



        public class ModuleGroup
        {
            public ModuleGroup(string _title, IEnumerable<ModuleInfo> _moduleInfos)
            {
                Title = _title;
                ModuleInfos = _moduleInfos;
            }
            public string Title { get; private set; }
            public IEnumerable<ModuleInfo> ModuleInfos { get; private set; }
        }
        public class ModuleInfo
        {
            ISupportServices parent;

            public ModuleInfo(string _type, object parent, string _title)
            {
                Type = _type;
                this.parent = (ISupportServices)parent;
                Title = _title;
            }
            public string Type { get; private set; }
            public virtual bool IsSelected { get; set; }
            public string Title { get; private set; }
            public virtual Uri Icon { get; set; }
            public ModuleInfo SetIcon(string icon)
            {
                this.Icon = AssemblyHelper.GetResourceUri(typeof(ModuleInfo).Assembly, string.Format("Images/{0}.png", icon));
                return this;
            }

            /// <summary>
            /// 显示当前模块
            /// </summary>
            /// <param name="parameter"></param>
            public void Show(object parameter = null)
            {
                try
                {
                    INavigationService navigationService = parent.ServiceContainer.GetRequiredService<INavigationService>();
                    navigationService.Navigate(Type, parameter, parent);
                }
                catch (Exception)
                {

                    MessageBox.Show("error!~");
                }

            }
        }
    }
}