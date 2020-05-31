using Medic.AppModels.Enums;
using Medic.AppModels.ProtocolDrugTherapies;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medic.Services.Helpers
{
    public class ProtocolDrugTherapyHelperBuilder : IHelperBuilder<ProtocolDrugTherapy>
    {
        private readonly ProtocolDrugTherapySearch ProtocolDrugTherapySearch;

        public ProtocolDrugTherapyHelperBuilder(ProtocolDrugTherapySearch protocolDrugTherapySearch)
        {
            ProtocolDrugTherapySearch = protocolDrugTherapySearch;
        }

        public IQueryable<ProtocolDrugTherapy> BuildQuery(IQueryable<ProtocolDrugTherapy> query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (ProtocolDrugTherapySearch == default)
            {
                return query;
            }

            switch (ProtocolDrugTherapySearch.Order)
            {
                case ProtocolDrugTherapyOrderEnum.DecisionDate:
                    query = ProtocolDrugTherapySearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pdt => pdt.DecisionDate) : query.OrderByDescending(pdt => pdt.DecisionDate);
                    break;
                case ProtocolDrugTherapyOrderEnum.DiagnoseCode:
                    query = ProtocolDrugTherapySearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pdt => pdt.Diag.MKBCode) : query.OrderByDescending(pdt => pdt.Diag.MKBCode);
                    break;
                case ProtocolDrugTherapyOrderEnum.ProtocolDate:
                    query = ProtocolDrugTherapySearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pdt => pdt.ProtocolDate) : query.OrderByDescending(pdt => pdt.ProtocolDate);
                    break;
                default:
                    query = ProtocolDrugTherapySearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pdt => pdt.Id) : query.OrderByDescending(pdt => pdt.Id);
                    break;
            }

            query = query.Take((int)ProtocolDrugTherapySearch.Length);

            return query;
        }
    }
}
