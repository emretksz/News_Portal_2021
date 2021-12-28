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
    
    public partial class MdmBlogs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MdmBlogs()
        {
            this.MdmComments = new HashSet<MdmComments>();
            this.Tags = new HashSet<Tags>();
        }
    
        public int MdmId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime RegisterDate { get; set; }
    
        public virtual MdmBlogDetails MdmBlogDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MdmComments> MdmComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tags> Tags { get; set; }
        public virtual MdmCategories MdmCategories { get; set; }
    }
}