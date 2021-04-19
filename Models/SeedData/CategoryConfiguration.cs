using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoProject.Models
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(
                 new Category { CategoryId = "work", Name = "Work" },
                 new Category { CategoryId = "home", Name = "Home" },
                 new Category { CategoryId = "ex", Name = "Exercise" },
                 new Category { CategoryId = "shop", Name = "Shopping" },
                 new Category { CategoryId = "call", Name = "Contact" }
            );
        }
    }
}
