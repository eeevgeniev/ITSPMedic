namespace Medic.Entities
{
    public partial class Provider
    {
        public Provider Copy()
        {
            return base.Copy<Provider>(this);
        }
    }
}