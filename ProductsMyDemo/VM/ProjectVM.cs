using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using ProductsMyDemo.ServiceReference2;


namespace ProductsMyDemo.VM
{
    [POCOViewModel]
    public class ProjectVM
    {

        public ProjectVM()
        {
            GetProjectList();
        }

        ProjectDataObjectList _ProjectList = new ProjectDataObjectList();
        ProjectDataObjectListWithPagination _PDWP = new ProjectDataObjectListWithPagination();

        public ProjectDataObjectList ProjectList
        {
            get
            {
                return _ProjectList;
            }

            set
            {
                _ProjectList = value;
            }
        }

        void GetProjectList()
        {
            //using (var client = new ProjectServiceClient())
            //{
            //    ProjectList = client.GetProjects(0);
            //}
            try
            {
                var client = new ProjectServiceClient();
                //PDWP = client.GetProjectsWithPagination(new Pagination { PageNumber = 1, PageSize = 20 });
                //ProjectList = PDWP.ProjectDataObjectList;
                ProjectList = client.GetProjects(20);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }


        public List<string> alas { get; set; }

        public ProjectDataObjectListWithPagination PDWP
        {
            get
            {
                return _PDWP;
            }

            set
            {
                _PDWP = value;
            }
        }
    }
}
