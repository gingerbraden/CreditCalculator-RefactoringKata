namespace CreditCalculator.After;

public class ImportantCreditLimitCalculator : ICreditLimitCalculator
{
    public decimal Calculate(Company company, Customer customer)
    {
        customer.HasCreditLimit = true;
        var creditService = new CustomerCreditServiceClient();

        var creditLimit = creditService.GetCreditLimit(
            customer.FirstName,
            customer.LastName,
            customer.DateOfBirth);

        creditLimit *= 2;
        return creditLimit;
    }
}