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
    
    public partial class Announcements
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public bool IsActvie { get; set; }
        public System.DateTime RegisterDate { get; set; }
    }
}