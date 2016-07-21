using System;
using System.Collections.Generic;
using Entities;
using Entities.Interfacies;

namespace Storage.Storages.Interfacies
{
    public interface IStorage<TEntity> where TEntity : IEntity
    {
        int Add(TEntity entity);

        /// <param name="id"> User's Id</param>
        void Delete(int id);

        IEnumerable<int> Search(Func<TEntity, bool>[] funcs);

        IEnumerable<User> GetAll(); 

        void Save();

        void Load();
    }
}