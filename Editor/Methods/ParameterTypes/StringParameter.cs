using System.Reflection;
using UnityEditor;

namespace EnhancedUnityEditor.Methods
{
    internal class StringParameter : Parameter<string>
    {
        public StringParameter(ParameterInfo parameterInfo) : base(parameterInfo)
        {
        }

        protected override string Draw(string currentValue)
        {
            return EditorGUILayout.TextField(name, currentValue);
        }
    }
}
