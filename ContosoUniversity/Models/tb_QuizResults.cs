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
    
    public partial class tb_QuizResults
    {
        public int AutoId { get; set; }
        public Nullable<int> QuestionId { get; set; }
        public Nullable<int> TestId { get; set; }
        public Nullable<bool> check1 { get; set; }
        public Nullable<bool> check2 { get; set; }
        public Nullable<bool> check3 { get; set; }
        public Nullable<bool> check4 { get; set; }
        public Nullable<bool> Check5 { get; set; }
        public Nullable<bool> Check6 { get; set; }
        public Nullable<int> ActualAns { get; set; }
        public Nullable<int> Answer { get; set; }
        public Nullable<int> Userid { get; set; }
        public string SessionId { get; set; }
        public Nullable<System.DateTime> SystemDate { get; set; }
    }
}
