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
        static public void Rounds()
        {
            int roundCount = 0;
            Gladiator player = new Gladiator();
            do
            {
                Goblin enemy = new Goblin();
                do
                {
                    enemy.Name = $"Enemy{roundCount + 1}";
                    Console.WriteLine(enemy.Name + " HP: " + enemy.HP);
                    Console.WriteLine(player.Name + " HP: " + player.HP);
                    player.Attack(enemy);
                } while (enemy.HP > 0);
                roundCount++;
            } while (roundCount < 10);
            Console.ReadLine();
        }
        static public int PlayerWin(AttackType playerAttack)
        {
            var wins = new Dictionary<AttackType, AttackType>
            {
                {AttackType.Direct, AttackType.Side},
                {AttackType.Side, AttackType.Counter},
                {AttackType.Counter, AttackType.Direct},
            };
            var monsterAttack = (AttackType)new Random().Next(0, 3);
            if (playerAttack == monsterAttack) return 1;
            else if (playerAttack == wins[monsterAttack]) return 0;
            else return 1;
        }
    }
}
