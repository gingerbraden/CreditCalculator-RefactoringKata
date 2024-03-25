namespace CreditCalculator.After;

public class RegularCreditLimitCalculator : ICreditLimitCalculator
{
    public decimal Calculate(Company company, Customer customer)
    {
        customer.HasCreditLimit = true;
        var creditService = new CustomerCreditServiceClient();

        var creditLimit = creditService.GetCreditLimit(
            customer.FirstName,
            customer.LastName,
            customer.DateOfBirth);

        return creditLimit;
    }
}