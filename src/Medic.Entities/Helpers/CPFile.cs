using AutoMapper;
using Medic.Models.CP;
using System.Collections.Generic;
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
                .ForMember(cpf => cpf.PatientTransfer, config => config.MapFrom((cpf, trg, prop, cntx) => cpf.Transfers != default ? new PatientTransfer() { Transfers = cntx.Mapper.Map<ICollection<Transfer>, List<CP.Transfer>>(cpf.Transfers) } : default))
                .ForMember(cpf => cpf.DateFromAsString, config => config.Ignore())
                .ForMember(cpf => cpf.DateToAsString, config => config.Ignore());

            expression.CreateMap<CP.CPFile, CPFile>()
                .ForMember(cpf => cpf.Id, config => config.Ignore())
                .ForMember(cpf => cpf.FileTypeId, config => config.Ignore())
                .ForMember(cpf => cpf.PracticeId, config => config.Ignore())
                .ForMember(cpf => cpf.Transfers, config => config.MapFrom(cpf => cpf.PatientTransfer != default ? cpf.PatientTransfer.Transfers : default))
                .ForMember(cpf => cpf.FileType, config => config.MapFrom(cpf => cpf.FileType == default ? default : new FileType() { Name = cpf.FileType }));
        }
    }
}