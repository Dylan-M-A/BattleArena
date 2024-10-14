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
        //all the character and enemy used in the game
        private bool _gameOver = false;
        Character player = new(name: "Player", maxHealth: 100, attackPower: 25, defensePower: 10);
        Gobling gobling = new(name: "Gobling", maxHealth: 10, attackPower: 5, defensePower: 1);
        GoblinKing goblinking = new(name: "Goblin King", maxHealth: 50, attackPower: 25, defensePower: 10);
        SkeletonArcher skeletonarcher = new(name: "Skeleton Archer", maxHealth: 25, attackPower: 10, defensePower: 0);
        Soldier soldier = new(name: "Soldier", maxHealth: 100, attackPower: 23, defensePower: 15);
        AutomaticDeath death = new(name: "Death", attackPower: 1000000);
        Enemy[] Enemy;
        Enemy baddue;
        private int i;

        internal AutomaticDeath Death { get => death; set => death = value; }
        //creating a function for use of two features.
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
        //creating function use for three features
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
        //making the inputs for battle
        private void BattleFunction(Character baddue)
        {
            while (player.Health > 0 && baddue.Health > 0)
            {
                int input = GetChoice("It is your turn. What will you do?", "Attack", "Heal", "Run");
                //player will attack and game will print out stats after telling the damage.
                if (input == 1)
                {
                    player.Attack(baddue);
                    baddue.Attack(player);
                    Console.WriteLine();
                    Console.WriteLine(player.Name + " did " + (player.AttackPower - baddue.DefensePower) + " damage to " + baddue.Name + "!");
                    baddue.PrintStats();
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();
                    if (baddue.Health > 0)
                    {
                        Console.WriteLine(baddue.Name + " did " + (baddue.AttackPower - player.DefensePower) + " damage to " + player.Name + "!");
                        player.PrintStats();
                        Console.WriteLine();
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                //player will be able to heal
                else if (input == 2)
                {
                    player.Heal(10);
                    Console.WriteLine("You have healed 10 health.");
                    Console.ReadKey();
                }
                //player will try to run but will die
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
            Enemy = [gobling, goblinking, skeletonarcher, soldier];
            Console.WriteLine("Your first opponent is a gobling.");
            player = new Character(name: "", maxHealth: 100, attackPower: 25, defensePower: 10);
            gobling = new Gobling(name: "Gobling", maxHealth: 10, attackPower: 5, defensePower: 1);
            player.PrintStats();
            Console.WriteLine();
            gobling.PrintStats();
            Console.Read();
        }
        private void Update()
            //player fights enemys and has player input fot attack, heal, and run.
        {
            player = new(name: "Player", maxHealth: 100, attackPower: 25, defensePower: 10);
            gobling = new(name: "Gobling", maxHealth: 10, attackPower: 5, defensePower: 1);
            goblinking = new(name: "Goblin King", maxHealth: 50, attackPower: 25, defensePower: 10);
            skeletonarcher = new(name: "Skeleton", maxHealth: 40, attackPower: 10, defensePower: 0);
            soldier = new(name: "Soldier", maxHealth: 100, attackPower: 23, defensePower: 15);
            Enemy = [gobling, goblinking,  skeletonarcher, soldier];
            //takes the battle function and uses it with every enemy type
            for (int i = 0; i < Enemy.Length; i++) //(int i = goblin; goblin.MaxHealth == goblin; i++) 
            {
                Enemy baddue = Enemy[i];
                Console.ReadKey();
                if (baddue == gobling)
                {
                    BattleFunction(baddue);
                }
                else if (baddue == goblinking)
                {
                    Console.WriteLine("Your next opponent is the Goblin King.");
                    player.PrintStats();
                    Console.WriteLine();
                    goblinking.PrintStats();
                    Console.WriteLine();
                    Console.ReadKey();
                    BattleFunction(baddue);
                }
                else if (baddue == skeletonarcher)
                {
                    Console.WriteLine("You're now facing a skeleton archer.");
                    player.PrintStats();
                    Console.WriteLine();
                    skeletonarcher.PrintStats();
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
