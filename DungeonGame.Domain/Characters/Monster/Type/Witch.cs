using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Monster.Type
{
    public class Witch : Monster
    {
        public override int HP { get; set; } = 90;
        public override int Damage { get; set; } = 30;
        public Witch()
        {
            HP = new Random().Next(95, 85);
            Damage = new Random().Next(25, 35);
        }
    }
}
