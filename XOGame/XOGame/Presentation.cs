using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace XOGame
{
    class Presentation
    {
        public PictureBox picXOGame;
        public int CellW;
        public int CellH;
        public int Width;
        public int Height;
        Graphics gXOGame;
        public Presentation(int width, int height,PictureBox pic)
        {
            picXOGame = pic;
            CellH = (height - 20) / 3;
            CellW = (width -  20) / 3;
            Bitmap bmp = new Bitmap(width, height);
            picXOGame.Image = bmp;
            gXOGame = Graphics.FromImage(picXOGame.Image);
            this.Width = width;
            this.Height = height;
            
        }
        public int[,] State = new int[3, 3];
        public void CopyState(ref int[,] state)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    State[i, j] = state[i, j];
        }
        public void Update()
        {
            gXOGame.FillRectangle(Brushes.White, 0, 0, Width, Height);
            gXOGame.FillRectangle(Brushes.LightGray, 5, 5, Width - 10, Height - 10);
            Pen p = new Pen(Color.Black, 3);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    gXOGame.DrawRectangle(p, 10 + i * CellW, 10 + j * CellH, CellW, CellH);
                    if (State[i, j] == 1)
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment  = StringAlignment.Center;
                        gXOGame.DrawString("X",new Font("Arial",50),Brushes.Black,new RectangleF(10+j*CellW,10+i*CellH,CellW,CellH));
                    }
                    if (State[i, j] == 2)
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        gXOGame.DrawString("O", new Font("Arial", 50), Brushes.Black, new RectangleF(10 + j * CellW, 10 + i * CellH, CellW, CellH));
                    }   

                }                
            picXOGame.Refresh();
        }

    }
}
