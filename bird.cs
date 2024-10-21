// Floppy Bird by Chrissie Brown in C#
// done with the help of the internet

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace flappy
{
    class Bird
    {
        PictureBox B;

        public const int UPWARD_SPEED = 5;
        public const int MAX_FLOOR = 330;
        public const float GRAVITY = (float) 0.5F;
        float speed = 0;    // currrent bird gravity speed

        int x; // current bird x and y
        int y;

        public PictureBox bB
        {
            get { return B; }
        }

        Point p;
        public int X
        {
            get { return x; }
            set { x = value;
            B.Location = new Point(value, y);
            }
        }

        public int Y
        {
            get { return y; }
            set { y = value;
            B.Location = new Point(x, value);
            }
        }

        // constructor
        public Bird ()
        {
            //this.B.BackgroundImage = global::flappy.Properties.Resources.Flappy_Bird;
            //this.B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            x = 60;
            y = 30;
            B = new PictureBox();
            // B.BackColor = SystemColors.ControlDarkDark; // Debug
            B.Location = new Point(x, y);
            B.Size = new Size(30, 30);
            B.Image = Properties.Resources.bird_up;
       }

        public void doPulse()
        {
            this.speed = -UPWARD_SPEED;
        }

        public void doPhysics ()
        {
            this.speed += GRAVITY;
            this.y += (int) this.speed;

            if (speed < 0) B.Image = Properties.Resources.bird_up;
            if (speed >= 0) B.Image = Properties.Resources.bird_down;

            if (y > MAX_FLOOR)    // magic number: bottom reached
                this.speed = 0;

            this.B.Location = new Point(x, y);  // set bird to new location.
        }

        public Point P
        {
            get
            {
                p.X = x;
                p.Y = y;
                return p;
            }
        }
    }


}
