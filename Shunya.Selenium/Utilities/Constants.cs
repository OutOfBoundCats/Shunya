// Author:- raj
// Created At:- 02/11/2023/4:08 pm

namespace Shunya.Selenium;

public class Constants
{
    public enum SupportedBrowsers {CHROME,FIREFOX,IE }

    public enum SchouldType
    {
        INCLUDE,
        
    };
    public enum AndType
    {
        INCLUDE,
        
    };
    public enum RestApiTypes {JSON,SOAP}
    //SNContext keys
    public static string snLoggerr = "SnLogger";
    public static string snWebDriver="SnWebDriver";
}