// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoProject.Models;

namespace ToDoProject.Migrations
{
    [DbContext(typeof(TicketContext))]
    partial class TicketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDoProject.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "work",
                            Name = "Work"
                        },
                        new
                        {
                            CategoryId = "home",
                            Name = "Home"
                        },
                        new
                        {
                            CategoryId = "ex",
                            Name = "Exercise"
                        },
                        new
                        {
                            CategoryId = "shop",
                            Name = "Shopping"
                        },
                        new
                        {
                            CategoryId = "call",
                            Name = "Contact"
                        });
                });

            modelBuilder.Entity("ToDoProject.Models.Status", b =>
                {
                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = "todo",
                            Name = "To Do"
                        },
                        new
                        {
                            StatusId = "inprogress",
                            Name = "In Progress"
                        },
                        new
                        {
                            StatusId = "qualityassurance",
                            Name = "Quality Assurance"
                        },
                        new
                        {
                            StatusId = "done",
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("ToDoProject.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointValue")
                        .HasColumnType("int");

                    b.Property<int>("SprintNumber")
                        .HasColumnType("int");

                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StatusId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = "work",
                            Description = "The first ticket",
                            DueDate = new DateTime(2021, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "First Ticket",
                            PointValue = 1,
                            SprintNumber = 1,
                            StatusId = "todo"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The second ticket",
                            Name = "Second Ticket",
                            PointValue = 7,
                            SprintNumber = 3,
                            StatusId = "inprogress"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The third ticket",
                            Name = "Third Ticket",
                            PointValue = 8,
                            SprintNumber = 6,
                            StatusId = "todo"
                        });
                });

            modelBuilder.Entity("ToDoProject.Models.Ticket", b =>
                {
                    b.HasOne("ToDoProject.Models.Category", "Category")
                        .WithMany("Tickets")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ToDoProject.Models.Status", "Status")
                        .WithMany("Tickets")
                        .HasForeignKey("StatusId");
                });
#pragma warning restore 612, 618
        }
    }
}
