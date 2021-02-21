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
        private bool showPublicMethods = false;

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

            showPublicMethods = EditorGUILayout.Foldout(showPublicMethods, "Public Methods");
            if (showPublicMethods)
            {
                foreach (var method in publicMethods)
                    method.Draw();
            }
        }
    }
}