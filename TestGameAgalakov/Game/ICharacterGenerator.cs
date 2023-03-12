using System.Collections.Generic;
using TestGameAgalakov.Characters;

namespace TestGameAgalakov;

public interface ICharacterGenerator
{
    IList<GameCharacter> GenerateCharacters(int numCharacters);
}