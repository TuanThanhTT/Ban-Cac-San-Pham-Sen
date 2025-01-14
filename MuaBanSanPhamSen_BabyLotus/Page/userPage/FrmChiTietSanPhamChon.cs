using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmChiTietSanPhamChon : UserControl
    {
        private Product pro;
        private List<Product> dsLaoiTuongTu { get; set; }
        private FrmUser userFrom;
        private User user;
        public FrmChiTietSanPhamChon(Product product, FrmUser userFrom, User user)
        {
            pro = product;
            this.userFrom = userFrom;
            this.user = user;   

            InitializeComponent();
            loadInfo();
            NBRSOLuongMua.Minimum = 0;
            NBRSOLuongMua.Maximum = 2000;

        }
        public List<Product> loadSanPhamTuongTu()
        {
            if (pro != null)
            {
                int loai = pro.categoryId;
                using (var context = new BanSanPhamSen())
                {
                     return context.Product.Where(s => s.categoryId == loai && s.productId!=pro.productId && s.isDelete == false).ToList();         
                }
            }
            return null;
        }

        public void loadInfo()
        {
            try
            {
                if(pro != null)
                {
                    lbTenSanPham.Text = pro.productName;
                    lbGiaBan.Text = pro.price + " vnđ";
                    lbSoLuongTon.Text = pro.quantity.ToString();
                    lbTrangThai.Text = (pro.isDelete) ? "Ngừng bán" : "Còn hàng";
                    txtMoTa.Text = pro.Decrepsition.ToString();

                    if (!string.IsNullOrEmpty(pro.imgs))
                    {
                        var listImg = pro.imgs.Trim().Split(';').ToArray();
                        string destFile = Path.Combine(Directory.GetCurrentDirectory(),"Upload", listImg[0].Trim());
                        if(File.Exists(destFile)) {
                            if (PTBHinhAnh.Image != null)
                            {
                                PTBHinhAnh.Image = null;
                            }
                            PTBHinhAnh.Image = Image.FromFile(destFile);
                        }

                        LayoutHinhAnh.FlowDirection = FlowDirection.LeftToRight;
                        LayoutHinhAnh.WrapContents= false;  
                        LayoutHinhAnh.Controls.Clear(); 
                        for(int i = 0; i < listImg.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(listImg[i]))
                            {
                                string path = Path.Combine(Directory.GetCurrentDirectory(), "Upload", listImg[i].Trim());
                                var f = new FrmAnhTuongTu(path, PTBHinhAnh);
                                LayoutHinhAnh.Controls.Add(f);
                            }
                          
                            

                        }


                    }
                    dsLaoiTuongTu = loadSanPhamTuongTu();

                    if (dsLaoiTuongTu != null)
                    {
                        //load san pham tuong tu 
                        if (dsLaoiTuongTu.Count > 0)
                        {
                            LayOutLoaiSanPhamTuongTu.Controls.Clear();
                            LayoutHinhAnh.FlowDirection = FlowDirection.LeftToRight;
                            LayOutLoaiSanPhamTuongTu.WrapContents = false;
                            foreach (var item in dsLaoiTuongTu)
                            {
                                
                                    var f = new FrmSanPhamTuongTu(item, userFrom, user);
                                    LayOutLoaiSanPhamTuongTu.Controls.Add(f);

                                   
                                
                            }
                        }
                    }
                   
                  

                }
            




            }
            catch(Exception ex) { 
                MessageBox.Show(ex+"","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }




        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbTenSanPham_Click(object sender, EventArgs e)
        {

        }

        private void LayoutHinhAnh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LayOutLoaiSanPhamTuongTu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMuangay_Click(object sender, EventArgs e)
        {
            try
            {

                int soLuong = Convert.ToInt32(NBRSOLuongMua.Value);
                if(soLuong  == 0)
                {
                    MessageBox.Show("Vui lòng chọn số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if(soLuong > pro.quantity)
                {
                    MessageBox.Show("Số lượng sản phẩm không được lớn hơn số lượng hiện có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }

                DialogResult result = MessageBox.Show("Bạn có muốn theo sản phẩm này vào giỏ hàng?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    if (user != null)
                    {
                        using (var context = new BanSanPhamSen())
                        {
                            // Kiểm tra xem người dùng đã có giỏ hàng hay chưa
                            var giohang = context.GioHangs.SingleOrDefault(g => g.userId == user.UserId);
                            if (giohang == null)
                            {
                                // Tạo giỏ hàng mới nếu chưa có
                                giohang = new GioHang
                                {
                                    userId = user.UserId,
                                    User = context.Users.SingleOrDefault(u => u.UserId == user.UserId)
                                };

                                if (giohang.User == null)
                                {
                                    // Nếu không tìm thấy người dùng, ném lỗi hoặc xử lý tương ứng
                                    throw new Exception("User không tồn tại.");
                                }

                                context.GioHangs.Add(giohang);
                                context.SaveChanges();
                            }

                            // Kiểm tra xem sản phẩm đã có trong giỏ hàng hay chưa
                            var item = context.ChiTietGioHang
                                .SingleOrDefault(i => i.gioHangId == giohang.Id && i.productId == pro.productId);

                            if (item != null)
                            {
                                // Nếu sản phẩm đã có trong giỏ hàng, tăng số lượng
                                item.quantity += soLuong;
                            }
                            else
                            {
                                // Nếu sản phẩm chưa có trong giỏ hàng, tạo item mới
                                item = new ChiTietGioHang
                                {
                                    productId = pro.productId,
                                    quantity = soLuong,
                                    gioHangId = giohang.Id
                                };
                                context.ChiTietGioHang.Add(item);
                            }

                            context.SaveChanges();
                            MessageBox.Show("Đã cập nhật giỏ hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }



                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex+"");
            }
        }
    }
}
