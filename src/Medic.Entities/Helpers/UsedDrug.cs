using AutoMapper;
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
                .ForMember(ud => ud.Id, config => config.Ignore());
        }
    }
}