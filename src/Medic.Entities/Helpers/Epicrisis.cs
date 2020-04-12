using AutoMapper;
using System;
using System.Linq;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class Epicrisis
    {
        public Epicrisis Copy()
        {
            return base.Copy<Epicrisis>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Epicrisis, CP.Epicrisis>()
                    .ForMember(e => e.DateOfSurgeryAsString, config => config.Ignore())
                    .ForMember(
                        e => e.DoctorsNames, 
                        config => config.MapFrom(
                            e => e.HealthcarePractitionerEpicrisises == default ? 
                            default : 
                            string.Join(", ", e.HealthcarePractitionerEpicrisises.Select(hpe => hpe.HealthcarePractitioner.Name))
                            )
                        );

            expression.CreateMap<CP.Epicrisis, Epicrisis>()
                    .ForMember(
                        e => e.HealthcarePractitionerEpicrisises,
                        config => config
                            .MapFrom(e => e.DoctorsNames == default ?
                            default :
                            e.DoctorsNames
                            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(
                                dn => new HealthcarePractitionerEpicrisis()
                                {
                                    HealthcarePractitioner = new HealthcarePractitioner() { Name = dn }
                                })
                            .ToList())
                            )
                    .ForMember(e => e.Out, config => config.Ignore())
                    .ForMember(e => e.Id, config => config.Ignore());
        }
    }
}
