using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BeHatSenLotus.Model
{
    public class Account
    {
        public int accountId { get; set; }  // Duy nhất một thuộc tính accountId
        public string username { get; set; }
        public string passs { get; set; }
        public DateTime createDate { get; set; }
        public bool IsLocked { get; set; }
     
        public int? EmployAccountId { get; set; }  
        public int? UserAccountId { get; set; }    
        public virtual Employee employee { get; set; }
        public virtual User user { get; set; }
        public virtual ICollection<AccountPermisstion> AccountPermisstions { get; set; }
    }



}
