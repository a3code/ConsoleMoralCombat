using System;
using TestGameAgalakov.Characters;

namespace TestGameAgalakov.Skills
{
    public sealed class RecoverEnergy : ISkill
    {
        public void Use(GameCharacter gameCharacter)
        {
            Console.WriteLine("Recover Energy.");
            gameCharacter.AddHealth(1);
        }
    }
}