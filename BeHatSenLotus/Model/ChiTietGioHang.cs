namespace BeHatSenLotus.Model
{
    public class ChiTietGioHang
    {
        public int id { get; set; } 

        public int productId { get; set; }  
        public int quantity { get; set; }   
        public int gioHangId { get; set; }  
        public virtual GioHang gioHang { get; set; }    
    }
}
