using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGameAgalakov.Characters;
using TestGameAgalakov.Skills;

namespace TestGameAgalakov
{
    public class GameCharacterFactory
    {
        public static GameCharacter CreateCharacter(string characterType, int index)
        {
            int hitLevel = RandomGenerator.GetHitLevel();//this is not good dependency it should be moved to parameters. just for simplicity

            switch (characterType)
            {
                case "Scorpion":
                    return new Scorpion("Scorpion " + index, 100, hitLevel, new List<ISkill>() { new IncreaseHitLevel() });
                case "SubZero":
                    return new SubZero("Sub Zero " + index, 100, hitLevel, new List<ISkill>() { new RecoverEnergy() });
                default:
                    throw new ArgumentException("Invalid character type.");
            }
        }
    }
}
