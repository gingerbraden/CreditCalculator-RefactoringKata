namespace CreditCalculator.After;

public class CreditLimitCalculatorFactory
{
    static Dictionary<String, ICreditLimitCalculator> calculators = new Dictionary<string, ICreditLimitCalculator>(){
        {CustomerConstants.REGULAR_CLIENT, new RegularCreditLimitCalculator()},
        {CustomerConstants.IMPORTANT_CLIENT, new ImportantCreditLimitCalculator()},
    };


    public static ICreditLimitCalculator GetCalculator(string type)
    {
        if (!calculators.ContainsKey(type))
        {
            throw new NotImplementedException();
        }
        return calculators[type];
    }
}