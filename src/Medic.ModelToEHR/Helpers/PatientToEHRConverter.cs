using Medic.AppModels.CommissionAprs;
using Medic.AppModels.Diagnoses;
using Medic.AppModels.DispObservations;
using Medic.AppModels.InClinicProcedures;
using Medic.AppModels.Ins;
using Medic.AppModels.Outs;
using Medic.AppModels.PathProcedures;
using Medic.AppModels.Patients;
using Medic.AppModels.Plannings;
using Medic.AppModels.ProtocolDrugTherapies;
using Medic.EHR.RM;
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Base;
using System;
using System.Linq;

namespace Medic.ModelToEHR.Helpers
{
    internal class PatientToEHRConverter : ToEHRBaseConverter
    {
        public PatientToEHRConverter(IEHRManager ehrManager)
            : base(ehrManager) { }

        internal ReferenceModel Convert(PatientViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryPatientBuilder = EhrManager.EntryBuilder;

            entryPatientBuilder.AddItems(
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IdentityNumber)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.IdentityNumber).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BirthDate)).Build())
                    .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.BirthDate).Build()).Build()
                );

            if (!string.IsNullOrWhiteSpace(model.FirstName))
            {
                entryPatientBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.FirstName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.FirstName).Build())
                        .Build());
            }

            if (!string.IsNullOrWhiteSpace(model.SecondName))
            {
                entryPatientBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SecondName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.SecondName).Build())
                        .Build());
            }

            if (!string.IsNullOrWhiteSpace(model.LastName))
            {
                entryPatientBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.LastName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.LastName).Build())
                        .Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Sex))
            {
                entryPatientBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sex)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Sex).Build())
                        .Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Address))
            {
                entryPatientBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Address)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Address).Build())
                        .Build());
            }

            if (!string.IsNullOrWhiteSpace(model.Notes))
            {
                entryPatientBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Notes)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Notes).Build())
                        .Build());
            }

            ICompositionBuilder compositionBuilder = EhrManager.CompositionBuilder
                .Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(name).Build());


            compositionBuilder.AddContent(EhrManager.SectionBuilder.Clear().AddMembers(entryPatientBuilder.Build()).Build());

            if (model.Ins != default && model.Ins.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Ins)).Build())
                        .AddMembers(model.Ins.Where(i => i != default).Select(i => CreateInEntry(i)).ToArray())
                        .Build());
            }

            if (model.InClinicProcedures != default && model.InClinicProcedures.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.InClinicProcedures)).Build())
                        .AddMembers(model.InClinicProcedures.Where(icp => icp != default).Select(icp => CreateInClinicProcedureEntry(icp)).ToArray())
                        .Build());
            }

            if (model.Outs != default && model.Outs.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Outs)).Build())
                        .AddMembers(model.Outs.Where(o => o != default).Select(o => CreateOutEntry(o)).ToArray())
                        .Build());
            }

            if (model.PathProcedures != default && model.PathProcedures.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PathProcedures)).Build())
                        .AddMembers(model.PathProcedures.Where(pp => pp != default).Select(pp => CreatePathProcedureEntry(pp)).ToArray())
                        .Build());
            }

            if (model.ProtocolDrugTherapies != default && model.ProtocolDrugTherapies.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProtocolDrugTherapies)).Build())
                        .AddMembers(model.ProtocolDrugTherapies.Where(pdt => pdt != default).Select(pdt => CreateProtocolDrugTherapyEntry(pdt)).ToArray())
                        .Build());
            }

            if (model.CommissionAprs != default && model.CommissionAprs.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CommissionAprs)).Build())
                        .AddMembers(model.CommissionAprs.Where(ca => ca != default).Select(ca => CreateCommissionAprEntry(ca)).ToArray())
                        .Build());
            }

            if (model.DispObservations != default && model.DispObservations.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DispObservations)).Build())
                        .AddMembers(model.DispObservations.Where(disp => disp != default).Select(disp => CreateDispObservationEntry(disp)).ToArray())
                        .Build());
            }

            if (model.Plannings != default && model.Plannings.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Plannings)).Build())
                        .AddMembers(model.Plannings.Where(p => p != default).Select(p => CreatePlannedEntry(p)).ToArray())
                        .Build());
            }

            ReferenceModel referenceModel = EhrManager
                .ReferenceModelBuilder
                .AddComposition(compositionBuilder.Build())
                .Build();

            return referenceModel;
        }

        private Entry CreateInEntry(PatientInPreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.EntryDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.EntryDate).Build()).Build()
                );

            if (model.SendDiagnoses != default && model.SendDiagnoses.Count > 0)
            {
                entryBuilder.AddItems(
                    model.SendDiagnoses.Where(sd => sd != default).Select(sd => CreateDiagnoseCluster(sd, nameof(model.SendDiagnoses))).ToArray()
                    );
            }

            return entryBuilder.Build();
        }

        private Entry CreateOutEntry(PatientOutPreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.OutDate).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBCode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBCode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBName).Build()).Build()
                );

            return entryBuilder.Build();
        }

        private Entry CreatePlannedEntry(PatientPlannedPreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ExaminationDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.ExaminationDate).Build()).Build()
                );

            if (model.Diagnoses != default && model.Diagnoses.Count > 0)
            {
                entryBuilder.AddItems(
                    model.Diagnoses.Where(sd => sd != default).Select(sd => CreateDiagnoseCluster(sd, nameof(model.Diagnoses))).ToArray()
                    );
            }

            return entryBuilder.Build();
        }

        private Entry CreateInClinicProcedureEntry(PatientInClinicProcedurePreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBCode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBCode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBName).Build()).Build()
                );

            if (model.PlanVisitDate != default)
            {
                EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PlanVisitDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.PlanVisitDate).Build()).Build());
            }

            return entryBuilder.Build();
        }

        private Entry CreatePathProcedureEntry(PatientPathProcedurePreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DateSend)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.DateSend).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBCode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBCode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBName).Build()).Build()
                );

            return entryBuilder.Build();
        }

        private Entry CreateProtocolDrugTherapyEntry(PatientProtocolDrugTherapyPreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProtocolDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.ProtocolDate).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBCode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBCode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBName).Build()).Build()
                );

            return entryBuilder.Build();
        }

        private Entry CreateCommissionAprEntry(PatientCommissionAprPreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DecisionDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.DecisionDate).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBCode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBCode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBName).Build()).Build()
                );

            return entryBuilder.Build();
        }

        private Entry CreateDispObservationEntry(PatientDispObservationPreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DispDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.DispDate).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBCode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBCode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MKBName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.MKBName).Build()).Build()
                );

            return entryBuilder.Build();
        }

        private Cluster CreateDiagnoseCluster(DiagnosePreviewViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return EhrManager.ClusterBuilder.Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(name).Build())
                .AddParts(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Name)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Name).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Code)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Code).Build()).Build()
                )
                .Build();
        }
    }
}
