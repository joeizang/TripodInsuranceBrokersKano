using System.Collections.Generic;
using System.Linq;

namespace apibackend.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Get(ISpecification<T> spec);

        //T Get(Expression<Func<Client,bool>> predicate);

        //T Get(Expression<Func<T, object>> inlcude, Expression<Func<T, bool>> predicate);

        List<T> GetAll(ISpecification<T> spec);

        IQueryable<T> Query(ISpecification<T> spec);

        int Commit();
    }
}
