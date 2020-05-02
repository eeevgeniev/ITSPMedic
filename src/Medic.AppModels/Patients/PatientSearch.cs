namespace Medic.AppModels.Patients
{
    /// <summary>
    /// Class for managing patient search
    /// </summary>
    public class PatientSearch
    {
        public string IdentityNumber { get; set; }

        public int? Age { get; set; }

        public int? OlderThan { get; set; }

        public int? YoungerThan { get; set; }
    }
}