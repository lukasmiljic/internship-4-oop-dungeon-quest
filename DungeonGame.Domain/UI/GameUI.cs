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
        static public void Stats(Hero player, Monster enemy) {
            Console.WriteLine($"ROUND {Battle.roundCount+1}");
            Console.WriteLine($"{player.Name} HP:{player.HP}");
            Console.WriteLine($"Enemy {enemy.Type} HP: {enemy.HP}");
            if (enemy.IsStunned == 1)
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

                //case GameConstants.AttackSuccess:
                //    Console.WriteLine($"{characterName.ToUpper()} WINS");
                //    break;

                case GameConstants.Stunned:
                    Console.WriteLine($"{characterName.ToUpper()} IS STUNNED");
                    break;

                default:
                    break;
            }
        }
    }
}
