﻿// <auto-generated />
using Athena_Activo_FijoAPI.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Athena_Activo_FijoAPI.Migrations
{
    [DbContext(typeof(AthenaDbContext))]
    [Migration("20231207010933_AgregarBaseDatos")]
    partial class AgregarBaseDatos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Athena_Activo_FijoAPI.Modelos.ActivosFijos", b =>
                {
                    b.Property<int>("ID_tipo_activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_tipo_activo"));

                    b.Property<string>("Descipcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tipoActivoID_tipo_activo")
                        .HasColumnType("int");

                    b.HasKey("ID_tipo_activo");

                    b.HasIndex("tipoActivoID_tipo_activo");

                    b.ToTable("ActivosFijos");
                });

            modelBuilder.Entity("Athena_Activo_FijoAPI.Modelos.AreasTrabajo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AreasTrabajo");
                });

            modelBuilder.Entity("Athena_Activo_FijoAPI.Modelos.Asignaciones", b =>
                {
                    b.Property<int>("Id_Asignaciones")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Asignaciones"));

                    b.Property<int>("ActivosFijosID_tipo_activo")
                        .HasColumnType("int");

                    b.Property<int>("PersonasId_Persona")
                        .HasColumnType("int");

                    b.HasKey("Id_Asignaciones");

                    b.HasIndex("ActivosFijosID_tipo_activo");

                    b.HasIndex("PersonasId_Persona");

                    b.ToTable("Asignaciones");
                });

            modelBuilder.Entity("Athena_Activo_FijoAPI.Modelos.Athena", b =>
                {
                    b.Property<int>("ID_Athena")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Athena"));

                    b.Property<int>("ActivosFijosID_tipo_activo")
                        .HasColumnType("int");

                    b.Property<int>("AsignacionesId_Asignaciones")
                        .HasColumnType("int");

                    b.Property<int>("tipoActivoID_tipo_activo")
                        .HasColumnType("int");

                    b.HasKey("ID_Athena");

                    b.HasIndex("ActivosFijosID_tipo_activo");

                    b.HasIndex("AsignacionesId_Asignaciones");

                    b.HasIndex("tipoActivoID_tipo_activo");

                    b.ToTable("Athena");
                });

            modelBuilder.Entity("Athena_Activo_FijoAPI.Modelos.Personas", b =>
                {
                    b.Property<int>("Id_Persona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Persona"));

                    b.Property<int>("AreasTrabajoid")
                        .HasColumnType("int");

                    b.Property<string>("n_carnet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Persona");

                    b.HasIndex("AreasTrabajoid");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Athena_Activo_FijoAPI.Modelos.tipoActivo", b =>
                {
                    b.Property<int>("ID_tipo_activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_tipo_activo"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_tipo_activo");

                    b.ToTable("tipoActivo");
                });

            modelBuilder.Entity("Athena_Activo_FijoAPI.Modelos.ActivosFijos", b =>
                {
                    b.HasOne("Athena_Activo_FijoAPI.Modelos.tipoActivo", "tipoActivo")
                        .WithMany()
                        .HasForeignKey("tipoActivoID_tipo_activo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tipoActivo");
                });

            modelBuilder.Entity("Athena_Activo_FijoAPI.Modelos.Asignaciones", b =>
                {
                    b.HasOne("Athena_Activo_FijoAPI.Modelos.ActivosFijos", "ActivosFijos")
                        .WithMany()
                        .HasForeignKey("ActivosFijosID_tipo_activo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Athena_Activo_FijoAPI.Modelos.Personas", "Personas")
                        .WithMany()
                        .HasForeignKey("PersonasId_Persona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivosFijos");

                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Athena_Activo_FijoAPI.Modelos.Athena", b =>
                {
                    b.HasOne("Athena_Activo_FijoAPI.Modelos.ActivosFijos", "ActivosFijos")
                        .WithMany()
                        .HasForeignKey("ActivosFijosID_tipo_activo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Athena_Activo_FijoAPI.Modelos.Asignaciones", "Asignaciones")
                        .WithMany()
                        .HasForeignKey("AsignacionesId_Asignaciones")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Athena_Activo_FijoAPI.Modelos.tipoActivo", "tipoActivo")
                        .WithMany()
                        .HasForeignKey("tipoActivoID_tipo_activo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivosFijos");

                    b.Navigation("Asignaciones");

                    b.Navigation("tipoActivo");
                });

            modelBuilder.Entity("Athena_Activo_FijoAPI.Modelos.Personas", b =>
                {
                    b.HasOne("Athena_Activo_FijoAPI.Modelos.AreasTrabajo", "AreasTrabajo")
                        .WithMany()
                        .HasForeignKey("AreasTrabajoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AreasTrabajo");
                });
#pragma warning restore 612, 618
        }
    }
}