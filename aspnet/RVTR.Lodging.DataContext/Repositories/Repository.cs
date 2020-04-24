using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Lodging.DataContext.Databases;
using RVTR.Lodging.ObjectModel.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RVTR.Lodging.DataContext.Repositories
{
    /// <summary>
    /// Generic repository for lodging entities
    /// </summary>
    /// <typeparam name="TEntity">The type of lodging entity</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {


        private readonly LodgingDbContext _db;

        public Repository(LodgingDbContext ldb)
        {
          _db = ldb;
        }

        public Repository(){}

        /// <summary>
        /// Delete given entity from the database
        /// </summary>
        /// <param name="id">The Id of the entity being deleted</param>
        /// <returns>Bool describing if the entity was removed</returns>
        public bool Delete(int id)
        {
            var entity = this.Select(id);
            if (entity != null)
            {
                var context = new ValidationContext(entity, null, null);
                var results = new List<ValidationResult>();
                if (Validator.TryValidateObject(entity, context, results, true))
                {
                    _db.Set<TEntity>().Remove(entity);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Inserts a new entity into the database
        /// </summary>
        /// <param name="entity">The entity to be inserted into the database</param>
        /// <returns>Bool describing if entity was inserted</returns>
        public bool Insert(TEntity entity)
        {
            var context = new ValidationContext(entity, null, null);
            var results = new List<ValidationResult>();
            if (Validator.TryValidateObject(entity, context, results, true))
            {
                _db.Set<TEntity>().Add(entity);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Select all entities of type TEntity
        /// </summary>
        /// <returns>An enumerable containing all instanced of TEntity in database</returns>
        public IEnumerable<TEntity> Select()
        {
          return _db.Set<TEntity>();
        }

        /// <summary>
        /// Select an entity by id (primary key)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Select(int id)
        {
          return _db.Set<TEntity>().Find(id);
        }

        /// <summary>
        ///Update an entity in the database
        /// </summary>
        /// <param name="entity">The given entity to be updated</param>
        /// <returns>Bool representing whether the given entity was updated in the database</returns>
        public bool Update(TEntity entity)
        {
            var context = new ValidationContext(entity, null, null);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(entity, context, results, true))
            {
                _db.Set<TEntity>().Update(entity);
                return true;
            }
            return false;
        }
    }
}
