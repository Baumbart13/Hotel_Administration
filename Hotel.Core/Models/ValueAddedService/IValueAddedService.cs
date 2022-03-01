namespace Hotel.Core.Models.ValueAddedService;

public interface IValueAddedService
{
    public decimal ConstPrice { get; }
    public decimal PerHourPrice { get; }
    public decimal Hours { get; protected set; }
    
    public decimal TotalPrice => ConstPrice + PerHourPrice * Hours;
    
    public Guest Guest { get; protected set; }
    
    public string Description { get; }
}