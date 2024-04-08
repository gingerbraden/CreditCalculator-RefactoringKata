namespace CreditCalculator.After;

public class Company
{
    public static Company RegularClient = new() { Id = 1, CompanyType = Constants.REGULAR_CLIENT };
    public static Company ImportantClient = new() { Id = 2, CompanyType = Constants.IMPORTANT_CLIENT };
    public static Company VeryImportantClient = new() { Id = 3, CompanyType = Constants.VERY_IMPORTANT_CLIENT };

    public int Id { get; set; }

    public string CompanyType { get; set; }
}