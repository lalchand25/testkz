using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OLProject.Controllers
{
    public class ttsController : Controller
    {
        //
        // GET: /tts/

        public ActionResult Index()
        {
            if (Request.HttpMethod == "POST")
            {
                string result = Request.Form["tts"];
                ViewData["lessonlisten"] = "<audio controls><source src='http://tts-api.com/tts.mp3?q=" + result + "'  type='audio/mpeg'> Your browser does not support this audio format.</audio>";
            }
            return View();
        }

    }
}
