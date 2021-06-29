﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210629054438_UpdateUser")]
    partial class UpdateUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Alerta", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Atividade")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistritoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdDistrito")
                        .HasColumnType("int");

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<string>("LocalizacaoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Tempo")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Transitividade")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DistritoId");

                    b.HasIndex("LocalizacaoId");

                    b.ToTable("Alerta");
                });

            modelBuilder.Entity("Domain.Entities.Cidade", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EstadoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<string>("LocalizacaoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("LocalizacaoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("Domain.Entities.Distrito", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CidadeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdCidade")
                        .HasColumnType("int");

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<string>("LocalizacaoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("LocalizacaoId");

                    b.ToTable("Distrito");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<string>("LocalizacaoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacaoId");

                    b.HasIndex("PaisId");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Domain.Entities.HistoricoPrevisao", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistritoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdDistrito")
                        .HasColumnType("int");

                    b.Property<double>("SensibilidadeTermica")
                        .HasColumnType("float");

                    b.Property<double>("TemperaturaMaxima")
                        .HasColumnType("float");

                    b.Property<double>("TemperaturaMinima")
                        .HasColumnType("float");

                    b.Property<DateTime>("Tempo")
                        .HasColumnType("datetime2");

                    b.Property<double>("Umidade")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DistritoId");

                    b.ToTable("HistoricoPrevisao");
                });

            modelBuilder.Entity("Domain.Entities.HistoricoUsuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("DistPerc")
                        .HasColumnType("float");

                    b.Property<DateTime>("Duracao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdLocalizacaoChegada")
                        .HasColumnType("int");

                    b.Property<int>("IdLocalizacaoPartida")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("LocalizacaoChegadaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LocalizacaoPartidaId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Rota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacaoChegadaId");

                    b.HasIndex("LocalizacaoPartidaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("HistoricoUsuario");
                });

            modelBuilder.Entity("Domain.Entities.Localizacao", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Localizacao");
                });

            modelBuilder.Entity("Domain.Entities.Marcadores", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("LocalizacaoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Marcadores");
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdLocal")
                        .HasColumnType("int");

                    b.Property<string>("LocalizacaoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacaoId");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("Domain.Entities.TipoUsuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Nome")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContaBancaria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdTipoUsuaurio")
                        .HasColumnType("int");

                    b.Property<string>("TipoUsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Entities.Alerta", b =>
                {
                    b.HasOne("Domain.Entities.Distrito", "Distrito")
                        .WithMany()
                        .HasForeignKey("DistritoId");

                    b.HasOne("Domain.Entities.Localizacao", "Localizacao")
                        .WithMany()
                        .HasForeignKey("LocalizacaoId");

                    b.Navigation("Distrito");

                    b.Navigation("Localizacao");
                });

            modelBuilder.Entity("Domain.Entities.Cidade", b =>
                {
                    b.HasOne("Domain.Entities.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");

                    b.HasOne("Domain.Entities.Localizacao", "Localizacao")
                        .WithMany()
                        .HasForeignKey("LocalizacaoId");

                    b.Navigation("Estado");

                    b.Navigation("Localizacao");
                });

            modelBuilder.Entity("Domain.Entities.Distrito", b =>
                {
                    b.HasOne("Domain.Entities.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");

                    b.HasOne("Domain.Entities.Localizacao", "Localizacao")
                        .WithMany()
                        .HasForeignKey("LocalizacaoId");

                    b.Navigation("Cidade");

                    b.Navigation("Localizacao");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.HasOne("Domain.Entities.Localizacao", "Localizacao")
                        .WithMany()
                        .HasForeignKey("LocalizacaoId");

                    b.HasOne("Domain.Entities.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId");

                    b.Navigation("Localizacao");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Domain.Entities.HistoricoPrevisao", b =>
                {
                    b.HasOne("Domain.Entities.Distrito", "Distrito")
                        .WithMany()
                        .HasForeignKey("DistritoId");

                    b.Navigation("Distrito");
                });

            modelBuilder.Entity("Domain.Entities.HistoricoUsuario", b =>
                {
                    b.HasOne("Domain.Entities.Localizacao", "LocalizacaoChegada")
                        .WithMany()
                        .HasForeignKey("LocalizacaoChegadaId");

                    b.HasOne("Domain.Entities.Localizacao", "LocalizacaoPartida")
                        .WithMany()
                        .HasForeignKey("LocalizacaoPartidaId");

                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("LocalizacaoChegada");

                    b.Navigation("LocalizacaoPartida");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Marcadores", b =>
                {
                    b.HasOne("Domain.Entities.Localizacao", "Localizacao")
                        .WithMany()
                        .HasForeignKey("LocalizacaoId");

                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Localizacao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.HasOne("Domain.Entities.Localizacao", "Localizacao")
                        .WithMany()
                        .HasForeignKey("LocalizacaoId");

                    b.Navigation("Localizacao");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.HasOne("Infrastructure.Identity.ApplicationUser", null)
                        .WithMany("Usuario")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Entities.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioId");

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
