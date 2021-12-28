using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA_MDM_MvcApp_2021.Models.ViewModels
{
    public class IndexViewModel
    {

        public List<MdmBlogs> MdmBlogs { get; set; }
        public List<MdmCategories> MdmCategories { get; set; }
        public List<MisakBlogs> MisakBlogs { get; set; }
        public List<Contacts> Contacts { get; set; }
    }
}