//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PA_MDM_MvcApp_2021.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MisakBlogDetails
    {
        public int MisakBlogId { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public string VideoURL { get; set; }
    
        public virtual Authors Authors { get; set; }
        public virtual MisakBlogs MisakBlogs { get; set; }
    }
}
