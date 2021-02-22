using Medic.AppModels.CeasedClinicals;
using Medic.AppModels.InClinicProcedures;
using Medic.EHR.Extracts;
using Medic.EHR.RM;
using Medic.EHR.RM.Base;
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Base;
using System;

namespace Medic.ModelToEHR.Helpers
{
    internal class InClinicProcedureToEHRConverter : ToEHRBaseConverter
    {
        internal InClinicProcedureToEHRConverter(IEHRManager ehrManager) 
            : base(ehrManager) { }

        internal EhrExtract Convert(InClinicProcedureViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryInClinicProcedureBuilder = EhrManager.EntryBuilder;

            entryInClinicProcedureBuilder.AddItems(
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientBranch)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientBranch).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientHealthRegion)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientHealthRegion).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DateSend)).Build())
                    .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.DateSend).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProcRefuse)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.ProcRefuse).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZYearChild)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.IZYearChild).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.VisitDoctorUniqueIdentifier)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.VisitDoctorUniqueIdentifier).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.VisitDoctorName)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.VisitDoctorName).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientStatus)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.PatientStatus).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NZOKPay)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.NZOKPay).Build()).Build()
                );

            if (model.TypeProcSend != default)
            {
                entryInClinicProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TypeProcSend)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.TypeProcSend).Build())
                        .Build());
            }

            if (model.TypeProcPriem != default)
            {
                entryInClinicProcedureBuilder.AddItems(
                     EhrManager.ElementBuilder
                     .Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TypeProcPriem)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.TypeProcPriem).Build())
                    .Build());
            }
            
            if (model.CPrSend != default)
            {
                entryInClinicProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CPrSend)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.CPrSend).Build())
                        .Build());
            }

            if (model.APrSend != default)
            {
                entryInClinicProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APrSend)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.APrSend).Build())
                        .Build());
            }

            if (model.CPrPriem != default)
            {
                entryInClinicProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CPrPriem)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.CPrPriem).Build())
                        .Build());
            }

            if (model.APrPriem != default)
            {
                entryInClinicProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APrPriem)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.APrPriem).Build())
                        .Build());
            }


            if (model.IZNumChild != default)
            {
                entryInClinicProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZNumChild)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.IZNumChild).Build())
                        .Build());
            }

            if (model.FirstVisitDate != default)
            {
                entryInClinicProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.FirstVisitDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.FirstVisitDate).Build())
                        .Build());
            }

            if (model.PlanVisitDate != default)
            {
                entryInClinicProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PlanVisitDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.PlanVisitDate).Build())
                        .Build());
            }

            Content inClinicProcedureContent = entryInClinicProcedureBuilder.Build();

            ICompositionBuilder compositionBuilder = EhrManager.CompositionBuilder
                .Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(name).Build());

            if (model.Patient != default)
            {
                compositionBuilder.AddContent(
                EhrManager.SectionBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Patient)).Build())
                    .AddMembers(base.CreatePatientEntry(model.Patient))
                    .Build());
            }

            if (model.Sender != default)
            {
                compositionBuilder.AddContent(
                EhrManager.SectionBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sender)).Build())
                    .AddMembers(base.CreatePractitionerEntry(model.Sender))
                    .Build());
            }

            if (model.FirstMainDiag != default)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.FirstMainDiag)).Build())
                        .AddMembers(base.CreateDiagEntry(model.FirstMainDiag))
                        .Build());
            }

            if (model.SecondMainDiag != default)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SecondMainDiag)).Build())
                        .AddMembers(base.CreateDiagEntry(model.SecondMainDiag))
                        .Build());
            }

            if (model.CeasedClinicalPath != default)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CeasedClinicalPath)).Build())
                        .AddMembers(CreateCeasedClinicalEntry(model.CeasedClinicalPath))
                        .Build());
            }

            compositionBuilder.AddContent(EhrManager.SectionBuilder.Clear().AddMembers(inClinicProcedureContent).Build());

            EhrExtract ehrExtractModel = EhrManager
                .EhrExtractModelBuilder
                .AddEhrSystem(EhrManager.IIBuilder.Clear().AddRoot(EhrManager.OIDBuilder.Build(systemId)).Build())
                .AddSubjectOfCare(EhrManager.IIBuilder.Clear().AddRoot(EhrManager.OIDBuilder.Build(model.Patient.IdentityNumber)).Build())
                .AddTimeCreated(EhrManager.TSBuilder.Clear().AddTime(DateTime.Now).Build())
                .AddComposition(compositionBuilder.Build())
                .Build();

            return ehrExtractModel;
        }

        private Entry CreateCeasedClinicalEntry(CeasedClinicalViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Code)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Code).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZMedicalWard)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.IZMedicalWard).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZYearMedicalWard)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.IZYearMedicalWard).Build()).Build()
                )
                .Build();
        }
    }
}
