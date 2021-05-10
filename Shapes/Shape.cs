using System;
using System.Drawing;
using System.Windows.Forms;
namespace CircleFractals.Shapes
{
    class Shape
    {
        private int x;
        private int y;
        private int minSize;
        private bool inline;
        private PictureBox pictureBox1;
        private delegate Bitmap ImageDrawing(Bitmap bmp);


        public virtual void Draw() { return; }
    }
}
