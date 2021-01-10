using Medic.AppModels.Transfers;
using Medic.EHR.Extracts;
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.ModelToEHR.Helpers
{
    internal class TransferToEHRConverter : ToEHRBaseConverter
    {
        public TransferToEHRConverter(IEHRManager ehrManager) 
            : base(ehrManager)
        {
        }

        internal EhrExtract Convert(TransferViewModel model, string name, string systemId)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryTrasnferBuilder = EhrManager.EntryBuilder;

            entryTrasnferBuilder.AddItems(
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZYear)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.IZYear).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZNumber)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.IZNumber).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CashPatient)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.CashPatient).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ClinicalProcedure)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.ClinicalProcedure).Build()).Build(),
                 EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ClinicalPath)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue(model.ClinicalPath).Build()).Build(),
                 EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DischargeWard)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue(model.DischargeWard).Build()).Build(),
                 EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TransferWard)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue(model.TransferWard).Build()).Build()
                );

            if (!string.IsNullOrWhiteSpace(model.AmbulatoryProcedure))
            {
                entryTrasnferBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AmbulatoryProcedure)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.AmbulatoryProcedure).Build()).Build()
                );
            }

            if (model.TransferDateTime != default)
            {
                entryTrasnferBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TransferDateTime)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.TransferDateTime).Build()).Build()
                );
            }

            if (!string.IsNullOrWhiteSpace(model.CPFile))
            {
                entryTrasnferBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CPFile)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.CPFile).Build()).Build()
                );
            }

            ICompositionBuilder compositionBuilder = EhrManager.CompositionBuilder
                .Clear()
                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(name).Build());

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

            EhrExtract ehrExtractModel = EhrManager
                .EhrExtractModelBuilder
                .AddEhrSystem(EhrManager.IIBuilder.Clear().AddRoot(EhrManager.OIDBuilder.Build(systemId)).Build())
                .AddTimeCreated(EhrManager.TSBuilder.Clear().AddTime(DateTime.Now).Build())
                .AddComposition(compositionBuilder.Build())
                .Build();

            return ehrExtractModel;
        }
    }
}
