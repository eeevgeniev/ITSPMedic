using Medic.AppModels.AccompanyingDrugs;
using Medic.AppModels.ChemotherapyParts;
using Medic.AppModels.Choices;
using Medic.AppModels.Diags;
using Medic.AppModels.DrugProtocols;
using Medic.AppModels.GenMarkers;
using Medic.AppModels.HematologyParts;
using Medic.AppModels.Histologies;
using Medic.AppModels.Practices;
using Medic.AppModels.ProtocolDrugTherapies;
using Medic.EHR.RM;
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Base;
using System;
using System.Linq;

namespace Medic.ModelToEHR.Helpers
{
    internal class ProtocolDrugTherapyToEHRConverter : ToEHRBaseConverter
    {
        public ProtocolDrugTherapyToEHRConverter(IEHRManager ehrManager) 
            : base(ehrManager) {}

        internal ReferenceModel Convert(ProtocolDrugTherapyViewModel model, string name)
        {
            IEntryBuilder entryProtocolDrugTherapyBuilder = EhrManager.EntryBuilder;

            entryProtocolDrugTherapyBuilder.AddItems(
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientBranch)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientBranch).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientHRegion)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientHRegion).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NumberOfDecision)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.NumberOfDecision).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DecisionDate)).Build())
                    .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.DecisionDate).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PracticeCodeProtocol)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PracticeCodeProtocol).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NumberOfProtocol)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.NumberOfProtocol).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProtocolDate)).Build())
                    .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.ProtocolDate).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Height)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Height).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Weight)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Weight).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BSA)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue(model.BSA).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TherapyLine)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.TherapyLine).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Scheme)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Scheme).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CycleCount)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.CycleCount).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sign)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Sign).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CPFile)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.CPFile).Build()).Build()
                );

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

            if (model.Chairman != default)
            {
                compositionBuilder.AddContent(
                EhrManager.SectionBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Chairman)).Build())
                    .AddMembers(base.CreatePractitionerEntry(model.Chairman))
                    .Build());
            }

            if (model.Diag != default)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Diag)).Build())
                        .AddMembers(base.CreateDiagEntry(model.Diag))
                        .Build());
            }

            if (model.Practice != default)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Practice)).Build())
                        .AddMembers(CreatePracticeEntry(model.Practice))
                        .Build());
            }

            if (model.HematologyPart != default)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HematologyPart)).Build())
                        .AddMembers(CreateHematologyPartEntry(model.HematologyPart))
                        .Build());
            }

            if (model.ChemotherapyPart != default)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ChemotherapyPart)).Build())
                        .AddMembers(CreateChemotherapyPartEntry(model.ChemotherapyPart))
                        .Build());
            }

            if (model.DrugProtocols != default && model.DrugProtocols.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DrugProtocols)).Build())
                        .AddMembers(model.DrugProtocols.Where(dp => dp != default).Select(dp => CreateDrugProtocolEntry(dp)).ToArray())
                        .Build());
            }

            if (model.AccompanyingDrugs != default && model.AccompanyingDrugs.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AccompanyingDrugs)).Build())
                        .AddMembers(model.AccompanyingDrugs.Where(ad => ad != default).Select(ad => CreateAccompanyingDrugEntry(ad)).ToArray())
                        .Build());
            }

            compositionBuilder.AddContent(EhrManager.SectionBuilder.Clear().AddMembers(entryProtocolDrugTherapyBuilder.Build()).Build());

            ReferenceModel referenceModel = EhrManager
                .ReferenceModelBuilder
                .AddComposition(compositionBuilder.Build())
                .Build();

            return referenceModel;
        }

        private Entry CreatePracticeEntry(PracticePreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Branch)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Branch).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Number)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Number).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Code)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Code).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Name)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Name).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HealthRegion)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.HealthRegion).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Address)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Address).Build()).Build()
                ).Build();
        }

        private Entry CreateDrugProtocolEntry(DrugProtocolPreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ATCCode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ATCCode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ATCName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ATCName).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Days)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Days).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ApplicationWay)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ApplicationWay).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.StandartDose)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.StandartDose).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IndividualDose)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.IndividualDose).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CycleDose)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.CycleDose).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AllDose)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.AllDose).Build()).Build()
                );

            if (model.TherapyType != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ClusterBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TherapyType)).Build())
                        .AddParts(
                            EhrManager.ElementBuilder.Clear()
                                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TherapyType.Code)).Build())
                                .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.TherapyType.Code).Build()).Build(),
                            EhrManager.ElementBuilder.Clear()
                                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TherapyType.Name)).Build())
                                .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.TherapyType.Name).Build()).Build()
                        ).Build()
                    );
            }

            return entryBuilder.Build();
        }

        private Entry CreateHematologyPartEntry(HematologyPartPreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder.Clear();

            if (model.PredMarker != default && model.PredMarker.Choices != default && model.PredMarker.Choices.Count > 0)
            {
                Cluster[] choiceCluster = model.PredMarker.Choices.Where(c => c != default).Select(c => CreateChoiceCluster(c, nameof(model.PredMarker.Choices))).ToArray();

                entryBuilder.AddItems(EhrManager.ClusterBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PredMarker)).Build())
                    .AddParts(choiceCluster)
                    .Build());
            }

            return entryBuilder.Build();
        }

        private Entry CreateChemotherapyPartEntry(ChemotherapyPartPreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DiagnoseDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.DiagnoseDate).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ExpandDiagnose)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ExpandDiagnose).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ECOG)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.ECOG).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Staging)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Staging).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TNM)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.TNM).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TherapyType)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.TherapyType).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.EvalAfterCycle)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.EvalAfterCycle).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Interval)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Interval).Build()).Build()
                );

            if (model.AddDiags != default && model.AddDiags.Count > 0)
            {
                entryBuilder.AddItems(model.AddDiags.Where(d => d != default).Select(d => CreateDiagCluster(d, nameof(model.AddDiags))).ToArray());
            }

            if (model.Histology != default)
            {
                entryBuilder.AddItems(CreateHistologyCluster(model.Histology, nameof(model.Histology)));
            }

            if (model.GenMarkers != default && model.GenMarkers.Count > 0)
            {
                entryBuilder.AddItems(model.GenMarkers
                    .Where(gm => gm != default)
                    .Select(gm => CreateGenMarkerCluster(gm, nameof(model.GenMarkers))).ToArray());
            }

            if (model.Evaluation != default && model.Evaluation.Choices != default && model.Evaluation.Choices.Count > 0)
            {
                Cluster[] choiceCluster = model.Evaluation.Choices.Where(c => c != default).Select(c => CreateChoiceCluster(c, nameof(model.Evaluation.Choices))).ToArray();

                entryBuilder.AddItems(EhrManager.ClusterBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Evaluation)).Build())
                    .AddParts(choiceCluster)
                    .Build());
            }

            return entryBuilder.Build();
        }

        private Entry CreateAccompanyingDrugEntry(AccompanyingDrugPreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder.Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ATCCode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ATCCode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ATCName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ATCName).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SingleDose)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.SingleDose).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AllDose)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.AllDose).Build()).Build()
                );

            if (model.TherapyType != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ClusterBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TherapyType)).Build())
                        .AddParts(
                            EhrManager.ElementBuilder.Clear()
                                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TherapyType.Code)).Build())
                                .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.TherapyType.Code).Build()).Build(),
                            EhrManager.ElementBuilder.Clear()
                                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TherapyType.Name)).Build())
                                .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.TherapyType.Name).Build()).Build()
                        )
                        .Build()
                    );
            }

            return entryBuilder.Build();
        }

        private Cluster CreateChoiceCluster(ChoicePreviewViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return EhrManager.ClusterBuilder.Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(name).Build())
                .AddParts(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Number)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Number).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Checked)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Checked).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Text)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Text).Build()).Build()
                ).Build();
        }

        private Cluster CreateDiagCluster(DiagPreviewViewModel model, string name)
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
                ).Build();
        }

        private Cluster CreateHistologyCluster(HistologyPreviewViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Cluster apr05Cluster = default;

            if (model.APr05 != default)
            {
                apr05Cluster = EhrManager.ClusterBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APr05)).Build())
                    .AddParts(
                        EhrManager.ElementBuilder.Clear()
                            .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APr05.DiagnoseDate)).Build())
                            .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.APr05.DiagnoseDate).Build()).Build(),
                        EhrManager.ElementBuilder.Clear()
                            .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APr05.Staging)).Build())
                            .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.APr05.Staging).Build()).Build(),
                        EhrManager.ElementBuilder.Clear()
                            .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APr05.Imuno)).Build())
                            .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.APr05.Imuno).Build()).Build(),
                        EhrManager.ElementBuilder.Clear()
                            .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APr05.Genetic)).Build())
                            .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.APr05.Genetic).Build()).Build(),
                        EhrManager.ElementBuilder.Clear()
                            .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APr05.Sign)).Build())
                            .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.APr05.Sign).Build()).Build(),
                        EhrManager.ElementBuilder.Clear()
                            .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APr05.NZOKPay)).Build())
                            .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.APr05.NZOKPay).Build()).Build()
                    ).Build();
            }

            IClusterBuilder clusterBuilder = EhrManager.ClusterBuilder.Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(name).Build())
                .AddParts(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NameHS)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.NameHS).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CodeHS)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.CodeHS).Build()).Build()
                );

            if (apr05Cluster != default)
            {
                clusterBuilder.AddParts(apr05Cluster);
            }

            return clusterBuilder.Build();
        }

        private Cluster CreateGenMarkerCluster(GenMarkerPreviewViewModel model, string name)
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
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sign)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Sign).Build()).Build()
                ).Build();
        }
    }
}
