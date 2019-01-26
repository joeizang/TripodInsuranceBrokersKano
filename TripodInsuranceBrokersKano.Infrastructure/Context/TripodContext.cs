using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TripodInsuranceBrokersKano.Infrastructure.Context
{
    public class TripodContext : DbContext
    {
        public TripodContext(DbContextOptions<TripodContext> options) : base(options)
        {
            
        }

        public TripodContext()
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
