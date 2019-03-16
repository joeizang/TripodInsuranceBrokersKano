using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;

namespace TripodInsuranceBrokersKano.Infrastructure.Abstractions
{
    public static class ClientSpecExtensions
    {

        public static ISpecification<Client> AddPredicates(this ISpecification<Client> spec,
            params Expression<Func<Client,bool>>[] predicates)
        {

            predicates.ToList().ForEach(p => spec.Predicates.Add(p));
            return spec;
        }

        public static ISpecification<Client> AddIncludes(this ISpecification<Client> spec,
            params Expression<Func<Client,object>>[] includes)
        {
            includes.ToList().ForEach(i => spec.Includes.Add(i));
            return spec;
        }

        public static ISpecification<Client> AddSortOrder(this ISpecification<Client> spec,
            params Expression<Func<Client,object>>[] sortOrder)
        {
            sortOrder.ToList().ForEach(s => spec.SortOrder.Add(s));
            return spec;
        }
    }
}
