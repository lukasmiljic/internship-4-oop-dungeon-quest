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


        public void RageAttack()
        {
            //attack(creature,1.5 damage)
            //HP = HP * 0.5;
        }
    }
}
