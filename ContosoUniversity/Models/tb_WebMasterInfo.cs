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
    
    public partial class tb_WebMasterInfo
    {
        public int ID { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string ContactNo { get; set; }
        public string Comments { get; set; }
        public Nullable<System.DateTime> SystemDate { get; set; }
        public string Category { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public string IPAddress { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public string DeleteStatus { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> ReplyDate { get; set; }
        public string ReplyComments { get; set; }
        public string ErrorImage { get; set; }
    }
}
