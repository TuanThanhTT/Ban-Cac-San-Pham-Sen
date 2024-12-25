using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHatSenLotus.Model
{
    public class Product
    {
        public int productId { get; set; }
        public int categoryId { get; set; } 
        public int manfactoryId { get; set; }   
        public string productName { get; set; } 
        public string Decrepsition { get; set; }    
        public bool isDelete { get; set; }
        public Decimal price { get; set; }
        public int quantity { get; set; }

        public virtual Category Category { get; set; }
        public virtual Manfactory Manfactory { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set;}
    }
}
