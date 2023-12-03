using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Hero.Vocation
{
    public class Marskman : Hero
    {
        public override int HP { get; set; } = 100;
        public override int Damage { get; set; } = 20;
        public int CricitcalChance { get; set; } = 5;
        const int CritMultiplier = 5;
        public int StunChance { get; set; } = 5;

        public override void Attack(Character charToAttack)
        {
            var rand = new Random();
            int rollDice = rand.Next(99);
            if (rollDice <= StunChance) Stun(charToAttack);
            rollDice = rand.Next(99);
            if (rollDice <= CricitcalChance) CriticalAttack(charToAttack);
        }

        public void CriticalAttack(Character charToAttack)
        {
            Damage *= CritMultiplier;
            charToAttack.HP -= Damage;
            Damage /= CritMultiplier;
        }

        public void Stun(Character charToAttack)
        {
            charToAttack.IsStunned = true;
        }
    }
}
