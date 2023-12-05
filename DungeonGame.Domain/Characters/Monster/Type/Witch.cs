using DungeonGame.Domain.Constants;
using DungeonGame.Domain.Enums;
using DungeonGame.Domain.Game;

namespace DungeonGame.Domain.Characters.Monster.Type
{
    public class Witch : Monster
    {
        public override int HP { get; set; } = 20;
        public override int Damage { get; set; } = 30;
        public static int MixUpChance = 5;
        public Witch()
        {
            HP = new Random().Next(20, 25);
            Damage = new Random().Next(25, 35);
            XP = 100;
            Name = "Witch";
            Type = MonsterType.Witch;
        }
        public override void Attack(Character charToAttack)
        {
            charToAttack.HP -= Damage;
        }

        public override int Turn(Character charToAttack, bool winFlag)
        {
            if (CheckStatus() == GameConstants.Stunned) return GameConstants.Stunned;
            if (!winFlag) return GameConstants.LostRound;
            if (new Random().Next(99) <= 10)
                Battle.MixUp = true;
            Attack(charToAttack);
            checkIfAlive(charToAttack);

            return GameConstants.AttackSuccess;
        }
    }
}
