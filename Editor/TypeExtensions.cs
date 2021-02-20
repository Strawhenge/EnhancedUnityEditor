using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EnhancedUnityEditor
{
    internal static class TypeExtensions
    {
        private static readonly Type[] monobehaviourHierarchyTypes = new Type[]
        {
            typeof(MonoBehaviour),
            typeof(Behaviour),
            typeof(Component),
            typeof(Object),
            typeof(object)
        };

        public static MethodInfo[] GetNonMonobehaviourMethods(this Type type)
        {
            return type
                .GetMethods()
                .Where(x => !monobehaviourHierarchyTypes.Contains(x.DeclaringType))
                .ToArray();
        }
    }
}