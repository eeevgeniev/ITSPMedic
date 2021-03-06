﻿using Medic.AppModels.Plannings;
using Medic.EHR.Extracts;
using Medic.EHR.RM.Base;
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Base;
using System;
using System.Linq;

namespace Medic.ModelToEHR.Helpers
{
    internal class PlannedToEHRConverter : ToEHRBaseConverter
    {
        internal PlannedToEHRConverter(IEHRManager ehrManager)
            : base(ehrManager) { }

        internal EhrExtract Convert(PlannedViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryPlannedBuilder = EhrManager
                .EntryBuilder
                .AddItems(
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
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Urgency)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Urgency).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NZOKPay)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.NZOKPay).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CPFile)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.CPFile).Build()).Build()
                );

            if (model.PlannedNumber != default)
            {
                entryPlannedBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PlannedNumber)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.PlannedNumber).Build())
                        .Build());
            }

            if (model.SendAPr != default)
            {
                entryPlannedBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendAPr)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.SendAPr).Build())
                        .Build());
            }

            if (model.InAPr != default)
            {
                entryPlannedBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.InAPr)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.InAPr).Build())
                        .Build());
            }

            if (model.PackageType != default)
            {
                entryPlannedBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PackageType)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.PackageType).Build())
                        .Build());
            }

            if (model.SendPackageType != default)
            {
                entryPlannedBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendPackageType)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.SendPackageType).Build())
                        .Build());
            }

            if (model.SendClinicalPath != default)
            {
                entryPlannedBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendClinicalPath)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.SendClinicalPath).Build()).Build());
            }

            if (model.PlannedEntryDate != default)
            {
                entryPlannedBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PlannedEntryDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.PlannedEntryDate).Build()).Build());
            }

            if (model.ClinicalPath != default)
            {
                entryPlannedBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ClinicalPath)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ClinicalPath).Build()).Build());
            }

            ICompositionBuilder compositionBuilder = EhrManager.CompositionBuilder
                .Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(name).Build());

            Content entryContent = entryPlannedBuilder.Build();

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

            compositionBuilder.AddContent(EhrManager.SectionBuilder.Clear().AddMembers(entryContent).Build());

            EhrExtract ehrExtractModel = EhrManager
                .EhrExtractModelBuilder
                .AddEhrSystem(EhrManager.IIBuilder.Clear().AddRoot(EhrManager.OIDBuilder.Build(systemId)).Build())
                .AddSubjectOfCare(EhrManager.IIBuilder.Clear().AddRoot(EhrManager.OIDBuilder.Build(model.Patient.IdentityNumber)).Build())
                .AddTimeCreated(EhrManager.TSBuilder.Clear().AddTime(DateTime.Now).Build())
                .AddComposition(compositionBuilder.Build())
                .Build();

            return ehrExtractModel;
        }
    }
}
