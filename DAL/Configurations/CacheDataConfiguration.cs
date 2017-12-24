using Common.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Configurations
{
    class CacheDataConfiguration : EntityTypeConfiguration<CaheData>
    {
        public CacheDataConfiguration()
        {
            HasKey(cd => cd.CacheDataId);
            Property(cd => cd.CacheDataId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(cd => cd.Param).WithMany(p => p.Points).WillCascadeOnDelete(true);

        }
    }
}
