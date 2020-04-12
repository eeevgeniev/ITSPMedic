using AutoMapper;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class CPFile
    {
        public CPFile Copy()
        {
            return base.Copy<CPFile>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<CPFile, CP.CPFile>()
                .ForMember(cpf => cpf.FileType, config => config.MapFrom(cpf => cpf.FileType == default ? default : cpf.FileType.Name))
                .ForMember(cpf => cpf.DateFromAsString, config => config.Ignore())
                .ForMember(cpf => cpf.DateToAsString, config => config.Ignore());

            expression.CreateMap<CP.CPFile, CPFile>()
                .ForMember(cpf => cpf.Id, config => config.Ignore())
                .ForMember(cpf => cpf.FileTypeId, config => config.Ignore())
                .ForMember(cpf => cpf.PracticeId, config => config.Ignore())
                .ForMember(cpf => cpf.FileType, config => config.MapFrom(cpf => cpf.FileType == default ? default : new FileType() { Name = cpf.FileType }));
        }
    }
}