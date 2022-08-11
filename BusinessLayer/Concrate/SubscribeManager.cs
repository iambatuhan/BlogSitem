using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class SubscribeManager
    {
        Repository<SubscribeMail> reposubscribemail = new Repository<SubscribeMail>();
        public int BLAdd(SubscribeMail p)
        {
            
            return reposubscribemail.Insert(p);
        }
    }
}
