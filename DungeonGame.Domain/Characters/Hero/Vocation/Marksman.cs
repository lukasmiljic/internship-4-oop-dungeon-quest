using DungeonGame.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Hero.Vocation
{
    public class Marksman : Hero
    {
        public override int HP { get; set; } = 100;
        public override int Damage { get; set; } = 20;
        public int CricitcalChance { get; set; } = 5;
        const int CritMultiplier = 5;
        public int StunChance { get; set; } = 5;
        public bool CritAttack { get; set; } = false;
        override public int Turn(Character charToAttack, bool winFlag)
        {
            CritAttack = false;
            if (HP <= 0)
            {
                Lives--;
                return GameConstants.Death;
            }
            if (!winFlag) return GameConstants.LostRound;
            Attack(charToAttack);
            checkIfAlive(charToAttack);
            return GameConstants.AttackSuccess;
        }
        public override void Attack(Character charToAttack)
        {
            var rand = new Random();
            int rollDice = rand.Next(99);
            if (rollDice <= StunChance) Stun(charToAttack);
            rollDice = rand.Next(99);
            if (rollDice <= CricitcalChance) CriticalAttack(charToAttack);
            else charToAttack.HP -= Damage;
        }

        public void CriticalAttack(Character charToAttack)
        {
            Damage *= CritMultiplier;
            charToAttack.HP -= Damage;
            Damage /= CritMultiplier;
        }

        public void Stun(Character charToAttack)
        {
            charToAttack.IsStunned += 2;
        }
    }
}
