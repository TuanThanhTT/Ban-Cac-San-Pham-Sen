using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus
{
    public class CustomTabControl : TabControl
    {
        private Image imgClose;
        public CustomTabControl()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.DrawItem += new DrawItemEventHandler(drawItem);
            this.Padding = new Point(15, 3);
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string imagePath = projectDirectory + "\\Image\\" + "icons8-x-48.png";
            imgClose = Image.FromFile(imagePath);
        }
        private void drawItem(object sender, DrawItemEventArgs e)
        {
            Rectangle tabRect = this.GetTabRect(e.Index);
            e.Graphics.DrawString(this.TabPages[e.Index].Text, this.Font, Brushes.Black, tabRect.X + 2, tabRect.Y + 2);

            Rectangle closeButton = new Rectangle(tabRect.Right - 20, tabRect.Top + 4, 16, 16);
            e.Graphics.DrawImage(imgClose, closeButton);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            Point p = e.Location;
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                Rectangle tabRect = this.GetTabRect(i);
                Rectangle closeButton = new Rectangle(tabRect.Right - 20, tabRect.Top + 4, 10, 10);
                if (closeButton.Contains(p))
                {
                    this.TabPages.RemoveAt(i);
                    break;
                }
            }
            if (this.TabPages.Count == 0)
            {
                this.Parent.Controls.Remove(this);
            }
            base.OnMouseClick(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Cursor = Cursors.Default;
        }
    }
}
