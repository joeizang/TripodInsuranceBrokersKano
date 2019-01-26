using System;
using System.Collections.Generic;
using System.Text;

namespace TripodInsuranceBrokersKano.DomainModels.Abstractions
{
    public interface IEntity
    {
        int Id { get; }

        DateTimeOffset CreatedAt { get; }

        DateTimeOffset UpdatedAt { get; }

        string CreatedBy { get; }

        string UpdatedBy { get; }

        bool Deleted { get; }
    }
}
