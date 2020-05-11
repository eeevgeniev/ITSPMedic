using AutoMapper;
using Medic.AppModels.ClinicUsedDrugs;
using CLPR = Medic.Models.CLPR;

namespace Medic.Entities
{
    public partial class ClinicUsedDrug
    {
        public ClinicUsedDrug Copy()
        {
            return base.Copy<ClinicUsedDrug>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ClinicUsedDrug, CLPR.ClinicUsedDrug>()
                .ForMember(cud => cud.DatePrescrAsString, config => config.Ignore())
                .ForMember(cud => cud.DrugDateAsString, config => config.Ignore())
                .ForMember(cud => cud.ProtocolDateAsString, config => config.Ignore());

            expression.CreateMap<CLPR.ClinicUsedDrug, ClinicUsedDrug>()
                .ForMember(cud => cud.VersionCodeId, config => config.Ignore())
                .ForMember(cud => cud.PathProcedure, config => config.Ignore())
                .ForMember(cud => cud.Id, config => config.Ignore());

            expression.CreateMap<ClinicUsedDrug, ClinicUsedDrugViewModel>();
        }
    }
}