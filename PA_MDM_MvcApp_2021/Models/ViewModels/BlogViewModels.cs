using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA_MDM_MvcApp_2021.Models.ViewModels
{
    public class BlogViewModels
    {
 
      public   IPagedList<MdmBlogs> MdmBlogs { get; set; }
      public  List<MdmCategories>MdmCategories { get; set; }
      public  List<Authors> Authors { get; set; }

    }
}