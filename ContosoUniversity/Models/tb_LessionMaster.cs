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
    
    public partial class tb_LessionMaster
    {
        public int LessionId { get; set; }
        public string LessionHeading { get; set; }
        public string LessionDesc { get; set; }
        public Nullable<int> SubHeadId { get; set; }
        public string imagePath { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<int> ClassId { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> TotalView { get; set; }
        public Nullable<int> Downloads { get; set; }
        public Nullable<int> Userid { get; set; }
        public string Ipaddress { get; set; }
        public Nullable<System.DateTime> SubmitDate { get; set; }
        public string Help { get; set; }
        public string Formulas { get; set; }
        public string UsefulTips { get; set; }
        public string Solution { get; set; }
        public string Question { get; set; }
        public string Tutorial { get; set; }
        public string SpeechText { get; set; }
        public Nullable<int> TeacherId { get; set; }
        public string IntroductionPage { get; set; }
        public string IfPass { get; set; }
        public string IfFail { get; set; }
        public string graphics { get; set; }
        public Nullable<int> PassingScore { get; set; }
        public string SlideImage { get; set; }
        public string SlideDescription { get; set; }
        public Nullable<bool> Publish { get; set; }
    }
}