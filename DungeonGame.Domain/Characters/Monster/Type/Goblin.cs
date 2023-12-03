using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Monster.Type
{
    public class Goblin : Monster
    {
        public override int HP { get; set; } = 30;
        public override int Damage { get; set; } = 10;
        public Goblin()
        {
            HP = new Random().Next(25, 35);
            Damage = new Random().Next(7, 14);
        }
    }
}
