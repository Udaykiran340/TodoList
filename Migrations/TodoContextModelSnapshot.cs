﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using W1.Models;

namespace W1.Migrations
{
    [DbContext(typeof(TodoContext))]
    partial class TodoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("W1.Models.item", b =>
                {
                    b.Property<int>("itemid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("itemid");

                    b.ToTable("item");
                });

            modelBuilder.Entity("W1.Models.todoitem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("i1itemid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("i1itemid");

                    b.ToTable("TodoItems");
                });

            modelBuilder.Entity("W1.Models.todoitem", b =>
                {
                    b.HasOne("W1.Models.item", "i1")
                        .WithMany()
                        .HasForeignKey("i1itemid");
                });
#pragma warning restore 612, 618
        }
    }
}
