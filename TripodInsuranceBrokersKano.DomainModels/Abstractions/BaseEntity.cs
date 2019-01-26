using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TripodInsuranceBrokersKano.DomainModels.Abstractions
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; protected set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset CreatedAt { get; protected set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset UpdatedAt { get; protected set; }

        [DataType(DataType.EmailAddress)]
        public string CreatedBy { get; protected set; }

        [DataType(DataType.EmailAddress)]
        public string UpdatedBy { get; protected set; }

        public bool Deleted { get; protected set; }
    }
}
