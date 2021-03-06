﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TetrisGame.Figures
{
    public class FigureZ : IFigure
    {
        public override Point[] Create(Point center, int num)
        {
            Point[] figure = new Point[4];
            if (num == 3)
                num = 1;
            if (num == 4)
                num = 2;
            switch (num)
            {
                case 1:
                    figure[0] = new Point(center.X, center.Y);
                    figure[1] = new Point(center.X - 1, center.Y);
                    figure[2] = new Point(center.X, center.Y + 1);
                    figure[3] = new Point(center.X + 1, center.Y + 1);
                    break;
                case 2:
                    figure[0] = new Point(center.X, center.Y);
                    figure[1] = new Point(center.X, center.Y + 1);
                    figure[2] = new Point(center.X + 1, center.Y);
                    figure[3] = new Point(center.X + 1, center.Y - 1);
                    break;

            }
            number = num;

            SetFigure(figure);
            return figure;
        }
    }
}


