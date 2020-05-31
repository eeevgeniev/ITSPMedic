using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Enums
{
    public enum PlannedProcedureOrderEnum
    {
        [Display(Name = nameof(Default))]
        Default,
        [Display(Name = nameof(SendDate))]
        SendDate,
        [Display(Name = nameof(SendDiagnoseCode))]
        SendDiagnoseCode,
        [Display(Name = nameof(DiagnoseCode))]
        DiagnoseCode
    }
}
