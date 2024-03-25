namespace CreditCalculator.After;

public interface ICreditLimitCalculator
{
    public decimal Calculate(Company company, Customer customer);
}