namespace Hotel.Core.Models.ValueAddedService;

public interface IValueAddedService
{
    public decimal ConstPrice { get; init; }
    public decimal PerHourPrice { get; init; }
    public decimal Hours { get; protected set; }
    
    public decimal TotalPrice => ConstPrice + PerHourPrice * Hours;
    
    public Guest Guest { get; protected set; }
}