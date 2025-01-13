using System;
using System.Collections.Generic;

namespace BeHatSenLotus.Model
{
    public class Order
    {
        public int OrderId { get; set; }    
        public int UserId { get; set; } 
        public DateTime CreateDate { get; set; }    
        public int? EmployeeId { get; set; }
        public Decimal totalAmount  {get; set; } 


        public virtual Employee Employees { get; set; }
        public virtual User Users { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }   
    }
}
