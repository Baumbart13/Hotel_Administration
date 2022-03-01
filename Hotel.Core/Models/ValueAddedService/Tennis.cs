namespace Hotel.Core.Models.ValueAddedService;

public class Tennis : IValueAddedService
{
    public decimal ConstPrice { get; init; } = 20.00m;
    public decimal PerHourPrice { get; init; } = 15.00m;

    decimal IValueAddedService.Hours { get; set; }

    Guest IValueAddedService.Guest { get; set; }

    public string Description => "Tennis";
}