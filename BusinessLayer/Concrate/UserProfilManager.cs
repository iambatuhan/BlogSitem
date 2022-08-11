using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class UserProfilManager
    {
        Repository<Author> repouser = new Repository<Author>();
        Repository<Blog> repuseroblog = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repouser.List().Where(x => x.Mail == p).ToList();

        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repuseroblog.List(x => x.AuthorID == id);
        }
        public int EditAuthor(Author p)
        {
            Author author = repouser.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorID = p.AuthorID;
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.AuthorSort = p.AuthorSort;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.Telefon = p.Telefon;
            return repouser.Update(p);



        }
    }
}
