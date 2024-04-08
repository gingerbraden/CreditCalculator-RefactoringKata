namespace CreditCalculator.After;

public class VIPCreditLimitCalculator : ICreditLimitCalculator
{
    public decimal Calculate(Company company, Customer customer)
    {
        return -1;
    }
}