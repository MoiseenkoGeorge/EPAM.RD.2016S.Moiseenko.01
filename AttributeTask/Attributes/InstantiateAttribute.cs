﻿using System;

namespace Attributes
{
    // Should be applied to classes only.
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class InstantiateUserAttribute : Attribute
    {
        public int Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public InstantiateUserAttribute(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public InstantiateUserAttribute(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public InstantiateUserAttribute()
        {
        }
    }
}
