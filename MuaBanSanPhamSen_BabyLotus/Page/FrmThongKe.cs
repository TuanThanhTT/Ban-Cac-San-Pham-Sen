using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
    public partial class FrmThongKe : UserControl
    {
        public FrmThongKe()
        {
            InitializeComponent();
            khoiTao();
        }

        public void khoiTao()
        {
            loadTableNhanVien();
            loadTableKhachHang();
            loadTableSanPham();
            LoadDoanhThu();
        }

        public async void loadTableNhanVien()
        {
            try
            {
                var ds = await getDanhSachNhanVienTheoDoanhThu();
                if (ds != null)
                {
                    var data = new DataTable();
                    data.Columns.Add("Id", typeof(int));
                    data.Columns.Add("Name",typeof(string));
                    data.Columns.Add("Price", typeof(Decimal));
                    data.Columns.Add("SoLuong",typeof(int));

                    if (ds.Count > 0)
                    {
                        foreach(var item in ds)
                        {
                            data.Rows.Add(item.maNhanVien, item.tenNhanVien, item.doanhThu, item.soHoaDonLap);
                        }
                        GVNhanVien.DataSource = data;   
                    }
                }



            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<List<NhanVienTheoDoanhThu>> getDanhSachNhanVienTheoDoanhThu()
        {
            try
            {
                using (var context = new BanSanPhamSen())
                {
                    var ds = await (from emp in context.Employees
                                    join donhang in context.Orders
                                    on emp.EmployeeId equals donhang.EmployeeId
                                    where donhang.EmployeeId != null
                                    group donhang by new { emp.EmployeeId, emp.FullName } into g
                                    select new NhanVienTheoDoanhThu
                                    {
                                        maNhanVien = g.Key.EmployeeId,
                                        tenNhanVien = g.Key.FullName,
                                        soHoaDonLap = g.Count(),
                                        doanhThu = g.Sum(x => x.totalAmount)
                                    }).Distinct()
                 .OrderByDescending(nv => nv.doanhThu)
                 .ToListAsync();

                    if (ds != null)
                    {
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

      





        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void GVNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNhanVienXem_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GVNhanVien.CurrentCell.RowIndex;
                var soLuong = GVNhanVien.Rows[selected].Cells[3].Value.ToString();

                var DoanhThu = GVNhanVien.Rows[selected].Cells[2].Value.ToString();
              
                txtDoanhThuDaBan.Text = DoanhThu+" vnđ";    
                txtSoLuongHoaDonLap.Text = soLuong; 



              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public async void loadTableKhachHang()
        {
            try
            {
                var ds = await getDanhSachKhachHang();
                if (ds != null)
                {
                    var data = new DataTable();
                    data.Columns.Add("Id", typeof(int));
                    data.Columns.Add("name", typeof(string));   
                    data.Columns.Add("Phone", typeof(string));

                    if (ds.Count > 0)
                    {
                        foreach(var item in ds)
                        {
                            data.Rows.Add(item.UserId, item.FullName, item.PhoneNumber);
                        }
                        GvKhachHang.DataSource = data;  
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public async Task<List<User>> getDanhSachKhachHang()
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {
                    var ds = await (from user in context.Users join donHang in context.Orders
                             on user.UserId equals donHang.UserId
                             where user.UserId == donHang.UserId
                             select user).Distinct().ToListAsync();
                    if (ds != null)
                    {
                        return ds;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return null;
        }


        private void GvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public async void loadTableSanPham()
        {
            try
            {
                var ds = await getDanhSachSanPham();
                if (ds != null)
                {
                    var data = new DataTable(); 
                    data.Columns.Add("Id", typeof(int));
                    data.Columns.Add("name",typeof(string));
                    data.Columns.Add("TongTien", typeof(Decimal));
                    data.Columns.Add("SoLuongBan", typeof(Decimal));
                    if (ds.Count > 0)
                    {
                        foreach(var item in ds)
                        {
                            data.Rows.Add(item.Id, item.Name, item.TongDoanhThu, item.soLuong);    
                        }
                        GVSanPham.DataSource = data;
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public async Task<List<SanPhamBanChay>> getDanhSachSanPham()
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {
                    var bestSellingProducts = await (from sp in context.Product
                                                     join dhct in context.OrderItems
                                                     on sp.productId equals dhct.ProductId
                                                     group dhct by new { sp.productId, sp.productName } into g
                                                     select new SanPhamBanChay
                                                     {
                                                         Id = g.Key.productId,
                                                         Name = g.Key.productName,
                                                         soLuong = g.Sum(x => x.Quantity),
                                                         TongDoanhThu = g.Sum(x => x.totalAmount)
                                                     })
                                .OrderByDescending(p => p.soLuong)
                                .ToListAsync();
                    if (bestSellingProducts != null)
                    {
                        return bestSellingProducts;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private void btnXemSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GVSanPham.CurrentCell.RowIndex;
                var soLuong = GVSanPham.Rows[selected].Cells[3].Value.ToString();

                var DoanhThu = GVSanPham.Rows[selected].Cells[2].Value.ToString();

                txtSanPhamDoanhThu.Text = DoanhThu + " vnđ";
                txtSanPhamSoLuongBan.Text = soLuong;




            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public async void LoadDoanhThu()
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {
                    var currentMonthRevenue = await (from donhang in context.Orders
                                                     where donhang.CreateDate.Month == DateTime.Now.Month
                                                     && donhang.CreateDate.Year == DateTime.Now.Year
                                                     select donhang.totalAmount).SumAsync();
                    txtDoanhThuThangHienTai.Text = currentMonthRevenue + " vnđ";


                    var monthlyRevenue = await (from donhang in context.Orders where donhang.CreateDate.Year == DateTime.Now.Year group donhang by donhang.CreateDate.Month into g select new { Month = g.Key, Revenue = g.Sum(x => x.totalAmount) }).ToListAsync();
                    Series series = new Series("Revenue");
                    series.ChartType = SeriesChartType.Pie;
                    chart1.Series.Clear();
                    chart1.Series.Add(series);

                    foreach (var data in monthlyRevenue)
                    {
                        DataPoint dataPoint = new DataPoint();
                        dataPoint.SetValueXY(data.Month, data.Revenue);
                        series.Points.Add(dataPoint);
                    }

                    chart1.ChartAreas[0].AxisX.Title = "Month";
                    chart1.ChartAreas[0].AxisY.Title = "Revenue (vnđ)";
                    chart1.Titles.Add("Tháng hiện tại");

                    // Customize the pie chart (optional)
                    foreach (DataPoint point in series.Points)
                    {
                        point.Label = string.Format("{0}: {1:C}", point.AxisLabel, point.YValues[0]);
                    }


                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

