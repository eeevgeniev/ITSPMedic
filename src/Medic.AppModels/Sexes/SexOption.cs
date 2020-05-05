using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Sexes
{
    public class SexOption
    {
        public int? Id { get; set; }

        [Display(Name = nameof(Name))]
        public string Name { get; set; }
    }
}