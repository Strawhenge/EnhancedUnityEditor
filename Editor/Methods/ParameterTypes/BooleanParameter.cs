using System.Reflection;
using UnityEditor;

namespace EnhancedUnityEditor.Methods
{
    internal class BooleanParameter : Parameter<bool>
    {
        public BooleanParameter(ParameterInfo parameterInfo) : base(parameterInfo)
        {
        }

        protected override bool Draw(bool currentValue)
        {
            return EditorGUILayout.Toggle(name, currentValue);
        }
    }
}
