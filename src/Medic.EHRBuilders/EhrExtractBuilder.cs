using Medic.EHR.Clinical;
using Medic.EHR.Complexes;
using Medic.EHR.Components;
using Medic.EHR.Primitives;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Medic.EHRBuilders
{
    public class EhrExtractBuilder : BaseInstanceIdentifierHelper, IEhrExtractBuilder
    {
        private bool _isDisposed = false;


        private EHRExtract EHRExtract;

        public EhrExtractBuilder()
        {
            EHRExtract = new EHRExtract();
        }

        public IEhrExtractBuilder AddCreationTime()
        {
            return AddCreationTime(DateTime.Now);
        }

        public EhrExtractBuilder AddComposition(Composition composition)
        {
            if (composition == default)
            {
                throw new ArgumentNullException(nameof(composition));
            }

            if (EHRExtract.Compositions == default)
            {
                EHRExtract.Compositions = new List<Composition>();
            }

            EHRExtract.Compositions.Add(composition);

            return this;
        }

        public IEhrExtractBuilder AddCreationTime(DateTime dateTime)
        {
            if (dateTime == default)
            {
                throw new ArgumentException(nameof(dateTime));
            }
            
            if (EHRExtract.TimeCreated == default)
            {
                EHRExtract.TimeCreated = new EHRDateTime();
            }

            EHRExtract.TimeCreated.Value = dateTime.ToString("s", CultureInfo.InvariantCulture);

            return this;
        }

        public IEhrExtractBuilder AddEhrId(string rootName, string extension, string identifierName)
        {
            base.ValidateInstanceIdentifierValues(rootName, extension, identifierName);

            if (EHRExtract.EhrId == default)
            {
                EHRExtract.EhrId = new InstanceIdentifier();
            }

            EHRExtract.EhrId.Root = rootName;
            EHRExtract.EhrId.Extension = extension;
            EHRExtract.EhrId.IdentifierName = identifierName;

            return this;
        }

        public IEhrExtractBuilder AddEhrSystem(string rootName, string extension, string identifierName)
        {
            base.ValidateInstanceIdentifierValues(rootName, extension, identifierName);

            if (EHRExtract.EhrSystem == default)
            {
                EHRExtract.EhrSystem = new InstanceIdentifier();
            }

            EHRExtract.EhrSystem.Root = rootName;
            EHRExtract.EhrSystem.Extension = extension;
            EHRExtract.EhrSystem.IdentifierName = identifierName;

            return this;
        }

        public IEhrExtractBuilder AddFolder(Folder folder)
        {
            if (folder == default)
            {
                throw new ArgumentNullException(nameof(folder));
            }

            if (EHRExtract.SubFolders == default)
            {
                EHRExtract.SubFolders = new List<Folder>();
            }

            EHRExtract.SubFolders.Add(folder);

            return this;
        }

        public IEhrExtractBuilder AddPolicyId(string policy)
        {
            if (string.IsNullOrWhiteSpace(policy))
            {
                throw new ArgumentException(nameof(policy));
            }

            if (EHRExtract.AccessPolicyIds == default)
            {
                EHRExtract.AccessPolicyIds = new List<string>();
            }

            EHRExtract.AccessPolicyIds.Add(policy);

            return this;
        }

        public IEhrExtractBuilder AddRmId(string rmId)
        {
            if (string.IsNullOrEmpty(rmId))
            {
                throw new ArgumentException(nameof(rmId));
            }

            EHRExtract.RmId = rmId;

            return this;
        }

        public EHRExtract Build()
        {
            return base.CreateDeepCopy<EHRExtract>(EHRExtract);
        }

        public IEhrExtractBuilder Clear()
        {
            EHRExtract = new EHRExtract();

            return this;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                EHRExtract = null;

                _isDisposed = !_isDisposed;
                GC.SuppressFinalize(this);
            }
        }
    }
}