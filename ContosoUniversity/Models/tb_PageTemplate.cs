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
    
    public partial class tb_PageTemplate
    {
        public int Pageid { get; set; }
        public string PageName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Nullable<int> SetModuleID { get; set; }
        public Nullable<int> PosId { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public string DeleteStatus { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
    }
}
