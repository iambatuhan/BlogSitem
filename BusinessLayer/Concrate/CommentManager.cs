using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class CommentManager
    {
        Repository<Comment> repocomment = new Repository<Comment>();
        public List<Comment> CommentList()
        {
            return repocomment.List();
        }
        public List<Comment> CommentByStatusTrue()
        {
            return repocomment.List(x=>x.CommentStatus==true);
        }
        public List<Comment> CommentBlogID(int id)
        {
            return repocomment.List(x=>x.BlogID == id);
        }
        public int CommentAdd(Comment c)
        {
            if (c.CommentText.Length <= 10 || c.CommentText.Length >= 500 ||c.UserName=="" || c.Mail=="")
            {
                return -1;
            }
            return repocomment.Insert(c);
            
        }
        public int UpdateComment(int id)
        {
            Comment comment = repocomment.Find(x => x.CommentID == id);
            comment.CommentStatus = false;
            return repocomment.Update(comment);
        }
    }
}
