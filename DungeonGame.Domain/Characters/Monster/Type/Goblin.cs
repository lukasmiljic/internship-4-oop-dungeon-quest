using DungeonGame.Domain.Constants;
using DungeonGame.Domain.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Monster.Type
{
    public class Goblin : Monster
    {
        public override int HP { get; set; } = 10;
        public override int Damage { get; set; } = 10;
        public Goblin()
        {
            HP = new Random().Next(5, 15);
            Damage = new Random().Next(7, 14);
            XP = 40;
            Name = "Goblin";
            Type = MonsterType.Goblin;
        }
        public override void Attack(Character charToAttack)
        {
            charToAttack.HP -= Damage;
        }

        public override int Turn(Character charToAttack, bool winFlag)
        {
            if (CheckStatus() == GameConstants.Stunned) return GameConstants.Stunned;
            if (!winFlag) return GameConstants.LostRound;
            Attack(charToAttack);
            checkIfAlive(charToAttack);
            return GameConstants.AttackSuccess;
        }
    }
}
