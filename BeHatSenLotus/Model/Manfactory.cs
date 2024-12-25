using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHatSenLotus.Model
{
    public class Manfactory
    {
        public int manfactoryId { get; set; }
        public int manfactoryName { get; set; }
        public string phoneNumber { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string city { get; set; }

        public virtual ICollection<Product> Products
        {
            get; set;
        }
    }
}
