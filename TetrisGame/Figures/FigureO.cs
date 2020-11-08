using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TetrisGame.Figures
{
    class FigureO:IFigure
    {
        public override Point[] Create(Point center, int num)
        {
            Point[] figure = new Point[4];
            num = 1;
            switch (num)
            {
                case 1:
                    figure[0] =new Point(center.X, center.Y);
                    figure[1] =new Point(center.X - 1, center.Y);
                    figure[2] =new Point(center.X, center.Y + 1);
                    figure[3] = new Point(center.X - 1, center.Y + 1);
                    break;            
            }
            number = num;

            SetFigure(figure);
            return figure;


        }
    }
}
