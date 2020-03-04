using System;

namespace TaxCalculator.Utility
{
    public static class Logger
    {
        public static void Error(string message, Exception exception)
        {
            Console.WriteLine( "Exception :"+exception +"occured.Check the message :"+message);
        }
    }
}