using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EnhancedUnityEditor.Methods
{
    internal class Vector3Parameter : Parameter<Vector3>
    {
        public Vector3Parameter(ParameterInfo parameterInfo) : base(parameterInfo)
        {
        }

        protected override Vector3 Draw(Vector3 currentValue)
        {
            return EditorGUILayout.Vector3Field(name, currentValue);
        }
    }
}
