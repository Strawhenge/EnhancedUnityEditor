using System;
using System.Reflection;
using UnityEditor;

namespace EnhancedUnityEditor.Methods
{
    internal class ObjectParameter : Parameter<UnityEngine.Object>
    {
        private readonly Type restrictType;

        public ObjectParameter(ParameterInfo parameterInfo) : base(parameterInfo)
        {
            restrictType = parameterInfo.ParameterType;
        }

        protected override UnityEngine.Object Draw(UnityEngine.Object currentValue)
        {
            var newValue = EditorGUILayout.ObjectField(name, currentValue, restrictType, allowSceneObjects: true);

            return restrictType.IsInstanceOfType(newValue)
                ? newValue
                : default;
        }
    }
}
