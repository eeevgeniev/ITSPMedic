using AutoMapper;
using Medic.AppModels.Evaluations;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Evaluation
    {
        public Evaluation Copy()
        {
            return base.Copy<Evaluation>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Evaluation, CP.Evaluation>();
            expression.CreateMap<Evaluation, CP.PredMarker>();

            expression.CreateMap<CP.Evaluation, Evaluation>()
                .ForMember(e => e.ClinicChemotherapyPartId, config => config.Ignore())
                .ForMember(e => e.ClinicChemotherapyPart, config => config.Ignore())
                .ForMember(e => e.ClinicHematologyPartId, config => config.Ignore())
                .ForMember(e => e.ClinicHematologyPart, config => config.Ignore())
                .ForMember(e => e.APr38s, config => config.Ignore())
                .ForMember(e => e.ClinicChemotherapyPartDecision, config => config.Ignore())
                .ForMember(e => e.ClinicHematologyPartDecision, config => config.Ignore())
                .ForMember(e => e.ChemotherapyPart, config => config.Ignore())
                .ForMember(e => e.HematologyPart, config => config.Ignore())
                .ForMember(e => e.Id, config => config.Ignore());

            expression.CreateMap<CP.PredMarker, Evaluation>()
                .ForMember(e => e.ClinicChemotherapyPartId, config => config.Ignore())
                .ForMember(e => e.ClinicChemotherapyPart, config => config.Ignore())
                .ForMember(e => e.ClinicHematologyPartId, config => config.Ignore())
                .ForMember(e => e.ClinicHematologyPart, config => config.Ignore())
                .ForMember(e => e.APr38s, config => config.Ignore())
                .ForMember(e => e.ClinicChemotherapyPartDecision, config => config.Ignore())
                .ForMember(e => e.ClinicHematologyPartDecision, config => config.Ignore())
                .ForMember(e => e.ChemotherapyPart, config => config.Ignore())
                .ForMember(e => e.HematologyPart, config => config.Ignore())
                .ForMember(e => e.Id, config => config.Ignore());

            expression.CreateMap<Evaluation, EvaluationPreviewViewModel>();
        }
    }
}
