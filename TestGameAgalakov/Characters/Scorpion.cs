using System;
using System.Collections.Generic;
using TestGameAgalakov.Actions;
using TestGameAgalakov.Skills;

namespace TestGameAgalakov.Characters
{
    /// <summary>
    /// Scorpion Character
    /// </summary>
    public sealed class Scorpion : GameCharacter, IMove, ISpeak
    {
        public Scorpion(string name, int health, int hitLevel = 3, IEnumerable<ISkill> skills = null) : base(name, health, hitLevel, skills)
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
                Console.Write($"{Name} have noting to say.");
                return;
            }

            var words = message.Split(new char[] { ' ', '.', ',' });
            Console.Write($"{Name} say: ");
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];

                switch (i % 3)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                }

                Console.Write(word + " ");
                Console.ResetColor();
            }
            Console.WriteLine("");
        }
    }
}
