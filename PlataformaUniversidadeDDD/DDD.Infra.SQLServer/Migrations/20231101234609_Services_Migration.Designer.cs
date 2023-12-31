﻿// <auto-generated />
using System;
using DDD.Infra.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDD.Infra.SQLServer.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20231101234609_Services_Migration")]
    partial class Services_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("UserSequence");

            modelBuilder.Entity("DDD.Domain.PicContext.Projeto", b =>
                {
                    b.Property<int>("ProjetoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjetoId"));

                    b.Property<int>("AnosDuracao")
                        .HasColumnType("int");

                    b.Property<string>("ProjetoDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjetoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjetoId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("DDD.Domain.PosGraduacaoContext.PosGraduacao", b =>
                {
                    b.Property<int>("PesquisadorId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int>("PosGradId")
                        .HasColumnType("int");

                    b.HasKey("PesquisadorId", "ProjetoId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("pos_graducacao", (string)null);
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.BoletimPersistence", b =>
                {
                    b.Property<int>("BoletimPersistenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BoletimPersistenceId"));

                    b.Property<int>("AlunoUserId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Nota")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BoletimPersistenceId");

                    b.HasIndex("AlunoUserId");

                    b.ToTable("Boletins");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisciplinaId"));

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<bool>("Ead")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DisciplinaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Matricula", b =>
                {
                    b.Property<int>("MatriculaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatriculaId"));

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.HasKey("MatriculaId");

                    b.HasIndex("AlunoId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("DDD.Domain.UserManagementContext.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [UserSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("UserId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DDD.Domain.PicContext.Pesquisador", b =>
                {
                    b.HasBaseType("DDD.Domain.UserManagementContext.User");

                    b.Property<int>("Titulacao")
                        .HasColumnType("int");

                    b.ToTable("Pesquisador", (string)null);
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Aluno", b =>
                {
                    b.HasBaseType("DDD.Domain.UserManagementContext.User");

                    b.ToTable("Aluno", (string)null);
                });

            modelBuilder.Entity("DDD.Domain.PosGraduacaoContext.PosGraduacao", b =>
                {
                    b.HasOne("DDD.Domain.PicContext.Pesquisador", "Pesquisador")
                        .WithMany()
                        .HasForeignKey("PesquisadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDD.Domain.PicContext.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pesquisador");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.BoletimPersistence", b =>
                {
                    b.HasOne("DDD.Domain.SecretariaContext.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Matricula", b =>
                {
                    b.HasOne("DDD.Domain.SecretariaContext.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDD.Domain.SecretariaContext.Disciplina", "Disciplina")
                        .WithMany()
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });
#pragma warning restore 612, 618
        }
    }
}
