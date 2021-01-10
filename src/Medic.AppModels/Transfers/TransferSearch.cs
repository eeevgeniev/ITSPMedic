using Medic.AppModels.Contracts;
using Medic.AppModels.Enums;
using Medic.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Transfers
{
    public class TransferSearch : IQueryStringBuilder
    {
        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstMainDiagCode)]
        public string FirstMainDiagCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SecondMainDiagCode)]
        public string SecondMainDiagCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Order)]
        public TransferOrderEnum Order { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Direction)]
        public OrderDirectionEnum Direction { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Length)]
        public PageLengthEnum Length { get; set; } = PageLengthEnum.SmallLength;

        public Dictionary<string, string> BuildQuery(string prefix)
        {
            Dictionary<string, string> queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(FirstMainDiagCode))
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(FirstMainDiagCode)}", FirstMainDiagCode);
            }

            if (!string.IsNullOrWhiteSpace(SecondMainDiagCode))
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(SecondMainDiagCode)}", SecondMainDiagCode);
            }

            queryString.Add(nameof(Order), ((int)Order).ToString());
            queryString.Add(nameof(Direction), ((int)Direction).ToString());
            queryString.Add(nameof(Length), ((int)Length).ToString());

            return queryString;
        }

        public override string ToString()
        {
            return $"{nameof(FirstMainDiagCode)}:{FirstMainDiagCode}&{nameof(SecondMainDiagCode)}:{SecondMainDiagCode}" +
                $"&{nameof(Order)}:{(int)Order}&{nameof(Direction)}:{(int)Direction}&{nameof(Length)}:{(int)Length}";
        }
    }
}
