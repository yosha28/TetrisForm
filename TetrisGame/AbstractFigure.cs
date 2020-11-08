using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TetrisGame
{
    public abstract class IFigure
    {
        public abstract Point[] Create(Point center, int num);
        //  public Point[] figure;
        public int number;
        public void SetFigure(Point[] figure)
        {
            //  number = num;
            for (int i = 0; i < 4; i++)
            {
                if (figure[i].Y < 0)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        figure[j].Y++;
                    }

                }
            }

        }
      
    }
    //public interface ICloneable
    //{
    //    object Clone();
    //}
    //public abstract class IFigure
    //{
    //    abstract public Point[] Create(Point center, int num);
    //    public int number;
    //    public bool AdmissibilityRoof(Point[] points)
    //    {
    //        for(int i=0;i<4;i++)
    //        {
    //            if(points[i].Y<0)
    //            {

    //                return false;
    //            }


    //        }
    //        return true;
    //    }
    //}




    //public class FigurePoints
    //{
    //    public List<Point> points;
    //    public FigurePoints next;
    //    public int number;

    //    public FigurePoints()
    //    {
    //        points = new List<Point>();

    //    }
    //    public int Number { get => number; set => number = value; }

    //}

}
