using Common.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configurations
{
    class ParamConfiguration : EntityTypeConfiguration<Param>
    {
        public ParamConfiguration()
        {
            HasKey(p => p.ParamId);
            Property(p => p.ParamId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
