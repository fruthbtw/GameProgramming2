using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public class Boss : Enemy
{
    // Constructor to initialize Boss object with type, health, and attack damage
    public Boss(string type, int health, int attackDamage)
        : base(type, health, attackDamage) // Call base class constructor
    {
    }

    // Method for boss's special attack asynchronously
    public async Task SpecialAttackAsync(Character target)
    {
        // Perform boss's special attack
        Console.WriteLine($"{Name} unleashes a devastating special attack!");
        await Task.Delay(2000); // Simulate delay for special attack animation
        target.Health -= AttackDamage * 3; // Inflict triple damage with boss's special attack
    }

    // Override method to print boss's status
    public override void PrintStatus()
    {
        base.PrintStatus(); // Call base class method to print basic status
    }
}