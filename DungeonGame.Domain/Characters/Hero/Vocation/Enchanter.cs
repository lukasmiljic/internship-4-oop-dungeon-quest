using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Hero.Vocation
{
    public class Enchanter : Hero
    {
        public override int HP { get; set; } = 90;
        public override int Damage { get; set; } = 30;
        public int Mana { get; set; } = 100;
        public int Lives { get; } = 2;



    }
}
