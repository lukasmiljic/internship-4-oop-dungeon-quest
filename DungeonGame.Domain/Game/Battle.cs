using DungeonGame.Domain.Characters;
using DungeonGame.Domain.Characters.Hero;
using DungeonGame.Domain.Characters.Monster;
using DungeonGame.Domain.Enums;
using DungeonGame.Domain.UI;

namespace DungeonGame.Domain.Game
{
    public class Battle
    {
        public static bool MixUp { get; set; } = false;
        public static int roundCount { get; set; } = 0;
        public static int turnCount { get; set; } = 0;
        
        static public void NewGame()
        {
            do
            {
                Rounds();
                Console.WriteLine("DO YOU WANT TO PLAY AGAIN?");
                if (!Helper.AreYouSure())
                    break;
            } while (true);
            Console.WriteLine("...GOODBYE");
        }
        static public bool Rounds()
        {
            roundCount = 0;
            var player = GameUI.CreateNewPlayer();
            do
            {
                turnCount = 0;
                var enemy = Monster.GenerateMonster();
                do
                {
                    MixUp = false;
                    GameUI.PrintStats(player, enemy);
                    var winner = ChooseWinner(GameUI.PlayerPickMove(), enemy.MonsterPickMove());
                    BattleStage(winner, player, enemy);
                    ++turnCount;
                    if (MixUp == true) DoMixUp(player, enemy);
                } while (enemy.isAlive && player.isAlive);
                ++roundCount;
                if (!player.isAlive)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("PLAYER DIED\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    return false;
                }
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"{enemy.Name} DIED\n");
                Console.BackgroundColor = ConsoleColor.Black;
                player.GainXP(enemy.XP);
            } while (roundCount < 10);
            Console.WriteLine("YOU WON!!!");
            return true;
        }
        static public int ChooseWinner(AttackType playerAttack, AttackType monsterAttack)
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

        static void DoMixUp(Character char1, Character char2)
        {
            char1.HP = new Random().Next(99);
            char2.HP = new Random().Next(99);
        }
    }
}
