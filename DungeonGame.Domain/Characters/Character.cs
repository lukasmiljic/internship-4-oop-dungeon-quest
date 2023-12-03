using DungeonGame.Domain.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters
{
    abstract public class Character
    {
        public string Name { get; set; }
        abstract public int HP { get; set; }
        abstract public int Damage { get; set; }

        //attack u abstract pretvorit
        public void Attack(Character charToAttack)
        {
            if (Battle.PlayerWin(Enums.AttackType.Direct) == 1)
                //charToAttack.HP -= this.Damage;
                Console.WriteLine("attack success");
            else Console.WriteLine("attack failed");
        }
    }
}
