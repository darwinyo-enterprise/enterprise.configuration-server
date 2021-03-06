﻿// <auto-generated />
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Enterprise.ConfigurationServer.Migrations
{
    [DbContext(typeof(ConfigurationDBContext))]
    [Migration("20180101140328_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Enterprise.ConfigurationServer.DataLayers.ConfigurationDB.ApplicationConfiguration", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AppID");

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<string>("Values")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("AppID");

                    b.ToTable("ApplicationConfiguration","Configuration");
                });

            modelBuilder.Entity("Enterprise.ConfigurationServer.DataLayers.ConfigurationDB.IntegratedApp", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ApplicationURL")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("CoreFeature");

                    b.Property<bool>("Integrated");

                    b.HasKey("ID");

                    b.HasIndex("ApplicationName")
                        .IsUnique();

                    b.HasIndex("ApplicationURL")
                        .IsUnique();

                    b.ToTable("IntegratedApp","Configuration");
                });

            modelBuilder.Entity("Enterprise.ConfigurationServer.DataLayers.ConfigurationDB.ApplicationConfiguration", b =>
                {
                    b.HasOne("Enterprise.ConfigurationServer.DataLayers.ConfigurationDB.IntegratedApp", "IntegratedApp")
                        .WithMany("ApplicationConfigurations")
                        .HasForeignKey("AppID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
