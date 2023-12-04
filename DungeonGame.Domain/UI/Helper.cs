using DungeonGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.UI
{
    public static class Helper
    {
        public static HeroVocation? ValidateVocation(string vocation)
        {
            if (vocation != HeroVocation.Enchanter.ToString() || vocation != HeroVocation.Marksman.ToString() || vocation != HeroVocation.Gladiator.ToString())
                return null;
            switch (vocation) 
            {
                case "G":
                    return HeroVocation.Gladiator;
                case "M":
                    return HeroVocation.Gladiator;
                case "E":
                    return HeroVocation.Gladiator;
            }
            return null;
        }
    }
}
