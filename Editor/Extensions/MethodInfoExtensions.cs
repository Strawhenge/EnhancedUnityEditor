using System.Reflection;

namespace EnhancedUnityEditor
{
    internal static class MethodInfoExtensions
    {
        public static bool HasReturnType(this MethodInfo methodInfo) =>
            methodInfo.ReturnType != typeof(void);
    }
}
