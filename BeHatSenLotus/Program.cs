using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeHatSenLotus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var context = new BanSanPhamSen())
            {
                context.Database.CreateIfNotExists();
            }
        }
    }
}
