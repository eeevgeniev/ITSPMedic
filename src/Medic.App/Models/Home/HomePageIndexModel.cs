using Medic.App.Models.Bases;
using Medic.AppModels.CPFiles;
using Medic.AppModels.HospitalPractices;
using System.Collections.Generic;
using System.Linq;

namespace Medic.App.Models.Home
{
    public class HomePageModel : BasePageModel
    {
        public List<CPFileSummaryViewModel> CPFileSummaryViewModels { get; set; }

        public List<HospitalPracticeSummaryViewModel> HospitalPracticeSummaryViewModels { get; set; }

        public int PatientCount { get; set; }

        public int PlanningsCount()
        {
            return CPFileSummaryViewModels.Sum(cp => cp.PlanningsCount);
        }

        public int InsCount()
        {
            return CPFileSummaryViewModels.Sum(cp => cp.InsCount);
        }

        public int OutsCount()
        {
            return CPFileSummaryViewModels.Sum(cp => cp.OutsCount);
        }

        public int ProtocolDrugTherapiesCPCount()
        {
            return CPFileSummaryViewModels.Sum(cp => cp.ProtocolDrugTherapiesCount);
        }

        public int PatientTransfersCPCount()
        {
            return CPFileSummaryViewModels.Sum(cp => cp.PatientTransfersCount);
        }

        public int InClinicProceduresCount()
        {
            return HospitalPracticeSummaryViewModels.Sum(hp => hp.InClinicProceduresCount);
        }

        public int PathProceduresCount()
        {
            return HospitalPracticeSummaryViewModels.Sum(hp => hp.PathProceduresCount);
        }

        public int DispObservationsCount()
        {
            return HospitalPracticeSummaryViewModels.Sum(hp => hp.DispObservationsCount);
        }

        public int CommissionAprsCount()
        {
            return HospitalPracticeSummaryViewModels.Sum(hp => hp.CommissionAprsCount);
        }

        public int ProtocolDrugTherapiesHPCount()
        {
            return HospitalPracticeSummaryViewModels.Sum(hp => hp.ProtocolDrugTherapiesCount);
        }

        public int PatientTransfersHPCount()
        {
            return HospitalPracticeSummaryViewModels.Sum(hp => hp.PatientTransfersCount);
        }
    }
}
