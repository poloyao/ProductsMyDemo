using DevExpress.Mvvm;
using DevExpress.Xpf.Printing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsMyDemo.Controls
{
    public class PrintViewModel : ViewModelBase
    {
        LinkPreviewModel printModel;

        public LinkPreviewModel PrintModel
        {
            get { return printModel; }
            set
            {
                SetProperty(ref printModel, value, () => this.PrintModel);
            }
        }

        public void UpdatePrintModel()
        {
            if (PrintingService.PreviewModelAction != null)
            {
                PrintModel = PrintingService.PreviewModelAction();
                PrintModel.Link.CreateDocument(true);
            }
        }
    }
    public static class PrintingService
    {
        public static Func<LinkPreviewModel> PreviewModelAction;
        public static bool HasPrinting
        {
            get
            {
                return PreviewModelAction != null;
            }
        }
    }
}
