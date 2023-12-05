using DungeonGame.Domain.Characters.Monster.Type;
using DungeonGame.Domain.Constants;
using DungeonGame.Domain.Enums;
using DungeonGame.Domain.Game;
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
        override public int XP { get; set; } = 50;

        static public Monster GenerateMonster()
        {
            var rand = new Random();
            var rollDice = rand.Next(99);
            Monster monster;
            if (rollDice >= WitchSpawnRate) monster = new Witch();
            if (rollDice >= BruteSpawnRate) monster = new Brute();
            else monster = new Goblin();
            return monster;
        }

        public int CheckStatus()
        {
            if (Battle.MixUp) HP = new Random().Next(99);
            if (IsStunned)
            {
                IsStunned = false;
                return GameConstants.Stunned!;
            }
            return GameConstants.NoInfo;
        }

        public AttackType MonsterPickMove()
        {
            var rnd = new Random();
            var monsterPick = (AttackType)rnd.Next(0, 3);
            Console.WriteLine($"{this.Name.ToUpper()} CHOSE {monsterPick.ToString().ToUpper()}");
            //return monsterPick;
            return AttackType.Side;
        }
    }
}
