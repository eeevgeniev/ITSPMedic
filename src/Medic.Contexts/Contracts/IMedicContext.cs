using Medic.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Medic.Contexts.Contracts
{
    public interface IMedicContext
    {
        DbSet<AccompanyingDrug> AccompanyingDrugs { get; set; }

        DbSet<APr05> APr05s { get; set; }

        DbSet<APr38> APr38s { get; set; }

        DbSet<CeasedClinical> CeasedClinicals { get; set; }

        DbSet<ChemotherapyPart> ChemotherapyParts { get; set; }

        DbSet<Choice> Choices { get; set; }

        DbSet<ClinicChemotherapyPart> ClinicChemotherapyParts { get; set; }

        DbSet<ClinicHematologyPart> ClinicHematologyParts { get; set; }

        DbSet<ClinicProcedure> ClinicProcedures { get; set; }

        DbSet<ClinicUsedDrug> ClinicUsedDrugs { get; set; }

        DbSet<CommissionApr> CommissionAprs { get; set; }

        DbSet<CommissionAprHealthcarePractitioner> CommissionAprHealthcarePractitioner { get; set; }

        DbSet<CPFile> CPFiles { get; set; }

        DbSet<Diag> Diags { get; set; }

        DbSet<Diagnose> Diagnoses { get; set; }

        DbSet<DispObservation> DispObservations { get; set; }

        DbSet<DoneProcedure> DoneProcedures { get; set; }

        DbSet<DrugPack> DrugPacks { get; set; }

        DbSet<DrugProtocol> DrugProtocols { get; set; }

        DbSet<DrugResidue> DrugResidues { get; set; }

        DbSet<Epicrisis> Epicrises { get; set; }

        DbSet<Evaluation> Evaluations { get; set; }

        DbSet<FileType> FileTypes { get; set; }

        DbSet<GenMarker> GenMarkers { get; set; }

        DbSet<HealthcarePractitioner> HealthcarePractitioners { get; set; }

        DbSet<HealthRegion> HealthRegions { get; set; }

        DbSet<HematologyPart> HematologyParts { get; set; }

        DbSet<HistologicalResult> HistologicalResults { get; set; }

        DbSet<Histology> Histologies { get; set; }

        DbSet<HospitalPractice> HospitalPractices { get; set; }

        DbSet<Implant> Implants { get; set; }

        DbSet<ImplantProductType> ImplantProductTypes { get; set; }

        DbSet<In> Ins { get; set; }

        DbSet<InClinicProcedure> InClinicProcedures { get; set; }

        DbSet<Marker> Markers { get; set; }

        DbSet<MDI> MDIs { get; set; }

        DbSet<MKB> MKBs { get; set; }

        DbSet<Out> Outs { get; set; }

        DbSet<PathProcedure> PathProcedures { get; set; }

        DbSet<Patient> Patients { get; set; }

        DbSet<PatientBranch> PatientBranches { get; set; }

        DbSet<Planned> Plannings { get; set; }

        DbSet<Practice> Practices { get; set; }

        DbSet<Procedure> Procedures { get; set; }

        DbSet<ProtocolDrugTherapy> ProtocolDrugTherapies { get; set; }

        DbSet<ProtocolDrugTherapyHealthPractitioner> ProtocolDrugTherapyHealthPractitioner { get; set; }

        DbSet<Provider> Providers { get; set; }

        DbSet<Redirected> Redirects { get; set; }

        DbSet<Resign> Resigners { get; set; }

        DbSet<SenderType> SenderTypes { get; set; }

        DbSet<Sex> Sexes { get; set; }

        DbSet<SpecialtyType> SpecialtyTypes { get; set; }

        DbSet<TherapyType> TherapyTypes { get; set; }

        DbSet<Transfer> Transfers { get; set; }

        DbSet<UsedDrug> UsedDrugs { get; set; }

        DbSet<VersionCode> VersionCodes { get; set; }

        DbSet<VSD> VSDs { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}