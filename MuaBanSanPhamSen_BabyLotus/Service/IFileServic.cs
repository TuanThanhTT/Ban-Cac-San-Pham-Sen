using MuaBanSanPhamSen_BabyLotus.Models;
using System.Collections.Generic;

namespace MuaBanSanPhamSen_BabyLotus.Service
{
    public interface IFileServic
    {
         bool XuatHoaDon(int maHocDon, string fileName);
         bool XuatDanhSachKHachHang(string fileName);
        bool XuatDanhSachNhanVienDoanhThu(string fileName, List<NhanVienTheoDoanhThu> list);
        bool XuatDanhSachSanPhamDoanhThuCao(string fileName, List<SanPhamBanChay> list);
    }
}
