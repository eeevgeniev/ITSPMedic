namespace Medic.Entities
{
    public partial class PatientBranch
    {
        public PatientBranch Copy()
        {
            return base.Copy<PatientBranch>(this);
        }
    }
}