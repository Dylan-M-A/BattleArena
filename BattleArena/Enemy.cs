using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BattleArena
{
    internal abstract class Enemy : Character
    {
        public Enemy(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
        }
        public abstract void SpecialAttack();

        public int length = Length;

        public static int Length { get; private set; }
    }
}
