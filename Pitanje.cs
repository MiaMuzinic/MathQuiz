using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OTTER
{
    class Pitanje
    {
        private string tekstPitanja;
        public string TekstPitanja
        {
            get { return tekstPitanja; }
            set { tekstPitanja = value; }
        }

        public List<string> odgovori;

        private int indeksTocnog;
        
        public int IndeksTocnog
        {
            get { return indeksTocnog;  }
            set { indeksTocnog = value; }
        }

        
        public Pitanje(string linija)
        {
            string[] s = linija.Split(';');
            
            tekstPitanja = s[0];

            odgovori = new List<string>();
            odgovori.Add(s[1].ToString());
            odgovori.Add(s[2].ToString());
            odgovori.Add(s[3].ToString());

            indeksTocnog = int.Parse(s[4]);
        }

        public bool ProvjeriTocanOdgovor(string tekst)
        {
            int i = odgovori.IndexOf(tekst);
            return i == indeksTocnog;
            
        }
        
    }

    public abstract class Odgovor : Sprite
    {
        private string naziv ;

        public string Naziv
        {
            get { return naziv ; }
            set { naziv  = value; }
        }
        public bool Tocan = false;

        public Odgovor(string path, int xcor, int ycor)
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
    }

    public class Odgovor1 : Odgovor
    {
        public string odg1;

        public Odgovor1(string path, int xcor, int ycor)
            : base(path, xcor, ycor)
        {
            this.Naziv = odg1;
            this.Tocan = false;
        }

    }

    public class Odgovor2 : Odgovor
    {
        public string odg2;

        public Odgovor2(string path, int xcor, int ycor)
            : base(path, xcor, ycor)
        {
            this.Naziv = odg2;
            this.Tocan = false;
        }

    }

    public class Odgovor3 : Odgovor
    {
        public string odg3;

        public Odgovor3(string path, int xcor, int ycor)
            : base(path, xcor, ycor)
        {
            this.Naziv = odg3;
            this.Tocan = false;
        }

    }
}
