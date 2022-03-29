﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ToDoContext))]
    [Migration("20220328130602_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)")
                        .HasColumnName("cor")
                        .HasColumnOrder(3);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nome")
                        .HasColumnOrder(2);

                    b.HasKey("Id")
                        .HasName("pk_categoria");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("categoria_id")
                        .HasColumnOrder(8);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime")
                        .HasColumnName("data_criacao")
                        .HasColumnOrder(6);

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime")
                        .HasColumnName("data_entrega")
                        .HasColumnOrder(7);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("descricao")
                        .HasColumnOrder(3);

                    b.Property<string>("Prioridade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("prioridade")
                        .HasColumnOrder(4);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status")
                        .HasColumnOrder(5);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("titulo")
                        .HasColumnOrder(2);

                    b.HasKey("Id")
                        .HasName("pk_tarefa");

                    b.HasIndex("CategoriaId")
                        .HasDatabaseName("idx_tarefa_categoria");

                    b.ToTable("tarefa", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Tarefa", b =>
                {
                    b.HasOne("Core.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_tarefa_categoria");

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}