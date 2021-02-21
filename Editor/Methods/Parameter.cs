using System.Reflection;
using UnityEngine;

namespace EnhancedUnityEditor.Methods
{
    internal abstract class Parameter
    {
        public static Parameter Create(ParameterInfo parameterInfo)
        {
            var type = parameterInfo.ParameterType;

            if (type == typeof(Vector3))
                return new Vector3Parameter(parameterInfo);

            return new ObjectParameter(parameterInfo);
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