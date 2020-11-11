using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisGame;
using TetrisGame.Figures;

namespace ControlLibrary
{

    public partial class UserControl1 : UserControl
    {
        Point[] figurePoints = new Point[4];
        Point[] nextPoints = new Point[4];
        const int width = 12, height = 21, k = 15;    
        int gameStatus;//создание новой,падение,конец игры/Enum?
        Point center = new Point();
        Point centerNext = new Point(15, 3);
        Tetris tetris;
        float scaleUnit;
        int sizeRect;
     
        public UserControl1()
        {
            InitializeComponent();
            StartGame();
            timer1.Stop();

        }
        private void StartGame()
        {
            tetris = new Tetris();
            center = Tetris.center;
            gameStatus = 1;
            tetris.CreateNextNewFigure();
            nextPoints = tetris.inext.Create(centerNext, tetris.inext.number);
            figurePoints = tetris.ifigure.Create(Tetris.center, tetris.ifigure.number);
            tetris.flag = 1;

        }
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            scaleUnit = ClientRectangle.Width > ClientRectangle.Height ?
                 ClientRectangle.Height / 317F : ClientRectangle.Width / 295F;
            sizeRect =(int)(scaleUnit * k);

            Graphics gr = e.Graphics;

            gr.Clear(Color.LightGray);

            for (int y = 0; y < height; y++)//контуры стакана
                for (int x = 0; x < width; x++)
                {
                    if (y < 20 && x < 10)
                    {
                        if (x < 4)//фигуры
                        {
                            gr.FillRectangle(Brushes.Red, nextPoints[x].X * sizeRect, nextPoints[x].Y * sizeRect, sizeRect, sizeRect);
                            gr.DrawRectangle(Pens.Black, nextPoints[x].X * sizeRect, nextPoints[x].Y * sizeRect, sizeRect, sizeRect);
                            gr.FillRectangle(Brushes.Red, figurePoints[x].X * sizeRect, figurePoints[x].Y * sizeRect, sizeRect, sizeRect);
                            gr.DrawRectangle(Pens.Black, figurePoints[x].X * sizeRect, figurePoints[x].Y * sizeRect, sizeRect, sizeRect);
                        }
                        if (tetris.field[x, y] == 1)//поле
                        {
                            gr.FillRectangle(Brushes.Blue, (x + 1) * sizeRect, y * sizeRect, sizeRect, sizeRect);
                            gr.DrawRectangle(Pens.Black, (x + 1) * sizeRect, y * sizeRect, sizeRect, sizeRect);
                        }
                    }
                    if (y == height - 1 || x == 0 || x == width - 1)//границы
                    {
                        gr.FillRectangle(Brushes.DarkGray, x * sizeRect, y * sizeRect, sizeRect, sizeRect);
                        gr.DrawRectangle(Pens.Black, x * sizeRect, y * sizeRect, sizeRect, sizeRect);
                    }
                }

            GraphicText(gr, "Next Figure", 3, Brushes.Black);
            GraphicText(gr, "Score", 6 * sizeRect, Brushes.Black);
            GraphicText(gr, tetris.score.ToString(), 7 * sizeRect, Brushes.Red);
            GraphicText(gr, "Level", 9 * sizeRect, Brushes.Black);
            GraphicText(gr, tetris.level.ToString(), 10 * sizeRect, Brushes.Red);
            GraphicText(gr, "Record", 12 * sizeRect, Brushes.Black);        
          GraphicText(gr, tetris.ReadRecord(), 13 * sizeRect, Brushes.Red);

            if (gameStatus == 2)
            {
                timer1.Stop();
                tetris.SaveRecord();
                FormGameOver gameOver = new FormGameOver();

                gameOver.ShowDialog();

                if (gameOver.DialogResult == DialogResult.OK)
                {
                    StartGame();
                    timer1.Start();
                    Invalidate();
                }
                if (gameOver.DialogResult == DialogResult.Cancel)
                {
                    Form tmp = this.FindForm();
                    tmp.Close();
                    tmp.Dispose();
                }
            }
        }
        private void GraphicText(Graphics gr, string text, int y, Brush brush)
        {
            Font = new Font(Font.Name, 12* scaleUnit);
            PointF point = new PointF((width + 1) * sizeRect, y);
            gr.DrawString(text, Font, brush, point);
        }

        private void UserControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                case Keys.Pause:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

            button1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = tetris.time;
            if (gameStatus == 1)//свободное падение
            {
                center.Y++;
                figurePoints = tetris.ifigure.Create(center, tetris.ifigure.number);
                if (!tetris.TouchFieldOrFloor(figurePoints))//достигла дна
                {
                    center.Y--;
                    figurePoints = tetris.ifigure.Create(center, tetris.ifigure.number);
                    for (int i = 0; i < 4; i++)
                    {
                        tetris.field[figurePoints[i].X - 1, figurePoints[i].Y] = 1;

                    }
                    gameStatus = 0;
                 //   FillingField();
                    Invalidate();
                }
            }
            else if (gameStatus == 0)//нужно создавать новую фигуру и сохранять в поле старую фигуру.
            {
                // FillingField();
                for (int i = 0; i < 4; i++)
                {
                    tetris.field[figurePoints[i].X - 1, figurePoints[i].Y] = 1;

                }
                tetris.DeleteLinesScore();
                tetris.CreateNextNewFigure();
                figurePoints = tetris.ifigure.Create(Tetris.center, tetris.ifigure.number);
                nextPoints = tetris.inext.Create(centerNext, tetris.inext.number);
                center = Tetris.center;
                gameStatus = 1;
                if (!tetris.TouchFieldOrFloor(figurePoints))
                {
                    center.Y--;
                    figurePoints = tetris.ifigure.Create(center, tetris.ifigure.number);
                    for (int i = 0; i < 4; i++)
                    {
                        tetris.field[figurePoints[i].X - 1, figurePoints[i].Y] = 1;

                    }
                    gameStatus = 2;//уперлась в поле на старте

                }

            }
            Invalidate();
        }
        private void FillingField()
        {
            for (int i = 0; i < 4; i++)
            {
                tetris.field[figurePoints[i].X - 1, figurePoints[i].Y] = 1;

            }
            tetris.DeleteLinesScore();
            tetris.CreateNextNewFigure();
            figurePoints = tetris.ifigure.Create(Tetris.center, tetris.ifigure.number);
            nextPoints = tetris.inext.Create(centerNext, tetris.inext.number);
            center = Tetris.center;
         //  gameStatus = 1;
        }
        private void UserControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    center.X--;
                    figurePoints = tetris.ifigure.Create(center, tetris.ifigure.number);
                    if (!tetris.TouchFieldOrFloor(figurePoints))
                    {
                        center.X++;
                        figurePoints = tetris.ifigure.Create(center, tetris.ifigure.number);
                    }
                    Invalidate();
                    break;
                case Keys.D:
                case Keys.Right:
                    center.X++;
                    figurePoints = tetris.ifigure.Create(center, tetris.ifigure.number);
                    if (!tetris.TouchFieldOrFloor(figurePoints))
                    {
                        center.X--;
                        figurePoints = tetris.ifigure.Create(center, tetris.ifigure.number);
                    }
                    Invalidate();
                    break;
                case Keys.W:
                case Keys.Up:
                    int tmp = tetris.ifigure.number;
                    tetris.ifigure.number++;
                    if (tetris.ifigure.number == 5)
                        tetris.ifigure.number = 1;
                    figurePoints = tetris.ifigure.Create(center, tetris.ifigure.number);
                    if (!tetris.TouchFieldOrFloor(figurePoints))
                    {
                        figurePoints = tetris.ifigure.Create(center, tmp);
                    }
                    Invalidate();
                    break;
                case Keys.S:
                case Keys.Down:
                    while (tetris.TouchFieldOrFloor(figurePoints))
                    {
                        center.Y++;
                        figurePoints = tetris.ifigure.Create(center, tetris.ifigure.number);
                        gameStatus = 1;
                    }
                    center.Y--;
                    figurePoints = tetris.ifigure.Create(center, tetris.ifigure.number);
                 
                    gameStatus = 0;
                    Invalidate();
                    break;
                case Keys.Pause:
                case Keys.P:
                    timer1.Stop();
                    button1.Visible = true;
                    button1.Text = "Continue Game";
                    break;
            }
        }

    }
}
