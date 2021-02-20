using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EnhancedUnityEditor
{
    [CustomEditor(typeof(MonoBehaviour), editorForChildClasses: true)]
    public class EnhancedEditor : Editor
    {
        private MethodInfo[] publicMethods = new MethodInfo[0];

        private void OnEnable()
        {
            var targetType = target.GetType();
            var targetMethods = targetType.GetNonMonobehaviourMethods();

            publicMethods = targetMethods.Where(x => x.IsPublic).ToArray();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            foreach (var method in publicMethods)
            {
                HandleMethod(method);
            }
        }

        private void HandleMethod(MethodInfo method)
        {
            if (GUILayout.Button(method.Name))
            {
                var returnValue = method.Invoke(target, new object[0]);

                if (method.ReturnType != typeof(void))
                {
                    Debug.Log(returnValue, target);
                }
            }
        }
    }
}