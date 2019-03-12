using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TripodInsuranceBrokersKano.DomainModels.Entities;

namespace TripodInsuranceBrokersKano.DomainModels.Abstractions
{
    public abstract class BaseEntity : IActionableEntity
    {
        [Key]
        public int Id { get;  set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset UpdatedAt { get; set; }

        [DataType(DataType.EmailAddress)]
        public string CreatedBy { get; set; }

        [DataType(DataType.EmailAddress)]
        public string UpdatedBy { get; set; }

        public bool Deleted { get; set; }
        public ActionType ActionType { get; set; }
    }
}
