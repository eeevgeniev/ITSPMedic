namespace Medic.Entities
{
    public partial class HealthcarePractitionerEpicrisis
    {
        public HealthcarePractitionerEpicrisis Copy()
        {
            return base.Copy<HealthcarePractitionerEpicrisis>(this);
        }
    }
}