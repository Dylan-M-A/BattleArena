using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    
    internal class Game
    {
        private bool _gameOver = false;
        Character player = new(name: "Player", maxHealth: 100, attackPower: 10, defensePower: 5);
        Goblin goblin = new(name: "Goblin", maxHealth: 10, attackPower: 5, defensePower: 3);
        AutomaticDeath death = new(name: "Death", attackPower: 1000000);
        Skeleton skeleton = new(name: "Skeleton", maxHealth: 40, attackPower: 10, defensePower: 0);
        Soldier soldier = new(name: "Soldier", maxHealth: 100, attackPower: 23, defensePower: 15);
        Enemy[] enemy;

        internal AutomaticDeath Death { get => death; set => death = value; }

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
        private int GetChoice(string description, string option1, string option2, string option3)
        {
            ConsoleKeyInfo key;
            int InputRecieved = 0;

            while (InputRecieved != 1 && InputRecieved != 2 && InputRecieved != 3)
            {
                //print options
                Console.Clear();
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. " + option3);
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
                else if (key.KeyChar == '3')
                {
                    InputRecieved = 3;
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
            //starts the game with printing stats
        {
            enemy = [goblin, skeleton, soldier];
            Console.WriteLine("Your first opponent is a goblin.");
            player = new Character(name: "", maxHealth: 100, attackPower: 10, defensePower: 5);
            goblin = new Goblin(name: "Goblin", maxHealth: 10, attackPower: 5, defensePower: 1);
            player.PrintStats();
            Console.WriteLine();
            goblin.PrintStats();
            Console.Read();
        }
        private void Update()
            //player fights enemys and has player input fot attack, heal, and run.
        {
            player = new Character(name: "Player", maxHealth: 100, attackPower: 10, defensePower: 5);
            goblin = new Goblin(name: "Goblin", maxHealth: 10, attackPower: 5, defensePower: 1);
            for (int i = 0; i < enemy[i].length; i++) //(int i = goblin; goblin.MaxHealth == goblin; i++) 
            {
                Enemy baddue = enemy[i];
                Console.ReadKey();
                int input = GetChoice("It is your turn. What will you do?", "Attack", "Heal", "Run");
                if (input == 1)
                {
                    player.Attack(baddue);
                    baddue.Attack(player);
                    Console.WriteLine();
                    Console.WriteLine(player.Name + " did " + " damage to " + baddue.Name + "!");
                    baddue.PrintStats();
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine(baddue.Name + " did " + " damage to " + player.Name + "!");
                    player.PrintStats();
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (input == 2)
                {
                    Character.Heal(10);
                }
                else if (input == 3)
                {
                    Console.WriteLine("You tried to run but were automatically killed.");
                    Console.WriteLine();
                    Console.ReadKey();
                    float damage = Death.Attack(player);
                    _gameOver = true;
                    break;
                }
            }
            Console.WriteLine();
            _gameOver = true;
        }
        private void End()
            //ends game
        {
            Console.ReadKey();
        }
        public void Run()
            //runs game
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
