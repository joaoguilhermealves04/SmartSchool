using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Helpers
{
    public static class DateTimeExtension
    {
        public static int GetCurrentAge(this DateTime dateTime)
        {
            var currentAge = DateTime.Now;
            int age = currentAge.Year - dateTime.Year;

            if (currentAge > dateTime.AddYears(age)) age--;

            return age; 
        }
    }
}
