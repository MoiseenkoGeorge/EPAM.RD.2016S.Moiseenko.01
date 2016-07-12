using System;
using System.Collections.Generic;

namespace Entities.Interfacies
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAllEntities();

        TEntity GetById();

        TEntity GetByPredicate(Func<TEntity, bool> func);

        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}