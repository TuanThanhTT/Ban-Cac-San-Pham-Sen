using System.Collections.Generic;

namespace BeHatSenLotus.Model
{
    public class GioHang
    {
        public int Id { get; set; } 
        public int userId { get; set; }

        public virtual ICollection<ChiTietGioHang> chitiet
        {
            get; set;
        }

        public virtual User User { get; set; }  

    }
}
