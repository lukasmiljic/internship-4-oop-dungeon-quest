using DungeonGame.Domain.Characters.Monster;
using DungeonGame.Domain.Characters.Monster.Type;
using DungeonGame.Domain.Game;

namespace DungeonGame.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Battle.Rounds();
            for (int i = 0; i < 10; i++)
            {
                var monster = Monster.GenerateMonster();
                DungeonGame.Domain.Game.Battle.roundCount++;
                //Console.WriteLine($"{monster.Name} {monster.HP}");
            }
        }
    }
}
