using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using ProductsMyDemo.ServiceReference2;
using System.ComponentModel;
using System.Collections;

namespace ProductsMyDemo.VM
{
    [POCOViewModel]
    public class ProjectVM:BindableBase
    {

        public ProjectVM()
        {
            Client = new ProjectServiceClient();
            ProjectPage = Client.GetProjectsWithPagination(new Pagination() { PageNumber = 1, PageSize = 200 });
            ProjectList = ProjectPage.ProjectDataObjectList;
            OrderDataList = new OrderDataListSource(ProjectList);
        }

        /// <summary>
        /// 双击项目行，弹出
        /// </summary>
        /// <param name="parameter"></param>
        public void DoubleProject(object parameter = null)
        {

        }

        ProjectDataObjectList _ProjectList;
        ProjectDataObjectListWithPagination _ProjectPage;
        ServiceReference2.ProjectServiceClient _Client;
        ProjectDataObject _SelectItem;

        public ProjectDataObjectList ProjectList
        {
            get { return _ProjectList; }
            set { SetProperty(ref _ProjectList, value, () => ProjectList); }
        }

        public ProjectServiceClient Client
        {
            get
            {
                return _Client;
            }

            set
            {
                _Client = value;
            }
        }

        public ProjectDataObjectListWithPagination ProjectPage
        {
            get
            {
                return _ProjectPage;
            }

            set
            {
                _ProjectPage = value;
            }
        }

        public ProjectDataObject SelectItem
        {
            get { return _SelectItem; }
            set { SetProperty(ref _SelectItem, value, () => _SelectItem); }
        }

        public OrderDataListSource OrderDataList
        {
            get;set;
        }

        

    }

    public class OrderDataListSource : IListSource
    {

        ProjectDataObjectList orders = new ProjectDataObjectList();
        static object Locker = new object();

        public OrderDataListSource(ProjectDataObjectList data)
        {
            orders = data;
        }

        public bool ContainsListCollection
        {
            get { return false; }
        }

        public IList GetList()
        {
            return orders;
        }
    }
}
