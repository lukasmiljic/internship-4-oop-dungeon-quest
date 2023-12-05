using DungeonGame.Domain.Constants;
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
        abstract public int XP { get; set; }
        abstract public void Attack(Character charToAttack);
        public bool isAlive { get; set; } = true;
        public bool IsResurrected { get; set; } = false;
        public bool IsStunned { get; set; }  = false;
        public int Lives { get; set; } = 1;
        static public void checkIfAlive(Character character) 
        {
            if (character.HP <= 0)
            {
                --character.Lives;
                if (character.Lives <= 0)
                    character.isAlive = false;
                else
                {
                    character.IsResurrected = true;
                    Console.WriteLine(character.Name + " RESURRECTED");
                    character.HP = 100;
                }
            }
            else character.isAlive = true;
        }
        abstract public int Turn(Character charToAttack, bool winFlag);
        public override string ToString()
        {
            return $"{Name} HP: {HP}";
        }

    }
}
