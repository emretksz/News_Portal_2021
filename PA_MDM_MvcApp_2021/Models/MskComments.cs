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
    
    public partial class MskComments
    {
        public int MskCommentId { get; set; }
        public string MskComment { get; set; }
        public string MskGuestName { get; set; }
        public string MskMail { get; set; }
        public bool IsReply { get; set; }
        public System.DateTime RegsiterDate { get; set; }
        public int MisakBlogId { get; set; }
    
        public virtual MisakBlogs MisakBlogs { get; set; }
    }
}