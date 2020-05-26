using System;

namespace Medic.Services.Base
{
    public abstract class DateTimeBaseHelper
    {
        protected (DateTime startDate, DateTime endDate) CalculateYearsBoundsByAges(int age)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day).AddYears(-1);
            DateTime endDate = new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day);

            return (startDate, endDate);
        }

        protected DateTime CalculateYearBoundByAge(int age) =>
            new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day);
    }
}
