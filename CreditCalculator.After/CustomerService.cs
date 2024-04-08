namespace CreditCalculator.After;

public class CustomerService
{
    public bool AddCustomer(
        string firstName,
        string lastName,
        string email,
        DateTime dateOfBirth,
        int companyId)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            return false;
        }

        if (!ValidateMail(email))
        {
            return false;
        }

        var age = CustomerUtil.CalculateAge(dateOfBirth);


        if (age < Constants.AGE_21)
        {
            return false;
        }

        var companyRepository = new CompanyRepository();
        var company = companyRepository.GetById(companyId);

        var customer = new Customer
        {
            Company = company,
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };

        CalculateCreditLimit(company, customer);

        if (customer.HasCreditLimit && customer.CreditLimit < Constants.LIMIT_OVER_40)
        {
            return false;
        }

        var customerRepository = new CustomerRepository();
        customerRepository.AddCustomer(customer);

        return true;
    }

    private static void CalculateCreditLimit(Company company, Customer customer)
    {
        customer.CreditLimit =
            CreditLimitCalculatorFactory.GetCalculator(company.CompanyType).Calculate(company, customer);
        if (customer.CreditLimit == -1)
        {
            // Skip credit check
            customer.HasCreditLimit = false;
        }
    }

    private static bool ValidateMail(string mail)
    {
        return Constants.EMAIL_REGEX_PATTERN.Match(mail).Success;
    }
}