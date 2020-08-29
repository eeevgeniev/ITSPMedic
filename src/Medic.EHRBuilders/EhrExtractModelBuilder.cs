using Medic.EHR.DataTypes;
using Medic.EHR.Extracts;
using Medic.EHR.RM;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class EhrExtractModelBuilder : DataValueBuilder, IEhrExtractModelBuilder
    {
        private EhrExtract _value;

        public EhrExtractModelBuilder()
        {
            Clear();
        }
        
        public IEhrExtractModelBuilder AddComposition(Composition composition)
        {
            if (composition == default)
            {
                return this;
            }
            
            if(_value.AllCompositions == default)
            {
                _value.AllCompositions = new List<Composition>();
            }
            
            _value.AllCompositions.Add(composition);

            return this;
        }

        public IEhrExtractModelBuilder AddEhrSystem(II ehrSystem)
        {
            if (ehrSystem == default)
            {
                return this;
            }

            _value.EhrSystem = ehrSystem;

            return this;
        }

        public IEhrExtractModelBuilder AddFolder(Folder folder)
        {
            if (folder == default)
            {
                return this;
            }

            if (_value.Folders == default)
            {
                _value.Folders = new List<Folder>();
            }
            
            _value.Folders.Add(folder);

            return this;
        }

        public IEhrExtractModelBuilder AddSubjectOfCare(II subjectOfCare)
        {
            if (subjectOfCare == default)
            {
                return this;
            }

            _value.SubjectOfCare = subjectOfCare;

            return this;
        }

        public IEhrExtractModelBuilder AddTimeCreated(TS timeCreated)
        {
            if (timeCreated == default)
            {
                return this;
            }

            _value.TimeCreated = timeCreated;

            return this;
        }

        public EhrExtract Build() => base.DeepClone<EhrExtract>(_value);

        public IEhrExtractModelBuilder Clear()
        {
            _value = base.ResetValue<EhrExtract>();

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
