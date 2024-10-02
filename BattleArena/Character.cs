using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Character
    {
        //giving characters their stats
        private string _name = "Character";
        private float _maxHealth = 10;
        private float _health = 10;
        private float _attackPower = 1;
        private float _defensePower = 1;
        //allowing those stats to be used for child classes
        public string Name { get { return _name; } protected set { _name = value; } }
        public float MaxHealth { get { return _maxHealth; } protected set { _maxHealth = value; } }
        public float Health
        {
            get { return _health; }
            protected set
            {
                _health = Math.Clamp(value, 0, _maxHealth);
            }
        }

        public float AttackPower { get { return _attackPower; } protected set { _attackPower = value; } }
        public float DefensePower { get { return _defensePower; } protected set { _defensePower = value; } }

        public Character(string name, float maxHealth, float attackPower, float defensePower)
        {
            _name = name;
            _maxHealth = maxHealth;
            _health = maxHealth;
            _attackPower = attackPower;  
            _defensePower = defensePower;
        }
        //making an attack function for the characters to use
        public float Attack(Character other)
        {

            float damage = Math.Max(0, _attackPower - other.DefensePower);
            other.TakeDamage(damage);
            return damage;
        }
        //all characters will be able to deal damage
        public void TakeDamage(float damage)
        {
            Health -= damage;
            if (Health == 0)
            {
                Die();
            }
        }
        //the player will use this function to heal a limited amount of health
        public float Heal(Character character)
        {
            float health = Math.Max(10, _health + character.MaxHealth);
            character.Heal(health);
            return health;
        }
        public void Heal(float health)
        {
            Health += health;
        }
        //when a character dies a string will appear with that characters name
        public void Die()
        {
            Console.WriteLine(Name + " has died!");
        }
        //printring out stats
        public void PrintStats()
        {
            Console.WriteLine("Name:          " + Name);
            Console.WriteLine("Health:        " + Health + "/" + MaxHealth);
            Console.WriteLine("Attack Power:  " + AttackPower);
            Console.WriteLine("Defense Power: " + DefensePower);
        }
    }
}
