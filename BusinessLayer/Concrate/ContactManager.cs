using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class ContactManager
    {
        Repository<Contact> repocontact = new Repository<Contact>();
      public int BlContact(Contact c)
        {
            if (c.Mail == "" ||c.Message=="" ||c.Name=="" ||c.SurName=="" ||c.Mail.Length<=10 ||c.Subject.Length<=3)
            {
                return -1;
            }
            else
            {
                return repocontact.Insert(c);
            }
        }
        public List<Contact> Getall()
        {
            return repocontact.List();
        }
        public Contact Details(int id)
        {
            return repocontact.Find(x=>x.ContactID==id);
        }

    }
}
