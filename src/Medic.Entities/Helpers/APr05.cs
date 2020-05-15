using AutoMapper;
using Medic.AppModels.APr05s;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class APr05
    {
        public APr05 Copy()
        {
            return base.Copy<APr05>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<APr05, CLPR.APr05>()
                .ForMember(ap => ap.DiagnoseDateAsString, config => config.Ignore());

            expression.CreateMap<CLPR.APr05, APr05>()
                .ForMember(ap => ap.ClinicHematologyPartId, config => config.Ignore())
                .ForMember(ap => ap.ClinicChemotherapyPartId, config => config.Ignore())
                .ForMember(ap => ap.HistologyId, config => config.Ignore())
                .ForMember(ap => ap.CommissionApr, config => config.Ignore())
                .ForMember(ap => ap.Id, config => config.Ignore());

            expression.CreateMap<APr05, APr05PreviewViewModel>();
        }
    }
}