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
        Character player = new(name: "Player", maxHealth: 100, attackPower: 20, defensePower: 10);
        Goblin goblin = new(name: "Goblin", maxHealth: 10, attackPower: 5, defensePower: 1);
        Skeleton skeleton = new(name: "Skeleton", maxHealth: 40, attackPower: 10, defensePower: 0);
        Soldier soldier = new(name: "Soldier", maxHealth: 100, attackPower: 23, defensePower: 15);
        AutomaticDeath death = new(name: "Death", attackPower: 1000000);
        Enemy[] Enemy;
        Enemy baddue;
        private int i;

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
        private void BattleFunction(Character baddue)
        {
            while (player.Health > 0 && baddue.Health > 0)
            {
                int input = GetChoice("It is your turn. What will you do?", "Attack", "Heal", "Run");
                if (input == 1)
                {
                    player.Attack(baddue);
                    baddue.Attack(player);
                    Console.WriteLine();
                    Console.WriteLine(player.Name + " did " + player.AttackPower + " damage to " + baddue.Name + "!");
                    baddue.PrintStats();
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine(baddue.Name + " did " + baddue.AttackPower + " damage to " + player.Name + "!");
                    player.PrintStats();
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (input == 2)
                {
                    player.Heal(10);
                    Console.WriteLine("You have healed 10 health.");
                    Console.ReadKey();
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
        }

        private void Start()
            //starts the game with printing stats
        {
            Enemy = [goblin, skeleton, soldier];
            Console.WriteLine("Your first opponent is a goblin.");
            player = new Character(name: "", maxHealth: 100, attackPower: 20, defensePower: 10);
            goblin = new Goblin(name: "Goblin", maxHealth: 10, attackPower: 5, defensePower: 1);
            player.PrintStats();
            Console.WriteLine();
            goblin.PrintStats();
            Console.Read();
        }
        private void Update()
            //player fights enemys and has player input fot attack, heal, and run.
        {
            player = new(name: "Player", maxHealth: 100, attackPower: 20, defensePower: 10);
            goblin = new(name: "Goblin", maxHealth: 10, attackPower: 5, defensePower: 1);
            skeleton = new(name: "Skeleton", maxHealth: 40, attackPower: 10, defensePower: 0);
            soldier = new(name: "Soldier", maxHealth: 100, attackPower: 23, defensePower: 15);
            Enemy = [goblin, skeleton, soldier];
            for (int i = 0; i < Enemy.Length; i++) //(int i = goblin; goblin.MaxHealth == goblin; i++) 
            {
                Enemy baddue = Enemy[i];
                Console.ReadKey();
                if (baddue == goblin)
                {
                    BattleFunction(baddue);
                }
                else if (baddue == skeleton)
                {
                    Console.WriteLine("Your next opponent is a skeleton.");
                    player.PrintStats();
                    Console.WriteLine();
                    skeleton.PrintStats();
                    Console.WriteLine();
                    Console.ReadKey();
                    BattleFunction(baddue);
                }
                else if (baddue == soldier)
                {
                    Console.WriteLine("Your final opponent is a soldier.");
                    player.PrintStats();
                    Console.WriteLine();
                    soldier.PrintStats();
                    Console.WriteLine();
                    Console.ReadKey();
                    BattleFunction(baddue);
                }
            }
            Console.WriteLine();
            _gameOver = true;
        }
        private void End()
            //ends game
        {
            Console.WriteLine("You have won all the battles. You are now the champion.");
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
