using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Hero
{
    abstract public class Hero : Character
    {
        public int XP { get; private set; } = 0;
        //public Vocation Vocation { get; private set; }
    }
}
