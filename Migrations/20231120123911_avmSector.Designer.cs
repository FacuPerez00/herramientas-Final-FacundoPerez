﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto.Data;

#nullable disable

namespace Proyecto.Migrations
{
    [DbContext(typeof(EmpleadosPuestosContext))]
    [Migration("20231120123911_avmSector")]
    partial class avmSector
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("EmpleadoPuesto", b =>
                {
                    b.Property<int>("EmpleadosId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PuestosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmpleadosId", "PuestosId");

                    b.HasIndex("PuestosId");

                    b.ToTable("EmpleadoPuesto");
                });

            modelBuilder.Entity("Proyecto.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ambiguedad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .HasColumnType("TEXT");

                    b.Property<int>("Edad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("PuestoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sueldo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Proyecto.Models.Puesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SectorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.ToTable("Puestos");
                });

            modelBuilder.Entity("Proyecto.Models.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sector");
                });

            modelBuilder.Entity("EmpleadoPuesto", b =>
                {
                    b.HasOne("Proyecto.Models.Empleado", null)
                        .WithMany()
                        .HasForeignKey("EmpleadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto.Models.Puesto", null)
                        .WithMany()
                        .HasForeignKey("PuestosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proyecto.Models.Puesto", b =>
                {
                    b.HasOne("Proyecto.Models.Sector", "Sector")
                        .WithMany("Puestos")
                        .HasForeignKey("SectorId");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("Proyecto.Models.Sector", b =>
                {
                    b.Navigation("Puestos");
                });
#pragma warning restore 612, 618
        }
    }
}
