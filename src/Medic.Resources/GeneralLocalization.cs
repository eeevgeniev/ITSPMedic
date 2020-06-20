using Medic.Resources.Bases;
using Medic.Resources.Contracts;
using Microsoft.Extensions.Localization;

namespace Medic.Resources
{
    public class GeneralLocalization : BaseLocalization, ILocalizationService
    {
        public const string AccessDenied = nameof(AccessDenied);
        public const string Bg = nameof(Bg);
        public const string Code = nameof(Code);
        public const string CommissionAprs = nameof(CommissionAprs);
        public const string CPFile = nameof(CPFile);
        public const string DiagnosesSummary = nameof(DiagnosesSummary);
        public const string DiagsSummary = nameof(DiagsSummary);
        public const string DispObservations = nameof(DispObservations);
        public const string En = nameof(En);
        public const string Error = nameof(Error);
        public const string Home = nameof(Home);
        public const string HospitalPracticeFile = nameof(HospitalPracticeFile);
        public const string InClinicProcedures = nameof(InClinicProcedures);
        public const string Inquires = nameof(Inquires);
        public const string Ins = nameof(Ins);
        public const string InvalidTry = nameof(InvalidTry);
        public const string Login = nameof(Login);
        public const string Logout = nameof(Logout);
        public const string MaxLengthPassword = nameof(MaxLengthPassword);
        public const string MaxLengthUsername = nameof(MaxLengthUsername);
        public const string Name = nameof(Name);
        public const string NoData = nameof(NoData);
        public const string NoSelection = nameof(NoSelection);
        public const string Outs = nameof(Outs);
        public const string Password = nameof(Password);
        public const string PathProcedures = nameof(PathProcedures);
        public const string Patients = nameof(Patients);
        public const string Plannings = nameof(Plannings);
        public const string Privacy = nameof(Privacy);
        public const string ProtocolDrugTherapies = nameof(ProtocolDrugTherapies);
        public const string RememberMe = nameof(RememberMe);
        public const string RequestError = nameof(RequestError);
        public const string RequiredPassword = nameof(RequiredPassword);
        public const string RequiredUsername = nameof(RequiredUsername);
        public const string Search = nameof(Search);
        public const string SiteTile = nameof(SiteTile);
        public const string UploadFiles = nameof(UploadFiles);
        public const string UsedDrugs = nameof(UsedDrugs);
        public const string Username = nameof(Username);

        public GeneralLocalization(IStringLocalizerFactory factory)
            : base(factory, nameof(GeneralLocalization)) { }

        public override string Get(string name)
        {
            return StringLocalizer[name];
        }
    }
}