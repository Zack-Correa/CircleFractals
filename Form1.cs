using System;
using System.Drawing;
using System.Windows.Forms;
using CircleFractals.Shapes;

namespace CircleFractals
{
    public partial class CircleFractalsFr : Form
    {
        public CircleFractalsFr()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Circle.image = new Bitmap(900, 900);
            Circle.circleCounter = 0;
            generateDrawing(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Circle.image = new Bitmap(900, 900);
            Circle.circleCounter = 0;
            generateDrawing(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Circle.image = new Bitmap(900, 900);
            Circle.circleCounter = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generateDrawing(Boolean inline)
        {
            Circle cl = new Circle(pictureBox1.Height / 2, pictureBox1.Width / 2, radiustxt.Text == "" ? 400 : float.Parse(radiustxt.Text));
            int maxsize = radiustxt.Text == "" ? 400 : int.Parse(radiustxt.Text);
            int minsize = minSizetxt.Text == "" ? 20 : int.Parse(minSizetxt.Text);
            float maxCircles = (maxsize / minsize);
            Circle.circleMax = (int)Convert.ToInt64(Math.Pow(double.Parse(maxCircles.ToString()), 4));
            Circle.updateImage = updateImage.Checked;
            cl.DrawCircles(minsize, inline, pictureBox1);
        }
    }
}
