namespace Medic.Entities
{
    public partial class ImplantProductType
    {
        public ImplantProductType Copy()
        {
            return base.Copy<ImplantProductType>(this);
        }
    }
}