using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Implant
    {
        public Implant Copy()
        {
            return base.Copy<Implant>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Implant, CP.Implant>()
                .ForMember(i => i.ProductType, config => config.MapFrom(i => i.ProductType == default ? default : i.ProductType.Name))
                .ForMember(i => i.ProviderId, config => config.MapFrom(i => i.Provider == default ? default : i.Provider.Code))
                .ForMember(i => i.Provider, config => config.MapFrom(i => i.Provider == default ? default : i.Provider.Name))
                .ForMember(hp => hp.DateAsString, config => config.Ignore())
                .ForMember(hp => hp.DistributorInvoiceDateAsString, config => config.Ignore());

            expression.CreateMap<CP.Implant, Implant>()
                .ForMember(i => i.ProductType, config => config.MapFrom(i => new ImplantProductType() { ProductType = i.ProductType }))
                .ForMember(i => i.ProductTypeId, config => config.Ignore())
                .ForMember(i => i.Provider, config => config.MapFrom(i => new Provider() { Code = i.ProviderId, Name = i.Provider }))
                .ForMember(i => i.ProviderId, config => config.Ignore())
                .ForMember(i => i.Procedure, config => config.Ignore())
                .ForMember(i => i.ClinicProcedure, config => config.Ignore())
                .ForMember(i => i.ClinicProcedureId, config => config.Ignore())
                .ForMember(i => i.Id, config => config.Ignore());
        }
    }
}