using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
namespace CircleFractals.Shapes
{
    class Circle
    {
        public static Bitmap image = new Bitmap(900, 900);
        public static int circleMax;
        public static int circleCounter = 0;
        public static bool updateImage;
        private int x;
        private int y;
        private float radius;
        private int minSize;
        private bool inline;
        private PictureBox pictureBox1;
        private delegate Bitmap ImageDrawing(Bitmap bmp);
        public Circle(int x, int y, float radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }
        public void DrawCircles(int minSize, bool inline, PictureBox pictureBox1)
        {
            this.minSize = minSize;
            this.inline = inline;
            this.pictureBox1 = pictureBox1;

            ImageDrawing localImage = DrawCircles;
            IAsyncResult result = localImage.BeginInvoke(new Bitmap(900, 900), null, null);
            result.AsyncWaitHandle.WaitOne();

            pictureBox1.Image = image;
            pictureBox1.Update();
            
        }

        private void DrawCircles(int minSize, bool inline, PictureBox pictureBox1, Bitmap localImage)
        {
            this.minSize = minSize;
            this.inline = inline;
            this.pictureBox1 = pictureBox1;

            image = this.DrawCircles(localImage);
        }



        private Bitmap DrawCircles(Bitmap imageLocal)
        {
            Pen blackPen = new Pen(Color.Black, 0.05f);
            Graphics panel = Graphics.FromImage(imageLocal);
            Rectangle rect = new Rectangle(Convert.ToInt32(this.x - this.radius), Convert.ToInt32(this.y - this.radius), Convert.ToInt32(this.radius * 2), Convert.ToInt32(this.radius * 2));

            panel.DrawEllipse(blackPen, rect);
            circleCounter++;
            bool IsUpdateImageCircle = circleMax % circleCounter == 0 || circleCounter % 5 == 0;
            if (updateImage && IsUpdateImageCircle)
            {            
                this.pictureBox1.Image = image;
                this.pictureBox1.Update();
            }


            if (this.radius > this.minSize)
            {
                new Circle(Convert.ToInt32(this.x + this.radius / 2), this.y, this.radius / 2).DrawCircles(this.minSize, this.inline, this.pictureBox1, imageLocal);
                new Circle(Convert.ToInt32(this.x - this.radius / 2), this.y, this.radius / 2).DrawCircles(minSize, this.inline, this.pictureBox1, imageLocal);
                if (!inline)
                {
                    new Circle(this.x, Convert.ToInt32(this.y - this.radius / 2), this.radius / 2).DrawCircles(this.minSize, this.inline, this.pictureBox1, imageLocal);
                    new Circle(this.x, Convert.ToInt32(this.y + this.radius / 2), this.radius / 2).DrawCircles(this.minSize, this.inline, this.pictureBox1, imageLocal);
                }
            }

            return imageLocal;
        }
    }
}
