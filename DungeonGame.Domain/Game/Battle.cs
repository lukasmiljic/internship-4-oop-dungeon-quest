using DungeonGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Game
{
    public class Battle
    {
        static public int PlayerWin(AttackType playerAttack)
        {
            var wins = new Dictionary<AttackType, AttackType>
            {
                {AttackType.Direct, AttackType.Side},
                {AttackType.Side, AttackType.Counter},
                {AttackType.Counter, AttackType.Direct},
            };
            var monsterAttack = (AttackType)new Random().Next(0, 3);
            if (playerAttack == monsterAttack) return 1;
            else if (playerAttack == wins[monsterAttack]) return 0;
            else return 1;
        }
    }
}
