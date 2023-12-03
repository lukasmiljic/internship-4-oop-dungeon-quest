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
        abstract public void Attack(Character charToAttack);
        public int IsStunned { get; set; }  = 0;
        public int Lives { get; set; } = 1;
        abstract public int Turn(Character charToAttack, bool winFlag);
    }
}
