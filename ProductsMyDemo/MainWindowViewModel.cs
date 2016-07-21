using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.UI;
using DevExpress.Utils;
using ProductsMyDemo.Loading;

namespace ProductsMyDemo
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            List<ModuleInfo> modules = new List<ModuleInfo>() {
                ViewModelSource.Create(() => new ModuleInfo("GridTasksModule", this, "合同管理")).SetIcon("GridTasks"),
                ViewModelSource.Create(() => new ModuleInfo("GridContactsModule", this, "项目放款")).SetIcon("GridContacts"),
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

        protected virtual INavigationService NavigationService { get { return null; } }

        protected virtual IApplicationJumpListService ApplicationJumpListService { get { return null; } }

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
                INavigationService navigationService = parent.ServiceContainer.GetRequiredService<INavigationService>();
                navigationService.Navigate(Type, parameter, parent);
            }
        }
    }
}