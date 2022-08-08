using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static PaintPainter.CursorUtils;

namespace PaintPainter
{
    public partial class Form1 : Form
    {
        private const int COLORS_IN_ROW = 10;
        private const int ROW_COUNT = 2;
        private const int COLOR_SQUARE_SIZE = 21;
        private const int SPACE_BETWEEN_COLORS = 6;

        List<Color> colors = new List<Color>();
        (Rectangle, Bitmap) palettePos;
        Bitmap image;
        Bitmap resizedImage;
        Rectangle targetArea;

        public Form1() {
            InitializeComponent();

            selectImageBtn.Enabled = false;
            selectTargetAreaBtn.Enabled = false;
            drawBtn.Enabled = false;
        }

        private void selectPaletteBtn_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
            Thread.Sleep(200);
            palettePos = ScreenSelection.MakeSelection();

            int jumpBetweenColors = COLOR_SQUARE_SIZE + SPACE_BETWEEN_COLORS;
            int initialJumpX = COLOR_SQUARE_SIZE / 2 + palettePos.Item1.X;
            int initialJumpY = COLOR_SQUARE_SIZE / 2 + palettePos.Item1.Y;
            for (int i = 0; i < ROW_COUNT; i++) {
                for (int j = 0; j < COLORS_IN_ROW; j++) {
                    int xPos = initialJumpX + jumpBetweenColors * j;
                    int yPos = initialJumpY + jumpBetweenColors * i;
                    colors.Add(palettePos.Item2.GetPixel(xPos, yPos));
                }
            }

            WindowState = FormWindowState.Normal;
            selectImageBtn.Enabled = true;
        }

        private void selectImageBtn_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                image = new Bitmap(ofd.FileName);
                selectTargetAreaBtn.Enabled = true;
                return;
            }
            MessageBox.Show("Image selection was not successful");
        }

        private void selectTargetArea_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
            Thread.Sleep(200);
            targetArea = ScreenSelection.MakeSelection().Item1;
            WindowState = FormWindowState.Normal;

            resizedImage = new Bitmap(image, new Size(targetArea.Width, targetArea.Height));
            drawBtn.Enabled = true;
        }

        int savedColorIdx = -1;
        private void draw_Click(object sender, EventArgs e) {
            for (int i = 0; i < resizedImage.Height; i++) {
                for (int j = 0; j < resizedImage.Width; j++) {
                    Color pixel = resizedImage.GetPixel(j, i);

                    // Pick best matching color
                    int colorIdx = -1;
                    double colorDiff = double.MaxValue;
                    for (int p = 0; p < colors.Count; p++) {
                        double rDiff = Math.Pow(pixel.R - colors[p].R, 2);
                        double gDiff = Math.Pow(pixel.G - colors[p].G, 2);
                        double bDiff = Math.Pow(pixel.B - colors[p].B, 2);
                        double currColorDiff = Math.Sqrt(rDiff + gDiff + bDiff);

                        if (currColorDiff < colorDiff) {
                            colorDiff = currColorDiff;
                            colorIdx = p;
                        }
                    }

                    if (colorIdx != savedColorIdx) {
                        savedColorIdx = colorIdx;

                        // Click on color
                        int jumpBetweenColors = COLOR_SQUARE_SIZE + SPACE_BETWEEN_COLORS;
                        int initialJumpX = COLOR_SQUARE_SIZE / 2 + palettePos.Item1.X;
                        int initialJumpY = COLOR_SQUARE_SIZE / 2 + palettePos.Item1.Y;
                        int xPos = initialJumpX + jumpBetweenColors * (colorIdx % COLORS_IN_ROW);
                        int yPos = initialJumpY + jumpBetweenColors * ((int)Math.Floor((double)colorIdx / COLORS_IN_ROW));

                        Console.WriteLine("colorIdx: " + colorIdx + " " + "xPos: " + colorIdx % COLORS_IN_ROW);
                        Console.WriteLine("colorIdx: " + colorIdx + " " + "yPos: " + ((int)Math.Floor((double)colorIdx / COLORS_IN_ROW)));

                        MoveCursor(this, xPos, yPos);
                        Thread.Sleep(5);
                        DoMouseClick();
                        Thread.Sleep(5);
                    }

                    // Paint
                    MoveCursor(this, targetArea.X + j, targetArea.Y + i);
                    Thread.Sleep(5);
                    DoMouseClick();
                    Thread.Sleep(5);
                }
            }
        }
    }
}
