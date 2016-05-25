using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
using OLProject.Models;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace OLProject.Controllers
{
    public class SpeechController : Controller
    {
        //
        // GET: /Speech/

        public ActionResult Index()
        {
             
            //if (Request.HttpMethod == "POST")
            //{
            //    //string result = Request.Form["subject"];
            //    //SpVoice objspeach = new SpVoice();
            //    //objspeach.Speak(result, SpeechVoiceSpeakFlags.SVSFDefault); objspeach.WaitUntilDone(Timeout.Infinite);
            //}
            //SpVoice v = new SpVoice();
            //SpeechLib.SpFileStream speechStream = new SpeechLib.SpFileStream();
            //speechStream.Open(Server.MapPath("~/uploads/test.wav"), SpeechLib.SpeechStreamFileMode.SSFMCreateForWrite, false);
            //v.AudioOutputStream = speechStream;
            //v.Volume = 100;
            //v.Rate = -1;
            ////// speak "hello world" or any string else 
            //v.Speak("hello world", SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);
            //Response.Write("<EMBED src='test.wav' hidden=true volume='100' type=audio/x-wav LOOP='FALSE' AUTOSTART='TRUE'></EMBED>");
           
            //v = null;
            //speechStream.Close();
            //speechStream = null;

            return View();
        }

        //
        // GET: /Speech/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Speech/Create

        public ActionResult Create()
        {
            //SpVoice objSpeech = new SpVoice();
            //string strFileName = Server.MapPath("~/uploads/test1.wav");
            //SpFileStream objSpeechFS = new SpFileStream();
            //objSpeechFS.Open(strFileName,
            //SpeechStreamFileMode.SSFMCreateForWrite, false);
            //objSpeech.AudioOutputStream = objSpeechFS;
            //objSpeech.Speak("Hello World",SpeechVoiceSpeakFlags.SVSFlagsAsync);
            //objSpeech.WaitUntilDone(Timeout.Infinite);
            //objSpeechFS.Close();
 

            return View();
        }

        //
        // POST: /Speech/Create

      
        
        //
        // GET: /Speech/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Speech/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Speech/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Speech/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
