using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeomComp_Lab1
{
    public partial class Form1 : Form
    {
        PointGenerator pointMaker;
        Bitmap bitmap;
        Point min = new Point(0, 0);
        Point max = new Point(250, 250);

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            PictureBox.Width = max.X + 30;
            PictureBox.Height = max.Y + 30;
            bitmap = new Bitmap(PictureBox.Width, PictureBox.Height);
            using (Graphics gx = Graphics.FromImage(bitmap))
            {
                pointMaker = new PointGenerator(min, max, 20, gx);
                pointMaker.DrawPoints();
            }
            
            this.Width = PictureBox.Width + 40;
            this.Height = PictureBox.Height + 80;
            PictureBox.Invalidate();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            using (Graphics gx = Graphics.FromImage(bitmap))
            {
                Program.MinimumAreaRectangleSimple(gx, pointMaker.PointCollection);
            }
            PictureBox.Invalidate();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
