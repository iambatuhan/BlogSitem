using BusinessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ConcactController : Controller
    {
        // GET: Concact
        ContactManager cm = new ContactManager();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult SendMail()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMail(Contact p)
        {
            cm.BlContact(p);
            return View();
        }
        public ActionResult SendBox()
        {
            var messagelist = cm.Getall();
            return View(messagelist);
        }
        public ActionResult MessageDetails(int id)
        {
            Contact messagedetail = cm.Details(id);
            return View(messagedetail);
        }
    }
}