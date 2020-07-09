using Medic.EHR.DataTypes;
using Medic.EHR.RM;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.EHRBuilders.Managers
{
    public class EHRManager : IEHRManager
    {
        private bool _isDisposed = false;

        private IAttestationInfoBuilder _attestationInfoBuilder;
        private IAuditInfoBuilder _auditInfoBuilder;
        private IBLBuilder _BLBuilder;
        private ICDBuilder _CDBuilder;
        private ICEBuilder _CEBuilder;
        private IClusterBuilder _clusterBuilder;
        private ICodedTextBuilder _codedTextBuilder;
        private ICompositionBuilder _compositionBuilder;
        private ICRBuilder _CRBuilder;
        private ICSBuilder _CSBuilder;
        private ICVBuilder _CVBuilder;
        private IDATEBuilder _DATEBuilder;
        private IDurationBuilder _durationBuilder;
        private IEDBuilder _EDBuilder;
        private IEIVLBuilder _EIVLBuilder;
        private IElementBuilder _elementBuilder;
        private IEntryBuilder _entryBuilder;
        private IFolderBuilder _folderBuilder;
        private IFunctionalRoleBuilder _functionalRoleBuilder;
        private IIIBuilder _IIBuilder;
        private IINTBuilder _INTBuilder;
        private IIVLBuilder _IVLBuilder;
        private IIVLPQBuilder _IVLPQBuilder;
        private IIVLTSBuilder _IVLTSBuilder;
        private ILinkBuilder _linkBuilder;
        private IOIDBuilder _OIDBuilder;
        private IORDBulder _ORDBulder;
        private IPIVLBuilder _PIVLBuilder;
        private IPQBuilder _PQBuilder;
        private IREALBuilder _REALBuilder;
        private IReferenceModelBuilder _referenceModelBuilder;
        private IRelatedPartyBuilder _relatedPartyBuilder;
        private IRTOBuilder _RTOBuilder;
        private ISectionBuilder _sectionBuilder;
        private ISimpleTextBuilder _simpleTextBuilder;
        private ITSBuilder _TSBuilder;
        private IURIBuilder _URIBuilder;

        public IAttestationInfoBuilder AttestationInfoBuilder
        {
            get
            {
                if (_attestationInfoBuilder != default)
                {
                    return _attestationInfoBuilder;
                }

                _attestationInfoBuilder = new AttestationInfoBuilder();

                return _attestationInfoBuilder;
            }
        }

        public IAuditInfoBuilder AuditInfoBuilder
        {
            get
            {
                if (_auditInfoBuilder != default)
                {
                    return _auditInfoBuilder;
                }

                _auditInfoBuilder = new AuditInfoBuilder();

                return _auditInfoBuilder;
            }
        }

        public IBLBuilder BLBuilder
        {
            get
            {
                if (_BLBuilder != default)
                {
                    return _BLBuilder;
                }

                _BLBuilder = new BLBuilder();

                return _BLBuilder;
            }
        }

        public ICDBuilder CDBuilder
        {
            get
            {
                if (_CDBuilder != default)
                {
                    return _CDBuilder;
                }

                _CDBuilder = new CDBuilder();

                return _CDBuilder;
            }
        }

        public ICEBuilder CEBuilder
        {
            get
            {
                if (_CEBuilder != default)
                {
                    return _CEBuilder;
                }

                _CEBuilder = new CEBuilder();

                return _CEBuilder;
            }
        }

        public IClusterBuilder ClusterBuilder
        {
            get
            {
                if (_clusterBuilder != default)
                {
                    return _clusterBuilder;
                }

                _clusterBuilder = new ClusterBuilder();

                return _clusterBuilder;
            }
        }

        public ICodedTextBuilder CodedTextBuilder
        {
            get
            {
                if (_codedTextBuilder != default)
                {
                    return _codedTextBuilder;
                }

                _codedTextBuilder = new CodedTextBuilder();

                return _codedTextBuilder;
            }
        }

        public ICompositionBuilder CompositionBuilder
        {
            get
            {

                if (_compositionBuilder != default)
                {
                    return _compositionBuilder;
                }

                _compositionBuilder = new CompositionBuilder();

                return _compositionBuilder;
            }
        }

        public ICRBuilder CRBuilder
        {
            get
            {
                if (_CRBuilder != default)
                {
                    return _CRBuilder;
                }

                _CRBuilder = new CRBuilder();

                return _CRBuilder;
            }
        }

        public ICSBuilder CSBuilder
        {
            get
            {
                if (_CSBuilder != default)
                {
                    return _CSBuilder;
                }

                _CSBuilder = new CSBuilder();

                return _CSBuilder;
            }
        }

        public ICVBuilder CVBuilder
        {
            get
            {
                if (_CVBuilder != default)
                {
                    return _CVBuilder;
                }

                _CVBuilder = new CVBuilder();

                return _CVBuilder;
            }
        }

        public IDATEBuilder DATEBuilder
        {
            get
            {
                if (_DATEBuilder != default)
                {
                    return _DATEBuilder;
                }

                _DATEBuilder = new DATEBuilder();

                return _DATEBuilder;
            }
        }

        public IDurationBuilder DurationBuilder
        {
            get
            {
                if (_durationBuilder != default)
                {
                    return _durationBuilder;
                }

                _durationBuilder = new DurationBuilder();

                return _durationBuilder;
            }
        }

        public IEDBuilder EDBuilder
        {
            get
            {
                if (_EDBuilder != default)
                {
                    return _EDBuilder;
                }

                _EDBuilder = new EDBuilder();

                return _EDBuilder;
            }
        }

        public IEIVLBuilder EIVLBuilder
        {
            get
            {
                if (_EIVLBuilder != default)
                {
                    return _EIVLBuilder;
                }

                _EIVLBuilder = new EIVLBuilder();

                return _EIVLBuilder;
            }
        }

        public IElementBuilder ElementBuilder
        {
            get
            {
                if (_elementBuilder != default)
                {
                    return _elementBuilder;
                }

                _elementBuilder = new ElementBuilder();

                return _elementBuilder;
            }
        }

        public IEntryBuilder EntryBuilder
        {
            get
            {
                if (_entryBuilder != default)
                {
                    return _entryBuilder;
                }

                _entryBuilder = new EntryBuilder();

                return _entryBuilder;
            }
        }

        public IFolderBuilder FolderBuilder
        {
            get
            {
                if (_folderBuilder != default)
                {
                    return _folderBuilder;
                }

                _folderBuilder = new FolderBuilder();

                return _folderBuilder;
            }
        }

        public IFunctionalRoleBuilder FunctionalRoleBuilder
        {
            get
            {
                if (_functionalRoleBuilder != default)
                {
                    return _functionalRoleBuilder;
                }

                _functionalRoleBuilder = new FunctionalRoleBuilder();

                return _functionalRoleBuilder;
            }
        }

        public IIIBuilder IIBuilder
        {
            get
            {
                if (_IIBuilder != default)
                {
                    return _IIBuilder;
                }

                _IIBuilder = new IIBuilder();

                return _IIBuilder;
            }
        }

        public IINTBuilder INTBuilder
        {
            get
            {
                if (_INTBuilder != default)
                {
                    return _INTBuilder;
                }

                _INTBuilder = new INTBuilder();

                return _INTBuilder;
            }
        }

        public IIVLBuilder IVLBuilder
        {
            get
            {
                if (_IVLBuilder != default)
                {
                    return _IVLBuilder;
                }

                _IVLBuilder = new IVLBuilder();

                return _IVLBuilder;
            }
        }

        public IIVLPQBuilder IVLPQBuilder
        {
            get
            {
                if (_IVLPQBuilder != default)
                {
                    return _IVLPQBuilder;
                }

                _IVLPQBuilder = new IVLPQBuilder();

                return IVLPQBuilder;
            }
        }

        public IIVLTSBuilder IVLTSBuilder
        {
            get
            {
                if (_IVLTSBuilder != default)
                {
                    return _IVLTSBuilder;
                }

                _IVLTSBuilder = new IVLTSBuilder();

                return _IVLTSBuilder;
            }
        }

        public ILinkBuilder LinkBuilder
        {
            get
            {
                if (_linkBuilder != default)
                {
                    return _linkBuilder;
                }

                _linkBuilder = new LinkBuilder();

                return _linkBuilder;
            }
        }

        public IOIDBuilder OIDBuilder
        {
            get
            {
                if (_OIDBuilder != default)
                {
                    return _OIDBuilder;
                }

                _OIDBuilder = new OIDBuilder();

                return _OIDBuilder;
            }
        }

        public IORDBulder ORDBulder
        {
            get
            {
                if (_ORDBulder != default)
                {
                    return _ORDBulder;
                }

                _ORDBulder = new ORDBulder();

                return _ORDBulder;
            }
        }

        public IPIVLBuilder PIVLBuilder
        {
            get
            {
                if (_PIVLBuilder != default)
                {
                    return _PIVLBuilder;
                }

                _PIVLBuilder = new PIVLBuilder();

                return _PIVLBuilder;
            }
        }

        public IPQBuilder PQBuilder
        {
            get
            {
                if (_PQBuilder != default)
                {
                    return _PQBuilder;
                }

                _PQBuilder = new PQBuilder();

                return _PQBuilder;
            }
        }

        public IREALBuilder REALBuilder
        {
            get
            {
                if (_REALBuilder != default)
                {
                    return _REALBuilder;
                }

                _REALBuilder = new REALBuilder();

                return _REALBuilder;
            }
        }

        public IReferenceModelBuilder ReferenceModelBuilder
        {
            get
            {
                if (_referenceModelBuilder != default)
                {
                    return _referenceModelBuilder;
                }

                _referenceModelBuilder = new ReferenceModelBuilder();

                return _referenceModelBuilder;
            }
        }

        public IRelatedPartyBuilder RelatedPartyBuilder
        {
            get
            {
                if (_relatedPartyBuilder != default)
                {
                    return _relatedPartyBuilder;
                }

                _relatedPartyBuilder = new RelatedPartyBuilder();

                return _relatedPartyBuilder;
            }
        }

        public IRTOBuilder RTOBuilder
        {
            get
            {
                if (_RTOBuilder != default)
                {
                    return _RTOBuilder;
                }

                _RTOBuilder = new RTOBuilder();

                return _RTOBuilder;
            }
        }

        public ISectionBuilder SectionBuilder
        {
            get
            {
                if (_sectionBuilder != default)
                {
                    return _sectionBuilder;
                }

                _sectionBuilder = new SectionBuilder();

                return _sectionBuilder;
            }
        }

        public ISimpleTextBuilder SimpleTextBuilder
        {
            get
            {
                if (_simpleTextBuilder != default)
                {
                    return _simpleTextBuilder;
                }

                _simpleTextBuilder = new SimpleTextBuilder();

                return _simpleTextBuilder;
            }
        }

        public ITSBuilder TSBuilder
        {
            get
            {
                if (_TSBuilder != default)
                {
                    return _TSBuilder;
                }

                _TSBuilder = new TSBuilder();

                return _TSBuilder;
            }
        }

        public IURIBuilder URIBuilder
        {
            get
            {
                if (_URIBuilder != default)
                {
                    return _URIBuilder;
                }

                _URIBuilder = new URIBuilder();

                return _URIBuilder;
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _attestationInfoBuilder?.Dispose();
                _auditInfoBuilder?.Dispose();
                _BLBuilder?.Dispose();
                _CDBuilder?.Dispose();
                _CEBuilder?.Dispose();
                _clusterBuilder?.Dispose();
                _codedTextBuilder?.Dispose();
                _compositionBuilder?.Dispose();
                _CRBuilder?.Dispose();
                _CSBuilder?.Dispose();
                _CVBuilder?.Dispose();
                _DATEBuilder?.Dispose();
                _durationBuilder?.Dispose();
                _EDBuilder?.Dispose();
                _EIVLBuilder?.Dispose();
                _elementBuilder?.Dispose();
                _entryBuilder?.Dispose();
                _folderBuilder?.Dispose();
                _functionalRoleBuilder?.Dispose();
                _IIBuilder?.Dispose();
                _INTBuilder?.Dispose();
                _IVLBuilder?.Dispose();
                _IVLPQBuilder?.Dispose();
                _IVLTSBuilder?.Dispose();
                _linkBuilder?.Dispose();
                _ORDBulder?.Dispose();
                _PIVLBuilder?.Dispose();
                _PQBuilder?.Dispose();
                _REALBuilder?.Dispose();
                _referenceModelBuilder?.Dispose();
                _relatedPartyBuilder?.Dispose();
                _RTOBuilder?.Dispose();
                _sectionBuilder?.Dispose();
                _simpleTextBuilder?.Dispose();
                _TSBuilder?.Dispose();
                _URIBuilder?.Dispose();

                GC.SuppressFinalize(this);
                _isDisposed = !_isDisposed;
            }
        }
    }
}
