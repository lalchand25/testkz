//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OLProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_SubjectMaster
    {
        public int SubjectId { get; set; }
        public string SubjectImge { get; set; }
        public string SubjectName { get; set; }
        public string SubjectDesc { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string IpAddress { get; set; }
        public Nullable<System.DateTime> SystemDate { get; set; }
        public string BigImage { get; set; }
        public Nullable<bool> Publish { get; set; }
        public string ShortDescription { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Duration { get; set; }
        public Nullable<int> CourseCategoryID { get; set; }
        public Nullable<bool> PublishAdmin { get; set; }
    }
}
