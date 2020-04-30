using Medic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medic.Contexts.Contracts
{
    public interface IMedicContext
    {
        DbSet<AccompanyingDrug> AccompanyingDrugs { get; set; }

        DbSet<CeasedClinicalPath> CeasedClinicalPaths { get; set; }

        DbSet<ChemotherapyPart> ChemotherapyParts { get; set; }

        DbSet<Choise> Choises { get; set; }

        DbSet<CPFile> CPFiles { get; set; }

        DbSet<Diagnose> Diagnoses { get; set; }

        DbSet<Diag> Diags { get; set; }

        DbSet<DrugProtocol> DrugProtocols { get; set; }

        DbSet<Epicrisis> Epicrises { get; set; }

        DbSet<Evaluation> Evaluations { get; set; }

        DbSet<FileType> FileTypes { get; set; }

        DbSet<GenMarker> GenMarkers { get; set; }

        DbSet<HealthcarePractitionerEpicrisis> HealthcarePractitionerEpicrisis { get; set; }

        DbSet<HealthcarePractitioner> HealthcarePractitioners { get; set; }
        DbSet<HealthRegion> HealthRegions { get; set; }

        DbSet<HematologyPart> HematologyParts { get; set; }

        DbSet<Histology> Histologies { get; set; }

        DbSet<HospitalPractice> HospitalPractices { get; set; }

        DbSet<ImplantProductType> ImplantProductTypes { get; set; }

        DbSet<Implant> Implants { get; set; }

        DbSet<InClinicProcedure> InClinicProcedures { get; set; }

        DbSet<In> Ins { get; set; }

        DbSet<Out> Outs { get; set; }

        DbSet<PathProcedure> PathProcedures { get; set; }

        DbSet<PatientBranch> PatientBranches { get; set; }

        DbSet<Patient> Patients { get; set; }

        DbSet<Practice> Practices { get; set; }

        DbSet<Procedure> Procedures { get; set; }

        DbSet<ProtocolDrugTherapy> ProtocolDrugTherapies { get; set; }

        DbSet<ProtocolDrugTherapyHealthPractitioner> ProtocolDrugTherapyHealthPractitioner { get; set; }

        DbSet<Provider> Providers { get; set; }

        DbSet<SenderType> SenderTypes { get; set; }

        DbSet<Sex> Sexes { get; set; }

        DbSet<SpecialtyType> SpecialtyTypes { get; set; }

        DbSet<TherapyType> TherapyTypes { get; set; }
    }
}