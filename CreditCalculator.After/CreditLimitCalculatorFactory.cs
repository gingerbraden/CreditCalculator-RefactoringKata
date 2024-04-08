namespace CreditCalculator.After;

public class CreditLimitCalculatorFactory
{
    static Dictionary<String, ICreditLimitCalculator> calculators = new Dictionary<string, ICreditLimitCalculator>(){
        {Constants.REGULAR_CLIENT, new RegularCreditLimitCalculator()},
        {Constants.IMPORTANT_CLIENT, new ImportantCreditLimitCalculator()},
        {Constants.VERY_IMPORTANT_CLIENT, new VIPCreditLimitCalculator()}
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