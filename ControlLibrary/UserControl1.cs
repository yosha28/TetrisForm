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
        public const int width = 12, height = 21, k = 15;
        public Graphics gr;
        int gameStatus;
        Point center = new Point();
        Point centerNext = new Point(15, 3);
        Tetris tetris;
      
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
            Graphics gr = e.Graphics;

            gr.Clear(Color.LightGray);

            for (int y = 0; y < height; y++)//контуры стакана
                for (int x = 0; x < width; x++)
                {
                    if (y == height - 1 || x == 0 || x == width - 1)
                    {
                        gr.FillRectangle(Brushes.DarkGray, x * k, y * k, k, k);
                        gr.DrawRectangle(Pens.Black, x * k, y * k, k, k);
                    }
                }

            for (int y = 0; y < 20; y++)//фигуры и поле
                for (int x = 0; x < 10; x++)
                {
                    if (tetris.field[x, y] == 1)
                    {
                        gr.FillRectangle(Brushes.Blue, (x + 1) * k, y * k, k, k);
                        gr.DrawRectangle(Pens.Black, (x + 1) * k, y * k, k, k);
                    }
                   
                }

            for (int i = 0; i < 4; i++)
            {
                gr.FillRectangle(Brushes.Red, nextPoints[i].X * k, nextPoints[i].Y * k, k, k);
                gr.DrawRectangle(Pens.Black, nextPoints[i].X * k, nextPoints[i].Y * k, k, k);
                gr.FillRectangle(Brushes.Red, figurePoints[i].X * k, figurePoints[i].Y * k, k, k);
                gr.DrawRectangle(Pens.Black, figurePoints[i].X * k, figurePoints[i].Y * k, k, k);
            }
        
            GraphicText(gr,"Next Figure", 3, Brushes.Black);
            GraphicText(gr, "Score", 6*k, Brushes.Black);
            GraphicText(gr, tetris.score.ToString(), 7 * k, Brushes.Red);
            GraphicText(gr, "Level", 9 * k, Brushes.Black);
            GraphicText(gr, tetris.level.ToString(), 10 * k, Brushes.Red);
            GraphicText(gr, "Record", 12 * k, Brushes.Black);
            GraphicText(gr, tetris.ReadRecord(), 13 * k, Brushes.Red);
            if (gameStatus == 2)
            {
                timer1.Stop();
                tetris.SaveRecord();
                FormGameOver gameOver = new FormGameOver();
               
                gameOver.ShowDialog();

              if(gameOver.DialogResult==DialogResult.OK)
                {
                    StartGame();
                    timer1.Start();
                    Invalidate();

                }
              
            }

        }
        private void GraphicText(Graphics gr,string text,int y,Brush brush)
        {
            Font = new Font(Font.Name, 12);
            PointF point = new PointF((width + 1) * k, y);
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
                //  case Keys.Enter:
                case Keys.Pause:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

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
                    tetris.DeleteLinesScore();
                    tetris.CreateNextNewFigure();
                    figurePoints = tetris.ifigure.Create(Tetris.center, tetris.ifigure.number);
                    nextPoints = tetris.inext.Create(centerNext, tetris.inext.number);
                    center = Tetris.center;
                    gameStatus = 1;

                    //  gameStatus = 2;
                    Invalidate();
                }
            }
            else if (gameStatus == 0)//нужно создавать новую фигуру и сохранять в поле старую фигуру.
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
                gameStatus = 1;
                if (!tetris.TouchFieldOrFloor(figurePoints)) gameStatus = 2;
 
            }
            Invalidate();
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
