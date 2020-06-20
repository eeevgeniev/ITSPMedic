using Medic.Resources.Bases;
using Medic.Resources.Contracts;
using Microsoft.Extensions.Localization;

namespace Medic.Resources
{
    public class PatientLocalization : BaseLocalization, ILocalizationService
    {
        public const string Address = nameof(Address);
        public const string Age = nameof(Age);
        public const string BirthDate = nameof(BirthDate);
        public const string FirstName = nameof(FirstName);
        public const string IdentityNumber = nameof(IdentityNumber);
        public const string LastName = nameof(LastName);
        public const string NoPatients = nameof(NoPatients);
        public const string NoResults = nameof(NoResults);
        public const string Notes = nameof(Notes);
        public const string NotSpecified = nameof(NotSpecified);
        public const string OlderThan = nameof(OlderThan);
        public const string PatientData = nameof(PatientData);
        public const string PatientSearch = nameof(PatientSearch);
        public const string PatientSearchMetaData = nameof(PatientSearchMetaData);
        public const string PatientViewMetaData = nameof(PatientViewMetaData);
        public const string Results = nameof(Results);
        public const string SecondName = nameof(SecondName);
        public const string Sex = nameof(Sex);
        public const string View = nameof(View);
        public const string ViewPatient = nameof(ViewPatient);
        public const string YoungerThan = nameof(YoungerThan);

        public PatientLocalization(IStringLocalizerFactory factory)
            : base(factory, nameof(PatientLocalization)) { }

        public override string Get(string name)
        {
            return StringLocalizer[name];
        }
    }
}