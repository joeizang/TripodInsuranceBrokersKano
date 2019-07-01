using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;
using TripodInsuranceBrokersKano.Infrastructure.Exceptions;

namespace TripodInsuranceBrokersKano.Infrastructure.Abstractions
{
    public class DataServiceBase<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repo;
        protected readonly IMapper _mapper;

        public DataServiceBase(IRepository<T> repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }



        public bool CheckForDuplicate(IApiModel model, params Expression<Func<T,bool>>[] predicates)
        {

            var includes = new List<Expression<Func<T, object>>> { }.ToArray();

            var entity = _repo.Query(predicates, includes).SingleOrDefault();

            if (entity is null) return true; //no duplicates were found so things are fine

            //duplicates found so return false
            return false;

        }

        public virtual List<TModel> GetAll<TModel>(ISpecification<T> spec) where TModel : IApiModel
        {
            var list = _repo.GetAll(spec);
            List<TModel> clientList = _mapper.Map<List<TModel>>(list);
            return clientList;
        }

        public virtual void Create<TModel>(TModel model, string creator) where TModel : IApiModel
        {
            if (!CheckForDuplicate(model))
            {
                var client = _mapper.Map<TModel, T>(model);
                _repo.Add(client);
                _repo.Commit();
            }
            //a record already exists like this one being created. Send them back
            throw new DuplicateRecordException("You cannot create an entity that exists already!!");
        }

        public virtual void Delete<TModel>(TModel model, ISpecification<T> spec) 
            where TModel : IApiModel
        {
            var client = _repo.Get(spec);

            _repo.Delete(client);
            _repo.Commit();
        }

        public void Update<TModel>(TModel model, ISpecification<T> spec) where TModel : IApiModel
        {
            var entity = _repo.Get(spec);

            if (entity is null)
                throw new NotFoundException("The entity you are looking for doesn't exist!");
            var updated = _mapper.Map<TModel, T>(model, entity);
            _repo.Update(updated);
            _repo.Commit();
        }

        public virtual TModel GetById<TModel>(int id, ISpecification<T> spec) where TModel : IApiModel
        {
            T target = _repo.Get(spec.AddPredicates(c => c.Id == id));
            var mClient = _mapper.Map<T, TModel>(target);
            return mClient;
        }
    }
}
