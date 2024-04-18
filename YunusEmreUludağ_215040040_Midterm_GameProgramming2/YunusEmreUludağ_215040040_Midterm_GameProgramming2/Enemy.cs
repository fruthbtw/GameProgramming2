using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Enemy : Character
{
    // Property to represent the type of enemy
    public string Type { get; set; }

    // Constructor to initialize Enemy object with type, health, and attack damage
    public Enemy(string type, int health, int attackDamage)
        : base(type, health, attackDamage) // Call base class constructor
    {
        Type = type; // Initialize enemy type
    }
}