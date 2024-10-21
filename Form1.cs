// Floppy Bird by Chrissie Brown in C#
// done with the help of the internet

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappy
{
    public partial class Form1 : Form
    {
        Bird bird = new Bird();
        Boolean Pulse = false;

	// minimal maximal horizontal pipe distance for random
        public const int MIN_HORIZ = 120; 
        public const int MAX_HORIZ = 200;

        public int score = 0;
        static int maxpipes = 4; // always >=3 !
        Pipe[] p = new Pipe[5]; // absolute max 5 pipes on screen

        Collision c = new Collision();

        bool introScreen = true;
        int introCounter;

        public Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // initialize timer
            Timer Clock = new Timer();
            Clock.Interval = 50; // milliseconds 
            Clock.Start();
            Clock.Tick += new EventHandler(Timer_Tick);

            // initialize pipes
            for (int i = 0; i < maxpipes; i++ )
            {
                p[i] = new Pipe();
                this.Controls.Add(p[i].pB);
                this.Controls.Add(p[i].pT);
                if (i > 0) 
			p[i].X = p[i - 1].X + random.Next(MIN_HORIZ, MAX_HORIZ);
			// y gap to next pipe
            }

            bird = new Bird();
            this.Controls.Add(bird.bB);
            this.label1.Text = " 0";
            introCounter = 0;

        }

        // timer code
        public void Timer_Tick(object sender, EventArgs eArgs)
        {
            if (introScreen == false)
            {
                // bird movement, bird physics
                if (Pulse == true)
                {
                    bird.doPulse();
                    Pulse = false;
                }
                bird.doPhysics();
            }

            // intro screen - bird auto move and stuff!
            if (introScreen == true)
            {
                bird.Y = p[0].Y + 30;

                // Blink
                introCounter++;
                if (introCounter > 10)
                {
                    this.label2.Visible = true;
                }
                if (introCounter > 20)
                {
                    this.label2.Visible = false;
                    introCounter = 0;
                }

                // if space pressed, lets begin!
                if (Pulse == true)      
                {
                    introScreen = false;
                    this.Flap.Text = "Space";
                    score = 0;
                    this.label1.Text = " " + score + " ";
                    this.label2.Visible = false;
                }
            }

            // pipes movement / scrolling
            for (int i = 0; i < maxpipes; i++)
            {
                p[i].X = p[i].X - 3;
            }

            // first pipe out of sight?
            if (p[0].X < -55) {
                this.Controls.Remove(p[0].pB);
                this.Controls.Remove(p[0].pT);
                // rotate pointers
                for (int i= 1; i < maxpipes; i++) {
                     p[i-1]=p[i];
                }
                // new pipe
                p[maxpipes-1] = new Pipe();
                this.Controls.Add(p[maxpipes-1].pB);
                this.Controls.Add(p[maxpipes-1].pT);
                p[maxpipes-1].X = p[maxpipes-2].X + random.Next(MIN_HORIZ, MAX_HORIZ);
             }

            if (introScreen == false)
            {
                // check collision on all pipes 
                for (int i = 0; i < maxpipes; i++)
                {
                    if (c.checkCollision(bird, p[i]))
                    {
                        this.Flap.Text = "Ouch!"; introScreen = true;
                    }

                }

                // count score
                for (int i = 0; i < maxpipes; i++)
                {
                    if (p[i].cT == false && bird.X >= p[i].X + 50) // 50 = pipe width
                    {
                        score++; p[i].cT = true;
                        this.label1.Text = " " + score + " ";
                    }
                }
            }
        }


        // user input: handle space bar press

        // Version 1
        private void Flap_KeyPress(object sender, KeyPressEventArgs e)
        {
             Pulse = true;
        }

        // Version2
        private void Flap_KeyDown(object sender, KeyEventArgs e)
        {
           // Pulse = true;
        }

    }
}
