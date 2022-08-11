using BusinessLayer;
using BusinessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager bm = new BlogManager();
        AuthorManager am = new AuthorManager();
        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail = bm.GetBlogByID(id);
            return PartialView(authordetail);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid = bm.GetAll().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault() ;
            ViewBag.blogauthorid = blogauthorid;
            var authorblogs = bm.GetBlogByAuthorID(blogauthorid);
            return PartialView();
        }
        public ActionResult AuthorList()
        {
           var authorlist= am.GetAll();
            return View(authorlist);
        }
        [HttpGet]
        public  ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            am.AddAuthorBl(p);
            return RedirectToAction("AuthorList");
        }
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = am.FindAuthor(id);
            return View(author);
           
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            am.EditAuthor(p);
            return RedirectToAction("AuthorList");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult NewAddAuthor()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult NewAddAuthor(Author p)
        {
            am.AddAuthorBl(p);
            return RedirectToAction("AuthorList");
        }
        public ActionResult NewAddAuthor1()
        {
            return View();
        }
    }
}