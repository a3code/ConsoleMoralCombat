using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGameAgalakov.Actions
{
    /// <summary>
    /// Interface add option to character to move
    /// </summary>
    internal interface IMove
    {
        void Move(int x, int y);
    }
}
