using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame.Domain.Game;
using DungeonGame.Domain.Constants;

namespace DungeonGame.Domain.Characters.Hero.Vocation
{
    public class Enchanter : Hero
    {
        public override int HP { get; set; } = 80;
        public override int Damage { get; set; } = 20;
        public int Mana { get; set; } = 99 + Level*5;
        public bool toAttack { get; set; } = true;
        public bool outOfMana { get; set; } = false;
        public override string ToString()
        {
            return $"Level {Level} {Name} HP: {HP} Mana: {Mana}";
        }

        public Enchanter()
        {
            Lives = 2;
        }
        override public int Turn(Character charToAttack, bool winFlag)
        {
            if (Battle.turnCount == 0)
                Mana = 100 + Level;
            if (!winFlag) return GameConstants.LostRound;
            if (Mana <= 0)
            {
                Mana = 100 + Level;
                return GameConstants.ManaRefilled;
            }
            if (!toAttack) 
            {
                Mana /= 2;
                HP = 90;
                return GameConstants.Heal;
            }
            
            Attack(charToAttack);
            checkIfAlive(charToAttack);
            if (!charToAttack.isAlive)
                GainXP(charToAttack.XP);
            return GameConstants.AttackSuccess;
        }
        public override void Attack(Character charToAttack)
        {
            charToAttack.HP -= Damage;
            Mana -= Damage / 2;
        }
    }
}
