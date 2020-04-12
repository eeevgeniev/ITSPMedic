namespace Medic.Entities
{
    public partial class SpecialtyType
    {
        public SpecialtyType Copy()
        {
            return base.Copy<SpecialtyType>(this);
        }
    }
}