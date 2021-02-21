using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EnhancedUnityEditor.Methods
{
    internal class Method
    {
        private readonly Object target;
        private readonly MethodInfo methodInfo;
        private readonly string name;
        private readonly bool hasReturnType;
        private readonly Parameter[] parameters;

        public Method(Object target, MethodInfo methodInfo)
        {
            this.target = target;
            this.methodInfo = methodInfo;

            name = methodInfo.Name;
            hasReturnType = methodInfo.HasReturnType();
            parameters = methodInfo
                .GetParameters()
                .Select(x => Parameter.Create(x))
                .ToArray();
        }

        public void Draw()
        {
            foreach (var parameter in parameters)
            {
                parameter.Draw();
            }

            if (GUILayout.Button(name))
                Invoke();

            EditorGUILayout.Space();
        }

        private void Invoke()
        {
            var parameterValues = parameters
                .Select(x => x.CurrentValue)
                .ToArray();

            var returnValue = methodInfo.Invoke(target, parameterValues);

            if (hasReturnType)
                Debug.Log(returnValue, target);
        }
    }
}
