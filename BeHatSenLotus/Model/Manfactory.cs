using System.Collections.Generic;

namespace BeHatSenLotus.Model
{
    public class Manfactory
    {
        public int manfactoryId { get; set; }
        public string manfactoryName { get; set; }
        public string phoneNumber { get; set; }
        public string Address { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public bool isDelete { get; set; }  

        public virtual ICollection<Product> Products
        {
            get; set;
        }
    }
}
