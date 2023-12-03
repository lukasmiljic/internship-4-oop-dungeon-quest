using DungeonGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Domain.Characters.Monster
{
    abstract public class Monster : Character
    {
        public MonsterType Type { get; set; }
    }
}
