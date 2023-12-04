﻿using DungeonGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Monster.Type
{
    public class Brute : Monster
    {
        public override int HP { get; set; } = 60;
        public override int Damage { get; set; } = 30;
        public Brute()
        {
            HP = new Random().Next(55, 65);
            Damage = new Random().Next(25, 35);
            Name = "Brute";
            Type = MonsterType.Brute;
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
