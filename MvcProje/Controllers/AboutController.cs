using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.Concrate;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About,
        AboutManager abm = new AboutManager();
        AuthorManager au = new AuthorManager();
        public ActionResult Index()
        {
            var aboutcontent = abm.GetAll();
            return View(aboutcontent);
        }
        public PartialViewResult About()
        {
            var aboutContentLıst = abm.GetAll();
            return PartialView(aboutContentLıst);
        }
        public PartialViewResult MeetTheTeam()
        {
            var authorlist = au.GetAll();
            return PartialView(authorlist);
        }
    }
}