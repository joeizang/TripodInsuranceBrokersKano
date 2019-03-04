﻿using System;
using System.Collections.Generic;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.DomainModels.Abstractions
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTimeOffset CreatedAt { get; set; }

        DateTimeOffset UpdatedAt { get; set; }

        string CreatedBy { get; set; }

        string UpdatedBy { get; set; }

        bool Deleted { get; set; }
    }
}
