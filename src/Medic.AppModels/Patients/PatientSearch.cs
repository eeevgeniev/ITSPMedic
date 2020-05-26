using Medic.AppModels.Contracts;
using Medic.AppModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Patients
{
    /// <summary>
    /// Class for managing patient search
    /// </summary>
    public class PatientSearch : IQueryStringBuilder
    {
        [Display(Name = nameof(IdentityNumber))]
        public string IdentityNumber { get; set; }

        [Display(Name = nameof(Age))]
        public int? Age { get; set; }

        [Display(Name = nameof(YoungerThan))]
        public int? YoungerThan { get; set; }

        [Display(Name = nameof(OlderThan))]
        public int? OlderThan { get; set; }

        [Display(Name = nameof(Sex))]
        public int? Sex { get; set; }

        [Display(Name = nameof(Order))]
        public PatientOrderEnum Order { get; set; }

        [Display(Name = nameof(Length))]
        public PageLengthEnum Length { get; set; } = PageLengthEnum.SmallLength;

        [Display(Name = nameof(Direction))]
        public OrderDirectionEnum Direction { get; set; }

        public Dictionary<string, string> BuildQuery(string prefix)
        {
            Dictionary<string, string> queryString = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(IdentityNumber))
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(IdentityNumber)}", IdentityNumber);
            }

            if (Age != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(Age)}", Age.ToString());
            }

            if (YoungerThan != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(YoungerThan)}", YoungerThan.ToString());
            }

            if (OlderThan != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(OlderThan)}", OlderThan.ToString());
            }

            if (Sex != default)
            {
                queryString.Add($"{(prefix != default ? $"{prefix}." : default)}{nameof(Sex)}", Sex.ToString());
            }

            queryString.Add($"{nameof(Order)}", ((int)Order).ToString());

            queryString.Add($"{nameof(Length)}", ((int)Length).ToString());

            queryString.Add($"{nameof(Direction)}", ((int)Direction).ToString());

            return queryString;
        }

        public override string ToString()
        {
            return $"{nameof(IdentityNumber)}:{IdentityNumber}&{nameof(Age)}:{Age}&{nameof(OlderThan)}:{OlderThan}" +
                $"&{nameof(YoungerThan)}:{YoungerThan}&{nameof(Sex)}:{Sex}&" +
                $"{nameof(Order)}:{(int)Order}&{nameof(Length)}:{(int)Length}&{nameof(Direction)}:{(int)Direction}";
        }
    }
}