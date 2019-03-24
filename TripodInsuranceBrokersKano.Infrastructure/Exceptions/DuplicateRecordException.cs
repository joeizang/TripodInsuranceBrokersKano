using System;
using System.Collections.Generic;
using System.Text;

namespace TripodInsuranceBrokersKano.Infrastructure.Exceptions
{
    public class DuplicateRecordException : Exception
    {
        public DuplicateRecordException(string message) : base(message)
        {
        }
    }
}
