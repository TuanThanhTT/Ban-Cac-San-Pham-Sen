
using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHatSenLotus.Migrations
{
    public class Permissition
    {
        public int permissitionId { get; set; }
        public string permissitionName { get;set; }

        public virtual ICollection<AccountPermisstion> accountPermissions { get; set; }

    }
}
