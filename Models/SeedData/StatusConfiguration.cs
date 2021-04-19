using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
    internal class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity)
        {
            entity.HasData(
                new Status { StatusId = "todo", Name = "To Do" },
                new Status { StatusId = "inprogress", Name = "In Progress" },
                new Status { StatusId = "qualityassurance", Name = "Quality Assurance" },
                new Status { StatusId = "done", Name = "Completed" }
            );
        }
    }
}
