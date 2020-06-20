using Medic.EHR.Clinical;
using Medic.EHR.Complexes;
using Medic.EHRBuilders.Base;
using Medic.EHRBuilders.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.EHRBuilders
{
    public class EhrFolderBuilder : BaseInstanceIdentifierHelper, IEhrFolderBuilder
    {
        private bool _isDisposed = false;


        private Folder Folder;

        public EhrFolderBuilder()
        {
            Folder = new Folder();
        }
        
        public IEhrFolderBuilder AddComposition(Composition composition)
        {
            if (composition == default)
            {
                throw new ArgumentNullException(nameof(composition));
            }

            if (Folder.Compositions == default)
            {
                Folder.Compositions = new List<Composition>();
            }

            Folder.Compositions.Add(composition);

            return this;
        }

        public IEhrFolderBuilder AddSubFolder(Folder folder)
        {
            if (folder == default)
            {
                throw new ArgumentNullException(nameof(folder));
            }

            if (Folder.SubFolders == default)
            {
                Folder.SubFolders = new List<Folder>();
            }

            Folder.SubFolders.Add(folder);

            return this;
        }

        public IEhrFolderBuilder AddSubjectOfCare(string rootName, string extension, string identifierName)
        {
            base.ValidateInstanceIdentifierValues(rootName, extension, identifierName);
            
            if (Folder.SubjectOfCare == default)
            {
                Folder.SubjectOfCare = new InstanceIdentifier();
            }

            Folder.SubjectOfCare.Root = rootName;
            Folder.SubjectOfCare.Extension = extension;
            Folder.SubjectOfCare.IdentifierName = identifierName;

            return this;
        }

        public Folder Build()
        {
            return base.CreateDeepCopy<Folder>(Folder);
        }

        public IEhrFolderBuilder Clear()
        {
            Folder = new Folder();

            return this;
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                Folder = null;

                _isDisposed = !_isDisposed;
                GC.SuppressFinalize(this);
            }
        }
    }
}
