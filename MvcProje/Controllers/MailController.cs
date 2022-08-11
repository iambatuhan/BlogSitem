using BusinessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        [HttpGet]
        [AllowAnonymous]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            SubscribeManager sm = new SubscribeManager();
            sm.BLAdd(p);
            return PartialView();
        }
    }
}