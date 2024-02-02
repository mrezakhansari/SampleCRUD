﻿namespace SampleCRUD.Domain;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime ProduceDate { get; set; }
    public string ManufacturePhone { get; set; }
    public string ManufactureEmail { get; set; }
}