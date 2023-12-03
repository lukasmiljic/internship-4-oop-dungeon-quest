using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Hero.Vocation
{
    public class Gladiator : Hero
    {
        public override int HP { get; set; } = 110;
        public override int Damage { get; set; } = 10;
        public bool rageAttack { get; set; }

        override public void Attack(Character charToAttack)
        {
            if (rageAttack) RageAttack(charToAttack);
            else charToAttack.HP -= Damage;
        }
        public void RageAttack(Character charToAttack)
        {
            Damage *= 2;
            HP -= (int)(HP * 0.15);
            charToAttack.HP -= Damage;
            Damage /= 2;
        }
    }
}
