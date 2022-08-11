using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public  string Name { get; set; }
        public string SurName { get; set; }
        public string Message { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public DateTime Tarih { get; set; }

    }
}
