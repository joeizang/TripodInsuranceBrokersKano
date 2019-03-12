using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.DomainModels.Abstractions
{
    public interface IActionableEntity : IEntity
    {
        ActionType ActionType { get; set; }
    }
}
