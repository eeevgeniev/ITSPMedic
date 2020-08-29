using Medic.EHRBuilders.Contracts;
using System;
using System.Threading;

namespace Medic.EHRBuilders.Managers
{
    public class EHRManager : IEHRManager
    {
        private bool _isDisposed = false;

        private ReaderWriterLockSlim _locker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

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
        private IEhrExtractModelBuilder _ehrExtractModelBuilder;
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
                if (_attestationInfoBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_attestationInfoBuilder == default)
                    {
                        _attestationInfoBuilder = new AttestationInfoBuilder();
                    }

                    _locker.ExitWriteLock();

                    return _attestationInfoBuilder;
                }

                

                return _attestationInfoBuilder;
            }
        }

        public IAuditInfoBuilder AuditInfoBuilder
        {
            get
            {
                if (_auditInfoBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_auditInfoBuilder == default)
                    {
                        _auditInfoBuilder = new AuditInfoBuilder();
                        
                    }

                    _locker.ExitWriteLock();
                }

                return _auditInfoBuilder;
            }
        }

        public IBLBuilder BLBuilder
        {
            get
            {
                if (_BLBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_BLBuilder == default)
                    {
                        _BLBuilder = new BLBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _BLBuilder;
            }
        }

        public ICDBuilder CDBuilder
        {
            get
            {
                if (_CDBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_CDBuilder == default)
                    {
                        _CDBuilder = new CDBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _CDBuilder;
            }
        }

        public ICEBuilder CEBuilder
        {
            get
            {
                if (_CEBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_CEBuilder == default)
                    {
                        _CEBuilder = new CEBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _CEBuilder;
            }
        }

        public IClusterBuilder ClusterBuilder
        {
            get
            {
                if (_clusterBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_clusterBuilder == default)
                    {
                        _clusterBuilder = new ClusterBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _clusterBuilder;
            }
        }

        public ICodedTextBuilder CodedTextBuilder
        {
            get
            {
                if (_codedTextBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_codedTextBuilder == default)
                    {
                        _codedTextBuilder = new CodedTextBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _codedTextBuilder;
            }
        }

        public ICompositionBuilder CompositionBuilder
        {
            get
            {

                if (_compositionBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_compositionBuilder == default)
                    {
                        _compositionBuilder = new CompositionBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _compositionBuilder;
            }
        }

        public ICRBuilder CRBuilder
        {
            get
            {
                if (_CRBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_CRBuilder == default)
                    {
                        _CRBuilder = new CRBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _CRBuilder;
            }
        }

        public ICSBuilder CSBuilder
        {
            get
            {
                if (_CSBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_CSBuilder == default)
                    {
                        _CSBuilder = new CSBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _CSBuilder;
            }
        }

        public ICVBuilder CVBuilder
        {
            get
            {
                if (_CVBuilder == default)
                {
                    _locker.EnterWriteLock();
                    
                    if (_CVBuilder == default)
                    {
                        _CVBuilder = new CVBuilder();
                    }
                    
                    _locker.ExitWriteLock();
                }

                return _CVBuilder;
            }
        }

        public IDATEBuilder DATEBuilder
        {
            get
            {
                if (_DATEBuilder == default)
                {
                    _locker.EnterWriteLock();
                    
                    if (_DATEBuilder == default)
                    {
                        _DATEBuilder = new DATEBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _DATEBuilder;
            }
        }

        public IDurationBuilder DurationBuilder
        {
            get
            {
                if (_durationBuilder == default)
                {
                    _locker.EnterWriteLock();
                    
                    if (_durationBuilder == default)
                    {
                        _durationBuilder = new DurationBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _durationBuilder;
            }
        }

        public IEDBuilder EDBuilder
        {
            get
            {
                if (_EDBuilder == default)
                {
                    _locker.EnterWriteLock();
                    
                    if (_EDBuilder == default)
                    {
                        _EDBuilder = new EDBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _EDBuilder;
            }
        }

        public IEIVLBuilder EIVLBuilder
        {
            get
            {
                if (_EIVLBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_EIVLBuilder == default)
                    {
                        _EIVLBuilder = new EIVLBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _EIVLBuilder;
            }
        }

        public IElementBuilder ElementBuilder
        {
            get
            {
                if (_elementBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_elementBuilder == default)
                    {
                        _elementBuilder = new ElementBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _elementBuilder;
            }
        }

        public IEntryBuilder EntryBuilder
        {
            get
            {
                if (_entryBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_entryBuilder == default)
                    {
                        _entryBuilder = new EntryBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _entryBuilder;
            }
        }

        public IFolderBuilder FolderBuilder
        {
            get
            {
                if (_folderBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_folderBuilder == default)
                    {
                        _folderBuilder = new FolderBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _folderBuilder;
            }
        }

        public IFunctionalRoleBuilder FunctionalRoleBuilder
        {
            get
            {
                if (_functionalRoleBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_functionalRoleBuilder == default)
                    {
                        _functionalRoleBuilder = new FunctionalRoleBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _functionalRoleBuilder;
            }
        }

        public IIIBuilder IIBuilder
        {
            get
            {
                if (_IIBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_IIBuilder == default)
                    {
                        _IIBuilder = new IIBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _IIBuilder;
            }
        }

        public IINTBuilder INTBuilder
        {
            get
            {
                if (_INTBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_INTBuilder == default)
                    {
                        _INTBuilder = new INTBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _INTBuilder;
            }
        }

        public IIVLBuilder IVLBuilder
        {
            get
            {
                if (_IVLBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_IVLBuilder == default)
                    {
                        _IVLBuilder = new IVLBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _IVLBuilder;
            }
        }

        public IIVLPQBuilder IVLPQBuilder
        {
            get
            {
                if (_IVLPQBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_IVLPQBuilder == default)
                    {
                        _IVLPQBuilder = new IVLPQBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return IVLPQBuilder;
            }
        }

        public IIVLTSBuilder IVLTSBuilder
        {
            get
            {
                if (_IVLTSBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_IVLTSBuilder == default)
                    {
                        _IVLTSBuilder = new IVLTSBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _IVLTSBuilder;
            }
        }

        public ILinkBuilder LinkBuilder
        {
            get
            {
                if (_linkBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_linkBuilder == default)
                    {
                        _linkBuilder = new LinkBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _linkBuilder;
            }
        }

        public IOIDBuilder OIDBuilder
        {
            get
            {
                if (_OIDBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_OIDBuilder == default)
                    {
                        _OIDBuilder = new OIDBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _OIDBuilder;
            }
        }

        public IORDBulder ORDBulder
        {
            get
            {
                if (_ORDBulder == default)
                {
                    _locker.EnterWriteLock();
                    
                    if (_ORDBulder == default)
                    {
                        _ORDBulder = new ORDBulder();
                    }

                    _locker.ExitWriteLock();
                }

                return _ORDBulder;
            }
        }

        public IPIVLBuilder PIVLBuilder
        {
            get
            {
                if (_PIVLBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_PIVLBuilder == default)
                    {
                        _PIVLBuilder = new PIVLBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _PIVLBuilder;
            }
        }

        public IPQBuilder PQBuilder
        {
            get
            {
                if (_PQBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_PQBuilder == default)
                    {
                        _PQBuilder = new PQBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _PQBuilder;
            }
        }

        public IREALBuilder REALBuilder
        {
            get
            {
                if (_REALBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_REALBuilder == default)
                    {
                        _REALBuilder = new REALBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _REALBuilder;
            }
        }

        public IEhrExtractModelBuilder EhrExtractModelBuilder
        {
            get
            {
                if (_ehrExtractModelBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_ehrExtractModelBuilder == default)
                    {
                        _ehrExtractModelBuilder = new EhrExtractModelBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _ehrExtractModelBuilder;
            }
        }

        public IRelatedPartyBuilder RelatedPartyBuilder
        {
            get
            {
                if (_relatedPartyBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_relatedPartyBuilder == default)
                    {
                        _relatedPartyBuilder = new RelatedPartyBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _relatedPartyBuilder;
            }
        }

        public IRTOBuilder RTOBuilder
        {
            get
            {
                if (_RTOBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_RTOBuilder == default)
                    {
                        _RTOBuilder = new RTOBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _RTOBuilder;
            }
        }

        public ISectionBuilder SectionBuilder
        {
            get
            {
                if (_sectionBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_sectionBuilder == default)
                    {
                        _sectionBuilder = new SectionBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _sectionBuilder;
            }
        }

        public ISimpleTextBuilder SimpleTextBuilder
        {
            get
            {
                if (_simpleTextBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_simpleTextBuilder == default)
                    {
                        _simpleTextBuilder = new SimpleTextBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _simpleTextBuilder;
            }
        }

        public ITSBuilder TSBuilder
        {
            get
            {
                if (_TSBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_TSBuilder == default)
                    {
                        _TSBuilder = new TSBuilder();
                    }

                    _locker.ExitWriteLock();
                }

                return _TSBuilder;
            }
        }

        public IURIBuilder URIBuilder
        {
            get
            {
                if (_URIBuilder == default)
                {
                    _locker.EnterWriteLock();

                    if (_URIBuilder == default)
                    {
                        _URIBuilder = new URIBuilder();
                    }

                    _locker.ExitWriteLock();
                }

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
                _ehrExtractModelBuilder?.Dispose();
                _relatedPartyBuilder?.Dispose();
                _RTOBuilder?.Dispose();
                _sectionBuilder?.Dispose();
                _simpleTextBuilder?.Dispose();
                _TSBuilder?.Dispose();
                _URIBuilder?.Dispose();
                
                _locker?.Dispose();

                GC.SuppressFinalize(this);
                _isDisposed = !_isDisposed;
            }
        }
    }
}
