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
        public bool IsStunned { get; set; }  = false;
        public int Level { get; set; } = 1;

        
    }
}
