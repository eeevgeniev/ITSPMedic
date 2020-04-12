namespace Medic.Entities
{
    public partial class MKB
    {
        public MKB Copy()
        {
            return base.Copy<MKB>(this);
        }
    }
}