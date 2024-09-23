using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Game
    {
        private bool _gameOver = false;
        Character player = new Character(name: "Player", maxHealth: 100, attackPower: 10, defensePower: 5);
        Character enemy = new Character(name: "Player", maxHealth: 100, attackPower: 9, defensePower: 5);

        private int GetInput(string description, string option1, string option2)
        {
            ConsoleKeyInfo key;
            int InputRecieved = 0;

            while(InputRecieved != 1 && InputRecieved != 2)
            {
                //print options
                Console.Clear();
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.Write("> ");

                //get input from player
                key = Console.ReadKey();
                
                //if first option
                if (key.KeyChar == '1')
                {
                    //set input recieved to 1
                    InputRecieved = 1;
                }
                //otherwise if second option
                else if (key.KeyChar == '2')
                {
                    //set input recieved to 2
                    InputRecieved = 2;
                }
                //else neither
                else
                {
                    //display error message
                    Console.WriteLine("\nInvalid Input");
                    Console.ReadKey();
                }
            }
            Console.WriteLine();
            return InputRecieved;
        }

        private void Start()
        {
            player = new Character(name: "Player", maxHealth: 100, attackPower: 10, defensePower: 5);
            enemy = new Character(name: "Player", maxHealth: 100, attackPower: 9, defensePower: 5);
            player.PrintStats();
            Console.WriteLine();
            enemy.PrintStats();
            Console.Read();
        }
        private void Update()
        {
            player = new Character(name: "Player", maxHealth: 100, attackPower: 10, defensePower: 5);
            enemy = new Character(name: "Player", maxHealth: 100, attackPower: 9, defensePower: 5);
            while (player.Health > 0 && enemy.Health > 0)
            { 
                float damage = player.Attack(enemy);
                float v = enemy.Attack(player);
                Console.ReadKey();
                int input = GetInput("It is your turn. What will you do?", "Attack", "Run");
                if (input == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine(player.Name + " did " + damage + " damage to " + enemy.Name + "!");
                    Console.WriteLine();
                    Console.WriteLine(enemy.Name + " did " + v + " damage to " + player.Name + "!");
                    player.PrintStats();
                    Console.WriteLine();
                    enemy.PrintStats();
                }
                else if (input == 2)
                {
                    Console.WriteLine("You tried to run but was automatically killed.");
                    Console.WriteLine();
                    _gameOver = true;
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        private void End()
        {

        }
        public void Run()
        {
            Start();
            while(!_gameOver)
            {
                Update();
            }
            End();
        }
    }
}
