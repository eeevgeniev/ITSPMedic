using Medic.AppModels.DispObservations;
using Medic.AppModels.Enums;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Linq;

namespace Medic.Services.Helpers
{
    public class DispObservationHelperBuilder : IHelperBuilder<DispObservation>
    {
        private readonly DispObservationSearch DispObservationSearch;

        public DispObservationHelperBuilder(DispObservationSearch dispObservationSearch)
        {
            DispObservationSearch = dispObservationSearch;
        }

        public IQueryable<DispObservation> BuildQuery(IQueryable<DispObservation> query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (DispObservationSearch == default)
            {
                return query;
            }

            switch (DispObservationSearch.Order)
            {
                case DispObservationOrderEnum.FirstMainDiagCode:
                    query = DispObservationSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(disp => disp.FirstMainDiag.MKBCode) : query.OrderByDescending(disp => disp.FirstMainDiag.MKBCode);
                    break;
                case DispObservationOrderEnum.SecondMainDiagCode:
                    query = DispObservationSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(disp => disp.SecondMainDiag.MKBCode) : query.OrderByDescending(disp => disp.SecondMainDiag.MKBCode);
                    break;
                case DispObservationOrderEnum.DispDate:
                    query = DispObservationSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(disp => disp.DispDate) : query.OrderByDescending(disp => disp.DispDate);
                    break;
                default:
                    query = DispObservationSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(disp => disp.Id) : query.OrderByDescending(disp => disp.Id);
                    break;
            }

            query = query.Take((int)DispObservationSearch.Length);

            return query;
        }
    }
}
