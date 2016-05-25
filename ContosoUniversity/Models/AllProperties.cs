using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLProject.Models
{
    
        
    public class LessonInformation
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 LessonId { get; set; }
        public Int32 ClassId { get; set; }
        public string LessonName { get; set; }
        public string UnitName { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }


    }

    public class QuizInformation
    {
        public Int32 QuizId { get; set; }
        public string Decription { get; set; }
        public string Ans1 { get; set; }
        public string Ans2 { get; set; }
        public string Ans3 { get; set; }
        public string Ans4 { get; set; }
        public string ImagePath { get; set; }
        public Int32 UserAns { get; set; }
        public Int32 ComputerAns { get; set; }
        public Int32 QuesTypeId { get; set; }
        public Boolean Check1 { get; set; }
        public Boolean Check2 { get; set; }
        public Boolean Check3 { get; set; }
        public Boolean Check4 { get; set; }

        

    }



}