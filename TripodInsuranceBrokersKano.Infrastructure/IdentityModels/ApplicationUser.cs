using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using TripodInsuranceBrokersKano.DomainModels.Abstractions;

namespace TripodInsuranceBrokersKano.Infrastructure.IdentityModels
{
    public class ApplicationUser : IdentityUser<int>, IEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Designation { get; set; }

    }
}
