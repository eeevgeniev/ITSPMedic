using AutoMapper;
using AutoMapper.QueryableExtensions;
using Medic.Contexts.Contracts;
using Medic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Medic.Services.Base
{
    public abstract class BaseServiceHelper
    {
        private readonly IMedicContext _medicContext;
        private readonly MapperConfiguration _configuration;

        public BaseServiceHelper(IMedicContext medicContext, MapperConfiguration configuration)
        {
            _medicContext = medicContext ?? throw new ArgumentNullException(nameof(medicContext));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected IMedicContext MedicContext => _medicContext;

        protected MapperConfiguration Configuration => _configuration;

        protected virtual T GetPatient<T>(Expression<Func<Patient, bool>> predicate) =>
            MedicContext.Patients
                .Where(predicate)
                .ProjectTo<T>(Configuration)
                .SingleOrDefault();

        protected virtual T GetHealthcarePractitioner<T>(Expression<Func<HealthcarePractitioner, bool>> predicate) =>
            MedicContext.HealthcarePractitioners
                .Where(predicate)
                .ProjectTo<T>(Configuration)
                .SingleOrDefault();

        protected virtual T GetDiag<T>(Expression<Func<Diag, bool>> predicate) =>
            GetDiagsHelper<T>(predicate).SingleOrDefault();

        protected virtual List<T> GetDiags<T>(Expression<Func<Diag, bool>> predicate) =>
            GetDiagsHelper<T>(predicate).ToList();

        protected virtual T GetCeasedClinical<T>(Expression<Func<CeasedClinical, bool>> predicate) =>
            MedicContext.CeasedClinicals
                .Where(predicate)
                .ProjectTo<T>(Configuration)
                .SingleOrDefault();

        protected virtual T GetDiagnose<T>(Expression<Func<Diagnose, bool>> predicate) => 
            GetDiagnoseHelper<T>(predicate).SingleOrDefault();

        protected virtual List<T> GetDiagnoses<T>(Expression<Func<Diagnose, bool>> predicate) => 
            GetDiagnoseHelper<T>(predicate).ToList();

        protected virtual List<T> GetProcedures<T>(Expression<Func<Procedure, bool>> predicate) =>
            MedicContext.Procedures
                .Where(predicate)
                .ProjectTo<T>(Configuration)
                .ToList();

        private IQueryable<T> GetDiagsHelper<T>(Expression<Func<Diag, bool>> predicate) => 
            MedicContext.Diags
               .Where(predicate)
               .ProjectTo<T>(Configuration);
        
        private IQueryable<T> GetDiagnoseHelper<T>(Expression<Func<Diagnose, bool>> predicate) =>
            MedicContext.Diagnoses
               .Where(predicate)
               .ProjectTo<T>(Configuration);
    }
}
