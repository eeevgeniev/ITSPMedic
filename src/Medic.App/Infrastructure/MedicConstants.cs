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
        internal const string PatientsCount = "PatientsCount";
        internal const string InsCount = "InsCount";
        internal const string OutsCount = "OutsCount";
        internal const string UsedDrugs = "UsedDrugs";
        internal const string ProtocolDrugTherapies = "ProtocolDrugTherapies";
        internal const string InClinicProcedures = "InClinicProcedures";
        internal const string PathProcedures = "PathProcedures";
        internal const string ClinicUsedDrugsCode = "ClinicUsedDrugsCode";
        internal const string CommissionAprs = "CommissionAprs";
        internal const string DispObservations = "DispObservations";
        internal const string PlannedProcedures = "PlannedProcedures";
        internal const string AtcNames = "AtcNames";
    }
}