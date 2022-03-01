namespace Hotel.Core.Models.ValueAddedService;

public class Swimming : IValueAddedService
{
    public decimal ConstPrice { get; init; } = 25.00m;
    public decimal PerHourPrice { get; init; } = 10.00m;

    decimal IValueAddedService.Hours { get; set; }

    Guest IValueAddedService.Guest { get; set; }
    public string Description => "Swimming";
}