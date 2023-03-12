using System;
using System.Collections.Generic;
using System.Linq;
using TestGameAgalakov.Actions;
using TestGameAgalakov.Characters;

namespace TestGameAgalakov
{
    /// <summary>
    /// Fight Simulator class 
    /// </summary>
    public class FightSimulator : IFightSimulator
    {
        private readonly IList<GameCharacter> _characters;

        /// <summary>
        /// Fight Simulator class 
        /// </summary>
        /// <param name="characters"></param>
        public FightSimulator(IList<GameCharacter> characters)
        {
            _characters = characters;
        }

        /// <summary>
        /// simulate fight each character with any random one
        /// </summary>
        /// <returns>only winner.</returns>
        public GameCharacter SimulateFight()
        {
            // Simulate fights between the characters until only one is left
            Random randIndex = new Random();
            while (_characters.Count > 1)
            {
                var fighters = SelectFithers(randIndex);
                var fighter1 = fighters.fighter1;
                var fighter2 = fighters.fighter2;
                Console.WriteLine("----");
                Console.WriteLine("Fight between {0} and {1}", fighter1, fighter2);

                FightersSpeakToEachOther(fighter1, fighter2);

                fighter1.Fight(fighter2);

                if (fighter2.IsAlive)
                {
                    fighter2.Fight(fighter1);
                    if (!fighter1.IsAlive)
                    {
                        DisplayKillMessage(fighter1);
                        _characters.Remove(fighter1); // Remove the defeated character from the list
                    }
                }
                else
                {
                    DisplayKillMessage(fighter2);
                    _characters.Remove(fighter2); // Remove the defeated character from the list
                }
            }

            return _characters.FirstOrDefault();
        }

        private (GameCharacter fighter1, GameCharacter fighter2) SelectFithers(Random randIndex)
        {
            // Choose two random characters to fight
            int index1 = randIndex.Next(_characters.Count);
            int index2 = randIndex.Next(_characters.Count);
            while (index2 == index1) // Make sure the two characters are not the same
            {
                index2 = randIndex.Next(_characters.Count);
            }

            // Have the characters fight each other
            return (_characters[index1], _characters[index2]);
        }

        private static void FightersSpeakToEachOther(GameCharacter fighter1, GameCharacter fighter2)
        {
            if (fighter1 is ISpeak speak)
            {
                speak.Speak(RandomGenerator.GetWord());
            }

            if (fighter2 is ISpeak speak2)
            {
                speak2.Speak(RandomGenerator.GetWord());
            }
        }

        private static void DisplayKillMessage(GameCharacter fighter)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{fighter} has been defeated!");
            Console.ResetColor();
        }

    }
}