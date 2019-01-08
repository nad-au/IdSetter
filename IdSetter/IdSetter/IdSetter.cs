using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;

namespace IdSetter
{
    public static class IdSetter
    {
        private static readonly Dictionary<Type, IIdFieldSetter> CachedIdFieldSetters = new Dictionary<Type, IIdFieldSetter>();

        public static void SetId<T>(this T instance, long id)
        {
            while (true)
            {
                if (CachedIdFieldSetters.TryGetValue(typeof(T), out var idFieldSetter))
                {
                    idFieldSetter.SetIdField(instance, id);
                    return;
                }

                CachedIdFieldSetters.Add(typeof(T), new IdFieldSetter<T>());
            }
        }
    }

    internal class IdFieldSetter<T> : IIdFieldSetter
    {
        private readonly SetMemberDelegate _idFieldSetter;

        public IdFieldSetter()
        {
            var allProperties = typeof(T).GetAllProperties();
            var fieldIdProperty = allProperties.SingleOrDefault(p => p.HasAttribute<IdFieldAttribute>());
            if (fieldIdProperty == null) return;

            _idFieldSetter = fieldIdProperty.CreateSetter();
        }

        public void SetIdField(object instance, object id)
        {
            _idFieldSetter?.Invoke(instance, id);
        }
    }

    internal interface IIdFieldSetter
    {
        void SetIdField(object instance, object id);
    }
}
