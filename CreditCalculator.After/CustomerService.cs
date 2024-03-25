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

        if (!email.Contains('@') && !email.Contains('.'))
        {
            return false;
        }

        var age = CalculateAge(dateOfBirth);


        if (age < 21)
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

        if (customer.HasCreditLimit && customer.CreditLimit < 500)
        {
            return false;
        }

        var customerRepository = new CustomerRepository();
        customerRepository.AddCustomer(customer);

        return true;
    }

    private static void CalculateCreditLimit(Company company, Customer customer)
    {
        if (CustomerConstants.VERY_IMPORTANT_CLIENT.Equals(company.Type))
        {
            // Skip credit check
            customer.HasCreditLimit = false;
        }
        else if (CustomerConstants.IMPORTANT_CLIENT.Equals(company.Type))
        {
            customer.CreditLimit = CreditLimitCalculatorFactory.GetCalculator(CustomerConstants.IMPORTANT_CLIENT).Calculate(company, customer); 
        }
        else
        {
            customer.CreditLimit = CreditLimitCalculatorFactory.GetCalculator(CustomerConstants.REGULAR_CLIENT).Calculate(company, customer);
        }
    }

    private static int CalculateAge(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        var age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month ||
            now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)
        {
            age--;
        }

        return age;
    }
}