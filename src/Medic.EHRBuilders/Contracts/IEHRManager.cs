using System;

namespace Medic.EHRBuilders.Contracts
{
    public interface IEHRManager : IDisposable
    {
        IAttestationInfoBuilder AttestationInfoBuilder { get; }

        IAuditInfoBuilder AuditInfoBuilder { get; }

        IBLBuilder BLBuilder { get; }

        ICDBuilder CDBuilder { get; }

        ICEBuilder CEBuilder { get; }

        IClusterBuilder ClusterBuilder { get; }

        ICodedTextBuilder CodedTextBuilder { get; }

        ICompositionBuilder CompositionBuilder { get; }

        ICRBuilder CRBuilder { get; }

        ICSBuilder CSBuilder { get; }

        ICVBuilder CVBuilder { get; }

        IDATEBuilder DATEBuilder { get; }

        IDurationBuilder DurationBuilder { get; }

        IEDBuilder EDBuilder { get; }

        IEIVLBuilder EIVLBuilder { get; }

        IElementBuilder ElementBuilder { get; }

        IEntryBuilder EntryBuilder { get; }

        IFolderBuilder FolderBuilder { get; }

        IFunctionalRoleBuilder FunctionalRoleBuilder { get; }

        IIIBuilder IIBuilder { get; }

        IINTBuilder INTBuilder { get; }

        IIVLBuilder IVLBuilder { get; }

        IIVLPQBuilder IVLPQBuilder { get; }

        IIVLTSBuilder IVLTSBuilder { get; }

        ILinkBuilder LinkBuilder { get; }

        IOIDBuilder OIDBuilder { get; }

        IORDBulder ORDBulder { get; }

        IPIVLBuilder PIVLBuilder { get; }

        IPQBuilder PQBuilder { get; }

        IREALBuilder REALBuilder { get; }

        IReferenceModelBuilder ReferenceModelBuilder { get; }

        IRelatedPartyBuilder RelatedPartyBuilder { get; }

        IRTOBuilder RTOBuilder { get; }

        ISectionBuilder SectionBuilder { get; }

        ISimpleTextBuilder SimpleTextBuilder { get; }

        ITSBuilder TSBuilder { get; }

        IURIBuilder URIBuilder { get; }
    }
}
