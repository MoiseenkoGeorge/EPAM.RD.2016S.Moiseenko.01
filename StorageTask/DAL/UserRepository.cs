﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using DAL.Interfacies;
using Entities;
using Storage.Criterias.Interfacies;
using Storage.Storages.Interfacies;

namespace DAL
{
    public class UserRepository : MarshalByRefObject, IUserRepository
    {
        private readonly IUserStorage userStorage;

        private readonly List<User> localUserStorage;

        private readonly ReaderWriterLockSlim rwls;

        public UserRepository(IUserStorage userStorage)
        {
            if(userStorage == null)
                throw new NullReferenceException(nameof(userStorage));
            this.userStorage = userStorage;
            this.localUserStorage = GetAllEntities().ToList();
            rwls = new ReaderWriterLockSlim();
        }

        public IEnumerable<User> GetAllEntities()
        {
            return userStorage.GetAll();
        }

        public User GetById()
        {
            throw new NotImplementedException();
        }

        public User GetByPredicate(Func<User, bool> func)
        {
            throw new NotImplementedException();
        }

        public void Attach(User entity)
        {
            User user;
            rwls.EnterReadLock();
            try
            {
                user = localUserStorage.AsParallel().FirstOrDefault(u => u.Id == entity.Id);
            }
            finally
            {
                rwls.ExitReadLock();
            }

            if (user == null)
            {
                rwls.EnterWriteLock();
                localUserStorage.Add(entity);
                rwls.ExitWriteLock();
            }
            else
            {
                throw new InvalidOperationException("The same user is already exists");
            }
        }

        public void Detach(User entity)
        {
            User user;
            rwls.EnterReadLock();
            try
            {
                user = localUserStorage.AsParallel().FirstOrDefault(u => u.Id == entity.Id);
            }
            finally
            {
                rwls.ExitReadLock();
            }

            if (user == null)
            {
                throw new InvalidOperationException("user is not exists");
            }

            rwls.EnterWriteLock();
            localUserStorage.Remove(entity);
            rwls.ExitWriteLock();
        }

        public int Create(User entity)
        {
            var result = userStorage.Add(entity);
            entity.Id = result;
            Attach(entity);
            return result;
        }

        public void Delete(User entity)
        {
            userStorage.Delete(entity.Id);
            Detach(entity);
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public List<int> GetUsersIdsByPredicate(IUserCriteria[] funcs)
        {
            return localUserStorage.AsParallel().Where(u => funcs.All(f => f.MeetCriteria(u))).Select(u => u.Id).ToList();
        }
    }
}