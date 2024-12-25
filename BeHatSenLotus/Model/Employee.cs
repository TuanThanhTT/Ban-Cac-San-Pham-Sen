using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHatSenLotus.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public bool Gender { get; set; }
        public bool IsDelete { get; set; }
        public DateTime BirthDay { get; set; }

        public virtual Account account { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
     


}
