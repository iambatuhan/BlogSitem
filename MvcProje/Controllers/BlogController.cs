using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProje.Controllers
{
    
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager();
        // GET: Blog
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
       
        [AllowAnonymous]
        public PartialViewResult BlogList(int page=1)
        {

            var BlogList = bm.GetAll().ToPagedList(page,3);
            return PartialView(BlogList);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        { 
            //1.Post için
            var PostTitle1 = bm.GetAll().OrderByDescending(z=>z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage1= bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var PostDate1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostTitle = PostTitle1;
            ViewBag.PostImage1 = PostImage1;
            ViewBag.PostDate1 = PostDate1;
            //2.Post için
            var PostTitle2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var PostDate2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostTitle2 = PostTitle2;
            ViewBag.PostImage2 = PostImage2;
            ViewBag.PostDate2 = PostDate2;
            //3.Post için
            var PostTitle3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var PostDate3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostTitle3 = PostTitle3;
            ViewBag.PostImage3 = PostImage3;
            ViewBag.PostDate3 = PostDate3;
            //4.Post için
            var PostTitle4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var PostDate4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostTitle4 = PostTitle4;
            ViewBag.PostImage4 = PostImage4;
            ViewBag.PostDate4 = PostDate4;
            //5.Post için
            var PostTitle5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var PostDate5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostTitle5 = PostTitle5;
            ViewBag.PostImage5 = PostImage5;
            ViewBag.PostDate5 = PostDate5;
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherPost()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult MailSubscribe()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.BlogByID(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogAllRead(int id)
        {
            var BlogDetailsList = bm.BlogByID(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListCategory = bm.GetBlogByCategory(id);
            var CategoryName = bm.GetBlogByCategory(id).Select(x => x.Category.CategoryName).FirstOrDefault();
            var CategoryDesc = bm.GetBlogByCategory(id).Select(x => x.Category.CategoryAcıklama).FirstOrDefault();
            ViewBag.CategoryDesc = CategoryDesc;
            ViewBag.CategoryName = CategoryName;
            return View(BlogListCategory);
        }
        public ActionResult AdminBlogList()
        {
            var BlogList = bm.GetAll();
            return View(BlogList);
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text=x.CategoryName,Value=x.CategoryID.ToString()}).ToList();
            ViewBag.values = values;
            List<SelectListItem> values1 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values1 = values1;
          
            
            return View();
       
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {           
           
                bm.BlogAddL(b);
                return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlog(id);
            return RedirectToAction("AdminBlogList");
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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentlist = cm.CommentBlogID(id);
            return View(commentlist);
        }
        public ActionResult AuthorBlogList(int id)
        {
           
           
            var blogs = bm.GetBlogByAuthorID(id);
            return View(blogs);


        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }




    }
}