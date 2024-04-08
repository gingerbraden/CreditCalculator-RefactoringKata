namespace CreditCalculator.After;

public class CustomerCreditServiceClient
{
    public decimal GetCreditLimit(string firstName, string lastName, DateTime dateOfBirth)
    {
        if (firstName == "John" && lastName == "Doe")
        {
            return Constants.LIMIT_JOHN_DOE;
        }

        if (CustomerUtil.CalculateAge(dateOfBirth) > Constants.AGE_40)
        {
            return Constants.LIMIT_OVER_40;
        }

        return Constants.LIMIT_BASE;
    }
}