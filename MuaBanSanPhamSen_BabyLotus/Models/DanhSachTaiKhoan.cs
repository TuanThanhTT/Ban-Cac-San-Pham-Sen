using System;

namespace MuaBanSanPhamSen_BabyLotus.Models
{
    public class DanhSachTaiKhoan
    {
        public int accountId { get; set; }  
        public string usserName { get; set; }   
        public string loaiTaiKhoan { get; set; }    
        public string quyenTaiKhoan { get; set; }   
        public DateTime ngayTao { get; set; }
        public string avartar { get; set; } 
        public int roleId { get; set; } 
        public string TrangThai { get; set; }   


    }
}
