using System;
using System.Runtime.CompilerServices;

namespace tyr.Core.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsAnonymousType(this Type type)
        {
            var hasCompilerGeneratedAttribute = Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false);
            var nameContainsAnonymousType = type.Name.Contains("AnonymousType");
            var nameStartsWithAnonymousTypeChars = type.Name.StartsWith("<>") || type.Name.StartsWith("VB$");
            var isAnonymousType = hasCompilerGeneratedAttribute && nameContainsAnonymousType &&
                                  nameStartsWithAnonymousTypeChars;
            return isAnonymousType;
        }
    }
}