﻿namespace Inventory.Models;
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString() => $"{Name}: {Age}";
    
}
