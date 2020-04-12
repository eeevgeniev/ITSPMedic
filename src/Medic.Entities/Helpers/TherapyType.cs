namespace Medic.Entities
{
    public partial class TherapyType
    {
        public TherapyType Copy()
        {
            return base.Copy<TherapyType>(this);
        }
    }
}