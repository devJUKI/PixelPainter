using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace PaintPainter
{
    public static class ScreenSelection
    {
        public static (Rectangle, Bitmap) MakeSelection() {
            Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
            Bitmap captureBitmap = new Bitmap(captureRectangle.Width, captureRectangle.Height, PixelFormat.Format32bppArgb);
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);

            Form form = new Form {
                Size = captureRectangle.Size,
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                TopMost = true
            };

            PictureBox pictureBox = new PictureBox {
                Image = captureBitmap,
                SizeMode = PictureBoxSizeMode.AutoSize
            };

            // TODO: Can't select from right to left
            bool done = false;
            Point point1 = new Point(-1, -1);
            Point point2 = new Point(-1, -1);
            new Thread(() => {
                pictureBox.MouseDown += (s, a) => {
                    point1 = new Point(a.X, a.Y);
                };


                pictureBox.MouseMove += (s, a) => {
                    point2 = new Point(a.X, a.Y);
                    pictureBox.Refresh();
                };

                pictureBox.MouseUp += (s, a) => {
                    form.Close();
                    done = true;
                };


                pictureBox.Paint += (s, a) => {
                    if (point1.X == -1) {
                        return;
                    }

                    Rectangle ee = new Rectangle(point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
                    using (Pen pen = new Pen(Color.Red, 2)) {
                        a.Graphics.DrawRectangle(pen, ee);
                    }
                };

                form.Controls.Add(pictureBox);
                form.ShowDialog();
            }).Start();

            while (done == false) { }

            int height = point2.Y - point1.Y;
            int width = point2.X - point1.X;
            Rectangle selectedSize = new Rectangle(point1.X, point1.Y, width, height);
            return (selectedSize, captureBitmap);
        }
    }
}
