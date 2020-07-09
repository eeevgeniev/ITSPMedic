using Medic.AppModels.Ins;
using Medic.EHR.RM;
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Contracts;
using System;
using System.Linq;

namespace Medic.ModelToEHR
{
    public class ToEHRConverter : IToEHRConverter
    {
        private readonly IEHRManager EhrManager;

        public ToEHRConverter(IEHRManager ehrManager)
        {
            EhrManager = ehrManager ?? throw new ArgumentNullException(nameof(ehrManager));
        }

        public ReferenceModel Convert(InViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var entryInsBuilder = EhrManager.EntryBuilder;
            
            entryInsBuilder.AddItems(
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientBranch)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientBranch).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientHRegion)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientHRegion).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.InType)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue(model.InType).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendDate)).Build()).AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.SendDate).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendUrgency)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue(model.SendUrgency).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendClinicalPath)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.SendClinicalPath).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.UniqueIdentifier)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.UniqueIdentifier).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ExaminationDate)).Build()).AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.ExaminationDate).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PlannedNumber)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue(model.PlannedNumber).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Urgency)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Urgency).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ClinicalPath)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ClinicalPath).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NZOKPay)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue(model.NZOKPay).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.InMedicalWard)).Build()).AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.InMedicalWard).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.EntryDate)).Build()).AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.EntryDate).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Severity)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Severity).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Payer)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Payer).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CPFile)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.CPFile).Build()).Build()
                );

            if (model.SendApr != default)
            {
                entryInsBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendApr)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.SendApr).Build()).Build());
            }

            if (model.InApr != default)
            {
                entryInsBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.InApr)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.InApr).Build()).Build());
            }

            if (model.Delay != default)
            {
                entryInsBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Delay)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.Delay).Build()).Build());
            }

            if (model.AgeInDays != default)
            {
                entryInsBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AgeInDays)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.AgeInDays).Build()).Build());
            }

            if (model.WeightInGrams != default)
            {
                entryInsBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.WeightInGrams)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.WeightInGrams).Build()).Build());
            }

            if (model.BirthWeight != default)
            {
                entryInsBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BirthWeight)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.BirthWeight).Build()).Build());
            }

            if (model.MotherIZYear != default)
            {
                entryInsBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MotherIZYear)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.MotherIZYear).Build()).Build());
            }

            if (model.MotherIZNo != default)
            {
                entryInsBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MotherIZNo)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.MotherIZNo).Build()).Build());
            }

            if (model.IZYear != default)
            {
                entryInsBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZYear)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.IZYear).Build()).Build());
            }

            if (model.IZNo != default)
            {
                entryInsBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZNo)).Build()).AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.IZNo).Build()).Build());
            }

            Section inSection = EhrManager.SectionBuilder.Clear().AddMembers(entryInsBuilder.Build()).Build();

            var entryPatientBuilder = EhrManager.EntryBuilder.Clear();
            entryPatientBuilder.AddItems(
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Patient.IdentityNumber)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Patient.IdentityNumber).Build()).Build(),
                EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Patient.Sex)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Patient.Sex).Build()).Build()
                );

            if (!string.IsNullOrWhiteSpace(model.Patient.FirstName))
            {
                entryPatientBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Patient.FirstName)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Patient.FirstName).Build()).Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Patient.SecondName))
            {
                entryPatientBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Patient.SecondName)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Patient.SecondName).Build()).Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Patient.LastName))
            {
                entryPatientBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Patient.LastName)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Patient.LastName).Build()).Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Patient.Address))
            {
                entryPatientBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Patient.Address)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Patient.Address).Build()).Build());
            }

            if (model.Patient.BirthDate != default)
            {
                entryPatientBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZNo)).Build()).AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.Patient.BirthDate).Build()).Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Patient.Notes))
            {
                entryPatientBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Patient.Notes)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Patient.Notes).Build()).Build());
            }

            Section patientSection = EhrManager.SectionBuilder.Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Patient)).Build())
                .AddMembers(entryPatientBuilder.Build()).Build();

            var entryPratitionerBuilder = EhrManager.EntryBuilder.Clear();

            if (!string.IsNullOrWhiteSpace(model.Sender.UniqueIdentifier))
            {
                entryPratitionerBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sender.UniqueIdentifier)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Sender.UniqueIdentifier).Build()).Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Sender.DeputyUniqueIdentifier))
            {
                entryPratitionerBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sender.DeputyUniqueIdentifier)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Sender.DeputyUniqueIdentifier).Build()).Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Sender.Speciality))
            {
                entryPratitionerBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sender.Speciality)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Sender.Speciality).Build()).Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Sender.Name))
            {
                entryPratitionerBuilder.AddItems(EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sender.Name)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Sender.Name).Build()).Build());
            }

            Section practitionerSection = EhrManager.SectionBuilder.Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sender)).Build())
                .AddMembers(entryPratitionerBuilder.Build()).Build();

            Section[] sendDiagnosesSection = model.SendDiagnoses.Select(sd =>
            {
                return EhrManager.SectionBuilder.Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendDiagnoses)).Build())
                .AddMembers(
                    EhrManager.EntryBuilder.Clear().AddItems(
                        EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(sd.Name)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(sd.Name).Build()).Build(),
                        EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(sd.Name)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(sd.Code).Build()).Build()
                        ).Build()
                ).Build();
            }).ToArray();

            Section[] diagnosesSection = model.Diagnoses.Select(sd =>
            {
                return EhrManager.SectionBuilder.Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Diagnoses)).Build())
                .AddMembers(
                    EhrManager.EntryBuilder.Clear().AddItems(
                        EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(sd.Name)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(sd.Name).Build()).Build(),
                        EhrManager.ElementBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(sd.Name)).Build()).AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(sd.Code).Build()).Build()
                        ).Build()
                ).Build();
            }).ToArray();

            ReferenceModel referenceModel = EhrManager
                .ReferenceModelBuilder
                .AddComposition(EhrManager.CompositionBuilder.Clear().AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText("In").Build()).AddContent(patientSection, practitionerSection).AddContent(sendDiagnosesSection).AddContent(diagnosesSection).AddContent(inSection).Build())
                .Build();

            return referenceModel;
        }
    }
}
