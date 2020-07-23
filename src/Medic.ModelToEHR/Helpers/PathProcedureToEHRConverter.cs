using Medic.AppModels.ClinicProcedures;
using Medic.AppModels.ClinicUsedDrugs;
using Medic.AppModels.DoneProcedures;
using Medic.AppModels.PathProcedures;
using Medic.AppModels.Procedures;
using Medic.EHR.RM;
using Medic.EHRBuilders.Contracts;
using Medic.ModelToEHR.Base;
using System;
using System.Linq;

namespace Medic.ModelToEHR.Helpers
{
    internal class PathProcedureToEHRConverter : ToEHRBaseConverter
    {
        public PathProcedureToEHRConverter(IEHRManager ehrManager) 
            : base(ehrManager) {}

        internal ReferenceModel Convert(PathProcedureViewModel model, string name)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryPathProcedureBuilder = EhrManager.EntryBuilder;

            entryPathProcedureBuilder.AddItems(
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientBranch)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientBranch).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientHRegion)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PatientHRegion).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TypeProcSend)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.TypeProcSend).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DateSend)).Build())
                    .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.DateSend).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.MedicalWard)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.MedicalWard).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.TypeProcPriem)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.TypeProcPriem).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProcRefuse)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.ProcRefuse).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZNumChild)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.IZNumChild).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.IZYearChild)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.IZYearChild).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.VisitDocumentUniqueIdentifier)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.VisitDocumentUniqueIdentifier).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.VisitDocumentName)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.VisitDocumentName).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AllDoneProcedures)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.AllDoneProcedures).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.AllDrugCost)).Build())
                    .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.AllDrugCost).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PatientStatus)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.PatientStatus).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.VisitDocumentUniqueIdentifier)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.VisitDocumentUniqueIdentifier).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutUniqueIdentifier)).Build())
                    .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.OutUniqueIdentifier).Build()).Build(),
                EhrManager.ElementBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NZOKPay)).Build())
                    .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.NZOKPay).Build()).Build()
                );

            if (model.CPrSend != default)
            {
                entryPathProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CPrSend)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.CPrSend).Build())
                        .Build());
            }

            if (model.APrSend != default)
            {
                entryPathProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APrSend)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.APrSend).Build())
                        .Build());
            }

            if (model.CPrPriem != default)
            {
                entryPathProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.CPrPriem)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.CPrPriem).Build())
                        .Build());
            }

            if (model.APrPriem != default)
            {
                entryPathProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.APrPriem)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.APrPriem).Build())
                        .Build());
            }

            if (model.FirstVisitDate != default)
            {
                entryPathProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.FirstVisitDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.FirstVisitDate).Build())
                        .Build());
            }

            if (model.DatePlanPriem != default)
            {
                entryPathProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DatePlanPriem)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.DatePlanPriem).Build())
                        .Build());
            }

            if (model.DateProcedureBegins != default)
            {
                entryPathProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DateProcedureBegins)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.DateProcedureBegins).Build())
                        .Build());
            }

            if (model.DateProcedureEnd != default)
            {
                entryPathProcedureBuilder.AddItems(
                    EhrManager.ElementBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DateProcedureEnd)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.DateProcedureEnd).Build())
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

            if (model.DoneNewProcedures != default && model.DoneNewProcedures.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DoneNewProcedures)).Build())
                        .AddMembers(model.DoneNewProcedures.Where(dnp => dnp != default).Select(dnp => CreateProcedureSummaryEntry(dnp)).ToArray())
                        .Build());
            }

            if (model.UsedDrugs != default && model.UsedDrugs.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.UsedDrugs)).Build())
                        .AddMembers(model.UsedDrugs.Where(ud => ud != default).Select(ud => CreateClinicUsedDrugEntry(ud)).ToArray())
                        .Build());
            }

            if (model.ClinicProcedures != default && model.ClinicProcedures.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ClinicProcedures)).Build())
                        .AddMembers(model.ClinicProcedures.Where(cp => cp != default).Select(cp => CreateClinicProcedureEntry(cp)).ToArray())
                        .Build());
            }

            if (model.DoneProcedures != default && model.DoneProcedures.Count > 0)
            {
                compositionBuilder.AddContent(
                    EhrManager.SectionBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DoneProcedures)).Build())
                        .AddMembers(model.DoneProcedures.Where(dp => dp != default).Select(dp => CreateDoneProcedureEntry(dp)).ToArray())
                        .Build());
            }

            compositionBuilder.AddContent(EhrManager.SectionBuilder.Clear().AddMembers(entryPathProcedureBuilder.Build()).Build());

            ReferenceModel referenceModel = EhrManager
                .ReferenceModelBuilder
                .AddComposition(compositionBuilder.Build())
                .Build();

            return referenceModel;
        }

        private Entry CreateProcedureSummaryEntry(ProcedureSummaryViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager
                .EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Date)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.Date).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Code)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.Code).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ACHICode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ACHICode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ImplantReferenceNumber)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ImplantReferenceNumber).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ImplantManufacturer)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ImplantManufacturer).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ImplantCode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ImplantCode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HLNumber)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.HLNumber).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.SendAPr)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.SendAPr).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.InAPr)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.InAPr).Build()).Build()
                );

            if (model.OutHospital != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.OutHospital)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.OutHospital).Build()).Build());
            }

            if (model.BedDays != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.BedDays)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.BedDays).Build()).Build());
            }

            if (model.HLDateFrom != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HLDateFrom)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.HLDateFrom).Build()).Build());
            }

            if (model.HLTotalDays != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.HLTotalDays)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.HLTotalDays).Build()).Build());
            }

            if (model.StateAtDischarge != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.StateAtDischarge)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.StateAtDischarge).Build()).Build());
            }

            if (model.Laparoscopic != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Laparoscopic)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.Laparoscopic).Build()).Build());
            }

            if (model.PathologicFinding != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PathologicFinding)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.PathologicFinding).Build()).Build());
            }

            if (model.EndCourse != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.EndCourse)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue((int)model.EndCourse).Build()).Build());
            }

            return entryBuilder.Build();
        }

        private Entry CreateClinicUsedDrugEntry(ClinicUsedDrugViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder =  EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DrugDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.DrugDate).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DrugCode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.DrugCode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DrugName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.DrugName).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DrugQuantity)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.DrugQuantity).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DrugCost)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.DrugCost).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ICDDrug)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ICDDrug).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.UINPrescr)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.UINPrescr).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.NoPrescr)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.NoPrescr).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.DatePrescr)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.DatePrescr).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.PracticeCodeProtocol)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.PracticeCodeProtocol).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProtocolNumber)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.ProtocolNumber).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProtocolDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.ProtocolDate).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProtocolType)).Build())
                        .AddValue(EhrManager.INTBuilder.Clear().AddValue(model.ProtocolType).Build()).Build()
                );

            if (model.VersionCode != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ClusterBuilder
                        .Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.VersionCode)).Build())
                        .AddParts(
                            EhrManager.ElementBuilder.Clear()
                                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.VersionCode.BatchNumber)).Build())
                                .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.VersionCode.BatchNumber).Build()).Build(),
                            EhrManager.ElementBuilder.Clear()
                                .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.VersionCode.QuantityPack)).Build())
                                .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.VersionCode.QuantityPack).Build()).Build()
                        ).Build()

                    );
            }

            return entryBuilder.Build();
        }

        private Entry CreateClinicProcedureEntry(ClinicProcedureViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return EhrManager.EntryBuilder
                .Clear()
                .AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProcedureName)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ProcedureName).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProcedureCode)).Build())
                        .AddValue(EhrManager.REALBuilder.Clear().AddValue((double)model.ProcedureCode).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProcedureDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate(model.ProcedureDate).Build()).Build(),
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ACHIcode)).Build())
                        .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.ACHIcode).Build()).Build()
                ).Build();
        }

        private Entry CreateDoneProcedureEntry(DoneProcedureViewModel model)
        {
            if (model == default)
            {
                throw new ArgumentNullException(nameof(model));
            }

            IEntryBuilder entryBuilder = EhrManager.EntryBuilder.Clear();

            if (model.ProcedureStartDate != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProcedureStartDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.ProcedureStartDate).Build()).Build());
            }

            if (model.ProcedureEndDate != default)
            {
                entryBuilder.AddItems(
                    EhrManager.ElementBuilder.Clear()
                        .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.ProcedureEndDate)).Build())
                        .AddValue(EhrManager.DATEBuilder.Clear().AddDate((DateTime)model.ProcedureEndDate).Build()).Build());
            }

            if (model.Doctor != default)
            {
                IClusterBuilder clusterBuilder = EhrManager.ClusterBuilder.Clear()
                    .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Doctor)).Build());

                if (!string.IsNullOrWhiteSpace(model.Doctor.UniqueIdentifier))
                {
                    clusterBuilder.AddParts(
                        EhrManager.ElementBuilder
                            .Clear()
                            .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Doctor.UniqueIdentifier)).Build())
                            .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Doctor.UniqueIdentifier).Build())
                            .Build());
                }

                if (!string.IsNullOrWhiteSpace(model.Doctor.DeputyUniqueIdentifier))
                {
                    clusterBuilder.AddParts(
                        EhrManager.ElementBuilder
                            .Clear()
                            .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Doctor.DeputyUniqueIdentifier)).Build())
                            .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Doctor.DeputyUniqueIdentifier).Build())
                            .Build());
                }

                if (!string.IsNullOrWhiteSpace(model.Doctor.Speciality))
                {
                    clusterBuilder.AddParts(
                        EhrManager.ElementBuilder
                            .Clear()
                            .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Doctor.Speciality)).Build())
                            .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Doctor.Speciality).Build())
                            .Build());
                }

                if (!string.IsNullOrWhiteSpace(model.Doctor.Name))
                {
                    clusterBuilder.AddParts(
                        EhrManager.ElementBuilder
                            .Clear()
                            .AddName(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(nameof(model.Doctor.Name)).Build())
                            .AddValue(EhrManager.SimpleTextBuilder.Clear().AddOriginalText(model.Doctor.Name).Build())
                            .Build());
                }

                entryBuilder.AddItems(clusterBuilder.Build());
            }

            return entryBuilder.Build();
        }
    }
}
