using System;
using TestGameAgalakov.Characters;

namespace TestGameAgalakov.Skills
{
    public sealed class IncreaseHitLevel : ISkill
    {
        public void Use(GameCharacter gameCharacter)
        {
            Console.WriteLine("Increase Hit Level");
            gameCharacter.IncreaseHitLevel();
        }
    }
}