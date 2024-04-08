using System.Text.RegularExpressions;

namespace CreditCalculator.After;

public class Constants
{
    // EMAIL CONSTANTS
    public static string EMAIL_REGEX = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";
    public static Regex EMAIL_REGEX_PATTERN = new Regex(EMAIL_REGEX);
    
    // CUSTOMER CONSTANTS
    public readonly static string VERY_IMPORTANT_CLIENT = "VeryImportantClient";
    public readonly static string IMPORTANT_CLIENT = "ImportantClient";
    public readonly static string REGULAR_CLIENT = "RegularClient";
    public readonly static int AGE_40 = 40;
    public readonly static int AGE_21 = 21;

    // CREDIT CONSTANTS
    public readonly static decimal LIMIT_JOHN_DOE = 600.0m;
    public readonly static decimal LIMIT_OVER_40 = 500.0m;
    public readonly static decimal LIMIT_BASE = 249.9m;
}