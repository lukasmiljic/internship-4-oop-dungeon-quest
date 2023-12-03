using DungeonGame.Domain.Enums;
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
        public static int Level { get; set; } = 1;
        public HeroVocation HeroVocation { get; private set; }
        public void GainXP(int newXP)
        {
            XP += newXP;
            if (XP >= 100)
            {
                Level++;
                XP %= 100;
            }
        }
    }
}
