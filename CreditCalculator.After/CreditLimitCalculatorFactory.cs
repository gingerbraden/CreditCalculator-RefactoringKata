namespace CreditCalculator.After;

public class CreditLimitCalculatorFactory
{
    Dictionary<String, Type> calculators = {
        {CustomerConstants.REGULAR_CLIENT, typeof(RegularCreditLimitCalculator)},
        {"banana", 20},
        {"orange", 15}
    };
}