using Medic.AppModels.Choices;
using System.Collections.Generic;

namespace Medic.AppModels.Evaluations
{
    public class EvaluationPreviewViewModel
    {
        public int Id { get; set; }
        
        public List<ChoicePreviewViewModel> Choices { get; set; }
    }
}
