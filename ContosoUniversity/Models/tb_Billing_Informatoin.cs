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
    
    public partial class tb_Billing_Informatoin
    {
        public int ID { get; set; }
        public string EmailID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Product_Cost { get; set; }
        public string Status { get; set; }
        public Nullable<int> EnquiryID { get; set; }
        public Nullable<System.DateTime> DateofPurchase { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public string DeleteStatus { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
        public Nullable<int> client { get; set; }
    }
}
