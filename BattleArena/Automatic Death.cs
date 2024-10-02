using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    //creating a death feature
    internal class AutomaticDeath
    {
        private string _name = "Death";
        private float _attackPower = 10000000;
        private string name;
        private int attackPower;

        public AutomaticDeath(string name, int attackPower)
        {
            this.name = name;
            this.attackPower = attackPower;
        }

        public string Name { get { return _name; } }
        public float AttackPower { get { return _attackPower; } }
        public void Death(string name, float attackPower)
        {
            _name = name;
            _attackPower = attackPower;
        }
        //allows death to kill you automatically
        public float Attack(Character other)
        {
            float damage = Math.Max(0, _attackPower - other.DefensePower);
            other.TakeDamage(damage);
            return damage;
        }
    }
}
