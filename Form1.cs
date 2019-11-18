using System;
using System.Drawing;
using System.Windows.Forms;

namespace CircleFractals
{
    public partial class CircleFractalsFr : Form
    {
        public CircleFractalsFr()
        {
            InitializeComponent();

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            mainPanel.Refresh();
            DrawCircles(mainPanel.Height/2,mainPanel.Width/2 , radiustxt.Text == "" ? 400 : float.Parse(radiustxt.Text), minSizetxt.Text == ""? 20 : int.Parse(minSizetxt.Text), true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainPanel.Refresh();
            DrawCircles(mainPanel.Height / 2, mainPanel.Width / 2, radiustxt.Text == "" ? 400 : float.Parse(radiustxt.Text), minSizetxt.Text == "" ? 20 : int.Parse(minSizetxt.Text), false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainPanel.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DrawCircles(int x, int y, float radius, int minSize, bool inline)
        {
            Pen blackPen = new Pen(Color.Black, 0.05f);
            Graphics panel = Graphics.FromHwnd(mainPanel.Handle);
            Rectangle rect = new Rectangle(Convert.ToInt32(x - radius), Convert.ToInt32(y - radius), Convert.ToInt32(radius * 2), Convert.ToInt32(radius * 2));

            panel.DrawEllipse(blackPen, rect);

            if (radius > minSize)
            {
                DrawCircles(Convert.ToInt32(x + radius / 2), y, radius / 2, minSize, inline);
                DrawCircles(Convert.ToInt32(x - radius / 2), y, radius / 2, minSize, inline);
                if (!inline)
                {
                    DrawCircles(x, Convert.ToInt32(y - radius / 2), radius / 2, minSize, inline);
                    DrawCircles(x, Convert.ToInt32(y + radius / 2), radius / 2, minSize, inline);
                }
            }

        }
    }
}
