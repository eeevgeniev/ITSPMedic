namespace Medic.Entities
{
    public partial class HealthRegion
    {
        public HealthRegion Copy()
        {
            return base.Copy<HealthRegion>(this);
        }
    }
}