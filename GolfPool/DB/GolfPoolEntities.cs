using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using GolfPool.Models;

namespace GolfPool.DB
{
    public class GolfPoolEntities : DbContext
    {
        public DbSet<GolferGroup> GolferGroups { get; set; }

        public DbSet<Golfer> Golfers { get; set; }

        public DbSet<Team> Teams { get; set; }

        public static void RecreateAndSeedDB()
        {

            //TODO: Remove after development
            Database.SetInitializer(new GolfPoolDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            var typesToRegister = GetType().Assembly.GetTypes()
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}