using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGameAgalakov.Actions
{
    /// <summary>
    /// Interface add option to character to speak
    /// </summary>
    public interface ISpeak
    {
        void Speak(string message);
    }
}
