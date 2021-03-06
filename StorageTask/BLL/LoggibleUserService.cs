﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.ServiceModel;
using BLL.Interfacies;
using BLL.Loggers.Interfacies;
using Entities;
using Storage.Criterias.Interfacies;

namespace BLL
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class LoggibleUserService : UserService
    {
        private readonly UserService userService;

        private ILogger logger;

        public LoggibleUserService(ILogger logger, UserService userService) : base(userService.Name)
        {
            if(logger == null || userService == null)
                throw new NullReferenceException();
            this.logger = logger;
            this.userService = userService;
        }

        public override bool IsMaster => userService.IsMaster;

        public override int AddUser(User user)
        {
            rwls.EnterWriteLock();
            try
            {
                logger.SendMessage(TraceEventType.Information, "try to add new user");
                var result = userService.AddUser(user);
                logger.SendMessage(TraceEventType.Information, $"addition of user is complete, his id - {result}");
                logger.SendMessage(TraceEventType.Information, $"send user by network, his id - {result}");
                return result;
            }
            catch (Exception e)
            {
                logger.SendMessage(TraceEventType.Error, $"error when add user : {e.Message}");
                throw;
            }
            finally
            {
                rwls.ExitWriteLock();
            }
        }

        public override void DeleteUser(User user)
        {
            rwls.EnterWriteLock();
            try
            {
                logger.SendMessage(TraceEventType.Information, "try to delete user");
                userService.DeleteUser(user);
                logger.SendMessage(TraceEventType.Information, "delete of user is complete");
            }
            catch (Exception e)
            {
                logger.SendMessage(TraceEventType.Error, $"error when delete user : {e.Message}");
                throw;
            }
            finally
            {
                rwls.ExitWriteLock();
            }
        }

        public override List<int> FindUsers(IUserCriteria[] funcs)
        {
            
            logger.SendMessage(TraceEventType.Information, $"Find user by predicates");
            rwls.EnterReadLock();
            try
            {
                var result = userService.FindUsers(funcs);
                logger.SendMessage(TraceEventType.Information, $"Find {result.Count()} users");
                return result;
            }
            finally
            {
                rwls.ExitReadLock();
            }
        }
    }
}