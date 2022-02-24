namespace Hotel.Core.Models.ValueAddedService;

public class Tennis : IValueAddedService
{
    public decimal ConstPrice { get; init; }
    public decimal PerHourPrice { get; init; }

    decimal IValueAddedService.Hours { get; set; }
    
}