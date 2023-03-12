using TestGameAgalakov.Characters;

namespace TestGameAgalakov;

public interface IFightSimulator
{
    /// <summary>
    /// SimulateFight and return winner
    /// </summary>
    /// <returns></returns>
    GameCharacter SimulateFight();
}