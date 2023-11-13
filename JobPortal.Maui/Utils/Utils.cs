using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Utils
{
    public class Utils
    {
        public static int CalculateAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthDate.Year;
            if (birthDate.Date > currentDate.AddYears(-age))
            {
                age--;
            }
            return age;
        }
        public static string[] GetFileExtension(string fileName)
        {
            int lastDotIndex = fileName.LastIndexOf('.');

            if (lastDotIndex == -1 || lastDotIndex == fileName.Length - 1)
            {
                return null;
            }
            string[] arr = { fileName.Substring(0,lastDotIndex), fileName.Substring(lastDotIndex + 1) };
            return arr;
        }
        public static string GenerateRandomNumber(int numberOfDigits)
        {
            if (numberOfDigits <= 0)
            {
                throw new ArgumentException("Number of digits must be greater than zero.", nameof(numberOfDigits));
            }

            Random random = new Random();
            int minValue = (int)Math.Pow(10, numberOfDigits - 1);
            int maxValue = (int)Math.Pow(10, numberOfDigits) - 1;

            return $"{random.Next(minValue, maxValue + 1)}";
        }
    }
}
