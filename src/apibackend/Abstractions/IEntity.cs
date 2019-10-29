using System;

namespace apibackend.Abstractions
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
