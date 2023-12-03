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
        public bool outOfMana { get; set; } = false;

        public int Turn(Character charToAttack, bool winFlag)
        {
            if (HP <= 0 && Lives > 1) 
            {
                Lives--;
                return 3;   //resurected
            }
            if (HP <= 0 && Lives <= 0) 
                return 0;   //died
            if (Battle.roundCount == 0) 
                Mana = 100 + Level;
            if (outOfMana && winFlag)
            {
                Mana = 100 + Level;
                return 1;
            }
            if (!toAttack) 
            {
                Mana /= 2;
                HP = 90;
                return 2;
            }
            Attack(charToAttack);
            return 0;

        }
        public override void Attack(Character charToAttack)
        {
            charToAttack.HP -= Damage;
            Mana -= Damage / 2;
        }
    }
}
