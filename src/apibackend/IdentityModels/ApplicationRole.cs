using System;
using apibackend.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace apibackend.IdentityModels
{
    public class ApplicationRole : IdentityRole<int>, IEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool Deleted { get; set; }

        public string Designation { get; set; }

        public Permissions Permissions { get; set; }

        public bool CanApprove { get; set; }

    }
}
