using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Constants
{
    public static class GameConstants
    {
        public const int LostRound = -1;
        public const int Death = 0;
        public const int AttackSuccess = 1;
        public const int Resurrected = 2;
        public const int ManaRefilled = 3;
        public const int Heal = 4;
    }
}
