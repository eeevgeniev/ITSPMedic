using Medic.AppModels.Epicrisises;
using Medic.AppModels.HistologicalResult;
using Medic.AppModels.Outs;
using Medic.AppModels.Procedures;
using Medic.AppModels.UsedDrugs;
using Medic.EHR.RM;
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Base;
using System;
using System.Linq;

namespace Medic.ModelToEHR.Helpers
{
    internal class OutToEHRConverter : ToEHRBaseConverter
    {
        internal OutToEHRConverter(IEHRManager ehrManager) 
            : base(ehrManager) { }

        internal ReferenceModel Convert(OutViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryOutBuilder = EhrManager.EntryBuilder;

            entryOutBuilder.AddItems(
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientBranch)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientBranch).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientHRegion)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientHRegion).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.InType)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.InType).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendDate)).Build())
                    .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.SendDate).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendUrgency)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.SendUrgency).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendClinicalPath)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue(model.SendClinicalPath).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PlannedNumber)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.PlannedNumber).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.UniqueIdentifier)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.UniqueIdentifier).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ExaminationDate)).Build())
                    .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.ExaminationDate).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PlannedNumber)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.PlannedNumber).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Urgency)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Urgency).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ClinicalPath)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue(model.ClinicalPath).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NZOKPay)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.NZOKPay).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.InMedicalWard)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.InMedicalWard).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.EntryDate)).Build())
                    .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.EntryDate).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Severity)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Severity).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Payer)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Payer).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutMedicalWard)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.OutMedicalWard).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutUniqueIdentifier)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.OutUniqueIdentifier).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutDate)).Build())
                    .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.OutDate).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutType)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.OutType).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BirthPractice)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.BirthPractice).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutClinicalPath)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue(model.OutClinicalPath).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutAPr)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.OutAPr).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HLNumber)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.HLNumber).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CPFile)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.CPFile).Build()).Build()
                );

            if (model.SendAPr != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendAPr)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.SendAPr).Build())
                        .Build());
            }

            if (model.InAPr != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.InAPr)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.InAPr).Build())
                        .Build());
            }

            if (model.Delay != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Delay)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.Delay).Build())
                        .Build());
            }

            if (model.AgeInDays != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AgeInDays)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.AgeInDays).Build())
                        .Build());
            }

            if (model.WeightInGrams != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.WeightInGrams)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.WeightInGrams).Build())
                        .Build());
            }

            if (model.BirthWeight != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BirthWeight)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.BirthWeight).Build())
                        .Build());
            }

            if (model.MotherIZYear != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MotherIZYear)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.MotherIZYear).Build())
                        .Build());
            }

            if (model.MotherIZNo != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MotherIZNo)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.MotherIZNo).Build())
                        .Build());
            }

            if (model.IZYear != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZYear)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.IZYear).Build())
                        .Build());
            }

            if (model.IZNo != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZNo)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.IZNo).Build())
                        .Build());
            }

            if (model.BirthNumber != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BirthNumber)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.BirthNumber).Build())
                        .Build());
            }

            if (model.BirthGestWeek != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BirthGestWeek)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.BirthGestWeek).Build())
                        .Build());
            }

            if (model.BedDays != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BedDays)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.BedDays).Build())
                        .Build());
            }

            if (model.HLDateFrom != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HLDateFrom)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.HLDateFrom).Build())
                        .Build());
            }

            if (model.HLTotalDays != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HLTotalDays)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.HLTotalDays).Build())
                        .Build());
            }

            if (model.StateAtDischarge != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.StateAtDischarge)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.StateAtDischarge).Build())
                        .Build());
            }

            if (model.Laparoscopic != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Laparoscopic)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.Laparoscopic).Build())
                        .Build());
            }

            if (model.EndCourse != default)
            {
                entryOutBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.EndCourse)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.EndCourse).Build())
                        .Build());
            }

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
            
            if (model.SendDiagnoses != default && model.SendDiagnoses.Count > 0)
            {
                compositionBuilder.AddContent(EhrManager.SectionBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendDiagnoses)).Build())
                    .AddMembers(model.SendDiagnoses.Where(sd => sd != default).Select(sd => base.CreateDiagnoseEntry(sd)).ToArray())
                    .Build());
            }

            if (model.Diagnoses != default && model.Diagnoses.Count > 0)
            {
                compositionBuilder.AddContent(EhrManager.SectionBuilder.Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Diagnoses)).Build())
                .AddMembers(model.Diagnoses.Where(d => d != default).Select(d => base.CreateDiagnoseEntry(d)).ToArray())
                .Build());
            }

            if (model.Dead != default)
            {
                compositionBuilder.AddContent(
                EhrManager.SectionBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Dead)).Build())
                    .AddMembers(base.CreateDiagnoseEntry(model.Dead))
                    .Build());
            }

            if (model.OutMainDiagnose != default)
            {
                compositionBuilder.AddContent(
                EhrManager.SectionBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutMainDiagnose)).Build())
                    .AddMembers(base.CreateDiagnoseEntry(model.OutMainDiagnose))
                    .Build());
            }

            if (model.OutDiagnoses != default && model.OutDiagnoses.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutDiagnoses)).Build())
                        .AddMembers(model.OutDiagnoses.Where(d => d != default).Select(d => base.CreateDiagnoseEntry(d)).ToArray())
                        .Build());
            }

            if (model.HistologicalResult != default)
            {
                compositionBuilder.AddContent(
                EhrManager.SectionBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HistologicalResult)).Build())
                    .AddMembers(CreateHistologicalResultEntry(model.HistologicalResult))
                    .Build());
            }

            if (model.Epicrisis != default)
            {
                compositionBuilder.AddContent(
                EhrManager.SectionBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Epicrisis)).Build())
                    .AddMembers(CreateEpicrisisEntry(model.Epicrisis))
                    .Build());
            }

            if (model.UsedDrugs != default && model.UsedDrugs.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HistologicalResult)).Build())
                        .AddMembers(model.UsedDrugs.Where(ud => ud != default).Select(ud => CreateUsedDrugEntry(ud)).ToArray())
                        .Build());
            }

            if (model.Procedures != default && model.Procedures.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HistologicalResult)).Build())
                    .AddMembers(model.Procedures.Where(p => p != default).Select(p => CreateProcedureEntry(p)).ToArray())
                    .Build());
            }

            compositionBuilder.AddContent(EhrManager.SectionBuilder.Clear().AddMembers(entryOutBuilder.Build()).Build());

            ReferenceModel referenceModel = EhrManager
                .ReferenceModelBuilder
                .AddComposition(compositionBuilder.Build())
                .Build();

            return referenceModel;
        }

        private Entry CreateHistologicalResultEntry(HistologicalResultSummaryViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder createHistologicalBuilder = EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Code)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.Code).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Date)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.Date).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Note)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Note).Build())
                        .Build()
                );

            return createHistologicalBuilder.Build();
        }

        private Entry CreateEpicrisisEntry(EpicrisisSummaryViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder createHistologicalBuilder = EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.History)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.History).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.FairCondition)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.FairCondition).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ClinicalExaminations)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ClinicalExaminations).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Consultations)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Consultations).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Regimen)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Regimen).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DiseaseCourse)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.DiseaseCourse).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Complications)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Complications).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SampleProtocol)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.SampleProtocol).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PostoperativeStatus)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PostoperativeStatus).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DischargeStatus)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.DischargeStatus).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Recommendations)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Recommendations).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CheckupAfterDischarge)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.CheckupAfterDischarge).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.GPRecommendations)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.GPRecommendations).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OtherDocuments)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.OtherDocuments).Build())
                        .Build()
                );

            if (model.DateOfSurgery != default)
            {
                createHistologicalBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DateOfSurgery)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.DateOfSurgery).Build())
                        .Build()
                    );
            }

            return createHistologicalBuilder.Build();
        }

        private Entry CreateUsedDrugEntry(UsedDrugSummaryViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder createHistologicalBuilder = EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Date)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.Date).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Code)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Code).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Quantity)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.Quantity).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Cost)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.Cost).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ICDDrug)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ICDDrug).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.UINPrescr)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.UINPrescr).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NoPrescr)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.NoPrescr).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PracticeCodeProtocol)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PracticeCodeProtocol).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProtocolNumber)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.ProtocolNumber).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProtocolDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.ProtocolDate).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProtocolType)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.ProtocolType).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BatchNumber)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.BatchNumber).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.QuantityPack)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.QuantityPack).Build())
                        .Build()
                );

            if (model.DatePrescr != default)
            {
                createHistologicalBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DatePrescr)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.DatePrescr).Build())
                        .Build()
                    );
            }

            return createHistologicalBuilder.Build();
        }

        private Entry CreateProcedureEntry(ProcedureSummaryViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder createHistologicalBuilder = EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Date)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.Date).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Code)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.Code).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ACHICode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ACHICode).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ImplantReferenceNumber)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ImplantReferenceNumber).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ImplantManufacturer)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ImplantManufacturer).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ImplantCode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ImplantCode).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HLNumber)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.HLNumber).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendAPr)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.SendAPr).Build())
                        .Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.InAPr)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.InAPr).Build())
                        .Build()
                );

            if (model.OutHospital != default)
            {
                createHistologicalBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutHospital)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.OutHospital).Build())
                        .Build()
                    );
            }

            if (model.BedDays != default)
            {
                createHistologicalBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BedDays)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.BedDays).Build())
                        .Build()
                    );
            }

            if (model.HLTotalDays != default)
            {
                createHistologicalBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HLTotalDays)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.HLTotalDays).Build())
                        .Build()
                    );
            }

            if (model.StateAtDischarge != default)
            {
                createHistologicalBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.StateAtDischarge)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.StateAtDischarge).Build())
                        .Build()
                    );
            }

            if (model.Laparoscopic != default)
            {
                createHistologicalBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Laparoscopic)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.Laparoscopic).Build())
                        .Build()
                    );
            }

            if (model.PathologicFinding != default)
            {
                createHistologicalBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PathologicFinding)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.PathologicFinding).Build())
                        .Build()
                    );
            }

            if (model.EndCourse != default)
            {
                createHistologicalBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.EndCourse)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.EndCourse).Build())
                        .Build()
                    );
            }

            if (model.HLDateFrom != default)
            {
                createHistologicalBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HLDateFrom)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.HLDateFrom).Build())
                        .Build()
                    );
            }

            return createHistologicalBuilder.Build();
        }
    }
}
