using Medic.EHR.DataTypes;
using Medic.EHR.RM;
using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface ILinkBuilder : IDisposable
    {
        public ILinkBuilder AddNature(CS nature);

        public ILinkBuilder AddRole(CV role);

        public ILinkBuilder AddFollowLink(bool followLink);

        public ILinkBuilder AddTarget(params II[] targets);

        Link Build();

        ILinkBuilder Clear();
    }
}
