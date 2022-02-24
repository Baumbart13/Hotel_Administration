namespace Hotel.Core.Models;

public class Reservation
{
    public DateTime Arrival { get; private set; } = DateTime.MinValue;
    public DateTime Departure { get; private set; } = DateTime.MinValue;
    public List<Guest> Guests { get; private set; } = new List<Guest>();
    public List<Apartment> Apartments { get; private set; } = new List<Apartment>();
    public List<Recipe> Recipes { get; private set; } = new List<Recipe>();

    public decimal Price
    {
        get
        {
            var sumPerNight = 0.0m;
            Apartments.ForEach(a => sumPerNight += a.PricePerNight);
            var sumRecipes = 0.0m;
            Recipes.ForEach(r => sumRecipes = r.Price);
            return sumRecipes + sumPerNight;
        }
    }
    
    
}