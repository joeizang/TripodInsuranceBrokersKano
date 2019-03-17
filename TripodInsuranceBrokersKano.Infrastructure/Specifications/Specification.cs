using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;

namespace TripodInsuranceBrokersKano.Infrastructure.Specifications
{
    public class Specification<T> : ISpecification<T> where T : BaseEntity
    {

        public Specification()
        {
            Predicates = new List<Expression<Func<T, bool>>>();
            Includes = new List<Expression<Func<T, object>>>();
            SortOrder = new List<Expression<Func<T, object>>>();
        }


        public List<Expression<Func<T, bool>>> Predicates { get; set; }
        public List<Expression<Func<T, object>>> SortOrder { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
