namespace Medic.Entities
{
    public partial class ProtocolDrugTherapyHealthPractitioner
    {
        public ProtocolDrugTherapyHealthPractitioner Copy()
        {
            return base.Copy<ProtocolDrugTherapyHealthPractitioner>(this);
        }
    }
}