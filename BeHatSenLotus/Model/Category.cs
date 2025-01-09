using System.Collections.Generic;

namespace BeHatSenLotus.Model
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public bool isDelete { get; set; }  
        public virtual ICollection<Product> Products
        {
            get; set;
        }
    }
}
