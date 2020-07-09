using Medic.EHR.DataTypes;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IDurationBuilder : IDisposable
    {
        IDurationBuilder AddNullFlavor(CS cs);

        IDurationBuilder AddDays(int days);

        IDurationBuilder AddHours(int hours);

        IDurationBuilder AddMinutes(int minutes);

        IDurationBuilder AddSeconds(int seconds);

        IDurationBuilder AddFractionalSecond(double fractionalSecond);

        IDurationBuilder AddSign(int sign);

        Duration Build();

        IDurationBuilder Clear();
    }
}
