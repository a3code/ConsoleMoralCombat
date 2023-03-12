using System;
using System.Collections.Generic;
using TestGameAgalakov.Actions;
using TestGameAgalakov.Skills;

namespace TestGameAgalakov.Characters
{
    /// <summary>
    /// Sub Zero
    /// </summary>
    public sealed class SubZero : GameCharacter, IMove, ISpeak
    {
        public SubZero(string name, int health, int hitLevel = 3, IEnumerable<ISkill> skills = null) : base(name, health, hitLevel, skills)
        {
        }

        public void Move(int x, int y)
        {
            Console.WriteLine($"{Name} move to x {x}, y {y}");
        }

        public void Speak(string message)
        {
           
            if (string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine($"{this} have noting to say.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{this} say: {message}");
            Console.ResetColor();
        }
    }
}
