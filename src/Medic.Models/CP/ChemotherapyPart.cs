﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace Medic.Models.CP
{
    public class ChemotherapyPart
    {
        private const string DateFormat = "yyyy-MM-dd";

        private DateTime _diagnoseDate;

        [XmlIgnore]
        public DateTime DiagnoseDate
        {
            get { return _diagnoseDate; }
            set { _diagnoseDate = value; }
        }

        [XmlElement(ElementName = "date_Diag")]
        public string DiagnoseDateAsString
        {
            get
            {
                return _diagnoseDate == default ? default : _diagnoseDate.ToString(DateFormat);
            }

            set
            {
                _diagnoseDate = DateTime.ParseExact(value, DateFormat, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "Expand_Diag")]
        public string ExpandDiagnose { get; set; }

        [XmlElement(ElementName = "AddDiag")]
        public List<AddDiag> AddDiags { get; set; }

        [XmlElement(ElementName = "Histology")]
        public Histology Histology { get; set; }

        [XmlElement(ElementName = "ECOG")]
        public int ECOG { get; set; }

        [XmlElement(ElementName = "Staging")]
        public string Staging { get; set; }

        [XmlElement(ElementName = "Staging_No")]
        public int? StagingNumber { get; set; }

        [XmlElement(ElementName = "TNM")]
        public string TNM { get; set; }

        [XmlElement(ElementName = "TargetAUC")]
        public decimal? TargetAUC { get; set; }

        [XmlElement(ElementName = "Gen_Markers")]
        public List<GenMarker> GenMarkers { get; set; }

        [XmlElement(ElementName = "Type_Therapy")]
        public int TherapyType { get; set; }

        [XmlElement(ElementName = "Eval_after_Cycle")]
        public int EvalAfterCycle { get; set; }

        [XmlElement(ElementName = "Interval")]
        public int Interval { get; set; }

        [XmlElement(ElementName = "Evaluation")]
        public Evaluation Evaluation { get; set; }

        [XmlElement(ElementName = "Status")]
        public int? Status { get; set; }
    }
}