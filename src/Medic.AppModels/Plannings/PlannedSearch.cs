using Medic.AppModels.Contracts;
using Medic.AppModels.Enums;
using Medic.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Plannings
{
    public class PlannedSearch : IQueryStringBuilder
    {
        [Display(Name = MedicDataAnnotationLocalizerProvider.SendDiagnoseCode)]
        public string SendDiagnoseCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DiagnoseCode)]
        public string DiagnoseCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Sex)]
        public int? Sex { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.HealthRegion)]
        public int? HealthRegion { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Age)]
        public int? Age { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OlderThan)]
        public int? OlderThan { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.YoungerThan)]
        public int? YoungerThan { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Order)]
        public PlannedOrderEnum Order { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Direction)]
        public OrderDirectionEnum Direction { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Length)]
        public PageLengthEnum Length { get; set; } = PageLengthEnum.SmallLength;

        public Dictionary<string, string> BuildQuery(string prefix)
        {
            Dictionary<string, string> queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(SendDiagnoseCode))
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(SendDiagnoseCode)}", SendDiagnoseCode);
            }

            if (!string.IsNullOrWhiteSpace(DiagnoseCode))
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(DiagnoseCode)}", DiagnoseCode);
            }

            if (Sex != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(Sex)}", Sex.ToString());
            }

            if (HealthRegion != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(HealthRegion)}", HealthRegion.ToString());
            }

            if (Age != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(Age)}", Age.ToString());
            }

            if (OlderThan != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(OlderThan)}", OlderThan.ToString());
            }

            if (YoungerThan != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(YoungerThan)}", YoungerThan.ToString());
            }

            queryString.Add(nameof(Order), ((int)Order).ToString());
            queryString.Add(nameof(Direction), ((int)Direction).ToString());
            queryString.Add(nameof(Length), ((int)Length).ToString());

            return queryString;
        }

        public override string ToString()
        {
            return $"{nameof(SendDiagnoseCode)}:{SendDiagnoseCode}&{nameof(DiagnoseCode)}:{DiagnoseCode}&{nameof(Sex)}:{Sex}" +
                $"&{nameof(HealthRegion)}:{HealthRegion}&{nameof(Age)}:{Age}&{nameof(OlderThan)}:{OlderThan}&{nameof(YoungerThan)}:{YoungerThan}" +
                $"&{nameof(Order)}:{(int)Order}&{nameof(Direction)}:{(int)Direction}&{nameof(Length)}:{(int)Length}";
        }
    }
}
