namespace Infrastructure.Models
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique key
        /// </summary>
        public int Id { get; set; }
    }
}
