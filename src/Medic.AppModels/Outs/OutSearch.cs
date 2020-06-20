using Medic.AppModels.Contracts;
using Medic.AppModels.Enums;
using Medic.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Outs
{
    public class OutSearch : IQueryStringBuilder
    {
        [Display(Name = MedicDataAnnotationLocalizerProvider.MainOutDiagnose)]
        public string MainOutDiagnose { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CountOfAdditionalOutDiagnoses)]
        public int? CountOfAdditionalOutDiagnoses { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Sex)]
        public int? Sex { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendDiagnose)]
        public string SendDiagnose { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CountOfAdditionalSendDiagnoses)]
        public int? CountOfAdditionalSendDiagnoses { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.HealthRegion)]
        public int? HealthRegion { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.UsedDrug)]
        public string UsedDrug { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Age)]
        public int? Age { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OlderThan)]
        public int? OlderThan { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.YoungerThan)]
        public int? YoungerThan { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Order)]
        public OutOrderEnum Order { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Direction)]
        public OrderDirectionEnum Direction { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Length)]
        public PageLengthEnum Length { get; set; } = PageLengthEnum.SmallLength;

        public Dictionary<string, string> BuildQuery(string prefix)
        {
            Dictionary<string, string> queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(MainOutDiagnose))
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(MainOutDiagnose)}", MainOutDiagnose);
            }

            if (CountOfAdditionalOutDiagnoses != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(CountOfAdditionalOutDiagnoses)}", CountOfAdditionalOutDiagnoses.ToString());
            }

            if (Sex != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(Sex)}", Sex.ToString());
            }

            if (!string.IsNullOrWhiteSpace(UsedDrug))
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(UsedDrug)}", UsedDrug);
            }

            if (!string.IsNullOrWhiteSpace(SendDiagnose))
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(SendDiagnose)}", SendDiagnose);
            }

            if (CountOfAdditionalSendDiagnoses != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(CountOfAdditionalSendDiagnoses)}", CountOfAdditionalSendDiagnoses.ToString());
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
            return $"{nameof(MainOutDiagnose)}:{MainOutDiagnose}&{nameof(CountOfAdditionalOutDiagnoses)}:{CountOfAdditionalOutDiagnoses}&{nameof(Sex)}:{Sex}&{nameof(SendDiagnose)}:{SendDiagnose}" +
                $"&{nameof(CountOfAdditionalSendDiagnoses)}:{CountOfAdditionalSendDiagnoses}&{nameof(HealthRegion)}:{HealthRegion}" +
                $"&{nameof(UsedDrug)}:{UsedDrug}&{nameof(Age)}:{Age}&{nameof(OlderThan)}:{OlderThan}&{nameof(YoungerThan)}:{YoungerThan}" + 
                $"&{nameof(Order)}:{(int)Order}&{nameof(Direction)}:{(int)Direction}&{nameof(Length)}:{(int)Length}";
        }
    }
}
