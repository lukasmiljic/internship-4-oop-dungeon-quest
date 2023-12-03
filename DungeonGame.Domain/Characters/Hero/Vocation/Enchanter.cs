using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.Domain.Game;

namespace DungeonGame.Domain.Characters.Hero.Vocation
{
    public class Enchanter : Hero
    {
        public override int HP { get; set; } = 90;
        public override int Damage { get; set; } = 30;
        public int Mana { get; set; } = 100 + Level;
        public int Lives { get; set; } = 2;
        public bool toAttack { get; set; } = true;

        public void Turn(bool toAttack)
        {
            if (Battle.roundCount == 0)
            {
                Mana = 100 * Level;
            }
        }
        public override void Attack(Character charToAttack)
        {
            
        }


    }
}
