using Microsoft.Extensions.Configuration;
using System;

namespace WeatherExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddUserSecrets<Program>()
            .Build();

            var accessKey = config["AccessKey"];

            while (true)
            {
                Console.WriteLine("Please Enter Zipcode:");

                string zipCode = Console.ReadLine();

                var weather = new Question(accessKey, zipCode);

                Console.WriteLine("Should I go outside: " + ConvertTrueFalseToYesNo(weather.IsRaining()));

                Console.WriteLine("Should I wear sunscreen?: " + ConvertTrueFalseToYesNo(weather.ShouldWearSunScreen()));

                Console.WriteLine("Can I fly my kite?: " + ConvertTrueFalseToYesNo(weather.CanFlyKite()));
            }
        }

        static string ConvertTrueFalseToYesNo(bool answer)
        {
            return answer ? "Yes" : "No";
        }
    }
}
