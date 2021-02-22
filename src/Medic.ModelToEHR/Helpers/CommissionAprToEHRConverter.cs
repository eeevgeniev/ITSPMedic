using Medic.AppModels.APr05s;
using Medic.AppModels.APr38s;
using Medic.AppModels.Choices;
using Medic.AppModels.CommissionAprs;
using Medic.EHR.Extracts;
using Medic.EHR.RM;
using Medic.EHR.RM.Base;
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Base;
using System;
using System.Linq;

namespace Medic.ModelToEHR.Helpers
{
    internal class CommissionAprToEHRConverter : ToEHRBaseConverter
    {
        internal CommissionAprToEHRConverter(IEHRManager ehrManager) 
            : base(ehrManager) { }

        internal EhrExtract Convert(CommissionAprViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryCommissionAprBuilder = EhrManager.EntryBuilder;

            entryCommissionAprBuilder.AddItems(
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientBranch)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientBranch).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientHRegion)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientHRegion).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendDate)).Build())
                    .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.SendDate).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SpecCommission)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.SpecCommission).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NoDecision)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.NoDecision).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DecisionDate)).Build())
                    .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.DecisionDate).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sign)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Sign).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NZOKPay)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.NZOKPay).Build()).Build()
                );

            if (model.AprSend != default)
            {
                entryCommissionAprBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AprSend)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.AprSend).Build())
                        .Build());
            }

            if (model.AprPriem != default)
            {
                entryCommissionAprBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AprPriem)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.AprPriem).Build())
                        .Build());
            }

            Content commissionAprContent = entryCommissionAprBuilder.Build();

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

            if (model.MainDiag != default)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MainDiag)).Build())
                        .AddMembers(base.CreateDiagEntry(model.MainDiag))
                        .Build());
            }

            if (model.AddDiags != default && model.AddDiags.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AddDiags)).Build())
                        .AddMembers(model.AddDiags.Where(ad => ad != default).Select(d => base.CreateDiagEntry(d)).ToArray())
                        .Build());
            }

            if (model.APr38 != default)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APr38)).Build())
                        .AddMembers(CreateAPr38PreviewViewModelEntry(model.APr38))
                        .Build());
            }

            if (model.APr05 != default)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APr05)).Build())
                        .AddMembers(CreateAPr05PreviewViewModelEntry(model.APr05))
                        .Build());
            }

            compositionBuilder.AddContent(EhrManager.SectionBuilder.Clear().AddMembers(commissionAprContent).Build());

            EhrExtract ehrExtractModel = EhrManager
                .EhrExtractModelBuilder
                .AddEhrSystem(EhrManager.IIBuilder.Clear().AddRoot(EhrManager.OIDBuilder.Build(systemId)).Build())
                .AddSubjectOfCare(EhrManager.IIBuilder.Clear().AddRoot(EhrManager.OIDBuilder.Build(model.Patient.IdentityNumber)).Build())
                .AddTimeCreated(EhrManager.TSBuilder.Clear().AddTime(DateTime.Now).Build())
                .AddComposition(compositionBuilder.Build())
                .Build();

            return ehrExtractModel;
        }

        private Entry CreateAPr05PreviewViewModelEntry(APr05PreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DiagnoseDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.DiagnoseDate).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Staging)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Staging).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Imuno)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Imuno).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Genetic)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Genetic).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Sign)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Sign).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NZOKPay)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.NZOKPay).Build()).Build()
                )
                .Build();
        }

        private Entry CreateAPr38PreviewViewModelEntry(APr38PreviewViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder =  EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Height)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Height).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Weight)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.Weight).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.History)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.History).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.FairCondition)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.FairCondition).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Therapy)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Therapy).Build()).Build()
                );

            if (model.Decision != default && model.Decision.Choices != default && model.Decision.Choices.Count > 0)
            {
                entryBuilder.AddItems(
                        EhrManager.ClusterBuilder.Clear()
                            .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Decision)).Build())
                            .AddParts(
                                EhrManager.ClusterBuilder
                                    .Clear()
                                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Decision.Choices)).Build())
                                    .AddParts(model.Decision.Choices.Where(ch => ch != default).Select(ch => ChoicePreviewViewModelToCluster(ch, nameof(model.Decision.Choices))).ToArray())
                                    .Build())
                            .Build()
                    );
            }

            return entryBuilder.Build();
        }

        private Cluster ChoicePreviewViewModelToCluster(ChoicePreviewViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return EhrManager.ClusterBuilder
                .Clear()
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
    }
}
