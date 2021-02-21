using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EnhancedUnityEditor.Methods
{
    internal abstract class Parameter
    {
        private static readonly Dictionary<Type, Type> parameterTypes = new Dictionary<Type, Type>();

        static Parameter()
        {
            var types = typeof(Parameter).Assembly
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Parameter)) && x.BaseType.IsGenericType);

            parameterTypes = types.ToDictionary(
                keySelector: x => x.BaseType.GenericTypeArguments.First(),
                elementSelector: x => x);
        }

        public static Parameter Create(ParameterInfo parameterInfo)
        {
            var type = parameterInfo.ParameterType;

            if (!parameterTypes.ContainsKey(type))
                return new ObjectParameter(parameterInfo);

            var parameterType = parameterTypes[type];
            return (Parameter)Activator.CreateInstance(parameterType, new object[] { parameterInfo });
        }

        public abstract object CurrentValue { get; }

        public abstract void Draw();
    }

    internal abstract class Parameter<T> : Parameter
    {
        protected readonly string name;

        private T currentValue;

        public Parameter(ParameterInfo parameterInfo)
        {
            name = parameterInfo.Name;
        }

        public override object CurrentValue => currentValue;

        public override void Draw()
        {
            currentValue = Draw(currentValue);
        }

        protected abstract T Draw(T currentValue);
    }
}