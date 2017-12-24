using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Common Repository interface.
    /// </summary>
    /// <typeparam name="TEntity">A model.</typeparam>
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity, new()
    {
        /// <summary>
        /// Tries to find an entity by the specified <paramref name="id"/>
        /// </summary>
        /// <param name="id">The key.</param>
        /// <param name="includes">The additional include if needed.</param>
        /// <returns>
        /// An entity with the specified <paramref name="id"/> or null in case if there are now enity with such <paramref name="id"/>
        /// </returns>
        TEntity GetById(int id, params Expression<Func<TEntity, BaseEntity>>[] includes);

        /// <summary>
        /// Returns all entities from the repository.
        /// </summary>
        /// <param name="includes">The additional include if needed.</param>
        /// <returns>
        /// All entities from the repository.
        /// </returns>
        ICollection<TEntity> GetAll(params Expression<Func<TEntity, BaseEntity>>[] includes);

        /// <summary>
        /// Returns all models from the repository asynchronously.
        /// </summary>
        /// <param name="includes">The additional include if needed.</param>
        /// <returns>
        /// All models from the repository.
        /// </returns>
        Task<ICollection<TEntity>> GetAllAsync(params Expression<Func<TEntity, BaseEntity>>[] includes);

        /// <summary>
        /// Tries to find entities from the repository using the specified <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="includes">The additional include if needed.</param>
        /// <returns>Entities which correspond to the <paramref name="filter"/>.</returns>
        ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, BaseEntity>>[] includes);

        /// <summary>
        /// Tries to find models from the repository asynchronously using the specified <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="includes">The additional include if needed.</param>
        /// <returns>Entities which correspond to the <paramref name="filter"/>.</returns>
        Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, BaseEntity>>[] includes);

        /// <summary>
        /// Tries to find an entity from the repository using the specified <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="includes">The additional include if needed.</param>
        /// <returns>Entities which correspond to the <paramref name="filter"/>.</returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, BaseEntity>>[] includes);

        /// <summary>
        /// Gets the number of entities contained in the repository.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The number of entities contained in the repository.
        /// </returns>
        int Count(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Determines whether items which correspond with the specified <paramref name="filter"/> exist in the repository.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// <b>true</b> if items which correspond with the specified <paramref name="filter"/> exist in the repository;
        /// otherwise <b>false</b>.
        /// </returns>
        bool Exist(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Adds or updates the specified <paramref name="model"/>.
        /// </summary>
        /// <param name="model">A model to add or update.</param>
        void AddOrUpdate(TEntity model);

        /// <summary>
        /// Adds or updates the specified array of <paramref name="models"/>.
        /// </summary>
        /// <param name="models">Models to add or update.</param>
        void AddOrUpdate(TEntity[] models);

        /// <summary>
        /// Deletes a model with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The model key.</param>
        void Delete(int id);

        /// <summary>
        /// Deletes the <paramref name="model"/> from the repository.
        /// </summary>
        /// <param name="model">The model to delete.</param>
        void Delete(TEntity model);

        /// <summary>
        /// Saves all changes.
        /// </summary>
        void SaveChanges();
    }
}
