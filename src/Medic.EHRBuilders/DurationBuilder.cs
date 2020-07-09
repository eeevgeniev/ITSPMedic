using Medic.EHR.DataTypes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders
{
    public class DurationBuilder : DataValueBuilder, IDurationBuilder
    {
        private Duration _value;

        public DurationBuilder()
        {
            Clear();
        }
        
        public IDurationBuilder AddDays(int days)
        {
            _value.Days = days;

            return this;
        }

        public IDurationBuilder AddFractionalSecond(double fractionalSecond)
        {
            _value.FractionalSecond = fractionalSecond;

            return this;
        }

        public IDurationBuilder AddHours(int hours)
        {
            _value.Hours = hours;

            return this;
        }

        public IDurationBuilder AddMinutes(int minutes)
        {
            _value.Minutes = minutes;

            return this;
        }

        public IDurationBuilder AddNullFlavor(CS cs)
        {
            _value.NullFlavor = cs;

            return this;
        }

        public IDurationBuilder AddSeconds(int seconds)
        {
            _value.Seconds = seconds;

            return this;
        }

        public IDurationBuilder AddSign(int sign)
        {
            _value.Sign = sign;

            return this;
        }

        public Duration Build() => base.DeepClone<Duration>(_value);

        public IDurationBuilder Clear()
        {
            _value = base.ResetValue<Duration>();

            return this;
        }

        public override void Dispose()
        {
            if (!base._isDisposed)
            {
                _value = null;
                GC.SuppressFinalize(this);
                base._isDisposed = !base._isDisposed;
            }
        }
    }
}
