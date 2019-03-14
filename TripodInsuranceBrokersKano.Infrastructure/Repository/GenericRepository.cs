using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;
using TripodInsuranceBrokersKano.DomainModels.Entities;
using TripodInsuranceBrokersKano.Infrastructure.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.Context;
using TripodInsuranceBrokersKano.Infrastructure.Services;

namespace TripodInsuranceBrokersKano.Infrastructure.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TripodContext _context;

        private DbSet<T> _set;
        private readonly UserResolverService _userService;

        public GenericRepository(TripodContext context, UserResolverService userService)
        {
            _context = context;
            _set = _context.Set<T>();
            _userService = userService;
        }

        public GenericRepository()
        {
        }

        public void Add(T entity)
        {
            //if you are here then you deserve to be here.
            //validation happens higher up the stack.
            entity.CreatedAt = DateTimeOffset.UtcNow;
            entity.CreatedBy = _userService.GetUser();
            entity.ActionType = ActionType.Update;
            _set.Add(entity);
        }

        public void Update(T entity)
        {
            entity.UpdatedAt = DateTimeOffset.UtcNow;
            entity.UpdatedBy = _userService.GetUser();
            entity.ActionType = ActionType.Update;
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            entity.Deleted = true;
            entity.UpdatedAt = DateTimeOffset.UtcNow;
            entity.UpdatedBy = _userService.GetUser();
            entity.ActionType = ActionType.Delete;
            _context.Entry(entity).State = EntityState.Modified;
            //add event so that logs can be written showing who, what when & where
        }

        public T Get(ISpecification<T> spec)
        {
            T result = null;

            spec.Includes?.ForEach(i => _set.Include(i));

            spec.Predicates?.ForEach(async p => result = await _set.AsNoTracking().SingleOrDefaultAsync(p));

            return result;
        }

        public List<T> GetAll(ISpecification<T> spec)
        {
            var result = Query(spec).AsNoTracking().ToList();
            return result;
        }

        public IQueryable<T> Query(ISpecification<T> spec)
        {
            IOrderedQueryable<T> orderedset = null;

            if (spec is null)
            {
                return _set;
            }

            if (spec?.SortOrder.Count > 1)
            {
                orderedset = _set.OrderBy(spec?.SortOrder.FirstOrDefault());
                var thens = spec?.SortOrder.GetRange(1, spec.SortOrder.Count - 1);
                thens.ForEach(t =>
                {
                    orderedset.ThenBy(t);
                });
                return orderedset;
            }

            spec?.Includes.ForEach(i => _set.Include(i));
            spec?.Predicates.ForEach(p =>
            {
                _set.Where(p);
            });
            return _set;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
