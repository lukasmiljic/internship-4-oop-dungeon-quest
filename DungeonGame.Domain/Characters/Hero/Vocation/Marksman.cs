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
        public float CricitcalChance { get; set; } = 5f;
        public float StunChance { get; set; } = 5f;
    }
}
