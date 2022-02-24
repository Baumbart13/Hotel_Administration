namespace Hotel.Core.Models;

public class Apartment
{
    public int Number { get; private set; } = 0;
    public uint BedAmount { get; private set; } = 0;
    public bool HasKitchen { get; private set; } = false;
    public bool HasBalcony { get; private set; } = false;
    public bool HasTerrace { get; private set; } = false;
    public decimal PricePerNight { get; private set; } = 0.0m;
}