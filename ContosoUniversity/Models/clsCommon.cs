using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace OLProject.Models
{



    public static class clsCommon
    {
        public static int GetWeekNumber(DateTime dtPassed)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        public static void SetCookie(string name, string value)
        {
            HttpCookie myCookie = new HttpCookie(name);
            myCookie.Value = value;
            myCookie.Expires.Date.AddDays(7);
            //   HttpContext.Current.Response.Cookies.Add(myCookie);
            HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(true);

            HttpContext.Current.Response.Cookies.Add(myCookie);
        }

        public static HttpCookie GetCookie(string name)
        {
            return HttpContext.Current.Request.Cookies[name];
        }


        public static void SetCookie2(string name, string value)
        {
            HttpCookie myCookie = new HttpCookie(name);
            myCookie.Value = value;
            myCookie.Expires.Date.AddDays(7);
            //   HttpContext.Current.Response.Cookies.Add(myCookie);
            HttpContext.Current.Response.Cache.SetAllowResponseInBrowserHistory(true);

            HttpContext.Current.Response.Cookies.Add(myCookie);
        }

        public static HttpCookie GetCookie2(string name)
        {
            return HttpContext.Current.Request.Cookies[name];
        }
        public static string getHeader(Int32 TaskId)
        {
            string result = "";
            string result1 = "";
            string result2 = "";

            result1 += "<thead>";
            result1 += "<tr>";
            result2 += "<thead>";
            result2 += "<tr>";

            kzonlineEntities db = new kzonlineEntities();
            var model1 = (from m in db.tb_HeaderMaster
                          from t in db.tb_HeaderDetail
                          where t.HeaderId == m.AutoId && t.TaskId == TaskId
                          select new
                          {

                              m.HeadingName,
                              m.HeadingImage,
                              t.AutoId
                          }).OrderBy(x => x.AutoId);
            int i = 0;
            foreach (var item in model1)
            {
                if (i == 0)
                {
                    result1 += "<th width='20%'><div align='left'><img src='../../Uploads/" + item.HeadingImage + "' width='50' height='50' /></div></th>";
                    result2 += "<th width='20%'><div align='left'>" + item.HeadingName + "</div></th>";
                    i += 1;
                }
                else
                {
                    result1 += "<th width='20%'><div align='center'><img src='../../Uploads/" + item.HeadingImage + "' width='50' height='50' /></div></th>";
                    result2 += "<th width='20%'><div align='center'>" + item.HeadingName + "</div></th>";
                }


            }

            result1 += "</tr>";
            result1 += "</thead>";
            result2 += "</tr>";
            result2 += "</thead>";

            result = result1 + result2;
            return result;

        }
        public static string getHeaderWithoutImages(Int32 TaskId)
        {
            string result = "";
            string result1 = "";
            string result2 = "";

            result1 += "<thead>";
            result1 += "<tr>";
            result2 += "<thead>";
            result2 += "<tr>";

            kzonlineEntities db = new kzonlineEntities();
            var model1 = (from m in db.tb_HeaderMaster
                          from t in db.tb_HeaderDetail
                          where t.HeaderId == m.AutoId && t.TaskId == TaskId
                          select new
                          {

                              m.HeadingName,
                              m.HeadingImage,
                              t.AutoId
                          }).OrderBy(x => x.AutoId);
            int i = 0;
            foreach (var item in model1)
            {
                if (i == 0)
                {
                   // result1 += "<th width='20%'><div align='left'><img src='../../Uploads/" + item.HeadingImage + "' width='50' height='50' /></div></th>";
                    result2 += "<th ><div align='left'>" + item.HeadingName + "</div></th>";
                    i += 1;
                }
                else
                {
                   // result1 += "<th width='20%'><div align='center'><img src='../../Uploads/" + item.HeadingImage + "' width='50' height='50' /></div></th>";
                    result2 += "<th ><div align='center'>" + item.HeadingName + "</div></th>";
                }


            }

            result1 += "</tr>";
            result1 += "</thead>";
            result2 += "</tr>";
            result2 += "</thead>";

          //  result = result1 + result2;
              result =  result2;

            return result;

        }
        public static string getCountryName(Int32 CountryID)
        {
            string result = "Not found";
            if (CountryID != null)
            {
                if (CountryID > 0)
                {
                    kzonlineEntities db = new kzonlineEntities();
                    var model1 = (from m in db.tb_CountryMaster
                                  where m.CountryID == CountryID
                                  select m);
                    if (model1.Count() > 0)
                    {
                        var model = (from m in db.tb_CountryMaster
                                     where m.CountryID == CountryID
                                     select m).Single();
                        result = model.CountryName;
                    }
                }
            }
            return result;
        }
        public static string getStateName(Int32 Id)
        {
            string result = "Not Found!";
            if (Id != null)
            {
                if (Id > 0)
                {
                    kzonlineEntities db = new kzonlineEntities();
                    var model1 = db.tb_StateMaster.ToList().Where(m => m.StateID == Id);
                    if (model1.Count() > 0)
                    {
                        var model = db.tb_StateMaster.ToList().Where(m => m.StateID == Id).Single();
                        result = model.StateName;
                    }
                }
            }
            return result;
        }

        public static string getDistrictName(Int32 Id)
        {
            string result = "Not found";
            if (Id != null)
            {
                if (Id > 0)
                {
                    kzonlineEntities db = new kzonlineEntities();

                    var model1 = db.tb_CityMaster.ToList().Where(m => m.CityID == Id);
                    if (model1.Count() > 0)
                    {
                        var model = db.tb_CityMaster.ToList().Where(m => m.CityID == Id).Single();
                        result = model.CityName;
                    }
                }
            }
            return result;
        }

        public static string getPageingInformation(Int32 PageNo, Int32 TotalPage, String UrlString)
        {
            String pageLinks = "Pages :";
            for (Int32 i = 1; i <= TotalPage; i++)
            {
                if (i == PageNo)
                {
                    pageLinks += " [<a href='" + UrlString + "?pageno=" + (i) + "' /><b>" + i.ToString() + "</b></a>]&nbsp;";
                }
                else
                {
                    pageLinks += " [<a href='" + UrlString + "?pageno=" + (i) + "' />" + i.ToString() + "</a>]&nbsp;";
                }
            }
            return pageLinks;
        }


        public static string getPageingInformationNew(Int32 PageNo, Int32 TotalPage, String UrlString)
        {
            kzonlineEntities db = new kzonlineEntities();
            string imagepath = "";
            String pageLinks = "";
            String BtnNext = "";
            String BtnPrevious = "";
            String BtnLast = "";
            String BtnFirst = "";

            //First Page
            var model = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == 15).Single();
            if (PageNo <= (TotalPage - 1))
            {
                imagepath = model.ImagePath;
//                BtnNext = "<a  style='float:right;' class='btn-grey' href='" + UrlString + "?pageno=" + (PageNo + 1) + "' /><img  width='60px' height='60px' src='../../uploads/" + imagepath + "' /><br />" + model.ButtonName + "</a>";

                BtnNext = " <li><a href='" + UrlString + "?pageno=" + (PageNo + 1) + "'><i class='fa fa-arrow-right' style='color:#61b74b;'></i>Next</a></li>";
            }
            else
            {
                imagepath = model.ImagePath1;
                //BtnNext = "<a  style='float:right;' class='btn-grey' href='" + UrlString + "?pageno=" + (PageNo + 1) + "' /><img  width='60px' height='60px' src='../../uploads/" + imagepath + "' /><br />" + model.ButtonName + "</a>";
                BtnNext = " <li><a href='" + UrlString + "?pageno=" + (PageNo + 1) + "'><i class='fa fa-arrow-right' style='color:#61b74b;'></i>Next</a></li>";


            }


            var model1 = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == 16).Single();
            var model2 = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == 18).Single();
            var model3 = db.tb_ButtonMaster.ToList().Where(x => x.ButtonId == 17).Single();
            if (PageNo > 1)
            {
                imagepath = model1.ImagePath;
                //Previous
              //  BtnPrevious = "<a  style='float:right;' class='btn-grey' href='" + UrlString + "?pageno=" + (PageNo - 1) + "' /><img  width='60px' height='60px' src='../../uploads/" + imagepath + "' /><br />" + model1.ButtonName + "</a>";
                BtnPrevious = "<li><a href='" + UrlString + "?pageno=" + (PageNo - 1) + "'><i class='fa fa-arrow-left' style='color:#61b74b;'></i>Previous </a></li>";

                if (TotalPage > 0)
                {
                    imagepath = model2.ImagePath;
                    //Last Page
                   // BtnLast = "<a style='float:right;' class='btn-grey' href='" + UrlString + "?pageno=" + TotalPage + "' /> <img  width='60px' height='60px' src='../../uploads/" + imagepath + "' /><br />" + model2.ButtonName + "</a>";
                    BtnLast = "<li><a href='" + UrlString + "?pageno=" + TotalPage + "'><i class='fa fa-step-forward' style='color:#de574c;'></i>Last</a></li>";

                    //First Page
                    imagepath = model3.ImagePath;
                    //BtnFirst = "<a style='float:right;' class='btn-grey' href='" + UrlString + "?pageno=1' /><img  width='60px' height='60px' src='../../uploads/" + imagepath + "' /><br />" + model3.ButtonName + "</a>";

                    BtnFirst = "  <li><a href='" + UrlString + "?pageno=1' /><i class='fa fa-step-backward'  style='color:#de574c;'></i>First</a></li>";

                }
            }

                //        @*  <li class="active"><a href="#web" data-toggle="tab"><i class="fa fa-bullhorn"></i>Speach</a></li>
                //<li><a href="#music" data-toggle="tab"><i class="fa fa-sign-out"></i>Quit</a></li>
                //<li><a href="#math" data-toggle="tab"><i class="fa fa-arrow-right"></i>Next</a></li>
                //<li><a href="#Production" data-toggle="tab"><i class="fa fa-arrow-left"></i>Previous </a></li>
                //<li><a href="#Photography" data-toggle="tab"><i class="fa fa-step-forward"></i>First</a></li>
                //<li><a href="#Geography" data-toggle="tab"><i class="fa fa-step-backward"></i>Last</a></li>*@

            else
            {
                imagepath = model1.ImagePath1;
                //BtnPrevious = "<a  style='float:right;' class='btn-grey' href='javascript:alert(&#34;Nothing&#34;)' /><img  width='60px' height='60px' src='../../uploads/" + imagepath + "' /><br />" + model1.ButtonName + "</a>";
                BtnPrevious = "<li><a href='javascript:alert(&#34;Nothing&#34;)'><i class='fa fa-arrow-left' style='color:#61b74b;'></i>Previous </a></li>";

                if (TotalPage > 0)
                {
                    imagepath = model2.ImagePath1;
                   // BtnLast = "<a style='float:right;' class='btn-grey' href='javascript:alert(&#34;Nothing&#34;)' /><img  width='60px' height='60px' src='../../uploads/" + imagepath + "' /><br />" + model2.ButtonName + "</a>";
                    BtnLast = "<li><a href='javascript:alert(&#34;Nothing&#34;)'><i class='fa fa-step-forward'  style='color:#de574c;'></i>Last</a></li>";


                    imagepath = model3.ImagePath1;
                    //BtnFirst = "<a style='float:right;' class='btn-grey' href='javascript:alert(&#34;Nothing&#34;)' /> <img  width='60px' height='60px' src='../../uploads/" + imagepath + "' /><br />" + model3.ButtonName + "</a>";
                    BtnFirst = "  <li><a href='javascript:alert(&#34;Nothing&#34;)' /><i class='fa fa-step-backward'  style='color:#de574c;'></i>First</a></li>";

                }

            }

            pageLinks = BtnFirst + BtnLast + BtnPrevious + BtnNext;
            return pageLinks;
        }

        public static string ErrorMessage(Int32 id)
        {
            String errorMsg = "";
            if (id == 1) //Create Record
            { errorMsg = "Record Create Successfully"; }
            if (id == 2) //Edit Record
            { errorMsg = "Record Update Successfully"; }
            if (id == 3) //Delete Record
            { errorMsg = "Record Delete Successfully"; }
            if (id == 4) //Delete Record
            { errorMsg = "Data Found in detail table, You can't  delete this"; }
            if (id == 5) //Delete Record
            { errorMsg = "Permissoion Created"; }

            return errorMsg;

        }
        public static string getSubjectName(Int32 SubjectId)
        {
            string result = "Not Found";

            kzonlineEntities db = new kzonlineEntities();
            if (SubjectId > 0)
            {
                var model1 = db.tb_SubjectMaster.ToList().Where(x => x.SubjectId == SubjectId);
                if (model1.Count() > 0)
                {
                    var model = db.tb_SubjectMaster.ToList().Where(x => x.SubjectId == SubjectId).Single();
                    result = model.SubjectName.ToString();
                }
            }
            return result;
        }

        public static string getClassName(Int32 ClassId)
        {
            string result = "Not Found";
            if (ClassId > 0)
            {
                kzonlineEntities db = new kzonlineEntities();
                var model = db.tb_ClassMaster.ToList().Where(x => x.ClassesId == ClassId).Single();
                result = model.ClassName;
            }
            return result;
        }
        public static string getClassNameProduct(Int32 ClassId)
        {
            string result = "Not Found";
            if (ClassId > 0)
            {
                kzonlineEntities db = new kzonlineEntities();
              //  var model1 = db.tb_ClassMaster.ToList().Where(x => x.ClassesId == ClassId).Single();
              //  var model = db.tb_ProductClassMaster.ToList().Where(x => x.AutoId == model1.ClassId).Single();
               // result = model.ClassName;
            }
            return result;
        }
        public static string getUnitName(Int32 UnitId)
        {
            string result = "Not Found";
            if (UnitId > 0)
            {
               // kzonlineEntities db = new kzonlineEntities();
               // var model = db.tb_UnitMaster.ToList().Where(x => x.UnitId == UnitId).Single();
               // result = model.UnitName;
            }
            return result;
        }
        public static string getUserName(Int32 UserId)
        {
            string result = "Not Found";
            if (UserId > 0)
            {
                kzonlineEntities db = new kzonlineEntities();
                var model = db.tb_UserMaster.ToList().Where(x => x.UserId == UserId).Single();
                result = model.ProfileName;
            }
            return result;
        }

        public static string getUserName1(Int32 UserId)
        {
            string result = "Not Found";
            if (UserId > 0)
            {
                kzonlineEntities db = new kzonlineEntities();
                var model = db.tb_UserMaster.ToList().Where(x => x.UserId == UserId).Single();
                result = model.UserName;
            }
            return result;
        }
        public static string getLessonName(Int32 LessonId)
        {
            string result = "Not Found";
            if (LessonId > 0)
            {
                kzonlineEntities db = new kzonlineEntities();
                var model = db.tb_LessionMaster.ToList().Where(x => x.LessionId == LessonId).Single();
                result = model.LessionHeading;
            }
            return result;
        }
        // 09/01/2014
        public static string getTabHome()
        {
            kzonlineEntities db = new kzonlineEntities();
            string result = "";
            result += "<li><a href='/Home'> Home </a></li>";
            var model = db.tb_ApplicationPage.ToList().Where(x => x.UseAsMenu == true);
            foreach (var item1 in model)
            {
                //result += "<li><img src='../../images/nav_separator.png' /></li>";
                result += "<li><a href='/" + item1.MvcUrl + "'>" + item1.Title + "</a></li>";
                result += " <li>| </li> ";
            }

            return result;
        }


        public static string getTab(Int32 userid, Int32 selectedInt)
        {
            if (selectedInt == null)
            {
                selectedInt = 0;
            }
            kzonlineEntities db = new kzonlineEntities();

            var item = (from m in db.tb_TaskMaster
                        from t in db.tb_TaskDetail
                        from mm in db.tb_ModuleMaster
                        where m.TaskID == t.TaskID && m.ModuleID == mm.ModuleId
                        && t.UserID == userid
                        && m.status == true
                        group mm by new { mm.ModuleId, mm.ModuleName, mm.Displayorderno } into g
                        orderby g.Key.Displayorderno, g.Key.ModuleId descending
                        select new
                        {
                            g.Key.ModuleId,
                            g.Key.ModuleName
                        });

            string result = "";

            if (selectedInt == 0)
            {
                //result += "<li><img src='../../images/nav_separator.png' /></li>";

                result += "<li><a class='selected' href='/Home'>Home</a><li>";
                result += " <li>| </li> ";
            }
            else
            {
                //result += "<li><img src='../../images/nav_separator.png' /></li>"; 
                result += "<li><a href='/Home'>Home</a><li>";
                result += " <li>| </li> ";
            }

            if (item.Count() > 0)
            {
                foreach (var tt in item)
                {
                    if (selectedInt == tt.ModuleId)
                    {
                        //result += "<li><img src='../../images/nav_separator.png' /></li>"; 
                        result += "<li><a class='selected' href='/profile/profile/" + tt.ModuleId + "'>" + tt.ModuleName + "</a><li>";
                        result += " <li>| </li> ";
                    }
                    else
                    {
                        //result += "<li><img src='../../images/nav_separator.png' /></li>";
                        result += "<li><a href='/profile/profile/" + tt.ModuleId + "'>" + tt.ModuleName + "</a><li>";
                        result += " <li>| </li> ";
                    }
                }
            }
            else
            {
                var model = db.tb_ApplicationPage.ToList().Where(x => x.UseAsMenu == true);
                foreach (var item1 in model)
                {
                    //result += "<li><img src='../../images/nav_separator.png' /></li>";
                    result += "<li><a href='/" + item1.MvcUrl + "'>" + item1.Title + "</a></li>";
                    result += " <li>| </li> ";
                }
                //result += "<li><img src='../../images/nav_separator.png' /></li>";
                //result += "<li><a href='/home/aboutus'>About Us</a></li>";
                //result += "<li><img src='../../images/nav_separator.png' /></li>";
                //result += "<li><a href='/home/Subjects'>Subjects </a></li>";
                //result += "<li><img src='../../images/nav_separator.png' /></li>";
                //result += "<li><a href='/home/Tutor'>Tutor Services</a></li>";
                //result += "<li><img src='../../images/nav_separator.png' /></li>";
                //result += "<li><a href='/home/Schools'>Schools</a></li>";
                //result += "<li><img src='../../images/nav_separator.png' /></li>";
                //result += "<li><a href='/home/contactus'>Contact Us</a></li>";
                //result += "<li style='float:right; padding:6px 15px 0px 0px;'><input class='search' type='text' /><input class='srch' type='button' value='' /></li>";
            }
            return result;

        }

        //21/11/2015 default at the time of login or confirmaiton

        public static string  SetDefaultPermissions(Int32 userTypeid, Int32 userid)
        {
            kzonlineEntities db = new kzonlineEntities();
            var detail = from m in db.tb_DefaultPermission
                         where m.CategoryId == userTypeid
                         select m;



            foreach (var item in detail)
            {

                var already = from m in db.tb_TaskDetail where m.UserID == userid && m.TaskID == item.TaskId select m;
                if (already.Count() > 0)
                {
                }
                else
                {
                    tb_TaskDetail sb = new tb_TaskDetail();
                    sb.UserID = Convert.ToInt32(userid);
                    sb.TaskID = Convert.ToInt32(item.TaskId);
                    sb.ModuleID = item.ModuleId;
                    db.tb_TaskDetail.Add(sb);
                    db.SaveChanges();
                }
            }





            return "string";





        }
        public static string GetSlides(Int32 LessonId, Int32 MenuId1)
        {
            kzonlineEntities db = new kzonlineEntities();
            var item = (from m in db.tb_LessionMaster
                        from t in db.tb_LessionMasterSlides
                        where m.LessionId == t.LessionId && m.LessionId == LessonId
                        select t);
            string result = "";
            int mcnt = 0;
            Int32 totaldays = DateTime.Now.Day;
            foreach (var tt in item)
            {
                mcnt += 1;
                if (tt.AutoId == MenuId1)
                {
                    result += "<li><b><a href='/SlideShow/Index/" + tt.AutoId + "?menuid=" + tt.AutoId + "'>" + tt.SlideDescription + "</a></b></li>";
                }
                else
                {
                    result += "<li><a href='/SlideShow/Index/" + tt.AutoId + "?menuid=" + tt.AutoId + "'>" + tt.SlideDescription + "</a></li>";
                }
            }
            return result;

        }


        public static void setUserHistory(Int32 userid, Int32 Subjectid, Int32 Classid, Int32 LessonId, Int32 SlideId, Int32 QuizId, Int32 UnitId, String iPAddress)
        {
            kzonlineEntities db = new kzonlineEntities();
            tb_UserLoginHistory model = new tb_UserLoginHistory();
            model.UserId = userid;
            model.SubjectId = Subjectid;
            model.ClassId = Classid;
            model.LessonId = LessonId;
            model.QuizId = QuizId;
            model.SlideId = SlideId;
            model.UnitId = UnitId;
            model.IpAdress = iPAddress;
            model.SystemDate = DateTime.Now;
            model.SystemTime = DateTime.Now.TimeOfDay.ToString();
            db.tb_UserLoginHistory.Add(model);
            db.SaveChanges();
        }

        public static void setUserPageAccessHistory(Int32 userid, String remarks, String iPAddress, String PageName)
        {
            kzonlineEntities db = new kzonlineEntities();
            tb_UserPageHistory model = new tb_UserPageHistory();

            model.UserID = userid;
            model.IpAddress = iPAddress;
            model.PageName = PageName;
            model.Remarks = remarks;
            model.AccessDate = DateTime.Now;
            db.tb_UserPageHistory.Add(model);

            db.SaveChanges();
        }

        public static string getTaskList(Int32 moduleid, Int32 userid, Int32 menuid)
        {
            kzonlineEntities db = new kzonlineEntities();

            var item = (from m in db.tb_TaskMaster
                        from t in db.tb_TaskDetail
                        from mm in db.tb_ModuleMaster
                        where m.TaskID == t.TaskID && m.ModuleID == mm.ModuleId
                        && m.ModuleID == moduleid
                          && t.UserID == userid
                        && m.status == true
                        orderby m.DispOrder
                        select m);

            string result = "<ul class='profile'>";
            string result1 = "<ul class='profile'>";
            int mcnt = 0;
            int balt = 0;
            string imagelink1 = "";
            string imagelink2 = "";
            imagelink1 = "<img src='../../uploads/inmouse.png' width='8px' height='8px' />";
            foreach (var tt in item)
            {
                mcnt += 1;
                balt = mcnt % 2;
                //dECS D-IILECS-BIRLA SUN MF-TXBS8825146
                if (tt.image == null)
                {
                    imagelink2 = "5.png";
                }
                else
                {
                    imagelink2 = tt.image;
                }
                if (balt == 0)
                {
                    result += "<li><a href='/" + tt.urlmvc + "?menuid=" + tt.TaskID + "'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr>";
                    result += "<td width='15%' align='left' valign='top'><img src='../../uploads/" + imagelink2 + "' width='48' height='48' /></td>";
                    result += "<td width='85%'><h4>" + tt.TaskName + "</h4> <p> " + tt.TaskDesc + "<a href='javascript:OpenPopup(&#34;/TaskMaster/popup/" + tt.TaskID + "&#34;);'>  ?</a> </p></td>";
                    result += "</tr></table></a></li>";
                }

                if (balt > 0)
                {
                    result1 += "<li><a href='/" + tt.urlmvc + "?menuid=" + tt.TaskID + "'><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr>";
                    result1 += "<td width='15%' align='left' valign='top'><img src='../../uploads/" + imagelink2 + "' width='48' height='48' /></td>";
                    result1 += "<td width='85%'><h4><a href='/" + tt.urlmvc + "?menuid=" + tt.TaskID + "'>" + tt.TaskName + "</a></h4><p>" + tt.TaskDesc + "<a href='javascript:OpenPopup(&#34;/TaskMaster/popup/" + tt.TaskID + "&#34;);'>  ?</a></p></td>";
                    result1 += "</tr></table></a></li>";
                }
            }

            result += "</ul>";
            result1 += "</ul>";
            return result1 + result;

        }
        public static string getTaskListNew(Int32 moduleid, Int32 userid, Int32 menuid)
        {
            kzonlineEntities db = new kzonlineEntities();
            var item = (from m in db.tb_TaskMaster
                        from t in db.tb_TaskDetail
                        from mm in db.tb_ModuleMaster
                        where m.TaskID == t.TaskID && m.ModuleID == mm.ModuleId
                        && t.UserID == userid
                        && m.ModuleID == moduleid
                        && m.status == true
                        orderby m.DispOrder
                        select m);


            string result = "";

            int mcnt = 0;

            string imagelink = "";


            Int32 totaldays = DateTime.Now.Day;

            foreach (var tt in item)
            {
                mcnt += 1;

                if (tt.CreationDate.Value.AddDays(5) > DateTime.Now)
                {
                    imagelink = "<br /><img src='../../images/newtask.gif' />";
                }
                else
                {
                    imagelink = "";
                }
                imagelink = "";

                if (tt.TaskID == menuid)
                {
                    result += "<li>" + imagelink + "<b><a href='/" + tt.urlmvc + "?menuid=" + tt.TaskID + "'>" + tt.TaskName + "</a></b></li>";
                }
                else
                {
                    result += "<li>" + imagelink + "<a href='/" + tt.urlmvc + "?menuid=" + tt.TaskID + "'>" + tt.TaskName + "</a></li>";
                }

            }

            result += " <li><a href='/login/LogOff'><i class='fa fa-laptop'></i> Logoff" + "<i class='fa arrow'></i></a> </li>";

            return result;

        }

        public static string getLeftTaskListNew(Int32 userid)
        {
            //kzonlineEntities db = new kzonlineEntities();
            //var item = (from m in db.tb_TaskMaster
            //            from t in db.tb_TaskDetail
            //            from mm in db.tb_ModuleMaster
            //            where m.TaskID == t.TaskID && m.ModuleID == mm.ModuleId
            //            && t.UserID == userid
            //            && m.status == true
            //            orderby m.DispOrder
            //            select m);


            //string result = "";

            //int mcnt = 0;

            //string imagelink = "";


            //Int32 totaldays = DateTime.Now.Day;

            //foreach (var tt in item)
            //{
            //    mcnt += 1;

            //    if (tt.CreationDate.Value.AddDays(5) > DateTime.Now)
            //    {
            //        imagelink = "<br /><img src='../../images/newtask.gif' />";
            //    }
            //    else
            //    {
            //        imagelink = "";
            //    }
            //    imagelink = "";

            //    //if (tt.TaskID == menuid)
            //    //{
            //    //    result += "<li>" + imagelink + "<b><a href='/" + tt.urlmvc + "?menuid=" + tt.TaskID + "'>" + tt.TaskName + "</a></b></li>";
            //    //}
            //    //else
            //    //{
            //        result += "<li>" + imagelink + "<a href='/" + tt.urlmvc + "?menuid=" + tt.TaskID + "'>" + tt.TaskName + "</a></li>";
            //    //}

            //}
            //return result;



            linqDataDataContext dblinq = new linqDataDataContext();
            var tbModule = (from m in dblinq.vwTaskDetails orderby m.Displayorderno where m.UserID == userid select new { m.ModuleId, m.Displayorderno, m.ModuleName }).Distinct();
            string result = "";
            foreach (var ttMo in tbModule)
            {

                result += " <li><a href='#'><i class='fa fa-laptop'></i> " + ttMo.ModuleName + "<i class='fa arrow'></i></a>";
                result += "   <ul class='nav nav-second-level'>";

                var tb = from m in dblinq.vwTaskDetails orderby m.DispOrder where m.UserID == userid && m.ModuleId == ttMo.ModuleId select m;

                foreach (var ttTask in tb)
                {

                    result += "<li><a href='/" + ttTask.urlmvc + "'>" + ttTask.TaskName + "</a><li>";


                }
                result += " </ul>";

            }
            result += " <li><a href='/login/LogOff'><i class='fa fa-laptop'></i> Logoff" + "<i class='fa arrow'></i></a> </li>";
            return result;

        }
    }
}