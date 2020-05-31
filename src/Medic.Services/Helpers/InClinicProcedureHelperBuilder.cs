using Medic.AppModels.Enums;
using Medic.AppModels.InClinicProcedures;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class InClinicProcedureHelperBuilder : IHelperBuilder<InClinicProcedure>
    {
        private readonly InClinicProcedureSearch InClinicProcedureSearch;

        public InClinicProcedureHelperBuilder(InClinicProcedureSearch inClinicProcedureSearch)
        {
            InClinicProcedureSearch = inClinicProcedureSearch;
        }

        public IQueryable<InClinicProcedure> BuildQuery(IQueryable<InClinicProcedure> query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (InClinicProcedureSearch == default)
            {
                return query;
            }

            switch (InClinicProcedureSearch.Order)
            {
                case InClinicProcedureOrderEnum.FirstMainDiagCode:
                    query = InClinicProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(icp => icp.FirstMainDiag.MKBCode) : query.OrderByDescending(icp => icp.FirstMainDiag.MKBCode);
                    break;
                case InClinicProcedureOrderEnum.SecondMainDiagCode:
                    query = InClinicProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(icp => icp.SecondMainDiag.MKBCode) : query.OrderByDescending(icp => icp.SecondMainDiag.MKBCode);
                    break;
                case InClinicProcedureOrderEnum.DateSend:
                    query = InClinicProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(icp => icp.DateSend) : query.OrderByDescending(icp => icp.DateSend);
                    break;
                default:
                    query = InClinicProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(icp => icp.Id) : query.OrderByDescending(icp => icp.Id);
                    break;
            }

            query = query.Take((int)InClinicProcedureSearch.Length);

            return query;
        }
    }
}
