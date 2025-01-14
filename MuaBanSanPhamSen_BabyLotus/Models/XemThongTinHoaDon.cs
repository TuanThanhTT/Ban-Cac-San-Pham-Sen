using System;

namespace MuaBanSanPhamSen_BabyLotus.Models
{
    public class XemThongTinHoaDon
    {
        public int ID { get; set; }
        public int maHoaDon { get; set; }
        public int maUser { get; set; }
        public string tenNguoiDung { get; set; }    
        public Decimal tongTien { get; set; }   
        public DateTime ngayLap { get; set; } 
        public int maNhanVien { get; set; } 
        public string tenNhanVien { get; set; }       

    }
}
