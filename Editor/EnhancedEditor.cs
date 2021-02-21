using EnhancedUnityEditor.Methods;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace EnhancedUnityEditor
{
    [CustomEditor(typeof(MonoBehaviour), editorForChildClasses: true)]
    public class EnhancedEditor : Editor
    {
        private Method[] publicMethods = new Method[0];

        private void OnEnable()
        {
            var targetType = target.GetType();
            var targetMethods = targetType.GetNonMonobehaviourMethods();

            publicMethods = targetMethods
                .Where(x => x.IsPublic)
                .Select(x => new Method(target, x))
                .ToArray();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.LabelField("Public Methods");
            foreach (var method in publicMethods)
            {
                method.Draw();
            }
        }
    }
}