using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.Context;

namespace TripodInsuranceBrokersKano.Infrastructure.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TripodContext _context;

        private DbSet<T> _set;


        public GenericRepository(TripodContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }


        public void Add(T entity)
        {
            //if you are here then you deserve to be here.
            //validation happens higher up the stack.
            _set.Add(entity);
        }

        public void Update(T entity)
        {
            _set.Update(entity);
        }

        public void Delete(T entity)
        {
            _set.GetType().GetProperty(nameof(entity.Deleted))
                .SetValue(entity.Deleted, true);
        }

        public T Get(List<Expression<Func<T, bool>>> predicates)
        {
            object result = null;

            foreach (var p in predicates)
            {
                result = _set.AsNoTracking().SingleOrDefault(p);
            }

            return (T)result;
        }

        public List<T> GetAll(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }
    }
}
