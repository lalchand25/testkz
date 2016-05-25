using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OLProject.Models;
using System.Net.Mail;


namespace OLProject.Models
{
    public static class emailSystem
    {

        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "abcdefghijk,znmxpowsldfjjdsfjfsdjmno123213pqrs123123tuvwxyzA12331BCDEFGHJKwerwer123123LMNOPQR333STUVWXY33333Z0123456789lkfdslksdf98234lks9843dsfj9043lkj330934KJFSFKLSFDSDFKLJHS982348342899324893894324LJKHFDSFDSFDS5lkj094538dfklhglkjfdsjlsfdlsdflsdlfklkjlkjdsflkjsdf";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }

            return new string(chars);
        }



        public static string emailerHeader()
        {
            String strheader = "";

            strheader += " <body>";

            strheader += "<div style='width:750px; margin:0 auto; border:3px solid #666; padding:20px 10px; border-radius:5px;'> ";

            strheader += "<table width='100%'>";
            strheader += "<tr>";
            strheader += " <td>  <img src='http://kzonline.org/SiteImages/site-logo.png' /> </td>";
            strheader += "<td colspan='2'><h1 style='font-size:26px; float:right; margin:0; font-family:Arial, Helvetica, sans-serif; font-weight:normal;  color:#e8424e;'>Welcome to Kin Zin Digital Media Inc</h1><h2 style='font-size:16px; float:right; margin:0; font-family:Arial, Helvetica, sans-serif; font-weight:normal;'>Your New Online Learning Management System</h2></td>";
            strheader += " </tr>";
            strheader += "<tr>";
            strheader += "  <td colspan='3'><hr style='border-top: dotted 1px;' /></td>";
            strheader += "</tr>";

            strheader += "<tr>";
            strheader += " <td colspan='3'>";

            return strheader;
        }

        public static string emailerFooter()
        {
            String strfooter = "";
            strfooter += " </td>";
            strfooter += " </tr>";
            strfooter += "  <tr>";
            strfooter += "  <td colspan='3'><img src='http://kzonline.org/SiteImages/online_courses.png' /></td>";
            strfooter += " </tr>";
            strfooter += "  <tr>";
            strfooter += "  <td colspan='3'><hr style='border-top: dotted 1px; margin:20px 0 0 0;' /></td>";
            strfooter += "  </tr>";
            strfooter += " <tr>";
            strfooter += "   <td colspan='3'><h1 style='font-size:28px; text-align:center; margin:10px 0 0px 0; font-family:Arial, Helvetica, sans-serif; font-weight:normal;  color:#e8424e;'>Online Courses from the World’s Top Publishers</h1><h2 style='font-size:20px; text-align:center; margin:0; font-family:Arial, Helvetica, sans-serif; font-weight:normal;'>Search for online courses on Web development, Project Management, Mobile Application, or anything else.</h2></td>";
            strfooter += " </tr>";
            strfooter += " </table>";
            strfooter += " </div>";
            strfooter += " </body>";
            return strfooter;

        }


        public static string emailHeader()
        {
            kzonlineEntities db = new kzonlineEntities();
            var model = db.tb_emailsDescription.ToList().Where(x => x.Autoid == 10).Single();

            String strheader = "<table cellspacing='0' cellpadding='0' width='100%' border='0' align='center' style='border-bottom:#9a9a9a 1px solid;border-left:#9a9a9a 1px solid;width:600px;border-top:#9a9a9a 1px solid;border-right:#9a9a9a 1px solid'>";
            strheader += "<tr><td style='padding-left:20px'><a target='_blank' href='http://www.gaganz.ca/'><img border='0' src='http://www.gaganz.ca/images/logo.jpg' alt=''></a></td>";
            strheader += "<td valign='top' align='right' style='padding-right:20px;padding-top:5px'><a target='_blank' href='http://www.gaganz.ca/login/LogOn' style='font:bold 11px arial;color:#D80303;text-decoration:none'>Login</a></td></tr>";

            return strheader;
        }

        public static string emailFooter()
        {

            String strFooter = "<tr><td style='padding-bottom:10px' colspan='2'><br />  Warm Regards,<br><b>Team Gaganz.com<br /></b></td></tr>";


            return strFooter;
        }
        public static void errorLog(string errodesc, string ipadress, string pagename, Int32 userid)
        {
            kzonlineEntities db = new kzonlineEntities();
            tb_realLogMaster tb = new tb_realLogMaster();
            tb.ErrorDesc = errodesc;
            tb.Ipaddress = ipadress;
            tb.PageName = pagename;
            tb.Userid = userid;
            tb.System = DateTime.Now;
            db.tb_realLogMaster.Add(tb);

            db.SaveChanges();

        }

        public static string sendNewFormat(String emailTo, string strSubject, string strbody)
        {
            string msg = "";
            try
            {

                kzonlineEntities db = new kzonlineEntities();

                //emailHeader
                var model = db.tb_emailsDescription.ToList().Where(x => x.Autoid == 17).Single();
                //emailFooter
                var model1 = db.tb_emailsDescription.ToList().Where(x => x.Autoid == 18).Single();

                string strbody1 = model.Description + "<br />";
                strbody1 += strbody + "<br />";
                strbody1 += model1.Description;

                strbody1 = emailerHeader() + strbody1 + emailerFooter();
                                


                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                //System.Net.NetworkCredential cred = new System.Net.NetworkCredential("support@goonlineschool.com", "sup123");
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential("info@kzonline.org", "Admin@1234#");

                mail.To.Add(emailTo);
                mail.Subject = strSubject;

                mail.From = new System.Net.Mail.MailAddress("info@kzonline.org");
                mail.Bcc.Add(new MailAddress("ceo@gaganz.com"));
                //mail.Bcc.Add(new MailAddress("support@goonlineschool.com"));
                mail.Bcc.Add(new MailAddress("lal@gaganz.com"));

                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Body = strbody1;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
                //03/05/2016 System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtpout.secureserver.net");
                smtp.Port = 25;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = cred;
                smtp.EnableSsl = false;
           
                smtp.Send(mail);

                msg = "Success";
                emailSystem.errorLog(emailTo + "->" + strSubject, "- Success", "sendNewFormat", 0);
            }
            catch (Exception ce)
            {
                msg = ce.Message;
                emailSystem.errorLog(emailTo + "->" + strSubject, " - Error : " + msg.Substring(1, 20), "sendNewFormat", 0);
            }

            return msg;
        }

        public static string sendNewFormat2(String emailTo, string strSubject, string strbody)
        {
            string msg = "";
            try
            {

                kzonlineEntities db = new kzonlineEntities();

                //emailHeader
                var model = db.tb_emailsDescription.ToList().Where(x => x.Autoid == 17).Single();
                //emailFooter
                var model1 = db.tb_emailsDescription.ToList().Where(x => x.Autoid == 18).Single();
                string strbody1 = model.Description + "<br />";
                strbody1 += strbody + "<br />";
                strbody1 += model1.Description;


                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential("support@goonlineschool.com", "sup123");

                mail.To.Add(emailTo);
                mail.Subject = strSubject;

                mail.From = new System.Net.Mail.MailAddress("no-reply@goonlineschool.com.com");
                mail.Bcc.Add(new MailAddress("ceo@gaganz.com"));
                //mail.Bcc.Add(new MailAddress("support@goonlineschool.com"));
                mail.Bcc.Add(new MailAddress("lal@gaganz.com"));

                mail.Priority = MailPriority.High;
                mail.IsBodyHtml = true;
                mail.Body = strbody1;

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("relay-hosting.secureserver.net");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = cred;
                smtp.EnableSsl = false;
                smtp.Port = 25;
                smtp.Send(mail);

                msg = "Success";
                emailSystem.errorLog(emailTo + "->" + strSubject, "- Success", "sendNewFormat", 0);
            }
            catch (Exception ce)
            {
                msg = ce.Message;
                emailSystem.errorLog(emailTo + "->" + strSubject, " - Error : " + msg.Substring(1, 20), "sendNewFormat", 0);
            }

            return msg;
        }
    }
}

