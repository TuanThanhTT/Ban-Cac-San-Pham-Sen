
using BeHatSenLotus.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHatSenLotus.Model
{
    public class AccountPermisstion
    {
        public int accountId { get; set; }
        public int permissitionId { get; set; } 


        public virtual Account Account { get; set; }
        public virtual Permissition Permissition { get; set; }


    }
}
