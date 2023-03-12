using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGameAgalakov.Characters;

namespace TestGameAgalakov.Actions
{
    /// <summary>
    /// Interface add option to character to fight to other character
    /// </summary>
    public interface IFight
    {
        void Fight(GameCharacter target);
    }
}
