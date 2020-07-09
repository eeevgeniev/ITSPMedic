using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Sexes
{
    public class SexOption
    {
        public int? Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Name)]
        public string Name { get; set; }
    }
}