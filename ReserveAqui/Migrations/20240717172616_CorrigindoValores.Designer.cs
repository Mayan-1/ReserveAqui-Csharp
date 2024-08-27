﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserveAqui.Config;

#nullable disable

namespace ReserveAqui.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240717172616_CorrigindoValores")]
    partial class CorrigindoValores
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ReserveAqui.Models.AdministradorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int?>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("ReserveAqui.Models.InstituicaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("ReserveAqui.Models.MaterialModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int?>("ReservaMaterialModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservaMaterialModelId");

                    b.ToTable("Materiais");
                });

            modelBuilder.Entity("ReserveAqui.Models.ProfessorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int?>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("ReserveAqui.Models.ReservaMaterialModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataReserva")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HoraFim")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HoraInicio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("ReservaMateriais");
                });

            modelBuilder.Entity("ReserveAqui.Models.ReservaSalaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("HoraFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("SalaId");

                    b.ToTable("ReservaSalas");
                });

            modelBuilder.Entity("ReserveAqui.Models.SalaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Disponivel")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("ReserveAqui.Models.AdministradorModel", b =>
                {
                    b.HasOne("ReserveAqui.Models.InstituicaoModel", "Instituicao")
                        .WithMany()
                        .HasForeignKey("InstituicaoId");

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("ReserveAqui.Models.MaterialModel", b =>
                {
                    b.HasOne("ReserveAqui.Models.ReservaMaterialModel", null)
                        .WithMany("Material")
                        .HasForeignKey("ReservaMaterialModelId");
                });

            modelBuilder.Entity("ReserveAqui.Models.ProfessorModel", b =>
                {
                    b.HasOne("ReserveAqui.Models.InstituicaoModel", "Instituicao")
                        .WithMany()
                        .HasForeignKey("InstituicaoId");

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("ReserveAqui.Models.ReservaMaterialModel", b =>
                {
                    b.HasOne("ReserveAqui.Models.ProfessorModel", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("ReserveAqui.Models.ReservaSalaModel", b =>
                {
                    b.HasOne("ReserveAqui.Models.ProfessorModel", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveAqui.Models.SalaModel", "Sala")
                        .WithMany("Reservas")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("ReserveAqui.Models.ReservaMaterialModel", b =>
                {
                    b.Navigation("Material");
                });

            modelBuilder.Entity("ReserveAqui.Models.SalaModel", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
