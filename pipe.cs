// Floppy Bird by Chrissie Brown in C#
// done with the help of the internet

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace flappy
{
    class Pipe
    {
        //form is 320 x 480
        static int gap = 100; // vertical gap beetween pipes

        PictureBox pipeTop;
        PictureBox pipeBot;
        int x;  // pipe x
        int y; // top pipe y for coll. detection 
        int topHeight;
        int botHeight;
        bool counted;   // for highscore counting

        public PictureBox pT {
            get {return pipeTop;}
        }

        public PictureBox pB {
            get {return pipeBot;}
        }

        public bool cT
        {
            set { counted = value; }
            get { return counted; }
        }


        // setter used when new pipes come in from right
        public int X {
            set
            {
                x = value;
                pipeTop.Location = new Point (value,0); 
                pipeBot.Location = new Point (value, topHeight + gap);
            }
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }
 
        public Pipe()
        {
            // initial values 
            x = 300;
            Random random = new Random();   // random for y gap placement
            topHeight = random.Next(50, 350 - gap); // y dimens = 0 - 400, pipes 50 - 350
            botHeight = 400 - gap - topHeight;
            y = topHeight;

            counted = false;

            pipeTop = new PictureBox();
            pipeTop.BackColor = SystemColors.ControlDarkDark;
            pipeTop.Location = new Point(x, 0);
            pipeTop.Size = new Size(50, topHeight);

            pipeBot = new PictureBox();
            pipeBot.BackColor = SystemColors.ControlDarkDark;
            pipeBot.Location = new Point(x, topHeight + gap);
            pipeBot.Size = new Size(50, botHeight);

            pipeTop.Image = Properties.Resources.pipe_top;
            pipeTop.SizeMode = PictureBoxSizeMode.StretchImage;
            pipeBot.Image = Properties.Resources.pipe_bot;
            pipeBot.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
