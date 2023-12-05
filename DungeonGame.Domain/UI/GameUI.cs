using DungeonGame.Domain.Characters;
using DungeonGame.Domain.Characters.Hero;
using DungeonGame.Domain.Characters.Monster;
using DungeonGame.Domain.Constants;
using DungeonGame.Domain.Enums;
using DungeonGame.Domain.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.UI
{
    internal class GameUI
    {
        static public Hero? CreateNewPlayer()
        {
            Console.WriteLine("CREATE PLAYER CHARACTER");
            Console.Write("[0] Gladiator [1] Marksman [2] Enchanter\nCLASS: ");
            var vocation = int.Parse(Console.ReadLine());
            Hero player = Hero.GenerateHero((HeroVocation)vocation);
            Console.Write("NAME: ");
            player.Name = Console.ReadLine();
            Console.WriteLine("PLAYER CREATED...");
            Console.ReadLine();
            return player;
        }
        static public void PrintStats(Hero player, Monster enemy) {
            Console.WriteLine($"ROUND {Battle.roundCount+1}");
            Console.WriteLine(player.ToString());
            Console.WriteLine(enemy.ToString());
            if (enemy.IsStunned)
                Console.WriteLine($"{enemy.Name} is stunned");
        }
        static public AttackType PlayerPickMove()
        {
            Console.Write("[0] DIRECT [1] SIDE [2] COUNTER\nCHOOSE YOUR MOVE: ");
            var playerMove = int.Parse(Console.ReadLine());
            return (AttackType)playerMove;
        }
        static public void characterStatus(int characterStatus, String characterName)
        {
            switch (characterStatus) 
            {
                case GameConstants.Resurrected:
                    Console.WriteLine($"{characterName.ToUpper()} RESSURECTED");
                    break;

                case GameConstants.Stunned:
                    Console.WriteLine($"{characterName.ToUpper()} IS STUNNED");
                    break;

                case GameConstants.ManaRefilled:
                    Console.WriteLine($"{characterName.ToUpper()} MANA RESTORED");
                    break;

                case GameConstants.Heal:
                    Console.WriteLine($"{characterName.ToUpper()} HEALED");
                    break;

                default:
                    break;
            }
        }
    }
}
