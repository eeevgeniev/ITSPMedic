﻿using Microsoft.EntityFrameworkCore;

namespace Medic.Entities
{
    public partial class HealthRegion
    {
        public void CreateRules(ModelBuilder builder)
        {
            builder.Entity<HealthRegion>(b =>
            {
                b.HasKey(model => model.Id);
                
                b.Property(model => model.Name).HasMaxLength(20);
                
                b.HasIndex(model => model.Code).IsUnique(true);
            });
        }
    }
}