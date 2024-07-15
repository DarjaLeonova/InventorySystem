﻿namespace InventorySystem.Data.Entities;

public class Product : BaseEntity
{ 
    public string? Name { get; set; } 
    public string? Description { get; set; } 
    public decimal Price { get; set; } 
    public int Quantity { get; set; }
}