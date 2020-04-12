namespace Medic.Entities
{
    public partial class SenderType
    {
        public SenderType Copy()
        {
            return base.Copy<SenderType>(this);
        }
    }
}