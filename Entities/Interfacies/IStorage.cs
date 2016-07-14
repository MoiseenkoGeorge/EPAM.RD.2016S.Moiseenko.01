using System;
using System.Collections.Generic;

namespace Entities.Interfacies
{
    public interface IStorage<TEntity> where TEntity : IEntity
    {
        int Add(TEntity entity);

        /// <param name="id"> User's Id</param>
        void Delete(int id);

        IEnumerable<int> Search(Func<TEntity, bool>[] funcs);

        void Save();

        void Load();
    }
}