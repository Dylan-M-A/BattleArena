using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    //creating a skeleton class
    internal class Skeleton : Enemy
    {
        public Skeleton(string name, float maxHealth, float attackPower, float defensePower) : base(name, maxHealth, attackPower, defensePower)
        {
        }

        public override void SpecialAttack()
        {
            throw new NotImplementedException();
        }

        public static implicit operator int(Skeleton v)
        {
            throw new NotImplementedException();
        }
    }
}
