namespace CreditCalculator.After;

public class Company
{
    public static Company RegularClient = new() { Id = 1, Type = CustomerConstants.REGULAR_CLIENT };
    public static Company ImportantClient = new() { Id = 2, Type = CustomerConstants.IMPORTANT_CLIENT };
    public static Company VeryImportantClient = new() { Id = 3, Type = CustomerConstants.VERY_IMPORTANT_CLIENT };

    public int Id { get; set; }

    public string Type { get; set; }
}