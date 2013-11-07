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
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            listAlgorithms.DataSource = Enum.GetValues(typeof(Program.Algorithms));
            PictureBox.Width = 500;
            PictureBox.Height = 300;
            this.Width = PictureBox.Width + 40;
            this.Height = PictureBox.Height + 80;
            bitmap = new Bitmap(PictureBox.Width, PictureBox.Height);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            object obj = listAlgorithms.SelectedItem;
            using (Graphics gx = Graphics.FromImage(bitmap))
            {
                gx.Clear(Color.Black);
                Program.MinimumAreaRectangleSimple(gx);
            }
            PictureBox.Invalidate();
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
