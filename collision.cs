// Floppy Bird by Chrissie Brown in C#
// done with the help of the internet

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flappy
{
    class Collision
    {
        public bool checkCollision(Bird bbb, Pipe ppp)
        {
            // TODO: use constants not magic numbers: 30 bird width, 50 pipe width, 100 pipe y gap
            if (bbb.X+30 >= ppp.X && bbb.X  <= ppp.X + 50)
            {
                if (bbb.Y <= ppp.Y) return true; 
                if (bbb.Y + 30 >= ppp.Y + 100) return true;
            }
            return false;
        }
    }
}
