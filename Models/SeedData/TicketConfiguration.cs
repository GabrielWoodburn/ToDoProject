using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
    internal class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> entity)
        {
            entity.HasOne(c => c.Category)
                .WithMany(t => t.Tickets)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(
                new Ticket { Id = 1, Name = "First Ticket", Description = "The first ticket", PointValue = 1, CategoryId = "work", DueDate = new DateTime(2021, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), SprintNumber = 1, StatusId = "todo" },
                new Ticket { Id = 2, Name = "Second Ticket", Description = "The second ticket", PointValue = 7, SprintNumber = 3, StatusId = "inprogress" },
                new Ticket { Id = 3, Name = "Third Ticket", Description = "The third ticket", PointValue = 8, SprintNumber = 6, StatusId = "todo" }
               );
        }
    }
}
