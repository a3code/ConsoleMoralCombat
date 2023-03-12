using System;

namespace TestGameAgalakov;

public static class RandomGenerator
{
    static readonly Random RandomWords = new();
    static readonly Random RandomHit = new();
    public static string GetWord()
    {
        int speechType = RandomWords.Next(4); // Assume 3 types of speeches for this example

        switch (speechType)
        {
            case 0:
                return "Let's do this!";
            case 1:
                return "I'm ready to fight!";
            case 2:
                return "You're going down!";
            case 3:
                return "You will die!";
            default:
                return "Let's fight!";
        }
    }

    public static int GetHitLevel()
    {
        return RandomHit.Next(25);
    }

}