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
        public void Attack(Character charToAttack)
        {
            if (Battle.PlayerWin(Enums.AttackType.Direct) == 1)
                Console.WriteLine("attack success");
            else Console.WriteLine("attack failed");
            Console.ReadLine();
        }
    }
}
