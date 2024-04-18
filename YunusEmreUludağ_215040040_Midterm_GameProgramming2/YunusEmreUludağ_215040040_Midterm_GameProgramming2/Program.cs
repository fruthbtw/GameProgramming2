using System;
using System.Threading.Tasks;
using System.Collections.Generic;


class Program
{
    static async Task Main(string[] args)
    {
        // Welcome message
        Console.WriteLine("Welcome to the Dungeon Escape Game!");

        // Asking user for hero name and enemy type
        Console.Write("Enter the name of your hero: ");
        string heroName = Console.ReadLine();

        Console.Write("Enter the type of enemy you will face (e.g., Goblin, Skeleton, Boss): ");
        string enemyType = Console.ReadLine();

        // Creating hero and enemy objects based on user input
        Hero hero = new Hero(heroName, 100, 50, 40);
        Character enemy;

        if (enemyType.ToLower() == "boss")
        {
            // If enemy type is "Boss", create a Boss character
            enemy = new Boss("Boss", 200, 30);
        }
        else
        {
            // If enemy type is anything else, create a generic Enemy character
            enemy = new Enemy(enemyType, 80, 20);
        }

        // Game setup message
        Console.WriteLine("You find yourself in a dark dungeon...");

        // Main game loop
        while (true)
        {
            // User options
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Explore further into the dungeon");
            Console.WriteLine("2. Rest to regain health and stamina");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Random chance to encounter a new enemy
                    Random random = new Random();
                    if (random.Next(1, 4) == 1) // 1/3 chance of encountering a new enemy
                    {
                        Console.WriteLine("You encounter a new enemy!");
                        enemy = GenerateRandomEnemy();
                        await Fight(hero, enemy);
                    }
                    else
                    {
                        Console.WriteLine("You explore deeper into the dungeon, but find nothing...");
                    }
                    break;
                case 2:
                    // Resting option to regain health and stamina
                    Console.WriteLine("You take a moment to rest and regain some health and stamina.");
                    hero.Health += 20;
                    hero.Stamina += 20;
                    if (hero.Health > 100) hero.Health = 100; // Health should not be more than 100
                    if (hero.Stamina > 40) hero.Stamina = 40; // Stamina should not be more than 40
                    break;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    continue;
            }

            // Check if hero is defeated
            if (hero.Health <= 0)
            {
                Console.WriteLine("Game Over! You were defeated by the enemy.");
                break;
            }
        }

        // End of game message
        Console.WriteLine("Thanks for playing!");
    }

    // Method for handling fights between hero and enemy
    static async Task Fight(Hero hero, Character enemy)
    {
        while (true)
        {
            // Printing hero and enemy status
            hero.PrintStatus();
            enemy.PrintStatus();

            // User action selection
            Console.WriteLine("Choose your action:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Special Attack (Costs 20 Stamina)");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Normal attack action
                    await hero.AttackAsync(enemy);
                    break;
                case 2:
                    // Special attack action
                    await hero.SpecialAttackAsync(enemy);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    continue;
            }

            // Check if enemy is defeated
            if (enemy.Health <= 0)
            {
                Console.WriteLine($"You defeated the {enemy.Name}! Congratulations!");
                break;
            }

            // Enemy's turn to attack
            if (enemy is Boss && enemy.Health < 100)
            {
                // Boss's special attack if health is below 100
                await ((Boss)enemy).SpecialAttackAsync(hero);
            }
            else
            {
                // Normal attack if not a boss or boss's health is not low enough
                await enemy.AttackAsync(hero);
            }

            // Check if hero is defeated
            if (hero.Health <= 0)
            {
                Console.WriteLine("Game Over! You were defeated by the enemy.");
                break;
            }

            // Delay for readability
            await Task.Delay(1000);
            Console.WriteLine();
        }
    }

    // Method for generating a random enemy
    static Enemy GenerateRandomEnemy()
    {
        // Randomly select enemy type and create corresponding enemy object
        Random random = new Random();
        string[] enemyTypes = { "Goblin", "Skeleton", "Witch" }; // Added new enemy types
        int index = random.Next(enemyTypes.Length);
        switch (enemyTypes[index])
        {
            case "Goblin":
                return new Enemy("Goblin", 60, 15);
            case "Skeleton":
                return new Enemy("Skeleton", 70, 20);
            case "Witch":
                return new Enemy("Witch", 80, 25);
            default:
                return new Enemy("Unknown", 50, 10);
        }
    }
}