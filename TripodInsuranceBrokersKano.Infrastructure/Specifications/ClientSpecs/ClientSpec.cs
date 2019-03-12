﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;

namespace TripodInsuranceBrokersKano.Infrastructure.Specifications.ClientSpecs
{
    public class ClientSpec : ISpecification<Client>
    {

        public ClientSpec()
        {
            Predicates = new List<Expression<Func<Client, bool>>>();
            SortOrder = new List<Expression<Func<Client, object>>>();
            Includes = new List<Expression<Func<Client, object>>>();
        }

        public virtual List<Expression<Func<Client, bool>>> Predicates { get; set; }
        public virtual List<Expression<Func<Client, object>>> SortOrder { get; set; }
        public virtual List<Expression<Func<Client, object>>> Includes { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

        public virtual ISpecification<Client> AddPredicate(params Expression<Func<Client, bool>>[] predicates)
        {
            foreach (var p in predicates)
            {
                Predicates.Add(p);
            }

            return this;
        }

        public virtual ISpecification<Client> AddSortOrder(params Expression<Func<Client, object>>[] criteria)
        {
            foreach(var c in criteria)
            {
                SortOrder.Add(c);
            }
            return this;
        }

        public virtual ISpecification<Client> AddIncludes(params Expression<Func<Client, object>>[] includes)
        {
            foreach(var i in includes)
            {
                Includes.Add(i);
            }
            return this;
        }
    }
}
