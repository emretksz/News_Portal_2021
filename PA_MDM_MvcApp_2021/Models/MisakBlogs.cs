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
    
    public partial class MisakBlogs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MisakBlogs()
        {
            this.MskComments = new HashSet<MskComments>();
            this.MisakTags = new HashSet<MisakTags>();
        }
    
        public int MisakBlogId { get; set; }
        public string Tilte { get; set; }
        public string SubTitle { get; set; }
        public string ImageURL { get; set; }
        public int MisakCategoryId { get; set; }
        public int MisakLocationId { get; set; }
        public bool IsAcitive { get; set; }
        public System.DateTime RegisterDate { get; set; }
    
        public virtual MisakBlogDetails MisakBlogDetails { get; set; }
        public virtual MisakCategories MisakCategories { get; set; }
        public virtual MisakLocations MisakLocations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MskComments> MskComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MisakTags> MisakTags { get; set; }
    }
}