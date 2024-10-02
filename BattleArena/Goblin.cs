using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Goblin : Enemy
    {
        public Goblin(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
        }

        public override void SpecialAttack()
        {
            throw new NotImplementedException();
        }

        public static implicit operator int(Goblin v)
        {
            throw new NotImplementedException();
        }
    }
}
