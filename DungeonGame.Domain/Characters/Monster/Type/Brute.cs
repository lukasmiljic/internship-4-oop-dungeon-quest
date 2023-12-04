﻿using DungeonGame.Domain.Constants;
using DungeonGame.Domain.Enums;
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
        public static int PowerAttackChance { get; set; } = 95;
        public Brute()
        {
            HP = new Random().Next(15, 25);
            Damage = new Random().Next(25, 35);
            XP = 60;
            Name = "Brute";
            Type = MonsterType.Brute;
        }

        public override void Attack(Character charToAttack)
        {
            var rand = new Random();
            int rollDice = rand.Next(99);
            if (rollDice >= PowerAttackChance) charToAttack.HP *= (int)(charToAttack.HP*0.5);
            charToAttack.HP -= Damage;
        }

        public override int Turn(Character charToAttack, bool winFlag)
        {
            if (HP <= 0)
            {
                Lives--;
                return GameConstants.Death;
            }
            if (!winFlag) return GameConstants.LostRound;
            if (CheckStatus() == GameConstants.Stunned) return GameConstants.Stunned;
            Attack(charToAttack);
            checkIfAlive(charToAttack);
            return GameConstants.AttackSuccess;
        }
    }
}
