﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TripodInsuranceBrokersKano.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
