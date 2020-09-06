using Medic.AppModels.HealthRegions;
using Medic.AppModels.Sexes;

namespace Medic.App.Infrastructure
{
    internal class MedicConstants
    {
        internal static readonly string[] AllowedLanguages = { "bg", "en" };
        internal const string DefaultLanguage = "en";
        internal const string LanguageCookieName = "lang";
        internal const int LanguageCookieSpanInDays = 365;
        internal const int SummaryPageLength = 50;
        internal const string AdministratorName = "administratorName";
        internal const string AdministratorEmail = "administratorEmail";
        internal const string AdministratorPassword = "administratorPassword";
        internal const string SexKeyName = nameof(SexOption);
        internal const string HealthRegionsKeyName = nameof(HealthRegionOption);
        internal const string PatientsCount = nameof(PatientsCount);
        internal const string InsCount = nameof(InsCount);
        internal const string OutsCount = nameof(OutsCount);
        internal const string UsedDrugs = nameof(UsedDrugs);
        internal const string ProtocolDrugTherapies = nameof(ProtocolDrugTherapies);
        internal const string InClinicProcedures = nameof(InClinicProcedures);
        internal const string PathProcedures = nameof(PathProcedures);
        internal const string ClinicUsedDrugsCode = nameof(ClinicUsedDrugsCode);
        internal const string CommissionAprs = nameof(CommissionAprs);
        internal const string DispObservations = nameof(DispObservations);
        internal const string Planned = nameof(Planned);
        internal const string AtcNames = nameof(AtcNames);
        internal const string IdentityErrorSeparator = ", ";
        internal const string ItupMedic = "ITSP Medic";
    }
}