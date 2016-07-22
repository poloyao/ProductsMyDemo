using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;

namespace ProductsMyDemo.VM
{
    [POCOViewModel]
    public class ContractVM
    {
        protected ContractVM()
        {
            //部分初始化
            CGAddPanel = 1;
        }


        public static ContractVM Create()
        {
            return ViewModelSource.Create(() => new ContractVM());
        }

        /// <summary>
        /// 反担保添加面板
        /// </summary>
        public int CGAddPanel { get; set; }

        /// <summary>
        /// 点击添加反担保按钮
        /// </summary>
        public void CGAdd()
        {
            CGAddPanel = 1;
        }
        /// <summary>
        /// 保存反担保
        /// </summary>
        public void CGSave()
        {
            CGAddPanel = 0;
        }


        public void Save()
        {

        }

    }
}
