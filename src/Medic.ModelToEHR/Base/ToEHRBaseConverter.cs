using Medic.AppModels.Diagnoses;
using Medic.AppModels.Diags;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using Medic.EHR.RM;
using Medic.EHRBuilders.Contracts;
using System;

namespace Medic.ModelToEHR.Base
{
    public abstract class ToEHRBaseConverter
    {
        private readonly IEHRManager _ehrManager;

        internal ToEHRBaseConverter(IEHRManager ehrManager)
        {
            _ehrManager = ehrManager ?? throw new ArgumentNullException(nameof(ehrManager));
        }

        protected IEHRManager EhrManager => _ehrManager;

        protected Entry CreatePatientEntry(PatientSummaryViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryPatientBuilder = EhrManager.EntryBuilder.Clear();
            entryPatientBuilder.AddItems(
                EhrManager.ElementBuilder
                    .Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IdentityNumber)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.IdentityNumber).Build())
                    .Build(),
                EhrManager.ElementBuilder
                    .Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sex)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Sex).Build())
                    .Build()
                );

            if (!string.IsNullOrWhiteSpace(model.FirstName))
            {
                entryPatientBuilder
                    .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.FirstName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.FirstName).Build()).Build());
            }

            if (!string.IsNullOrWhiteSpace(model.SecondName))
            {
                entryPatientBuilder
                    .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SecondName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.SecondName).Build()).Build());
            }

            if (!string.IsNullOrWhiteSpace(model.LastName))
            {
                entryPatientBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.LastName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.LastName).Build()).Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Address))
            {
                entryPatientBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Address)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Address).Build()).Build());
            }

            if (model.BirthDate != default)
            {
                entryPatientBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BirthDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.BirthDate).Build()).Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Notes))
            {
                entryPatientBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Notes)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Notes).Build()).Build());
            }

            return entryPatientBuilder.Build();
        }

        protected Entry CreatePractitionerEntry(HealthcarePractitionerSummaryViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryPratitionerBuilder = EhrManager.EntryBuilder.Clear();

            if (!string.IsNullOrWhiteSpace(model.UniqueIdentifier))
            {
                entryPratitionerBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.UniqueIdentifier)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.UniqueIdentifier).Build())
                        .Build());
            }

            if (!string.IsNullOrWhiteSpace(model.DeputyUniqueIdentifier))
            {
                entryPratitionerBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DeputyUniqueIdentifier)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.DeputyUniqueIdentifier).Build())
                        .Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Speciality))
            {
                entryPratitionerBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Speciality)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Speciality).Build())
                        .Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                entryPratitionerBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Name)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Name).Build())
                        .Build());
            }

            return entryPratitionerBuilder.Build();
        }

        protected Entry CreateDiagnoseEntry(DiagnosePreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder
                    .Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Code)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Code).Build())
                    .Build())
                .Build();
        }

        protected Entry CreateDiagEntry(DiagPreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder
                    .Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Code)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Code).Build())
                    .Build(),
                    EhrManager.ElementBuilder
                    .Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Name)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Name).Build())
                    .Build())
                .Build();
        }
    }
}
