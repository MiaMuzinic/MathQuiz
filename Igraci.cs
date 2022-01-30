using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace OTTER
{


    public class Igrac 
    {
        private string ime;
        private int bodovi;

        public string Ime
        {
            get { return ime; }
            set
            {
                if(value == "")
                {
                    ime = "Player";
                }
                else
                {
                    ime = value;
                }
            }
        }

        public int Bodovi
        {
            get { return bodovi; }
            set { bodovi = value; }
        }

        public Igrac(string i, int b)
        {
            this.Ime = i;
            this.bodovi = 0;
        }


    }

    public class SlavniMatematicari : Sprite
    {
        public string ime;

        public SlavniMatematicari(string path, int xcor, int ycor)
            : base(path, xcor, ycor)
        {

        }

        public bool Clicked(Point p)
        {
            if (p.X > this.X && p.X < this.X + this.Width)
            {
                if (p.Y > this.Y && p.Y < this.Y + this.Heigth)
                    return true;
            }

            return false;
        }

        public override int X  
        {
            get
            {
                return this.x;
            }
            set
            {
                if (value < GameOptions.LeftEdge)
                {
                    x = GameOptions.LeftEdge;
                }
                else if (value > GameOptions.RightEdge - this.Width)
                {
                    x = GameOptions.RightEdge - this.Width;
                }
                else
                {
                    x = value;
                }
            }
        }

        public override int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (value < GameOptions.UpEdge)
                {
                    y = GameOptions.UpEdge;
                }
                else if (value > GameOptions.DownEdge - this.Heigth)
                {
                    y = GameOptions.DownEdge - this.Heigth;
                }
                else
                {
                    y = value;
                }
            }
        }
    }

}
