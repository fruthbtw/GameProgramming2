using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class Hero : Character
{
    // Property to represent hero's stamina
    public int Stamina { get; set; }

    // Constructor to initialize Hero object with name, health, attack damage, and stamina
    public Hero(string name, int health, int attackDamage, int stamina)
        : base(name, health, attackDamage) // Call base class constructor
    {
        Stamina = stamina; // Initialize hero's stamina
    }

    // Method for hero's special attack asynchronously
    public async Task SpecialAttackAsync(Character target)
    {
        if (Stamina >= 20) // Check if hero has enough stamina for special attack
        {
            // Perform special attack on the target
            Console.WriteLine($"{Name} performs a special attack on {target.Name}!");
            await Task.Delay(1500); // Simulate delay for special attack animation
            target.Health -= AttackDamage * 2; // Inflict double damage with special attack
            Stamina -= 20; // Reduce stamina after using special attack
        }
        else
        {
            // Print message if hero doesn't have enough stamina for special attack
            Console.WriteLine($"{Name} doesn't have enough stamina for a special attack!");
        }
    }

    // Override method to print hero's status including stamina
    public override void PrintStatus()
    {
        base.PrintStatus(); // Call base class method to print basic status
        Console.WriteLine($"Stamina: {Stamina}\n"); // Print hero's stamina
    }
}