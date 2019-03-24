using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.Infrastructure.Abstractions
{
    public class DataServiceBase<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repo;
        protected readonly IMapper _mapper;
        protected readonly ISpecification<T> _spec;

        public DataServiceBase(IRepository<T> repo,
                                 IMapper mapper, ISpecification<T> spec)
        {
            _repo = repo;
            _mapper = mapper;
            _spec = spec;
        }



        public void CheckForDuplicates(object model)
        {
            //check to see if there is a type in the assemblies of the application
            //that allow for casting of model to the appropriate type based on the 
            //method it is being invoked inside of.

            //know what type this is being called form.
            var hostType = this.GetType();
            var methods = hostType.GetMethods();

            var p = methods.ToList().Where(m => m.Name.Contains("Create")).SingleOrDefault();
        }
    }
}
