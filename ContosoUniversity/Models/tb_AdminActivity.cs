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
    
    public partial class tb_AdminActivity
    {
        public long LogID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string PageName { get; set; }
        public string Description { get; set; }
        public string IpAddress { get; set; }
        public Nullable<System.DateTime> SystemDate { get; set; }
    }
}