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
    
    public partial class MdmComments
    {
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public string GuestName { get; set; }
        public string GuestMail { get; set; }
        public int IsReply { get; set; }
        public int MdmId { get; set; }
        public  Nullable <int> UserId { get; set; }
    
        public virtual MdmBlogs MdmBlogs { get; set; }
        public virtual Users Users { get; set; }
    }
}
