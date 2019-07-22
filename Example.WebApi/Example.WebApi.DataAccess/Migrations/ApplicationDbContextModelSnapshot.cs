﻿// <auto-generated />
using System;
using Example.WebApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Example.WebApi.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Example.WebApi.DataAccess.Model.Database.Master.Customers", b =>
                {
                    b.Property<long>("customerID");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("mobile")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("customerID");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Example.WebApi.DataAccess.Model.Database.Operation.Transactions", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<decimal>("amount")
                        .HasColumnType("numeric(15,2)");

                    b.Property<string>("currency")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<long>("customerID");

                    b.Property<DateTime>("date");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("id");

                    b.HasIndex("customerID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Example.WebApi.DataAccess.Model.Database.Operation.Transactions", b =>
                {
                    b.HasOne("Example.WebApi.DataAccess.Model.Database.Master.Customers", "customers")
                        .WithMany("transactions")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
