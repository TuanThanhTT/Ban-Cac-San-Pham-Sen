using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Service
{
    public class FileServic : IFileServic
    {
        public bool XuatDanhSachKHachHang(string fileName)
        {
            try
            {
                using (var context = new BanSanPhamSen())
                {
                    var ds = context.Users.Distinct().ToList();
                    if(ds!=null && ds.Count > 0)
                    {
                        var data = new DataTable();
                        data.Columns.Add("STT", typeof(int));
                        data.Columns.Add("Họ Tên",typeof(string));
                        data.Columns.Add("Điện Thoại", typeof(string));
                        int index = 1;
                        foreach(var item in ds)
                        {
                            data.Rows.Add(index, item.FullName, item.PhoneNumber);
                            index++;
                        }

                        if(data != null && data.Rows.Count> 0)
                        {
                            var fileExport = new FileInfo(Path.GetFullPath(fileName));
                            string startAt = "A2";
                            string sheetname = "Danh Sách Khách Hàng";
                            bool isPrintHeader = true;

                            using (ExcelPackage ecl = new ExcelPackage(fileExport))
                            {
                                ExcelWorksheet wc = ecl.Workbook.Worksheets.Add(sheetname);
                                wc.Cells[startAt].LoadFromDataTable(data, isPrintHeader);
                                wc.Cells["A1:C1"].Merge = true;
                                wc.Cells["A1"].Value = "Danh Sách Khách Hàng";
                                wc.Cells["A1"].Style.Font.Size = 16;
                                wc.Cells["A1"].Style.Font.Bold = true;
                                wc.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;




                                var dataRange = wc.Cells["A2:C" + (data.Rows.Count + 2)];
                                dataRange.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                dataRange.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                dataRange.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                dataRange.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                                var headerRange = wc.Cells["A2:C2"];
                                headerRange.Style.Font.Bold = true;
                                headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                                ecl.Save();

                            }
                            return true;
                        }

                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            return false;
        }

        public bool XuatDanhSachNhanVienDoanhThu(string fileName, List<NhanVienTheoDoanhThu> list)
        {
            try
            {
                using (var context = new BanSanPhamSen())
                {
                    var ds = list;
                    if (ds != null && ds.Count > 0)
                    {
                        var data = new DataTable();
                        data.Columns.Add("STT", typeof(int));
                        data.Columns.Add("mã Nhân Viên", typeof(string));
                        data.Columns.Add("Tên Nhân viên", typeof(string));
                        data.Columns.Add("Doanh Thu Bán Hàng", typeof(Decimal));
                        data.Columns.Add("Số hóa đơn Bán", typeof(int));
                        int index = 1;
                        foreach (var item in ds)
                        {
                            data.Rows.Add(index, item.maNhanVien,item.tenNhanVien, item.doanhThu, item.soHoaDonLap);
                            index++;
                        }

                        if (data != null && data.Rows.Count > 0)
                        {
                            var fileExport = new FileInfo(Path.GetFullPath(fileName));
                            string startAt = "A2";
                            string sheetname = "Danh Sách Nhân Viên Bán Hàng Có Doanh Thu Cao";
                            bool isPrintHeader = true;

                            using (ExcelPackage ecl = new ExcelPackage(fileExport))
                            {
                                ExcelWorksheet wc = ecl.Workbook.Worksheets.Add(sheetname);
                                wc.Cells[startAt].LoadFromDataTable(data, isPrintHeader);
                                wc.Cells["A1:E1"].Merge = true;
                                wc.Cells["A1"].Value = "Danh Sách Nhân Viên Bán Hàng Có Doanh Thu Cao";
                                wc.Cells["A1"].Style.Font.Size = 16;
                                wc.Cells["A1"].Style.Font.Bold = true;
                                wc.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;




                                var dataRange = wc.Cells["A2:E" + (data.Rows.Count + 2)];
                                dataRange.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                dataRange.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                dataRange.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                dataRange.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                                var headerRange = wc.Cells["A2:E2"];
                                headerRange.Style.Font.Bold = true;
                                headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                                ecl.Save();

                            }
                            return true;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public bool XuatDanhSachSanPhamDoanhThuCao(string fileName, List<SanPhamBanChay> list)
        {
            try
            {
                using (var context = new BanSanPhamSen())
                {
                    var ds = list;
                    if (ds != null && ds.Count > 0)
                    {
                        var data = new DataTable();
                        data.Columns.Add("STT", typeof(int));
                        data.Columns.Add("mã Nhân Viên", typeof(string));
                        data.Columns.Add("Tên Sản Phẩm", typeof(string));
                        data.Columns.Add("Số lượng Bán Ra", typeof(int));
                        data.Columns.Add("Tổng Doanh Thu", typeof(Decimal));
                        int index = 1;
                        foreach (var item in ds)
                        {
                            data.Rows.Add(index, item.Id, item.Name, item.soLuong, item.TongDoanhThu);
                            index++;
                        }

                        if (data != null && data.Rows.Count > 0)
                        {
                            var fileExport = new FileInfo(Path.GetFullPath(fileName));
                            string startAt = "A2";
                            string sheetname = "Sản Phẩm Bán Chạy";
                            bool isPrintHeader = true;

                            using (ExcelPackage ecl = new ExcelPackage(fileExport))
                            {
                                ExcelWorksheet wc = ecl.Workbook.Worksheets.Add(sheetname);
                                wc.Cells[startAt].LoadFromDataTable(data, isPrintHeader);
                                wc.Cells["A1:E1"].Merge = true;
                                wc.Cells["A1"].Value = "Sản Phẩm Bán Chạy";
                                wc.Cells["A1"].Style.Font.Size = 16;
                                wc.Cells["A1"].Style.Font.Bold = true;
                                wc.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;




                                var dataRange = wc.Cells["A2:E" + (data.Rows.Count + 2)];
                                dataRange.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                dataRange.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                dataRange.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                dataRange.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                                var headerRange = wc.Cells["A2:E2"];
                                headerRange.Style.Font.Bold = true;
                                headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                                ecl.Save();

                            }
                            return true;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public  bool XuatHoaDon(int maHocDon, string fileName)
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {
                    var hoaDon = context.Orders.Find(maHocDon);
                    if(hoaDon != null)
                    {
                        var ds = (from user in context.Users
                                 join hd in context.Orders
                                 on user.UserId equals hd.UserId
                                 join ct in context.OrderItems
                                 on hd.OrderId equals ct.OrderId
                                 join sp in context.Product
                                 on ct.ProductId equals sp.productId
                                 join emp in context.Employees
                                 on hd.EmployeeId equals emp.EmployeeId
                                 where hd.EmployeeId != null && hd.OrderId == hoaDon.OrderId
                                 select new XuatHoaDon
                                 {
                                     id = hd.OrderId,
                                     tenKhachHang = user.FullName,
                                     maHoaDon = hd.OrderId,
                                     nhanVienLap = emp.FullName,
                                     maSanPham = sp.productId,
                                     tenSanPham = sp.productName,
                                     giaBan = sp.price,
                                     soDienThaoi = user.PhoneNumber,
                                     soLuong = ct.Quantity,
                                     ngayMua = hd.CreateDate,
                                     tongTien = (ct.Quantity * sp.price)                             
                                 }).Distinct().ToList();
                        if(ds!=null && ds.Count >0 )
                        {
                            //tien hanh in ra file 
                            var data = new DataTable();
                            data.Columns.Add("Stt", typeof(int));
                            data.Columns.Add("Tên Khách Hàng",typeof(string));
                            data.Columns.Add("Điện Thoại",typeof(string));   
                            data.Columns.Add("Mã Sản Phẩm", typeof(int));
                            data.Columns.Add("Tên Sản Phẩm", typeof(string));
                            data.Columns.Add("Giá Bán",typeof(Decimal));
                            data.Columns.Add("Số Lượng",typeof(int));
                            data.Columns.Add("Tổng Tiền",typeof(decimal));   
                            data.Columns.Add("Ngày Lập",typeof(string));
                            int index = 1;
                            foreach(var item in ds)
                            {

                                data.Rows.Add(index, item.tenKhachHang, item.soDienThaoi, item.maSanPham, item.tenSanPham, item.giaBan, item.soLuong, item.tongTien, item.ngayMua.ToString("dd/MM/yyyy"));    
                                index++;
                            }
                            if(data.Rows.Count > 0)
                            {
                                var fileExport = new FileInfo(Path.GetFullPath(fileName));
                                string startAt = "A2";
                                string sheetname = "Hóa Đơn Mua Hàng";
                                bool isPrintHeader = true;

                                using (ExcelPackage ecl = new ExcelPackage(fileExport))
                                {
                                    ExcelWorksheet wc = ecl.Workbook.Worksheets.Add(sheetname);
                                    wc.Cells[startAt].LoadFromDataTable(data, isPrintHeader);
                                    wc.Cells["A1:F1"].Merge = true;
                                    wc.Cells["A1"].Value = "Hóa Đơn Mua Hàng";
                                    wc.Cells["A1"].Style.Font.Size = 16;
                                    wc.Cells["A1"].Style.Font.Bold = true;
                                    wc.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;




                                    var dataRange = wc.Cells["A2:I" + (data.Rows.Count + 2)];
                                    dataRange.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    dataRange.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    dataRange.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    dataRange.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                                    var headerRange = wc.Cells["A2:I2"];
                                    headerRange.Style.Font.Bold = true;
                                    headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                                    ecl.Save();

                                }
                                return true;
                            }
                          
                        }

                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }
}
