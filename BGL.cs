using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace OTTER
{
    /// <summary>
    /// -
    /// </summary>
    public partial class BGL : Form
    {
        /* ------------------- */
        #region Environment Variables

        List<Func<int>> GreenFlagScripts = new List<Func<int>>();

        /// <summary>
        /// Uvjet izvršavanja igre. Ako je <c>START == true</c> igra će se izvršavati.
        /// </summary>
        /// <example><c>START</c> se često koristi za beskonačnu petlju. Primjer metode/skripte:
        /// <code>
        /// private int MojaMetoda()
        /// {
        ///     while(START)
        ///     {
        ///       //ovdje ide kod
        ///     }
        ///     return 0;
        /// }</code>
        /// </example>
        public static bool START = true;

        //sprites
        /// <summary>
        /// Broj likova.
        /// </summary>
        public static int spriteCount = 0, soundCount = 0;

        /// <summary>
        /// Lista svih likova.
        /// </summary>
        //public static List<Sprite> allSprites = new List<Sprite>();
        public static SpriteList<Sprite> allSprites = new SpriteList<Sprite>();

        //sensing
        int mouseX, mouseY;
        Sensing sensing = new Sensing();

        //background
        List<string> backgroundImages = new List<string>();
        int backgroundImageIndex = 0;
        string ISPIS = "";

        SoundPlayer[] sounds = new SoundPlayer[1000];
        TextReader[] readFiles = new StreamReader[1000];
        TextWriter[] writeFiles = new StreamWriter[1000];
        bool showSync = false;
        int loopcount;
        DateTime dt = new DateTime();
        String time;
        double lastTime, thisTime, diff;

        #endregion
        /* ------------------- */
        #region Events

        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            try
            {
                foreach (Sprite sprite in allSprites)
                {
                    if (sprite != null)
                        if (sprite.Show == true)
                        {
                            g.DrawImage(sprite.CurrentCostume, new Rectangle(sprite.X, sprite.Y, sprite.Width, sprite.Heigth));
                        }
                    if (allSprites.Change)
                        break;
                }
                if (allSprites.Change)
                    allSprites.Change = false;
            }
            catch
            {
                //ako se doda sprite dok crta onda se mijenja allSprites
                MessageBox.Show("Greška!");
            }
        }

        private void startTimer(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            Init();
        }

        private void updateFrameRate(object sender, EventArgs e)
        {
            updateSyncRate();
        }

        /// <summary>
        /// Crta tekst po pozornici.
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        public void DrawTextOnScreen(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            var brush = new SolidBrush(Color.WhiteSmoke);
            string text = ISPIS;

            SizeF stringSize = new SizeF();
            Font stringFont = new Font("Arial", 14);
            stringSize = e.Graphics.MeasureString(text, stringFont);

            using (Font font1 = stringFont)
            {
                RectangleF rectF1 = new RectangleF(0, 0, stringSize.Width, stringSize.Height);
                e.Graphics.FillRectangle(brush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(text, font1, Brushes.Black, rectF1);
            }
        }

        private void mouseClicked(object sender, MouseEventArgs e)
        {
            //sensing.MouseDown = true;
            sensing.MouseDown = true;
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            //sensing.MouseDown = true;
            sensing.MouseDown = true;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            //sensing.MouseDown = false;
            sensing.MouseDown = false;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;

            //sensing.MouseX = e.X;
            //sensing.MouseY = e.Y;
            //Sensing.Mouse.x = e.X;
            //Sensing.Mouse.y = e.Y;
            sensing.Mouse.X = e.X;
            sensing.Mouse.Y = e.Y;

        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            sensing.Key = e.KeyCode.ToString();
            sensing.KeyPressedTest = true;
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            sensing.Key = "";
            sensing.KeyPressedTest = false;
        }

        private void Update(object sender, EventArgs e)
        {
            if (sensing.KeyPressed(Keys.Escape))
            {
                START = false;
            }

            if (START)
            {
                this.Refresh();
            }
        }

        #endregion
        /* ------------------- */
        #region Start of Game Methods

        //my
        #region my

        //private void StartScriptAndWait(Func<int> scriptName)
        //{
        //    Task t = Task.Factory.StartNew(scriptName);
        //    t.Wait();
        //}

        //private void StartScript(Func<int> scriptName)
        //{
        //    Task t;
        //    t = Task.Factory.StartNew(scriptName);
        //}

        private int AnimateBackground(int intervalMS)
        {
            while (START)
            {
                setBackgroundPicture(backgroundImages[backgroundImageIndex]);
                Game.WaitMS(intervalMS);
                backgroundImageIndex++;
                if (backgroundImageIndex == 3)
                    backgroundImageIndex = 0;
            }
            return 0;
        }

        private void KlikNaZastavicu()
        {
            foreach (Func<int> f in GreenFlagScripts)
            {
                Task.Factory.StartNew(f);
            }
        }

        #endregion

        /// <summary>
        /// BGL
        /// </summary>
        public BGL()
        {
            InitializeComponent();
        }
        public BGL(string ime, int bodovi, string razina, string tekstPitanja, List<string> odg)
        {
            InitializeComponent();
            this._imeigraca = ime;
            this._brojbodova = bodovi;
            this._razina = razina;
            this._tekstpitanja = tekstPitanja;
            this.odg1 = odg;
        }
        /// <summary>
        /// Pričekaj (pauza) u sekundama.
        /// </summary>
        /// <example>Pričekaj pola sekunde: <code>Wait(0.5);</code></example>
        /// <param name="sekunde">Realan broj.</param>
        public void Wait(double sekunde)
        {
            int ms = (int)(sekunde * 1000);
            Thread.Sleep(ms);
        }

        //private int SlucajanBroj(int min, int max)
        //{
        //    Random r = new Random();
        //    int br = r.Next(min, max + 1);
        //    return br;
        //}

        /// <summary>
        /// -
        /// </summary>
        public void Init()
        {
            if (dt == null) time = dt.TimeOfDay.ToString();
            loopcount++;
            //Load resources and level here
            this.Paint += new PaintEventHandler(DrawTextOnScreen);
            SetupGame();
        }

        /// <summary>
        /// -
        /// </summary>
        /// <param name="val">-</param>
        public void showSyncRate(bool val)
        {
            showSync = val;
            if (val == true) syncRate.Show();
            if (val == false) syncRate.Hide();
        }

        /// <summary>
        /// -
        /// </summary>
        public void updateSyncRate()
        {
            if (showSync == true)
            {
                thisTime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
                diff = thisTime - lastTime;
                lastTime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;

                double fr = (1000 / diff) / 1000;

                int fr2 = Convert.ToInt32(fr);

                syncRate.Text = fr2.ToString();
            }

        }

        //stage
        #region Stage

        /// <summary>
        /// Postavi naslov pozornice.
        /// </summary>
        /// <param name="title">tekst koji će se ispisati na vrhu (naslovnoj traci).</param>
        public void SetStageTitle(string title)
        {
            this.Text = title;
        }

        /// <summary>
        /// Postavi boju pozadine.
        /// </summary>
        /// <param name="r">r</param>
        /// <param name="g">g</param>
        /// <param name="b">b</param>
        public void setBackgroundColor(int r, int g, int b)
        {
            this.BackColor = Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Postavi boju pozornice. <c>Color</c> je ugrađeni tip.
        /// </summary>
        /// <param name="color"></param>
        public void setBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        /// <summary>
        /// Postavi sliku pozornice.
        /// </summary>
        /// <param name="backgroundImage">Naziv (putanja) slike.</param>
        public void setBackgroundPicture(string backgroundImage)
        {
            this.BackgroundImage = new Bitmap(backgroundImage);
        }

        /// <summary>
        /// Izgled slike.
        /// </summary>
        /// <param name="layout">none, tile, stretch, center, zoom</param>
        public void setPictureLayout(string layout)
        {
            if (layout.ToLower() == "none") this.BackgroundImageLayout = ImageLayout.None;
            if (layout.ToLower() == "tile") this.BackgroundImageLayout = ImageLayout.Tile;
            if (layout.ToLower() == "stretch") this.BackgroundImageLayout = ImageLayout.Stretch;
            if (layout.ToLower() == "center") this.BackgroundImageLayout = ImageLayout.Center;
            if (layout.ToLower() == "zoom") this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        #endregion

        //sound
        #region sound methods

        /// <summary>
        /// Učitaj zvuk.
        /// </summary>
        /// <param name="soundNum">-</param>
        /// <param name="file">-</param>
        public void loadSound(int soundNum, string file)
        {
            soundCount++;
            sounds[soundNum] = new SoundPlayer(file);
        }

        /// <summary>
        /// Sviraj zvuk.
        /// </summary>
        /// <param name="soundNum">-</param>
        public void playSound(int soundNum)
        {
            sounds[soundNum].Play();
        }

        /// <summary>
        /// loopSound
        /// </summary>
        /// <param name="soundNum">-</param>
        public void loopSound(int soundNum)
        {
            sounds[soundNum].PlayLooping();
        }

        /// <summary>
        /// Zaustavi zvuk.
        /// </summary>
        /// <param name="soundNum">broj</param>
        public void stopSound(int soundNum)
        {
            sounds[soundNum].Stop();
        }

        #endregion

        //file
        #region file methods

        /// <summary>
        /// Otvori datoteku za čitanje.
        /// </summary>
        /// <param name="fileName">naziv datoteke</param>
        /// <param name="fileNum">broj</param>
        public void openFileToRead(string fileName, int fileNum)
        {
            readFiles[fileNum] = new StreamReader(fileName);
        }

        /// <summary>
        /// Zatvori datoteku.
        /// </summary>
        /// <param name="fileNum">broj</param>
        public void closeFileToRead(int fileNum)
        {
            readFiles[fileNum].Close();
        }

        /// <summary>
        /// Otvori datoteku za pisanje.
        /// </summary>
        /// <param name="fileName">naziv datoteke</param>
        /// <param name="fileNum">broj</param>
        public void openFileToWrite(string fileName, int fileNum)
        {
            writeFiles[fileNum] = new StreamWriter(fileName);
        }

        /// <summary>
        /// Zatvori datoteku.
        /// </summary>
        /// <param name="fileNum">broj</param>
        public void closeFileToWrite(int fileNum)
        {
            writeFiles[fileNum].Close();
        }

        /// <summary>
        /// Zapiši liniju u datoteku.
        /// </summary>
        /// <param name="fileNum">broj datoteke</param>
        /// <param name="line">linija</param>
        public void writeLine(int fileNum, string line)
        {
            writeFiles[fileNum].WriteLine(line);
        }

        /// <summary>
        /// Pročitaj liniju iz datoteke.
        /// </summary>
        /// <param name="fileNum">broj datoteke</param>
        /// <returns>vraća pročitanu liniju</returns>
        public string readLine(int fileNum)
        {
            return readFiles[fileNum].ReadLine();
        }

        /// <summary>
        /// Čita sadržaj datoteke.
        /// </summary>
        /// <param name="fileNum">broj datoteke</param>
        /// <returns>vraća sadržaj</returns>
        public string readFile(int fileNum)
        {
            return readFiles[fileNum].ReadToEnd();
        }

        #endregion

        //mouse & keys
        #region mouse methods

        /// <summary>
        /// Sakrij strelicu miša.
        /// </summary>
        public void hideMouse()
        {
            Cursor.Hide();
        }

        /// <summary>
        /// Pokaži strelicu miša.
        /// </summary>
        public void showMouse()
        {
            Cursor.Show();
        }

        /// <summary>
        /// Provjerava je li miš pritisnut.
        /// </summary>
        /// <returns>true/false</returns>
        public bool isMousePressed()
        {
            //return sensing.MouseDown;
            return sensing.MouseDown;
        }

        /// <summary>
        /// Provjerava je li tipka pritisnuta.
        /// </summary>
        /// <param name="key">naziv tipke</param>
        /// <returns></returns>
        public bool isKeyPressed(string key)
        {
            if (sensing.Key == key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Provjerava je li tipka pritisnuta.
        /// </summary>
        /// <param name="key">tipka</param>
        /// <returns>true/false</returns>
        public bool isKeyPressed(Keys key)
        {
            if (sensing.Key == key.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #endregion
        /* ------------------- */

        /* ------------ GAME CODE START ------------ */

        /* Game variables */
        private string _imeigraca, _razina, _tekstpitanja;
        private int _brojbodova;
        public bool QuickMathON, LogicalON, AboutMathON;
        public string datoteka;
        List<string> odg1;
        Igrac igrac;
        VrstaRazine Quick_Math, Logical, About_Math;
        SlavniMatematicari Einstein;
        Odgovor1 o1;
        Odgovor2 o2;
        Odgovor3 o3;
        List<Pitanje> svaPitanja;

        /* Initialization */
        public delegate void TouchHandler();
        public static event TouchHandler DodirSLikom;

        Label Vrijeme;
        int Preostalo;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Preostalo > 0)
            {
                Preostalo--;
                Vrijeme.Invoke((MethodInvoker)(() => Vrijeme.Text = Preostalo.ToString()));
            }
            else if(Preostalo==0)
            {
                timer3.Stop();
                START = false;
                using (StreamWriter sw = File.AppendText(GameOptions.datoteka))
                {
                    igrac.Ime = _imeigraca;
                    sw.WriteLine(igrac.Ime + " " + igrac.Bodovi);
                }
                Kraj gotovo = new Kraj(_imeigraca, igrac.Bodovi);
                allSprites.Clear();
                this.Invoke((Action)delegate { this.Close(); });
                gotovo.ShowDialog();
            }
        }

        private void Dodir()
        {
            if (Einstein.TouchingSprite(o1))
            {
                Einstein.X = 50;
                Einstein.Y = 60;
            }
            if (Einstein.TouchingSprite(o2))
            {
                Einstein.X = 50;
                Einstein.Y = 60;
            }
            if (Einstein.TouchingSprite(o3))
            {
                Einstein.X = 50;
                Einstein.Y = 60;
            }

        }

        private void SetupGame()
        {
            //1. setup stage
            SetStageTitle("MathQuiz");
            setBackgroundColor(Color.WhiteSmoke);
            
            //none, tile, stretch, center, zoom
            setPictureLayout("stretch");
            igrac = new Igrac(_imeigraca, _brojbodova);
            igrac.Ime = _imeigraca;
            igrac.Bodovi = _brojbodova;

            ISPIS = String.Format("Igrac: {0} Bodovi= {1} / 10", igrac.Ime, igrac.Bodovi);
            
            //2. add sprites
            o1 = new Odgovor1("sprites//Einstein_Tocno.png", 80, 380);
            o1.SetSize(35);
            Game.AddSprite(o1);

            o2 = new Odgovor2("sprites//Einstein_Tocno.png", 300, 380);
            o2.SetSize(35);
            Game.AddSprite(o2);

            o3 = new Odgovor3("sprites//Einstein_Tocno.png", 530, 380);
            o3.SetSize(35);
            Game.AddSprite(o3);

            Einstein = new SlavniMatematicari("sprites//Einstein_Razina.png", 50, 60);
            Einstein.SetSize(20);
            Game.AddSprite(Einstein);

            if (_razina == "Quick_Math")
            {

                OtvoriQuickMath();
                QuickMathON = true;
                LogicalON = false;
                AboutMathON = false;

            }

            else if (_razina == "Logical")
            {
                OtvoriLogical();
                QuickMathON = false;
                LogicalON = true;
                AboutMathON = false;
   
            }

            else if (_razina == "About_Math")
            {
                OtvoriAboutMath();
                QuickMathON = false;
                LogicalON = false;
                AboutMathON = true;

            }

            Vrijeme = new Label();  
            Vrijeme.Location = new Point(GameOptions.RightEdge-100,50);
            Vrijeme.AutoSize = true;
            Vrijeme.Text = "";
            Vrijeme.ForeColor = Color.White;
            Vrijeme.BackColor = Color.DarkOrange;
            this.Controls.Add(Vrijeme);

            //3. scripts that start
            MouseDown += OdaberiMatematicara;
            MouseMove += KretanjeMatematicara;
            DodirSLikom += Dodir;
        }

        private void UcitavanjePitanja()
        {
            Random g = new Random();
            int slbr = g.Next(0, svaPitanja.Count);

            Pitanje p = svaPitanja[slbr];
            svaPitanja.RemoveAt(slbr);

            lbl_tekstpitanja.Text = p.TekstPitanja;

            string tocan = p.odgovori[p.IndeksTocnog - 1];
            label2.Text = p.odgovori[0].ToString();
            label3.Text = p.odgovori[1].ToString();
            label4.Text = p.odgovori[2].ToString();
            if (label2.Text == tocan)
            {
                o1.Tocan = true;
                o2.Tocan = false;
                o3.Tocan = false;

            }
            if (label3.Text == tocan)
            {

                o2.Tocan = true;
                o1.Tocan = false;
                o3.Tocan = false;

            }
            if (label4.Text == tocan)
            {
                o3.Tocan = true;
                o1.Tocan = false;
                o2.Tocan = false;

            }
        }

        private void OtvoriQuickMath()
        {
            Preostalo = 6;
            Quick_Math = new VrstaRazine()
            {
                ImeRazine = "Quick_Math",
                Pozadinarazine = "backgrounds\\quick_math.jpeg",
            };
            setBackgroundPicture(Quick_Math.Pozadinarazine);

            string lokalnaDatoteka = "Quick_Math_Easy.txt";
            NewMethod(lokalnaDatoteka);
            UcitavanjePitanja();
            
        }

        private void NewMethod(string lokalnaDatoteka)
        {
            svaPitanja = new List<Pitanje>();
            using (StreamReader sr = File.OpenText(lokalnaDatoteka))
            {
                string linija;

                while ((linija = sr.ReadLine()) != null)
                {
                    odg1 = new List<string>();
                    Pitanje p = new Pitanje(linija);
                    svaPitanja.Add(p);
                }
            }
        }

        private void OtvoriLogical()
        {
            Preostalo = 40;
            Logical = new VrstaRazine()
            {
                ImeRazine = "Logical",
                Pozadinarazine = "backgrounds\\logical.jpeg",     
            };
            setBackgroundPicture(Logical.Pozadinarazine);
            string lokalnaDatoteka = "Logical_Difficult.txt";
            NewMethod(lokalnaDatoteka);
            UcitavanjePitanja();
            
        }
        
        private void OtvoriAboutMath()
        {
            Preostalo = 20;
            About_Math = new VrstaRazine()
            {
                ImeRazine = "About_Math",
                Pozadinarazine = "backgrounds\\board.jpeg"
            };
            setBackgroundPicture(About_Math.Pozadinarazine);
            
            string lokalnaDatoteka = "About_Math_Difficult.txt";
            NewMethod(lokalnaDatoteka);
            UcitavanjePitanja();
            
        }
        

        /* Scripts */ 
        SlavniMatematicari odabrani = null;

        void OdaberiMatematicara(object sender, MouseEventArgs e)
        {
            if (Einstein.Clicked(sensing.Mouse))
            {
                odabrani = Einstein;
            }

        }
        
        private void ProvjeraRazine()
        {
            if (_razina == "Quick_Math")
            {
                OtvoriQuickMath();
            }
            else if (_razina == "Logical")
            {
                OtvoriLogical();
            }
            else if (_razina == "About_Math")
            {
                OtvoriAboutMath();
            }
        }

        void KretanjeMatematicara(object sender, MouseEventArgs e)
        {

            if (odabrani != null)
            {
                if (sensing.MouseDown)
                {
                    odabrani.Goto_MousePoint(sensing.Mouse);
                }
                else
                {
                    if (odabrani.TouchingSprite(o1))
                    {
                        
                        if (o1.Tocan==true)
                        {
                            igrac.Bodovi+=1;
                            ProvjeraRazine();
                            DodirSLikom.Invoke();
                        }
                        else
                        {
                            igrac.Bodovi -= 1;
                            ProvjeraRazine();
                            DodirSLikom.Invoke();
                        }
                        
                    }

                    else if (odabrani.TouchingSprite(o2))
                    {
                        if (o2.Tocan == true)  
                        {
                            igrac.Bodovi += 1;
                            ProvjeraRazine();
                            DodirSLikom.Invoke();
                        }
                        else
                        {
                            igrac.Bodovi -= 1;
                            ProvjeraRazine();
                            DodirSLikom.Invoke();
                        }
                    }

                    else if (odabrani.TouchingSprite(o3))
                    {
                        if (o3.Tocan == true) 
                        {
                            igrac.Bodovi += 1;
                            ProvjeraRazine();
                            DodirSLikom.Invoke();
                        }
                        else
                        {
                            igrac.Bodovi -= 1;
                            ProvjeraRazine();
                            DodirSLikom.Invoke();
                        }
                    } 

                    if(igrac.Bodovi==10 || igrac.Bodovi == -5)
                    {
                        START = false;
                        using (StreamWriter sw = File.AppendText(GameOptions.datoteka))
                        {
                            igrac.Ime = _imeigraca;
                            sw.WriteLine(igrac.Ime + " " + igrac.Bodovi);
                        }
                        Kraj gotovo = new Kraj(_imeigraca, igrac.Bodovi);
                        allSprites.Clear();
                        this.Invoke((Action)delegate { this.Close(); });
                        gotovo.ShowDialog();
                    }
                    odabrani = null;
                    ISPIS = String.Format("Igrac: {0} Bodovi= {1} / 10", igrac.Ime, igrac.Bodovi);
                }
            }
        }
      
    }
    
}
