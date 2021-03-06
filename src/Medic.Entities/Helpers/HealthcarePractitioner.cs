﻿using AutoMapper;
using Medic.AppModels.HealthcarePractitioners;
using CLPR = Medic.Models.CLPR;
using CP = Medic.Models.CP;

namespace Medic.Entities
{
    public partial class HealthcarePractitioner
    {
        public HealthcarePractitioner Copy()
        {
            return base.Copy<HealthcarePractitioner>(this);
        }

        public void ConfigureTransformations(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<HealthcarePractitioner, CP.Sender>()
                .ForMember(s => s.Speciality, config => config.MapFrom(hpc => hpc.Speciality == default ? default : hpc.Speciality.SpecialtyCode));

            expression.CreateMap<HealthcarePractitioner, CLPR.Sender>()
                .ForMember(s => s.SenderType, config => config.MapFrom(hp => hp.SenderType == default ? default : hp.SenderType.Code))
                .ForMember(s => s.HealthRegion, config => config.MapFrom(hp => hp.HealthRegion == default ? default : hp.HealthRegion.Code))
                .ForMember(s => s.PracticeCode, config => config.MapFrom(hp => hp.Practice == default ? default : hp.Practice.Code))
                .ForMember(s => s.PracticeName, config => config.MapFrom(hp => hp.Practice == default ? default : hp.Practice.Name))
                .ForMember(s => s.DoctorName, config => config.MapFrom(hp => hp.Name));

            expression.CreateMap<HealthcarePractitioner, CP.Chairman>()
                .ForMember(c => c.Speciality, config => config.MapFrom(hp => hp.Speciality == default ? default : hp.Speciality.SpecialtyCode))
                .ForMember(c => c.DoctorName, config => config.MapFrom(hp => hp.Name));

            expression.CreateMap<HealthcarePractitioner, CP.Member>()
                .ForMember(m => m.Speciality, config => config.MapFrom(hp => hp.Speciality == default ? default : hp.Speciality.Id))
                .ForMember(m => m.DoctorName, config => config.MapFrom(hp => hp.Name));

            expression.CreateMap<HealthcarePractitioner, CLPR.Doctor>()
                .ForMember(d => d.SpecialtyCode, config => config.MapFrom(hp => hp.Speciality == default ? default : hp.Speciality.SpecialtyCode));

            expression.CreateMap<CP.Sender, HealthcarePractitioner>()
                .ForMember(hp => hp.Speciality, config => config.MapFrom(s => s.Speciality == default? default : new SpecialtyType() { SpecialtyCode = s.Speciality }))
                .ForMember(hp => hp.SpecialityId, config => config.Ignore())
                .ForMember(hp => hp.HealthRegion, config => config.Ignore())
                .ForMember(hp => hp.HealthRegionId, config => config.Ignore())
                .ForMember(hp => hp.SenderType, config => config.Ignore())
                .ForMember(hp => hp.SenderTypeId, config => config.Ignore())
                .ForMember(hp => hp.Name, config => config.Ignore())
                .ForMember(hp => hp.Ins, config => config.Ignore())
                .ForMember(hp => hp.InClinicProcedures, config => config.Ignore())
                .ForMember(hp => hp.Outs, config => config.Ignore())
                .ForMember(hp => hp.PathProcedures, config => config.Ignore())
                .ForMember(hp => hp.ProtocolDrugTherapiesAsChairman, config => config.Ignore())
                .ForMember(hp => hp.ProtocolDrugTherapies, config => config.Ignore())
                .ForMember(hp => hp.PracticeId, config => config.Ignore())
                .ForMember(hp => hp.CommissionAprs, config => config.Ignore())
                .ForMember(hp => hp.ChairmanOfCommissionAprs, config => config.Ignore())
                .ForMember(hp => hp.CommissionAprsMembers, config => config.Ignore())
                .ForMember(hp => hp.DispObservations, config => config.Ignore())
                .ForMember(hp => hp.DoctorDispObservations, config => config.Ignore())
                .ForMember(hp => hp.DoneProcedures, config => config.Ignore())
                .ForMember(hp => hp.Planned, config => config.Ignore())
                .ForMember(hp => hp.NZOKCode, config => config.Ignore())
                .ForMember(hp => hp.UINSubst, config => config.Ignore())
                .ForMember(hp => hp.Id, config => config.Ignore());

            expression.CreateMap<CLPR.Sender, HealthcarePractitioner>()
                .ForMember(hp => hp.SenderType, config => config.MapFrom(s => new SenderType() { Code = s.SenderType }))
                .ForMember(hp => hp.SenderTypeId, config => config.Ignore())
                .ForMember(hp => hp.HealthRegion, config => config.MapFrom(s => s.HealthRegion == default ? default : new HealthRegion() { Code = s.HealthRegion }))
                .ForMember(hp => hp.HealthRegionId, config => config.Ignore())
                .ForMember(hp => hp.Name, config => config.MapFrom(s => s.DoctorName))
                .ForMember(hp => hp.Speciality, config => config.Ignore())
                .ForMember(hp => hp.SpecialityId, config => config.Ignore())
                .ForMember(hp => hp.ClinicalNumber, config => config.Ignore())
                .ForMember(hp => hp.Ins, config => config.Ignore())
                .ForMember(hp => hp.InClinicProcedures, config => config.Ignore())
                .ForMember(hp => hp.Outs, config => config.Ignore())
                .ForMember(hp => hp.PathProcedures, config => config.Ignore())
                .ForMember(hp => hp.ProtocolDrugTherapiesAsChairman, config => config.Ignore())
                .ForMember(hp => hp.ProtocolDrugTherapies, config => config.Ignore())
                .ForMember(hp => hp.Practice, config => config.Ignore())
                .ForMember(hp => hp.PracticeId, config => config.Ignore())
                .ForMember(hp => hp.CommissionAprs, config => config.Ignore())
                .ForMember(hp => hp.ChairmanOfCommissionAprs, config => config.Ignore())
                .ForMember(hp => hp.CommissionAprsMembers, config => config.Ignore())
                .ForMember(hp => hp.DispObservations, config => config.Ignore())
                .ForMember(hp => hp.DoctorDispObservations, config => config.Ignore())
                .ForMember(hp => hp.DoneProcedures, config => config.Ignore())
                .ForMember(hp => hp.Planned, config => config.Ignore())
                .ForMember(hp => hp.DeputyUniqueIdentifier, config => config.Ignore())
                .ForMember(hp => hp.Id, config => config.Ignore());

            expression.CreateMap<CP.Chairman, HealthcarePractitioner>()
                .ForMember(hp => hp.Speciality, config => config.MapFrom(c => c.Speciality == default ? default : new SpecialtyType() { SpecialtyCode = c.Speciality }))
                .ForMember(hp => hp.SpecialityId, config => config.Ignore())
                .ForMember(hp => hp.Name, config => config.MapFrom(c => c.DoctorName))
                .ForMember(hp => hp.HealthRegion, config => config.Ignore())
                .ForMember(hp => hp.HealthRegionId, config => config.Ignore())
                .ForMember(hp => hp.SenderType, config => config.Ignore())
                .ForMember(hp => hp.SenderTypeId, config => config.Ignore())
                .ForMember(hp => hp.ClinicalNumber, config => config.Ignore())
                .ForMember(hp => hp.Ins, config => config.Ignore())
                .ForMember(hp => hp.InClinicProcedures, config => config.Ignore())
                .ForMember(hp => hp.Outs, config => config.Ignore())
                .ForMember(hp => hp.PathProcedures, config => config.Ignore())
                .ForMember(hp => hp.ProtocolDrugTherapiesAsChairman, config => config.Ignore())
                .ForMember(hp => hp.ProtocolDrugTherapies, config => config.Ignore())
                .ForMember(hp => hp.Practice, config => config.Ignore())
                .ForMember(hp => hp.PracticeId, config => config.Ignore())
                .ForMember(hp => hp.CommissionAprs, config => config.Ignore())
                .ForMember(hp => hp.ChairmanOfCommissionAprs, config => config.Ignore())
                .ForMember(hp => hp.CommissionAprsMembers, config => config.Ignore())
                .ForMember(hp => hp.DispObservations, config => config.Ignore())
                .ForMember(hp => hp.DoctorDispObservations, config => config.Ignore())
                .ForMember(hp => hp.DoneProcedures, config => config.Ignore())
                .ForMember(hp => hp.Planned, config => config.Ignore())
                .ForMember(hp => hp.DeputyUniqueIdentifier, config => config.Ignore())
                .ForMember(hp => hp.NZOKCode, config => config.Ignore())
                .ForMember(hp => hp.UINSubst, config => config.Ignore())
                .ForMember(s => s.Id, config => config.Ignore());

            expression.CreateMap<CP.Member, HealthcarePractitioner>()
                .ForMember(hp => hp.Speciality, config => config.MapFrom(m => m.Speciality == default ? default : new SpecialtyType() { SpecialtyCode = m.Speciality }))
                .ForMember(hp => hp.SpecialityId, config => config.Ignore())
                .ForMember(hp => hp.Name, config => config.MapFrom(m => m.DoctorName))
                .ForMember(hp => hp.HealthRegion, config => config.Ignore())
                .ForMember(hp => hp.HealthRegionId, config => config.Ignore())
                .ForMember(hp => hp.SenderType, config => config.Ignore())
                .ForMember(hp => hp.SenderTypeId, config => config.Ignore())
                .ForMember(hp => hp.ClinicalNumber, config => config.Ignore())
                .ForMember(hp => hp.Ins, config => config.Ignore())
                .ForMember(hp => hp.InClinicProcedures, config => config.Ignore())
                .ForMember(hp => hp.Outs, config => config.Ignore())
                .ForMember(hp => hp.PathProcedures, config => config.Ignore())
                .ForMember(hp => hp.ProtocolDrugTherapiesAsChairman, config => config.Ignore())
                .ForMember(hp => hp.ProtocolDrugTherapies, config => config.Ignore())
                .ForMember(hp => hp.Practice, config => config.Ignore())
                .ForMember(hp => hp.PracticeId, config => config.Ignore())
                .ForMember(hp => hp.CommissionAprs, config => config.Ignore())
                .ForMember(hp => hp.ChairmanOfCommissionAprs, config => config.Ignore())
                .ForMember(hp => hp.CommissionAprsMembers, config => config.Ignore())
                .ForMember(hp => hp.DispObservations, config => config.Ignore())
                .ForMember(hp => hp.DoctorDispObservations, config => config.Ignore())
                .ForMember(hp => hp.DoneProcedures, config => config.Ignore())
                .ForMember(hp => hp.Planned, config => config.Ignore())
                .ForMember(hp => hp.DeputyUniqueIdentifier, config => config.Ignore())
                .ForMember(hp => hp.NZOKCode, config => config.Ignore())
                .ForMember(hp => hp.UINSubst, config => config.Ignore())
                .ForMember(hp => hp.Id, config => config.Ignore());

            expression.CreateMap<CLPR.Doctor, HealthcarePractitioner>()
                .ForMember(hp => hp.Speciality, config => config.MapFrom(d => d.SpecialtyCode == default ? default : new SpecialtyType() { SpecialtyCode = d.SpecialtyCode }))
                .ForMember(hp => hp.SpecialityId, config => config.Ignore())
                .ForMember(hp => hp.Name, config => config.MapFrom(d => d.Name))
                .ForMember(hp => hp.HealthRegion, config => config.Ignore())
                .ForMember(hp => hp.HealthRegionId, config => config.Ignore())
                .ForMember(hp => hp.SenderType, config => config.Ignore())
                .ForMember(hp => hp.SenderTypeId, config => config.Ignore())
                .ForMember(hp => hp.ClinicalNumber, config => config.Ignore())
                .ForMember(hp => hp.Ins, config => config.Ignore())
                .ForMember(hp => hp.InClinicProcedures, config => config.Ignore())
                .ForMember(hp => hp.Outs, config => config.Ignore())
                .ForMember(hp => hp.PathProcedures, config => config.Ignore())
                .ForMember(hp => hp.ProtocolDrugTherapiesAsChairman, config => config.Ignore())
                .ForMember(hp => hp.ProtocolDrugTherapies, config => config.Ignore())
                .ForMember(hp => hp.Practice, config => config.Ignore())
                .ForMember(hp => hp.PracticeId, config => config.Ignore())
                .ForMember(hp => hp.CommissionAprs, config => config.Ignore())
                .ForMember(hp => hp.ChairmanOfCommissionAprs, config => config.Ignore())
                .ForMember(hp => hp.CommissionAprsMembers, config => config.Ignore())
                .ForMember(hp => hp.DispObservations, config => config.Ignore())
                .ForMember(hp => hp.DoctorDispObservations, config => config.Ignore())
                .ForMember(hp => hp.DoneProcedures, config => config.Ignore())
                .ForMember(hp => hp.Planned, config => config.Ignore())
                .ForMember(hp => hp.DeputyUniqueIdentifier, config => config.Ignore())
                .ForMember(hp => hp.NZOKCode, config => config.Ignore())
                .ForMember(hp => hp.UINSubst, config => config.Ignore())
                .ForMember(hp => hp.Id, config => config.Ignore());

            expression.CreateMap<HealthcarePractitioner, HealthcarePractitionerSummaryViewModel>()
                .ForMember(hpsm => hpsm.Speciality, config => config.MapFrom(hp => hp.Speciality != default ? hp.Speciality.Name : default));
        }
    }
}