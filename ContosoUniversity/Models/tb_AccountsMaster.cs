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
    
    public partial class tb_AccountsMaster
    {
        public int ID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Type { get; set; }
        public Nullable<int> Code { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DebitorCreditor { get; set; }
        public Nullable<int> UserID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public string DeleteStatus { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
    }
}
