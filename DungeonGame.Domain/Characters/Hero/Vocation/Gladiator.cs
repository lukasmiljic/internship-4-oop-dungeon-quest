using DungeonGame.Domain.Constants;
using DungeonGame.Domain.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Hero.Vocation
{
    public class Gladiator : Hero
    {
        public override int HP { get; set; } = 100;
        public override int Damage { get; set; } = 12;
        public bool rageAttack { get; set; }
        override public int Turn(Character charToAttack, bool winFlag)
        {
            if (!winFlag) return GameConstants.LostRound;
            Attack(charToAttack);
            checkIfAlive(charToAttack);
            if (!charToAttack.isAlive)
            {
                GainXP(charToAttack.XP);
            }
            return GameConstants.AttackSuccess;
        }
        override public void Attack(Character charToAttack)
        {
            Console.WriteLine("RAGE ATTACK");
            rageAttack = Helper.AreYouSure();
            if (rageAttack) RageAttack(charToAttack);
            else charToAttack.HP -= Damage;
        }
        public void RageAttack(Character charToAttack)
        {
            HP -= (int)(HP * 0.15);
            charToAttack.HP -= Damage*2;
            Console.WriteLine($"RAGE ATTACK HIT FOR {Damage * 2} POINTS");
        }
    }
}
