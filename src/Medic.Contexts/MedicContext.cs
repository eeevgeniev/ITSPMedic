using Medic.Contexts.Contracts;
using Medic.Entities;
using Medic.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Medic.Contexts
{
    /// <summary>
    /// Context for managing entity models
    /// </summary>
    public class MedicContext : DbContext, IMedicContext
    {
        public MedicContext(DbContextOptions<MedicContext> options)
            : base(options) { }

        public DbSet<AccompanyingDrug> AccompanyingDrugs { get; set; }

        public DbSet<APr05> APr05s { get; set; }

        public DbSet<APr38> APr38s { get; set; }

        public DbSet<CeasedClinicalPath> CeasedClinicalPaths { get; set; }

        public DbSet<ChemotherapyPart> ChemotherapyParts { get; set; }

        public DbSet<Choise> Choises { get; set; }

        public DbSet<ClinicChemotherapyPart> ClinicChemotherapyParts { get; set; }

        public DbSet<ClinicHematologyPart> ClinicHematologyParts { get; set; }

        public DbSet<ClinicProcedure> ClinicProcedures { get; set; }

        public DbSet<ClinicUsedDrug> ClinicUsedDrugs { get; set; }

        public DbSet<CommissionApr> CommissionAprs { get; set; }

        public DbSet<CommissionAprHealthcarePractitioner> CommissionAprHealthcarePractitioner { get; set; }

        public DbSet<CPFile> CPFiles { get; set; }

        public DbSet<Diag> Diags { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<DispObservation> DispObservations { get; set; }

        public DbSet<DoneProcedure> DoneProcedures { get; set; }

        public DbSet<DrugProtocol> DrugProtocols { get; set; }

        public DbSet<Epicrisis> Epicrises { get; set; }

        public DbSet<Evaluation> Evaluations { get; set; }

        public DbSet<FileType> FileTypes { get; set; }

        public DbSet<GenMarker> GenMarkers { get; set; }

        public DbSet<HealthcarePractitioner> HealthcarePractitioners { get; set; }

        public DbSet<HealthcarePractitionerEpicrisis> HealthcarePractitionerEpicrisis { get; set; }

        public DbSet<HealthRegion> HealthRegions { get; set; }

        public DbSet<HematologyPart> HematologyParts { get; set; }

        public DbSet<HistologicalResult> HistologicalResults { get; set; }

        public DbSet<Histology> Histologies { get; set; }

        public DbSet<HospitalPractice> HospitalPractices { get; set; }

        public DbSet<Implant> Implants { get; set; }

        public DbSet<ImplantProductType> ImplantProductTypes { get; set; }

        public DbSet<In> Ins { get; set; }

        public DbSet<InClinicProcedure> InClinicProcedures { get; set; }

        public DbSet<MDI> MDIs { get; set; }

        public DbSet<MKB> MKBs { get; set; }

        public DbSet<Out> Outs { get; set; }

        public DbSet<PathProcedure> PathProcedures { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientBranch> PatientBranches { get; set; }

        public DbSet<PatientTransfer> PatientTransfers { get; set; }

        public DbSet<PlannedProcedure> PlannedProcedures { get; set; }

        public DbSet<Practice> Practices { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<ProtocolDrugTherapy> ProtocolDrugTherapies { get; set; }

        public DbSet<ProtocolDrugTherapyHealthPractitioner> ProtocolDrugTherapyHealthPractitioner { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<SenderType> SenderTypes { get; set; }

        public DbSet<Sex> Sexes { get; set; }

        public DbSet<SpecialtyType> SpecialtyTypes { get; set; }

        public DbSet<TherapyType> TherapyTypes { get; set; }

        public DbSet<UsedDrug> UsedDrugs { get; set; }

        public DbSet<VersionCode> VersionCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type modelBuilderType = typeof(IModelBuilder);

            Type contextType = this.GetType();
            Type dbSetType = typeof(DbSet<>);

            contextType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(t => t.PropertyType.IsGenericType && t.PropertyType.GetGenericTypeDefinition() == dbSetType && t.PropertyType.GetGenericArguments().Length == 1)
                .Select(t => t.PropertyType.GetGenericArguments()[0])
                .ToList()
                .ForEach(t =>
                {
                    if (t.GetConstructors().Any(c => c.GetParameters().Length == 0))
                    {
                        IModelBuilder builder = (IModelBuilder)Activator.CreateInstance(t);

                        builder.CreateRules(modelBuilder);
                    }
                    else
                    {
                        throw new InvalidOperationException(nameof(t.Name));
                    }
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}