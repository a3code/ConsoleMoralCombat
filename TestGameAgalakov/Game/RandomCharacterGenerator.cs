using System;
using System.Collections.Generic;
using TestGameAgalakov.Characters;

namespace TestGameAgalakov;

public class RandomCharacterGenerator : ICharacterGenerator
{
    private readonly Random _randomCharacter;

    public RandomCharacterGenerator()
    {
        _randomCharacter = new Random();
    }

    public IList<GameCharacter> GenerateCharacters(int numCharacters)
    {
        var characters = new List<GameCharacter>();

        for (int i = 0; i < numCharacters; i++)
        {
            int type = _randomCharacter.Next(2);
            string characterType = type == 0 ? "Scorpion" : "SubZero";
            // it could be a enum here
            var character = GameCharacterFactory.CreateCharacter(characterType, i);
            characters.Add(character);
        }

        return characters;
    }
}