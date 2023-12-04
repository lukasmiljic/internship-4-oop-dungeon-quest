using DungeonGame.Domain.Characters;
using DungeonGame.Domain.Characters.Hero;
using DungeonGame.Domain.Characters.Hero.Vocation;
using DungeonGame.Domain.Characters.Monster.Type;
using DungeonGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Game
{
    public class Battle
    {
        public static bool MixUp { get; set; } = false;
        public static int roundCount { get; set; } = 0;
        static public bool Rounds()
        {
            roundCount = 0;
            Gladiator player = new Gladiator();
            do
            {
                Goblin enemy = new Goblin();
                do
                {
                    enemy.Name = $"Enemy{roundCount + 1}";
                    Console.WriteLine(enemy.Name + " HP: " + enemy.HP);
                    Console.WriteLine(player.Name + " HP: " + player.HP);
                    if (PlayerWin(AttackType.Direct) == 1)
                    {
                        Console.WriteLine("attack success");
                        player.Attack(enemy);
                    }
                    else
                    {
                        Console.WriteLine("attack fail");
                        enemy.Attack(player);
                    }
                } while (enemy.HP > 0 && player.HP > 0);
                roundCount++;
                if (player.HP < 0)
                {
                    Console.WriteLine("Player died");
                    return false;
                }
                Console.WriteLine($"{enemy.Name} died");
            } while (roundCount < 10);
            Console.WriteLine("you win");
            return true;
        }
        static public int PlayerWin(AttackType playerAttack)
        {
            var rnd = new Random();
            var wins = new Dictionary<AttackType, AttackType>
            {
                {AttackType.Direct, AttackType.Side},
                {AttackType.Side, AttackType.Counter},
                {AttackType.Counter, AttackType.Direct},
            };
            var monsterAttack = (AttackType)rnd.Next(0, 3);
            if (playerAttack == monsterAttack) return 2;
            else if (playerAttack == wins[monsterAttack]) return 0;
            else return 1;
        }
    }
}
