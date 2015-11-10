using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class Cell
    {
        public Cell Top, Bottom, Left, Right, TopLeft, TopRight, BottomLeft, BottomRight;
        public bool Alive, Next;
        public Cell(bool b = false)
        {
            Alive = b;
            Next = false;
        }
    }
}
