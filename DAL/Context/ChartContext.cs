using Common.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace DAL.Context
{
    public class ChartContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartContext"/> class.
        /// </summary>
        public ChartContext() : this("ChartDbConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartContext"/> class.
        /// </summary>
        /// <param name="connectionStringOrName">
        /// The connection string or Db name.
        /// </param>
        public ChartContext(string connectionStringOrName) : base(connectionStringOrName)
        {
        }

        public DbSet<Param> Params { get; set; }

        public DbSet<CacheData> CaheData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                          .Where(type => !string.IsNullOrEmpty(type.Namespace))
                                          .Where(type => type.BaseType != null &&
                                                         type.BaseType.IsGenericType &&
                                                         type.BaseType.GetGenericTypeDefinition() ==
                                                         typeof(EntityTypeConfiguration<>));
            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic)configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
