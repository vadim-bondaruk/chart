using Common.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configurations
{
    class CacheDataConfiguration : EntityTypeConfiguration<CacheData>
    {
        public CacheDataConfiguration()
        {
            HasKey(cd => cd.Id);
            Property(cd => cd.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(cd => cd.Param).WithMany(p => p.Points).HasForeignKey(cd => cd.ParamId).WillCascadeOnDelete(true);
            
        }
    }
}
