using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipImageTool
{
    public class CustomTabControl : TabControl
    {
        public CustomTabControl()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.SizeMode = TabSizeMode.Normal;
            this.Padding = new Point(15, 4);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tabPage = this.TabPages[e.Index];

            SolidBrush backgroundBrush = (e.State == DrawItemState.Selected) ?
                new SolidBrush(Color.LightGray) : new SolidBrush(Color.White);
            g.FillRectangle(backgroundBrush, e.Bounds);
            backgroundBrush.Dispose();

            Font tabFont = (e.State == DrawItemState.Selected) ? new Font(this.Font, FontStyle.Bold) : this.Font;

            int imageWidth = 0;
            if (this.ImageList != null && tabPage.ImageIndex >= 0)
            {
                Image tabImage = this.ImageList.Images[tabPage.ImageIndex];
                imageWidth = tabImage.Width;
                Rectangle imageRect = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + (e.Bounds.Height - tabImage.Height) / 2, tabImage.Width, tabImage.Height);
                g.DrawImage(tabImage, imageRect);
            }

            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Alignment = StringAlignment.Center;

            RectangleF textRect = new RectangleF(e.Bounds.X + imageWidth + 10, e.Bounds.Y, e.Bounds.Width - imageWidth - 10, e.Bounds.Height);

            using (SolidBrush textBrush = new SolidBrush(Color.Black))
                g.DrawString(tabPage.Text, tabFont, textBrush, textRect, strFormat);

            if (e.State == DrawItemState.Selected)
                tabFont.Dispose();
        }
    }
}
