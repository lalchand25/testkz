using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OLProject.Models;
namespace OLProject.Models
{
    public class DataRepository
    {
        kzonlineEntities db = new kzonlineEntities();

        public IQueryable<LessonInformation> LessonList()
        {
            var searchResults = (from m in db.tb_LessionMaster
                                 from t in db.tb_SubjectMaster
                                 from p in db.tb_ClassMaster
                                 from h in db.tb_UnitMaster
                                 where m.SubjectId == t.SubjectId 
                                 && p.ClassesId == m.ClassId && h.UnitId == m.UnitId
                                 orderby m.LessionId ascending
                                 select new LessonInformation
                                 {
                                     LessonName = m.LessionHeading,
                                     SubjectName = t.SubjectName,
                                     ClassName = p.ClassName,
                                     LessonId = m.LessionId,
                                     UnitName = h.UnitName
                                 }).AsQueryable();

            return searchResults;
        }
    }
}