using Medic.EHR.DataTypes;
using Medic.EHR.RM;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class LinkBuilder : DataValueBuilder, ILinkBuilder
    {
        private Link _value;

        public LinkBuilder()
        {
            Clear();
        }
        
        public ILinkBuilder AddFollowLink(bool followLink)
        {
            _value.FollowLink = followLink;

            return this;
        }

        public ILinkBuilder AddNature(CS nature)
        {
            _value.Nature = nature;

            return this;
        }

        public ILinkBuilder AddRole(CV role)
        {
            _value.Role = role;

            return this;
        }

        public ILinkBuilder AddTarget(params II[] targets)
        {
            if (targets == default || targets.Length == 0)
            {
                return this;
            }

            if (_value.Target == default)
            {
                _value.Target = new List<II>();
            }

            _value.Target.AddRange(targets);

            return this;
        }

        public Link Build() => base.DeepClone<Link>(_value);

        public ILinkBuilder Clear()
        {
            _value = base.ResetValue<Link>();

            return this;
        }

        public override void Dispose()
        {
            if (!base._isDisposed)
            {
                _value = null;
                GC.SuppressFinalize(this);
                _isDisposed = !base._isDisposed;
            }
        }
    }
}
