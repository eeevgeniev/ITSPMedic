﻿using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Out
    /// </summary>
    [Serializable]
    public partial class Out : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public Patient Patient { get; set; }

        public int? PatientBranchId { get; set; }

        public PatientBranch PatientBranch { get; set; }

        public int? PatientHRegionId { get; set; }

        public HealthRegion PatientHRegion { get; set; }

        public int InType { get; set; }

        public int? SenderId { get; set; }

        public HealthcarePractitioner Sender { get; set; }

        public DateTime SendDate { get; set; }

        public ICollection<Diagnose> SendDiagnoses { get; set; } = new HashSet<Diagnose>();

        public int SendUrgency { get; set; }

        public int? SendPackageType { get; set; }

        public string SendClinicalPath { get; set; }

        public string SendAPr { get; set; }

        public string UniqueIdentifier { get; set; }

        public DateTime ExaminationDate { get; set; }

        public DateTime? PlannedEntryDate { get; set; }

        public int? PlannedNumber { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; } = new HashSet<Diagnose>();

        public int Urgency { get; set; }

        public int? PackageType { get; set; }

        public string ClinicalPath { get; set; }

        public string InAPr { get; set; }

        public int NZOKPay { get; set; }

        public string InMedicalWard { get; set; }

        public DateTime EntryDate { get; set; }

        public int? Severity { get; set; }

        public int? Delay { get; set; }

        public int Payer { get; set; }

        public int? AgeInDays { get; set; }

        public int? WeightInGrams { get; set; }

        public int? BirthWeight { get; set; }

        public int? MotherIZYear { get; set; }

        public int? MotherIZNo { get; set; }

        public int? IZYear { get; set; }

        public int? IZNo { get; set; }

        public string OutMedicalWard { get; set; }

        public string OutUniqueIdentifier { get; set; }

        public DateTime OutDate { get; set; }

        public int OutType { get; set; }

        public int? DeadId { get; set; }

        public Diagnose Dead { get; set; }

        public string BirthPractice { get; set; }

        public int? BirthNumber { get; set; }

        public int? BirthGestWeek { get; set; }

        public int? ResignId { get; set; }

        public Resign Resign { get; set; }

        public int? RedirectedId { get; set; }

        public Redirected Redirected { get; set; }

        public string OutClinicalPath { get; set; }

        public string OutAPr { get; set; }

        public int? HistologicalResultId { get; set; }

        public HistologicalResult HistologicalResult { get; set; }

        public int EpicrisisId { get; set; }

        public Epicrisis Epicrisis { get; set; }

        public string IZinDetail { get; set; }

        public int? OutMainDiagnoseId { get; set; }

        public Diagnose OutMainDiagnose { get; set; }

        public ICollection<Diagnose> OutDiagnoses { get; set; } = new HashSet<Diagnose>();

        public string LinkMedia { get; set; }

        public ICollection<UsedDrug> UsedDrugs { get; set; } = new HashSet<UsedDrug>();

        public ICollection<Procedure> Procedures { get; set; } = new HashSet<Procedure>();

        public int? BedDays { get; set; }

        public DateTime? HLDateFrom { get; set; }

        public string HLNumber { get; set; }

        public int? HLTotalDays { get; set; }

        public int? StateAtDischarge { get; set; }

        public int? Laparoscopic { get; set; }

        public int? PathologicFinding { get; set; }

        public int? EndCourse { get; set; }

        public int? CPFileId { get; set; }

        public CPFile CPFile { get; set; }
    }
}