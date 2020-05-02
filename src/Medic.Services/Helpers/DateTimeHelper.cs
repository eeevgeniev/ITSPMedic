using System;

namespace Medic.Services.Helpers
{
    internal sealed class DateTimeHelper
    {
        internal (DateTime startDate, DateTime endDate) CalculateYearsBoundsByAges(int age)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day).AddYears(-1);
            DateTime endDate = new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day);

            return (startDate, endDate);
        }

        internal DateTime CalculateYearBoundByAge(int age) => 
            new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day);
    }
}