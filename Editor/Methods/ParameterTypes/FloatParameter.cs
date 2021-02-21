using System.Reflection;
using UnityEditor;

namespace EnhancedUnityEditor.Methods
{
    internal class FloatParameter : Parameter<float>
    {
        public FloatParameter(ParameterInfo parameterInfo) : base(parameterInfo)
        {
        }

        protected override float Draw(float currentValue)
        {            
            return EditorGUILayout.FloatField(name, currentValue);
        }
    }
}
