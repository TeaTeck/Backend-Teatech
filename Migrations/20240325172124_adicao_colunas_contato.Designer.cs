﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.Infrastructure;

#nullable disable

namespace BackendTeaTech.Migrations
{
    [DbContext(typeof(ConnectionContext))]
    [Migration("20240325172124_adicao_colunas_contato")]
    partial class adicao_colunas_contato
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.ChildAssisted", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Aversions")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("aversions");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_date");

                    b.Property<string>("FoodSelectivity")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("food_selectivity");

                    b.Property<string>("MedicalRecord")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("medical_record");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Photo")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("photo");

                    b.Property<string>("Preferences")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("preferences");

                    b.Property<Guid?>("fk_responsible_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("fk_responsible_id");

                    b.ToTable("child_assisteds");
                });

            modelBuilder.Entity("WebApplication1.Models.Responsible", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ContactOne")
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("contact_one");

                    b.Property<string>("ContactTwo")
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("contact_two");

                    b.Property<string>("NameResponsibleOne")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name_responsible_one");

                    b.Property<string>("NameResponsibleTwo")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name_responsible_two");

                    b.Property<string>("ResponsibleCpfOne")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("responsible_cpf_one");

                    b.Property<string>("ResponsibleCpfTwo")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("resposible_cpf_two");

                    b.Property<string>("ResponsibleKinshipOne")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("responsible_kinship_one");

                    b.Property<string>("ResponsibleKinshipTwo")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("responsible_kinship_two");

                    b.Property<Guid?>("fk_user_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("fk_user_id");

                    b.ToTable("responsibles");
                });

            modelBuilder.Entity("WebApplication1.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<int>("UserType")
                        .HasMaxLength(20)
                        .HasColumnType("integer")
                        .HasColumnName("user_type");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("WebApplication1.Models.ChildAssisted", b =>
                {
                    b.HasOne("WebApplication1.Models.Responsible", "Responsible")
                        .WithMany()
                        .HasForeignKey("fk_responsible_id");

                    b.Navigation("Responsible");
                });

            modelBuilder.Entity("WebApplication1.Models.Responsible", b =>
                {
                    b.HasOne("WebApplication1.User", "User")
                        .WithMany()
                        .HasForeignKey("fk_user_id");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
