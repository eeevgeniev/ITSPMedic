namespace Medic.Entities
{
    public partial class Sex
    {
        public Sex Copy()
        {
            return base.Copy<Sex>(this);
        }
    }
}