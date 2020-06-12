using AutoMapper;
using Medic.AppModels.ChemotherapyParts;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class ChemotherapyPart
    {
        public ChemotherapyPart Copy()
        {
            return base.Copy<ChemotherapyPart>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ChemotherapyPart, CP.ChemotherapyPart>()
                    .ForMember(cp => cp.DiagnoseDateAsString, config => config.Ignore());

            expression.CreateMap<CP.ChemotherapyPart, ChemotherapyPart>()
                   .ForMember(cp => cp.HistologyId, config => config.Ignore())
                   .ForMember(cp => cp.EvaluationId, config => config.Ignore())
                   .ForMember(cp => cp.ProtocolDrugTherapy, config => config.Ignore())
                   .ForMember(cp => cp.ProtocolDrugTherapyId, config => config.Ignore())
                   .ForMember(cp => cp.Id, config => config.Ignore());

            expression.CreateMap<ChemotherapyPart, ChemotherapyPartPreviewViewModel>();
        }
    }
}