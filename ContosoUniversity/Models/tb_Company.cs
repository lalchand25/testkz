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
    
    public partial class tb_Company
    {
        public int CompanyID { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string CompName { get; set; }
        public string DispalyName { get; set; }
        public string Description { get; set; }
        public string Logopath { get; set; }
        public string Slogan { get; set; }
        public string Address { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNo { get; set; }
        public string Fax { get; set; }
        public string Cell { get; set; }
        public string Website { get; set; }
        public string ContactPerson { get; set; }
        public Nullable<bool> Terms { get; set; }
        public string IpAddress { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> ActiveStatus { get; set; }
        public string DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletionDate { get; set; }
    }
}
