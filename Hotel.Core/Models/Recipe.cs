using Hotel.Core.Models.ValueAddedService;

namespace Hotel.Core.Models;

public class Recipe
{
    public enum Method
    {
        Cash,
        PayPal,
        Visa
    }

    public decimal Price
    {
        get
        {
            var sumApartments = Apartments.Sum(a => a.PricePerNight);
            var sumServices = AdditionalServices.Sum(service => service.TotalPrice);
            return sumApartments + sumServices;
        }
    }

    public DateOnly PaymentDate { get; private set; } = DateOnly.MinValue;
    public Method PaymentMethod { get; private set; } = Method.Cash;
    public Guest Guest { get; private set; }
    public List<Apartment> Apartments { get; private set; } = new List<Apartment>();
    public List<IValueAddedService> AdditionalServices { get; private set; } = new List<IValueAddedService>();
}