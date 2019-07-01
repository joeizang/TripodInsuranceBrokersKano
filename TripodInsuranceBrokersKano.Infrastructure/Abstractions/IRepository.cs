using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.Infrastructure.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Get(ISpecification<T> spec);

        //T Get(Expression<Func<Client,bool>> predicate);

        //T Get(Expression<Func<T, object>> inlcude, Expression<Func<T, bool>> predicate);

        Task<List<T>> GetAll(ISpecification<T> spec);

        IQueryable<T> Query(ISpecification<T> spec);

        //IQueryable<T> Query(List<Expression<Func<T, object, bool>>> predicates,
        //    List<Expression<Func<T, object>>> includes);

        IQueryable<T> Query(Expression<Func<T, bool>>[] predicates,
            Expression<Func<T, object>>[] includes);


        int Commit();
    }
}
