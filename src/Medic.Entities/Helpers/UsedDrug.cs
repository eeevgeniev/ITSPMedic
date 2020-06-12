using AutoMapper;
using Medic.AppModels.UsedDrugs;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class UsedDrug
    {
        public UsedDrug Copy()
        {
            return base.Copy<UsedDrug>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<UsedDrug, CP.UsedDrug>()
                .ForMember(ud => ud.DateAsString, config => config.Ignore())
                .ForMember(ud => ud.DatePrescrAsString, config => config.Ignore())
                .ForMember(ud => ud.ProtocolDateAsString, config => config.Ignore());

            expression.CreateMap<CP.UsedDrug, UsedDrug>()
                .ForMember(ud => ud.Out, config => config.Ignore())
                .ForMember(ud => ud.OutId, config => config.Ignore())
                .ForMember(ud => ud.Id, config => config.Ignore());

            expression.CreateMap<UsedDrug, UsedDrugSummaryViewModel>()
                .ForMember(udsvm => udsvm.BatchNumber, config => config.MapFrom(ud => ud.VersionCode != default ? ud.VersionCode.BatchNumber : default))
                .ForMember(udsvm => udsvm.QuantityPack, config => config.MapFrom(ud => ud.VersionCode != default ? ud.VersionCode.QuantityPack : default));
        }
    }
}