using System;
using System.Collections.Generic;
using TestGameAgalakov.Characters;

namespace TestGameAgalakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mortal Combat.");
            int numCharacters = GetNumberOfCharacters();
            var characters = CreateCharacters(numCharacters, new RandomCharacterGenerator());
            IFightSimulator fightSimulator = new FightSimulator(characters);
            var winner = fightSimulator.SimulateFight();
            OutputWinner(winner, numCharacters);
        }

        private static int GetNumberOfCharacters()
        {
            int numCharacters = 0;
            while (numCharacters <= 0)
            {
                Console.Write("How many characters do you want to create? ");
                if (!int.TryParse(Console.ReadLine(), out numCharacters))
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            return numCharacters;
        }

        private static IList<GameCharacter> CreateCharacters(int numCharacters, ICharacterGenerator characterGenerator)
        {
            return characterGenerator.GenerateCharacters(numCharacters);
        }

        private static void OutputWinner(GameCharacter winner, int numCharacters)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The winner is {winner?.Name}! Killed: {winner?.Kills} opponents of {numCharacters}");
            Console.ResetColor();
            winner?.SayAboutMyLife();
            Console.ReadLine();
        }

    }
}
