namespace Medic.Entities
{
    public partial class PractitionerType
    {
        public PractitionerType Copy()
        {
            return base.Copy<PractitionerType>(this);
        }
    }
}