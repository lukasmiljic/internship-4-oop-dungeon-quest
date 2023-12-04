using DungeonGame.Domain.Characters.Monster.Type;
using DungeonGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Monster
{
    abstract public class Monster : Character
    {
        public MonsterType Type { get; set; }
        static public int BruteSpawnRate {get; set;} = 70;
        static public int WitchSpawnRate { get; set; } = 100;

        static public Monster GenerateMonster()
        {
            var rand = new Random();
            var rollDice = rand.Next(99);
            Console.WriteLine($"{BruteSpawnRate} {WitchSpawnRate}");
            Monster monster;
            if (rollDice >= WitchSpawnRate) monster = new Witch();
            if (rollDice >= BruteSpawnRate) monster = new Brute();
            else monster = new Goblin();
            return monster;
        }
    }
}
