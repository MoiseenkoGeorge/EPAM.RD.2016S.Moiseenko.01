using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Attributes
{
    public class Creator
    {
        public IEnumerable<User> Create(Type type)
        {
            if (type == typeof(User))
                return CreateUsers(type);
            return CreateAdvancedUsers(type);
        }

        private IEnumerable<AdvancedUser> CreateAdvancedUsers(Type type)
        {
            List<AdvancedUser> users = new List<AdvancedUser>();

            var instAttr = Assembly.GetExecutingAssembly().GetCustomAttributes<InstantiateAdvancedUserAttribute>();

            var ctor = type.GetConstructor(new[] { typeof(int), typeof(int) });
            var ctorAttr = ctor.GetCustomAttributes<MatchParameterWithPropertyAttribute>();

            foreach (var advancedUserAttribute in instAttr)
            {
                int id = advancedUserAttribute.Id;
                int externalId = advancedUserAttribute.ExternalId;

                if (id == 0)
                    id = GetPropertyValueFromAttribute(type,
                        ctorAttr.Single(x => x.Parametrname == nameof(id)).PropertyName);
                if (externalId == 0)
                    externalId = GetPropertyValueFromAttribute(type,
                        ctorAttr.Single(x => x.Parametrname == nameof(externalId)).PropertyName);

                AdvancedUser newUser = (AdvancedUser)ctor.Invoke(new object[] { id, externalId });
                if (!IsValidStringFieldOrProperty(type, nameof(newUser.FirstName), advancedUserAttribute.FirstName) || !IsValidStringFieldOrProperty(type, nameof(newUser.LastName), advancedUserAttribute.LastName))
                    throw new ValidationException();

                newUser.FirstName = advancedUserAttribute.FirstName;
                newUser.LastName = advancedUserAttribute.LastName;
                users.Add(newUser);

            }
            return users;
        }

        private IEnumerable<User> CreateUsers(Type type)
        {
            List<User> users = new List<User>();

            var instantiateAttributes = type.GetCustomAttributes<InstantiateUserAttribute>(false);

            var ctor = type.GetConstructor(new[] { typeof(int) });
            var ctorAttr = ctor.GetCustomAttribute<MatchParameterWithPropertyAttribute>();
            foreach (var attribute in instantiateAttributes)
            {
                int id = attribute.Id;
                if (attribute.Id == 0)
                    id = GetPropertyValueFromAttribute(type, ctorAttr.PropertyName);
                var field = type.GetField("_id", BindingFlags.NonPublic | BindingFlags.Instance);
                if (!IsValidIntegerFieldOrProperty(type, field.Name, id))
                    throw new ValidationException();
                User newUser = (User)ctor.Invoke(new object[] { id });
                if (!IsValidStringFieldOrProperty(type, nameof(newUser.FirstName), attribute.FirstName) || !IsValidStringFieldOrProperty(type, nameof(newUser.LastName), attribute.LastName))
                    throw new ValidationException();

                newUser.FirstName = attribute.FirstName;
                newUser.LastName = attribute.LastName;
                users.Add(newUser);
            }

            return users;
        }

        private int GetPropertyValueFromAttribute(Type type, string name)
        {
            var attrs = type.GetProperty(name).GetCustomAttributes(true);
            int id = 0;
            foreach (var element in attrs)
            {
                var defValAttr = (DefaultValueAttribute)element;
                id = (int)defValAttr.Value;
            }
            return id;
        }

        private bool IsValidStringFieldOrProperty(Type type, string name, string value)
        {
            MemberInfo info = type.GetField(name) as MemberInfo ??
                type.GetProperty(name) as MemberInfo;
            var attr = info.GetCustomAttributes<StringValidatorAttribute>(true);
            return attr.All(attribute => value.Length <= attribute.MaxStringLength);
        }

        private bool IsValidIntegerFieldOrProperty(Type type, string name, int value)
        {
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            MemberInfo info = type.GetField(name, bindingFlags) as MemberInfo ??
                type.GetProperty(name, bindingFlags) as MemberInfo;

            var attr = info.GetCustomAttributes<IntValidatorAttribute>(true);
            return attr.All(attribute => value <= attribute.maxValue && value >= attribute.minValue);
        }
    }
}