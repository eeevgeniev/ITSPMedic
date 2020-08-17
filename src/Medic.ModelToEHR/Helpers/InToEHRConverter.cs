using Medic.AppModels.Ins;
using Medic.EHR.RM;
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Base;
using System;
using System.Linq;

namespace Medic.ModelToEHR.Helpers
{
    internal class InToEHRConverter : ToEHRBaseConverter
    {
        internal InToEHRConverter(IEHRManager ehrManager) 
            : base(ehrManager) {}

        internal ReferenceModel Convert(InViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryInsBuilder = EhrManager.EntryBuilder;

            entryInsBuilder.AddItems(
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
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CPFile)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.CPFile).Build()).Build()
                );

            if (model.SendClinicalPath != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendClinicalPath)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.SendClinicalPath).Build())
                        .Build());
            }

            if (model.ClinicalPath != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ClinicalPath)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.ClinicalPath).Build())
                        .Build());
            }

            if (model.SendAPr != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendAPr)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.SendAPr).Build())
                        .Build());
            }

            if (model.InAPr != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.InAPr)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.InAPr).Build())
                        .Build());
            }

            if (model.Delay != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Delay)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.Delay).Build())
                        .Build());
            }

            if (model.AgeInDays != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AgeInDays)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.AgeInDays).Build())
                        .Build());
            }

            if (model.WeightInGrams != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.WeightInGrams)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.WeightInGrams).Build())
                        .Build());
            }

            if (model.BirthWeight != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BirthWeight)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.BirthWeight).Build())
                        .Build());
            }

            if (model.MotherIZYear != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MotherIZYear)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.MotherIZYear).Build())
                        .Build());
            }

            if (model.MotherIZNo != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MotherIZNo)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.MotherIZNo).Build())
                        .Build());
            }

            if (model.IZYear != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZYear)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.IZYear).Build())
                        .Build());
            }

            if (model.IZNo != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZNo)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.IZNo).Build())
                        .Build());
            }

            if (model.PackageType != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PackageType)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.PackageType).Build())
                        .Build());
            }

            if (model.SendPackageType != default)
            {
                entryInsBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendPackageType)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.SendPackageType).Build())
                        .Build());
            }

            ICompositionBuilder compositionBuilder = EhrManager.CompositionBuilder.Clear()
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
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendDiagnoses)).Build())
                        .AddMembers(model.SendDiagnoses.Where(sd => sd != default).Select(sd => base.CreateDiagnoseEntry(sd)).ToArray())
                        .Build());
            }

            if (model.Diagnoses != default && model.Diagnoses.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Diagnoses)).Build())
                        .AddMembers(model.Diagnoses.Where(d => d != default).Select(d => base.CreateDiagnoseEntry(d)).ToArray())
                        .Build());
            }

            compositionBuilder.AddContent(EhrManager.SectionBuilder.Clear().AddMembers(entryInsBuilder.Build()).Build());

            ReferenceModel referenceModel = EhrManager
                .ReferenceModelBuilder
                .AddComposition(compositionBuilder.Build())
                .Build();

            return referenceModel;
        }
    }
}
