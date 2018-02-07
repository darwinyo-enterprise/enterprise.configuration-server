using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.ConfigurationServer.DataLayers.ConfigurationDB
{
    public class ConfigurationDBContext : DbContext
    {
        public ConfigurationDBContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Stored Proc That Used For Get All Permited Roles Menu By Menu ID.
        /// </summary>
        /// <param name="menuID">
        /// GUID Menu
        /// </param>
        /// <returns>
        /// Roles array
        /// </returns>
        public string[] GetAllAppMenuRoleByMenuID(Guid menuID)
        {
            List<string> result = new List<string>();
            // ADO.NET Codes
            using (var cmd = this.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = @"[Configuration].[GetAllAppMenuRoleByMenuID]";

                SqlParameter sqlParameter = new SqlParameter("@menuID", menuID);
                cmd.Parameters.Add(sqlParameter);

                // Open Connection
                this.Database.OpenConnection();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    result.Add(rdr["Name"].ToString());
                }

                // Dispose Connection
                this.Database.CloseConnection();
            }

            return result.ToArray();
        }

        public string[] GetAllAppCategoryMenuRoleByCategoryMenuID(Guid menuCategoryID)
        {
            List<string> result = new List<string>();
            // ADO.NET Codes
            using (var cmd = this.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = @"[Configuration].[GetAllAppCategoryMenuRoleByCategoryMenuID]";

                SqlParameter sqlParameter = new SqlParameter("@menuCategoryID", menuCategoryID);
                cmd.Parameters.Add(sqlParameter);

                // Open Connection
                this.Database.OpenConnection();

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    result.Add(rdr["Name"].ToString());
                }

                // Dispose Connection
                this.Database.CloseConnection();
            }

            return result.ToArray();
        }

        public DbSet<AppMenuLayout> AppMenuLayouts { get; set; }
        public DbSet<ApplicationConfiguration> ApplicationConfigurations { get; set; }
        public DbSet<IntegratedApp> IntegratedApps { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<AppMenu> AppMenus { get; set; }
        public DbSet<AppMenuCategory> AppMenuCategories { get; set; }
        public DbSet<MenuPermittedRole> MenuPermittedRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(x =>
            {
                x.ToTable("Project", "Configuration");

                x.Property(e => e.ProjectName)
                .IsRequired()
                .HasMaxLength(200);

                x.Property(e => e.ProjectVersion)
                .IsRequired()
                .HasMaxLength(200);

                x.HasMany(e => e.IntegratedApps)
                .WithOne(e => e.Project);
            });
            modelBuilder.Entity<IntegratedApp>(x =>
            {
                x.ToTable("IntegratedApp", "Configuration");

                x.HasIndex(e => e.ApplicationName)
                .IsUnique();
                x.HasIndex(e => e.ApplicationURL)
                .IsUnique();

                x.Property(e => e.ApplicationName)
                .IsRequired()
                .HasMaxLength(200);
                x.Property(e => e.ApplicationURL)
                .IsRequired()
                .HasMaxLength(200);
            });
            modelBuilder.Entity<ApplicationConfiguration>(x =>
            {
                x.ToTable("ApplicationConfiguration", "Configuration");

                x.HasIndex(e => e.IntegratedAppID);

                x.Property(e => e.Key)
                .IsRequired();
                x.Property(e => e.Values)
                .IsRequired();

                x.HasOne(e => e.IntegratedApp)
                .WithMany(e => e.ApplicationConfigurations)
                .HasForeignKey(e => e.IntegratedAppID);
            });
            modelBuilder.Entity<AppMenu>(x =>
            {
                x.ToTable("AppMenu", "Configuration");

                x.HasIndex(e => e.IntegratedAppID);

                x.Property(e => e.MenuTitle)
                .IsRequired()
                .HasMaxLength(100);

                x.Property(e => e.MenuHref)
                .IsRequired()
                .HasMaxLength(100);

                x.Property(e => e.MenuIcon)
                .HasMaxLength(100);

                x.HasIndex(e => e.AppMenuCategoryID);

                x.HasOne(e => e.AppMenuCategory)
                .WithMany(e => e.AppMenus)
                .HasForeignKey(e => e.AppMenuCategoryID);

                x.HasMany(e => e.MenuPermittedRoles)
                .WithOne(e => e.AppMenu)
                .HasForeignKey(e => e.AppMenuID);

                x.HasOne(e => e.IntegratedApp)
                .WithMany(e => e.AppMenus)
                .HasForeignKey(e => e.IntegratedAppID);
            });
            modelBuilder.Entity<AppMenuLayout>(x =>
            {
                x.ToTable("AppMenuLayout", "Configuration");

                x.Property(e => e.LayoutName)
                .IsRequired();
            });
            modelBuilder.Entity<AppMenuCategory>(x =>
            {
                x.ToTable("AppMenuCategory", "Configuration");

                x.Property(e => e.MenuCategory)
                .IsRequired()
                .HasMaxLength(100);

                x.HasMany(e => e.MenuPermittedRole)
                .WithOne(e => e.AppMenuCategory);

            });
            modelBuilder.Entity<MenuPermittedRole>(x =>
            {
                x.ToTable("MenuPermittedRole", "Configuration");

                x.HasOne(e => e.AppMenuCategory)
                .WithMany(e => e.MenuPermittedRole)
                .HasForeignKey(e => e.AppMenuCategoryID);

                x.HasOne(e => e.AppMenu)
                .WithMany(e => e.MenuPermittedRoles)
                .HasForeignKey(e => e.AppMenuID);
            });
        }
    }
}
