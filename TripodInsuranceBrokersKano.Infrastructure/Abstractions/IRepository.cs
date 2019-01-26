using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.Infrastructure.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Get(ISpecification<T> spec);

        List<T> GetAll(ISpecification<T> spec);

        IQueryable<T> Query(ISpecification<T> spec);

        int Commit();
    }
}
