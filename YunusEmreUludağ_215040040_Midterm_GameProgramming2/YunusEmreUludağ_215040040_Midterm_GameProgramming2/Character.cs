using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Character
{
    // Properties to represent character's name, health, and attack damage
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackDamage { get; set; }

    // Constructor to initialize Character object with name, health, and attack damage
    public Character(string name, int health, int attackDamage)
    {
        Name = name; // Initialize character's name
        Health = health; // Initialize character's health
        AttackDamage = attackDamage; // Initialize character's attack damage
    }

    // Method for character's attack asynchronously
    public virtual async Task AttackAsync(Character target)
    {
        Console.WriteLine($"{Name} attacks {target.Name} and deals {AttackDamage} damage."); // Print attack message
        await Task.Delay(1000); // Simulate delay for attack animation
        target.Health -= AttackDamage; // Inflict damage on the target
    }

    // Method to print character's status
    public virtual void PrintStatus()
    {
        // Print character's name, health, and attack damage
        Console.WriteLine($"Name: {Name}\nHealth: {Health}\nAttack Damage: {AttackDamage}\n");
    }
}