using System;
using System.Collections.Generic;
using Entities.Interfacies;

namespace DAL.Interfacies
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAllEntities();

        TEntity GetById();

        TEntity GetByPredicate(Func<TEntity, bool> func);

        /// <summary>
        /// Attach entity to local storage
        /// </summary>
        void Attach(TEntity entity);

        /// <summary>
        /// Detach entity to local storage
        /// </summary>
        void Detach(TEntity entity);

        int Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}