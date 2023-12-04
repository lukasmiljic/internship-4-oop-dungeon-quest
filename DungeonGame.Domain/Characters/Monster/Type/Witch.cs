using DungeonGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Monster.Type
{
    public class Witch : Monster
    {
        public override int HP { get; set; } = 70;
        public override int Damage { get; set; } = 30;
        public Witch()
        {
            HP = new Random().Next(65, 80);
            Damage = new Random().Next(25, 35);
            Name = "Witch";
            Type = MonsterType.Witch;
        }

        public override void Attack(Character charToAttack)
        {
            throw new NotImplementedException();
        }

        public override int Turn(Character charToAttack, bool winFlag)
        {
            throw new NotImplementedException();
        }
    }
}
