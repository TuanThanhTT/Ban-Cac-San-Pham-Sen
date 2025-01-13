using System.Collections.Generic;

namespace BeHatSenLotus.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool IsDelete { get; set; }

        public virtual Account account { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual GioHang GioHang { get; set; }
    }



}
