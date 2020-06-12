using Medic.AppModels.Enums;
using Medic.AppModels.PathProcedures;
using Medic.Entities;
using Medic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medic.Services.Helpers
{
    public class PathProcedureHelperBuilder : IHelperBuilder<PathProcedure>
    {
        private readonly PathProcedureSearch PathProcedureSearch;

        public PathProcedureHelperBuilder(PathProcedureSearch pathProcedureSearch)
        {
            PathProcedureSearch = pathProcedureSearch;
        }

        public IQueryable<PathProcedure> BuildQuery(IQueryable<PathProcedure> query)
        {
            if (query == default)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (PathProcedureSearch == default)
            {
                return query;
            }

            switch (PathProcedureSearch.Order)
            {
                case PathProcedureOrderEnum.FirstMainDiagCode:
                    query = PathProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pp => pp.FirstMainDiag.MKBCode) : query.OrderByDescending(pp => pp.FirstMainDiag.MKBCode);
                    break;
                case PathProcedureOrderEnum.SecondMainDiagCode:
                    query = PathProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pp => pp.SecondMainDiag.MKBCode) : query.OrderByDescending(pp => pp.SecondMainDiag.MKBCode);
                    break;
                case PathProcedureOrderEnum.DateSend:
                    query = PathProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pp => pp.DateSend) : query.OrderByDescending(pp => pp.DateSend);
                    break;
                default:
                    query = PathProcedureSearch.Direction == OrderDirectionEnum.Asc ?
                        query.OrderBy(pp => pp.Id) : query.OrderByDescending(pp => pp.Id);
                    break;
            }

            query = query.Take((int)PathProcedureSearch.Length);

            return query;
        }
    }
}
