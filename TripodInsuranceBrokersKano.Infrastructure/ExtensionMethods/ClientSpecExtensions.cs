using System;
using System.Linq;
using System.Linq.Expressions;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.Infrastructure.Abstractions
{
    public static class ClientSpecExtensions
    {

        public static ISpecification<T> AddPredicates<T>(this ISpecification<T> spec,
            params Expression<Func<T,bool>>[] predicates) where T : BaseEntity
        {

            predicates.ToList().ForEach(p => spec.Predicates.Add(p));
            return spec;
        }

        public static ISpecification<T> AddIncludes<T>(this ISpecification<T> spec,
            params Expression<Func<T,object>>[] includes) where T : BaseEntity
        {
            includes.ToList().ForEach(i => spec.Includes.Add(i));
            return spec;
        }

        public static ISpecification<T> AddSortOrder<T>(this ISpecification<T> spec,
            params Expression<Func<T,object>>[] sortOrder) where T : BaseEntity
        {
            sortOrder.ToList().ForEach(s => spec.SortOrder.Add(s));
            return spec;
        }


        
    }
}
