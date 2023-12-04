using DungeonGame.Domain.Characters;
using DungeonGame.Domain.Characters.Hero;
using DungeonGame.Domain.Characters.Hero.Vocation;
using DungeonGame.Domain.Characters.Monster;
using DungeonGame.Domain.Characters.Monster.Type;
using DungeonGame.Domain.Enums;
using DungeonGame.Domain.UI;
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
        public static int turnCount { get; set; } = 0;
        static public bool NewGame()
        {
            roundCount = 0;
            var player = GameUI.CreateNewPlayer();
            do
            {
                turnCount = 0;
                var enemy = Monster.GenerateMonster();
                do
                {
                    GameUI.Stats(player, enemy);
                    var playerWinFlag = PlayerWin(GameUI.PlayerPickMove(), enemy.MonsterPickMove());
                    BattleStage(playerWinFlag, player,enemy);
                    turnCount++;
                } while (enemy.isAlive && player.isAlive);
                roundCount++;
                if (player.Lives == 0)
                {
                    Console.WriteLine("PLAYER DIED\n");
                    return false;
                }
                Console.WriteLine($"{enemy.Name} DIED\n");
                player.GainXP(enemy.XP);
            } while (roundCount < 10);
            Console.WriteLine("YOU WON!!!");
            return true;
        }
        static public int PlayerWin(AttackType playerAttack, AttackType monsterAttack)
        {
            var wins = new Dictionary<AttackType, AttackType>
            {
                {AttackType.Direct, AttackType.Side},
                {AttackType.Side, AttackType.Counter},
                {AttackType.Counter, AttackType.Direct},
            };
            if (playerAttack == monsterAttack) return 2;
            else if (playerAttack == wins[monsterAttack]) return 0;
            else return 1;
        }

        static public void BattleStage(int playerWinFlag, Hero player, Monster enemy)
        {
            var characterStatus = 0;
            if (playerWinFlag == 1)
            {
                Console.WriteLine($"{player.Name} WON!");
                characterStatus = player.Turn(enemy, true);
                GameUI.characterStatus(characterStatus, player.Name);
            }
            else if (playerWinFlag == 0)
            {
                Console.WriteLine($"{enemy.Name} WON!");
                characterStatus = enemy.Turn(player, true);
                GameUI.characterStatus(characterStatus,enemy.Name);
            }
            else if (playerWinFlag == 2)
            {
                Console.WriteLine("IT'S A TIE");
            }
            Console.ReadLine();
        }
    }
}
