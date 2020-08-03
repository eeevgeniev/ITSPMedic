﻿using Medic.Resources.Bases;
using Medic.Resources.Contracts;
using Microsoft.Extensions.Localization;

namespace Medic.Resources
{
    public class MedicDataLocalization : BaseLocalization, ILocalizationService
    {
        public const string AccompanyingDrugs = nameof(AccompanyingDrugs);
        public const string ACHICode = nameof(ACHICode);
        public const string AddDiag = nameof(AddDiag);
        public const string AddDiagCodes = nameof(AddDiagCodes);
        public const string AdditionalDiagnoses = nameof(AdditionalDiagnoses);
        public const string AdditionalInformation = nameof(AdditionalInformation);
        public const string Address = nameof(Address);
        public const string AgeInDays = nameof(AgeInDays);
        public const string AllDoneProcedures = nameof(AllDoneProcedures);
        public const string AllDose = nameof(AllDose);
        public const string AllDrugCost = nameof(AllDrugCost);
        public const string Anamnesa = nameof(Anamnesa);
        public const string ApplicationWay = nameof(ApplicationWay);
        public const string APr05 = nameof(APr05);
        public const string APr05sImuno = nameof(APr05sImuno);
        public const string APr38 = nameof(APr38);
        public const string APr38s = nameof(APr38s);
        public const string AprCode = nameof(AprCode);
        public const string APrPriem = nameof(APrPriem);
        public const string APrSend = nameof(APrSend);
        public const string Asc = nameof(Asc);
        public const string ATCCode = nameof(ATCCode);
        public const string ATCName = nameof(ATCName);
        public const string AverageQuantity = nameof(AverageQuantity);
        public const string BatchNumber = nameof(BatchNumber);
        public const string BedDays = nameof(BedDays);
        public const string BirthDate = nameof(BirthDate);
        public const string BirthGestWeek = nameof(BirthGestWeek);
        public const string BirthNumber = nameof(BirthNumber);
        public const string BirthPractice = nameof(BirthPractice);
        public const string BirthWeight = nameof(BirthWeight);
        public const string Branch = nameof(Branch);
        public const string BSA = nameof(BSA);
        public const string CeasedClinicalPath = nameof(CeasedClinicalPath);
        public const string CeasedOnly = nameof(CeasedOnly);
        public const string CeasedProcedure = nameof(CeasedProcedure);
        public const string Chairman = nameof(Chairman);
        public const string Checked = nameof(Checked);
        public const string CheckupAfterDischarge = nameof(CheckupAfterDischarge);
        public const string ChemotherapyPart = nameof(ChemotherapyPart);
        public const string ClinicalExaminations = nameof(ClinicalExaminations);
        public const string ClinicalPath = nameof(ClinicalPath);
        public const string ClinicProcedures = nameof(ClinicProcedures);
        public const string Code = nameof(Code);
        public const string CodeHS = nameof(CodeHS);
        public const string CommissionApr = nameof(CommissionApr);
        public const string CommissionAprs = nameof(CommissionAprs);
        public const string CommissionAprsSummary = nameof(CommissionAprsSummary);
        public const string CommissionAprSummary = nameof(CommissionAprSummary);
        public const string CommissionAprsView = nameof(CommissionAprsView);
        public const string CommissionAprView = nameof(CommissionAprView);
        public const string Complications = nameof(Complications);
        public const string Consultations = nameof(Consultations);
        public const string Cost = nameof(Cost);
        public const string Count = nameof(Count);
        public const string CPFile = nameof(CPFile);
        public const string CPFilesSummary = nameof(CPFilesSummary);
        public const string CPFileSummary = nameof(CPFileSummary);
        public const string CPrPriem = nameof(CPrPriem);
        public const string CPrSend = nameof(CPrSend);
        public const string CycleCount = nameof(CycleCount);
        public const string CycleDose = nameof(CycleDose);
        public const string Date = nameof(Date);
        public const string DateOfSurgery = nameof(DateOfSurgery);
        public const string DatePlanPriem = nameof(DatePlanPriem);
        public const string DatePrescr = nameof(DatePrescr);
        public const string DateProcedureBegins = nameof(DateProcedureBegins);
        public const string DateProcedureEnd = nameof(DateProcedureEnd);
        public const string DateSend = nameof(DateSend);
        public const string Days = nameof(Days);
        public const string Dead = nameof(Dead);
        public const string DecisionDate = nameof(DecisionDate);
        public const string Default = nameof(Default);
        public const string Delay = nameof(Delay);
        public const string DeputyUniqueIdentifier = nameof(DeputyUniqueIdentifier);
        public const string Desc = nameof(Desc);
        public const string Diag = nameof(Diag);
        public const string DiagCode = nameof(DiagCode);
        public const string DiagDate = nameof(DiagDate);
        public const string Diagnose = nameof(Diagnose);
        public const string DiagnoseCode = nameof(DiagnoseCode);
        public const string DiagnoseName = nameof(DiagnoseName);
        public const string DiagnoseDate = nameof(DiagnoseDate);
        public const string Diagnoses = nameof(Diagnoses);
        public const string DiagnoseSummaryTitle = nameof(DiagnoseSummaryTitle);
        public const string Diags = nameof(Diags);
        public const string DiagSummaryTitle = nameof(DiagSummaryTitle);
        public const string Direction = nameof(Direction);
        public const string DischargeStatus = nameof(DischargeStatus);
        public const string DiseaseCourse = nameof(DiseaseCourse);
        public const string DispanserDate = nameof(DispanserDate);
        public const string DispDate = nameof(DispDate);
        public const string DispNum = nameof(DispNum);
        public const string DispObservation = nameof(DispObservation);
        public const string DispObservations = nameof(DispObservations);
        public const string DispObservationsSummary = nameof(DispObservationsSummary);
        public const string DispObservationSummary = nameof(DispObservationSummary);
        public const string DispObservationsView = nameof(DispObservationsView);
        public const string DispObservationView = nameof(DispObservationView);
        public const string DispVisit = nameof(DispVisit);
        public const string Doctor = nameof(Doctor);
        public const string DoneNewProcedures = nameof(DoneNewProcedures);
        public const string DoneProcedures = nameof(DoneProcedures);
        public const string DrugName = nameof(DrugName);
        public const string DrugCode = nameof(DrugCode);
        public const string DrugCost = nameof(DrugCost);
        public const string DrugDate = nameof(DrugDate);
        public const string DrugProtocols = nameof(DrugProtocols);
        public const string DrugProtocolsATCNames = nameof(DrugProtocolsATCNames);
        public const string DrugQuantity = nameof(DrugQuantity);
        public const string ECOG = nameof(ECOG);
        public const string EndCourse = nameof(EndCourse);
        public const string EntryDate = nameof(EntryDate);
        public const string Epicrisis = nameof(Epicrisis);
        public const string EvalAfterCycle = nameof(EvalAfterCycle);
        public const string Evaluation = nameof(Evaluation);
        public const string ExaminationDate = nameof(ExaminationDate);
        public const string ExpandDiagnose = nameof(ExpandDiagnose);
        public const string FairCondition = nameof(FairCondition);
        public const string FirstMainDiag = nameof(FirstMainDiag);
        public const string FirstMainDiagCode = nameof(FirstMainDiagCode);
        public const string FirstMainDiagName = nameof(FirstMainDiagName);
        public const string FirstVisitDate = nameof(FirstVisitDate);
        public const string Genetic = nameof(Genetic);
        public const string GenMarkers = nameof(GenMarkers);
        public const string GPRecommendations = nameof(GPRecommendations);
        public const string HealthRegion = nameof(HealthRegion);
        public const string Height = nameof(Height);
        public const string HematologyPart = nameof(HematologyPart);
        public const string HistologicalResult = nameof(HistologicalResult);
        public const string Histology = nameof(Histology);
        public const string History = nameof(History);
        public const string HLDateFrom = nameof(HLDateFrom);
        public const string HLNumber = nameof(HLNumber);
        public const string HLTotalDays = nameof(HLTotalDays);
        public const string HospitalPracticeFile = nameof(HospitalPracticeFile);
        public const string HospitalPracticeFileSummary = nameof(HospitalPracticeFileSummary);
        public const string HospitalPracticesSummary = nameof(HospitalPracticesSummary);
        public const string HState = nameof(HState);
        public const string ICDDrug = nameof(ICDDrug);
        public const string IdentityNumber = nameof(IdentityNumber);
        public const string ImplantCode = nameof(ImplantCode);
        public const string ImplantManufacturer = nameof(ImplantManufacturer);
        public const string ImplantReferenceNumber = nameof(ImplantReferenceNumber);
        public const string Imuno = nameof(Imuno);
        public const string InApr = nameof(InApr);
        public const string InClinicProcedure = nameof(InClinicProcedure);
        public const string InClinicProcedures = nameof(InClinicProcedures);
        public const string InClinicProceduresSummary = nameof(InClinicProceduresSummary);
        public const string InClinicProcedureSummary = nameof(InClinicProcedureSummary);
        public const string InClinicProceduresView = nameof(InClinicProceduresView);
        public const string IndividualDose = nameof(IndividualDose);
        public const string Information = nameof(Information);
        public const string InMedicalWard = nameof(InMedicalWard);
        public const string Ins = nameof(Ins);
        public const string InsSummary = nameof(InsSummary);
        public const string InSummary = nameof(InSummary);
        public const string InsView = nameof(InsView);
        public const string Interval = nameof(Interval);
        public const string InType = nameof(InType);
        public const string InvalidFile = nameof(InvalidFile);
        public const string InvalidId = nameof(InvalidId);
        public const string InView = nameof(InView);
        public const string IZMedicalWard = nameof(IZMedicalWard);
        public const string IZNo = nameof(IZNo);
        public const string IZNumChild = nameof(IZNumChild);
        public const string IZYear = nameof(IZYear);
        public const string IZYearChild = nameof(IZYearChild);
        public const string IZYearMedicalWard = nameof(IZYearMedicalWard);
        public const string Laparoscopic = nameof(Laparoscopic);
        public const string LargeLength = nameof(LargeLength);
        public const string Length = nameof(Length);
        public const string MainDiag = nameof(MainDiag);
        public const string MainDiagCode = nameof(MainDiagCode);
        public const string MainDiagName = nameof(MainDiagName);
        public const string MDICode = nameof(MDICode);
        public const string MDIName = nameof(MDIName);
        public const string MDIs = nameof(MDIs);
        public const string MedicalWard = nameof(MedicalWard);
        public const string MKBCode = nameof(MKBCode);
        public const string MKBName = nameof(MKBName);
        public const string MonthSummaries = nameof(MonthSummaries);
        public const string MotherIZNo = nameof(MotherIZNo);
        public const string MotherIZYear = nameof(MotherIZYear);
        public const string Name = nameof(Name);
        public const string NameHS = nameof(NameHS);
        public const string NoDecision = nameof(NoDecision);
        public const string NoPrescr = nameof(NoPrescr);
        public const string NoResults = nameof(NoResults);
        public const string NormalLength = nameof(NormalLength);
        public const string NoSelection = nameof(NoSelection);
        public const string Notes = nameof(Notes);
        public const string Number = nameof(Number);
        public const string NumberOfDecision = nameof(NumberOfDecision);
        public const string NumberOfProtocol = nameof(NumberOfProtocol);
        public const string NZOKPay = nameof(NZOKPay);
        public const string Order = nameof(Order);
        public const string OtherDocuments = nameof(OtherDocuments);
        public const string OutAPr = nameof(OutAPr);
        public const string OutClinicalPath = nameof(OutClinicalPath);
        public const string OutDate = nameof(OutDate);
        public const string OutDiagnoseCode = nameof(OutDiagnoseCode);
        public const string OutDiagnoseName = nameof(OutDiagnoseName);
        public const string OutDiagnoses = nameof(OutDiagnoses);
        public const string OutHospital = nameof(OutHospital);
        public const string OutMainDiagnose = nameof(OutMainDiagnose);
        public const string OutMainDiagnoseCode = nameof(OutMainDiagnoseCode);
        public const string OutMedicalWard = nameof(OutMedicalWard);
        public const string Outs = nameof(Outs);
        public const string OutsSummary = nameof(OutsSummary);
        public const string OutSummary = nameof(OutSummary);
        public const string OutsView = nameof(OutsView);
        public const string OutType = nameof(OutType);
        public const string OutUniqueIdentifier = nameof(OutUniqueIdentifier);
        public const string OutView = nameof(OutView);
        public const string PathologicFinding = nameof(PathologicFinding);
        public const string PathProcedure = nameof(PathProcedure);
        public const string PathProcedures = nameof(PathProcedures);
        public const string PathProceduresSummary = nameof(PathProceduresSummary);
        public const string PathProcedureSummary = nameof(PathProcedureSummary);
        public const string PathProceduresView = nameof(PathProceduresView);
        public const string Patient = nameof(Patient);
        public const string PatientBranch = nameof(PatientBranch);
        public const string PatientHRegion = nameof(PatientHRegion);
        public const string Patients = nameof(Patients);
        public const string PatientsSummary = nameof(PatientsSummary);
        public const string PatientStatus = nameof(PatientStatus);
        public const string PatientTransfers = nameof(PatientTransfers);
        public const string Payer = nameof(Payer);
        public const string Planned = nameof(Planned);
        public const string PlannedEntryDate = nameof(PlannedEntryDate);
        public const string PlannedNumber = nameof(PlannedNumber);
        public const string PlannedSummary = nameof(PlannedSummary);
        public const string PlannedView = nameof(PlannedView);
        public const string Plannings = nameof(Plannings);
        public const string PlanningsSummary = nameof(PlanningsSummary);
        public const string PlanningsView = nameof(PlanningsView);
        public const string PlanVisitDate = nameof(PlanVisitDate);
        public const string PostoperativeStatus = nameof(PostoperativeStatus);
        public const string Practice = nameof(Practice);
        public const string PracticeCodeProtocol = nameof(PracticeCodeProtocol);
        public const string ProcedureCode = nameof(ProcedureCode);
        public const string ProcedureDate = nameof(ProcedureDate);
        public const string ProcedureEndDate = nameof(ProcedureEndDate);
        public const string ProcedureName = nameof(ProcedureName);
        public const string Procedures = nameof(Procedures);
        public const string ProcedureStartDate = nameof(ProcedureStartDate);
        public const string ProcRefuse = nameof(ProcRefuse);
        public const string ProtocolType = nameof(ProtocolType);
        public const string ProtocolDate = nameof(ProtocolDate);
        public const string ProtocolDrugTherapies = nameof(ProtocolDrugTherapies);
        public const string ProtocolDrugTherapiesSummary = nameof(ProtocolDrugTherapiesSummary);
        public const string ProtocolDrugTherapiesView = nameof(ProtocolDrugTherapiesView);
        public const string ProtocolDrugTherapyView = nameof(ProtocolDrugTherapyView);
        public const string ProtocolDrugTherapyViewSummary = nameof(ProtocolDrugTherapyViewSummary);
        public const string ProtocolNumber = nameof(ProtocolNumber);
        public const string Quantity = nameof(Quantity);
        public const string QuantityPack = nameof(QuantityPack);
        public const string Recommendations = nameof(Recommendations);
        public const string Regimen = nameof(Regimen);
        public const string Results = nameof(Results);
        public const string SampleProtocol = nameof(SampleProtocol);
        public const string Scheme = nameof(Scheme);
        public const string SecondMainDiag = nameof(SecondMainDiag);
        public const string SecondMainDiagCode = nameof(SecondMainDiagCode);
        public const string SecondMainDiagName = nameof(SecondMainDiagName);
        public const string SendApr = nameof(SendApr);
        public const string SendClinicalPath = nameof(SendClinicalPath);
        public const string SendDate = nameof(SendDate);
        public const string SendDiagnose = nameof(SendDiagnose);
        public const string SendDiagnoseCode = nameof(SendDiagnoseCode);
        public const string SendDiagnoseName = nameof(SendDiagnoseName);
        public const string SendDiagnoses = nameof(SendDiagnoses);
        public const string SendDignoseCode = nameof(SendDignoseCode);
        public const string Sender = nameof(Sender);
        public const string SendUrgency = nameof(SendUrgency);
        public const string Severity = nameof(Severity);
        public const string Sign = nameof(Sign);
        public const string SingleDose = nameof(SingleDose);
        public const string SmallLength = nameof(SmallLength);
        public const string SpecCommission = nameof(SpecCommission);
        public const string Speciality = nameof(Speciality);
        public const string Staging = nameof(Staging);
        public const string StandartDose = nameof(StandartDose);
        public const string StateAtDischarge = nameof(StateAtDischarge);
        public const string Summary = nameof(Summary);
        public const string SummaryInformation = nameof(SummaryInformation);
        public const string SummaryInformationKeywords = nameof(SummaryInformationKeywords);
        public const string Text = nameof(Text);
        public const string Therapy = nameof(Therapy);
        public const string TherapyLine = nameof(TherapyLine);
        public const string TherapyType = nameof(TherapyType);
        public const string TNM = nameof(TNM);
        public const string TotalCosts = nameof(TotalCosts);
        public const string TotalCount = nameof(TotalCount);
        public const string TotalPatients = nameof(TotalPatients);
        public const string TotalUses = nameof(TotalUses);
        public const string TypeProcPriem = nameof(TypeProcPriem);
        public const string TypeProcSend = nameof(TypeProcSend);
        public const string UINPrescr = nameof(UINPrescr);
        public const string UniqueIdentifier = nameof(UniqueIdentifier);
        public const string Update = nameof(Update);
        public const string UploadFiles = nameof(UploadFiles);
        public const string Urgency = nameof(Urgency);
        public const string UsedDrug = nameof(UsedDrug);
        public const string UsedDrugCode = nameof(UsedDrugCode);
        public const string UsedDrugCodes = nameof(UsedDrugCodes);
        public const string UsedDrugs = nameof(UsedDrugs);
        public const string UsedDrugsInformationKeywords = nameof(UsedDrugsInformationKeywords);
        public const string VersionCode = nameof(VersionCode);
        public const string View = nameof(View);
        public const string ViewCommissionApr = nameof(ViewCommissionApr);
        public const string ViewDispObservation = nameof(ViewDispObservation);
        public const string ViewIn = nameof(ViewIn);
        public const string ViewInClinicProcedure = nameof(ViewInClinicProcedure);
        public const string ViewOut = nameof(ViewOut);
        public const string ViewPathProcedure = nameof(ViewPathProcedure);
        public const string ViewPatient = nameof(ViewPatient);
        public const string ViewPlannedProcedure = nameof(ViewPlannedProcedure);
        public const string ViewProtocolDrugTherapy = nameof(ViewProtocolDrugTherapy);
        public const string VisitDocumentName = nameof(VisitDocumentName);
        public const string VisitDocumentUniqueIdentifier = nameof(VisitDocumentUniqueIdentifier);
        public const string Weight = nameof(Weight);
        public const string WeightInGrams = nameof(WeightInGrams);
        public const string ExportAsXml = nameof(ExportAsXml);
        public const string ExportAsJson = nameof(ExportAsJson);
        public const string ExportAsExcel = nameof(ExportAsExcel);

        public MedicDataLocalization(IStringLocalizerFactory factory)
            : base(factory, nameof(MedicDataLocalization)) { }

        public override string Get(string name)
        {
            return StringLocalizer[name];
        }
    }
}
