using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;

namespace TripodInsuranceBrokersKano.Tests
{
    public class TestRepository<T> : IRepository<T> where T : BaseEntity
    {
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
