using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TetrisGame.Figures;
using System.IO;

namespace TetrisGame
{
    public class Tetris
    {
        public int[,] field = new int[10, 20];
        public static Point center = new Point(5, 0);
        public IFigure ifigure;
        public IFigure inext;
        public int score, record, time, level, amtFigure, flag;   
      //  amtFigure счетчик фигур для изменения уровней
      //  flag для создания новой и след.фигур  
        public Tetris()
        {
            for (int y = 0; y < 20; y++)
                for (int x = 0; x < 10; x++)
                {
                    field[x, y] = 0;
                }
            time = 2000;
            level = 1;
            flag = 0;
        }
        public IFigure AssortyFigure()
        {
            Random round = new Random();
            int num = round.Next(1, 5);
            IFigure setFigure = null; 
            int form = round.Next(1, 8);

            switch (form)
            {
                case 1: setFigure = new FigureJ(); break;
                case 2: setFigure = new FigureL(); break;
                case 3: setFigure = new FigureO(); break;
                case 4: setFigure = new FigureI(); break;
                case 5: setFigure = new FigureT(); break;
                case 6: setFigure = new FigureS(); break;
                case 7: setFigure = new FigureZ(); break;
            }
            setFigure.number = num;
            return setFigure;
        }
        public bool TouchFieldOrFloor(Point[] figure)
        {
            for (int k = 0; k < 4; k++)
                for (int y = 0; y < 20; y++)
                    for (int x = 0; x < 10; x++)
                    {
                        if (field[x, y] == 1)//в поле врезались
                        {
                            if (figure[k].X - 1 == x && figure[k].Y - center.Y == y) return false;
                        }
                        else//в пол и стены
                        {
                            if (figure[k].Y >= 20 || figure[k].X >= 11 || figure[k].X <= 0) return false;
                        }
                    }
            return true;
        }
        public void CreateNextNewFigure()
        {
            if (flag == 0)
            {
                ifigure = AssortyFigure();
                inext = AssortyFigure();
                flag = 1;
            }
            else
            {
                ifigure = inext;
                inext = null;
                inext = AssortyFigure();
            }

        }
        public void DeleteLinesScore()
        {
            int[,] tmpField = new int[10, 20];
            int count = 0;
            int str = 0;
            for (int y = 19, tmpY = 19; y > -1; y--, tmpY--)
            {
                count = 0;
                for (int x = 0; x < 10; x++)
                {
                    if (field[x, y] == 1)
                        count++;
                }
                if (count == 10)
                {
                    str++;
                    tmpY++;
                }
                else
                {
                    for (int x = 0; x < 10; x++)
                    {
                        tmpField[x, tmpY] = field[x, y];
                    }

                }
            }
            if (str == 1) score = score + 100;
            if (str == 2) score = score + 300;
            if (str == 3) score = score + 700;
            if (str == 4) score = score + 1500;
            field = tmpField;

            amtFigure++;
            if (amtFigure > 2)
            {
                NewLevel();
                amtFigure = 0;
            }

        }
      
        public void NewLevel()
        {
            if (level < 10)
            {
                level++;
                time = time - 200;
            }
        }
        public void SaveRecord()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            string path = dir + "Record.txt";
            if (score > record)
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write($"{score} ");
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write($"{record} ");
                }
            }

        }
        public string ReadRecord()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            string path = dir + "Record.txt";    
            if(!File.Exists(path))
            {
                SaveRecord();
            }         
            using (StreamReader sr = File.OpenText(path))
            {
                record = int.Parse(sr.ReadToEnd());
                return record.ToString();
            }

        }

    }
}