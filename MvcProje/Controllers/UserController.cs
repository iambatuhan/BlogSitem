using BusinessLayer;
using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfilManager UserProfil = new UserProfilManager();
        BlogManager bm = new BlogManager();
        AuthorManager  am=new AuthorManager();

      
        public ActionResult Index()
        {
         
            return View();
        }
        public PartialViewResult Partial1(string p)
        {
            var mail = (string)Session["Mail"];
            var profilvalues = UserProfil.GetAuthorByMail(mail);
            return PartialView(profilvalues);
        }
        
        public ActionResult UpdateUserEdit(Author p) {

            UserProfil.EditAuthor(p);
            return RedirectToAction("Index");
        }
        
        public ActionResult BlogList(String p)
        {
            p= (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = UserProfil.GetBlogByAuthor(id);
            return View(blogs);


        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.Update(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values1 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values1 = values1;
            return View(blog);

        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlog(p);
            return RedirectToAction("BlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlog(id);
            return RedirectToAction("AdminBlogList");
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values1 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values1 = values1;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddL(b);
            return RedirectToAction("BlogList");

        }
      
        

         public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin","Login");
        }
        
    }
}