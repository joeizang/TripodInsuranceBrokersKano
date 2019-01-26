using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TripodInsuranceBrokersKano.Infrastructure.Abstractions
{
    public interface ISpecification<T> where T : class
    {
        List<Expression<Func<T, bool>>> Predicates { get; set; }

        List<Expression<Func<T,object>>> SortOrder { get; set; }

        int Skip { get; set; }

        int Take { get; set; }
    }
}
