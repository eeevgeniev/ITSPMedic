namespace Medic.Entities
{
    public partial class CommissionAprHealthcarePractitioner
    {
        public CommissionAprHealthcarePractitioner Copy()
        {
            return base.Copy<CommissionAprHealthcarePractitioner>(this);
        }
    }
}
