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
    
    public partial class tb_ServiceMaster
    {
        public int ServiceID { get; set; }
        public string ServiceCategoryName { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
    }
}
