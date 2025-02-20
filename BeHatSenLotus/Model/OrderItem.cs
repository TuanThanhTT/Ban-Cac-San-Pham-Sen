﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHatSenLotus.Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }    
        public int OrderId { get; set; }    
        public int ProductId { get; set; }  
        public int Quantity { get; set; }   
        public Decimal totalAmount { get; set; }
        
        public virtual Product Product { get; set; }    
        public virtual Order Order { get; set; }    

    }
}
