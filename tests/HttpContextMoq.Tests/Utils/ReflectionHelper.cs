using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FluentAssertions.Common;
using NSubstitute;
using NSubstitute.Extensions;

namespace HttpContextNSubstitute.Tests.Utils
{
    public static class ReflectionHelper
    {
        public static MethodInfo GetMethodInfo<TContext, TProperty>(this TContext instance, Expression<Func<TContext, TProperty>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                var propertyInfo = (PropertyInfo)memberExpression.Member;
                return propertyInfo.GetMethod;
            }
            else if (propertyExpression.Body is MethodCallExpression methodCall)
            {
                return methodCall.Method;
            }

            return default;
        }

        public static TContext VerifyGet<TContext, TProperty>(this TContext instance, Expression<Func<TContext, TProperty>> getterExpression, int count = 1) where TContext : class
        {
            getterExpression.Compile().Invoke(instance);

            var calls = instance.ReceivedCalls();
            var methodInfo = instance.GetMethodInfo(getterExpression);
            var matchingCall = calls.Where(c => c.GetMethodInfo() == methodInfo).Count();
            if (matchingCall != count)
            {
                throw new Exception($"Expected to receive call on property getter '{methodInfo.Name}', but received call null.");
            }

            return instance;
        }

        public static void Set<TContext, TProperty>(this TContext instance, Expression<Func<TContext, TProperty>> propertyExpression, TProperty value)
        {
            var memberExpr = (MemberExpression)propertyExpression.Body;
            var propertyInfo = (PropertyInfo)memberExpr.Member;
            propertyInfo.SetValue(instance, value);
        }

        public static TContext VerifySet<TContext>(this TContext instance, Action<TContext> setterExpression, int count = 1) where TContext : class
        {
            var expectedArguments = instance.ExtractArgumentsFromExpression(setterExpression);
            var calls = instance.ReceivedCalls();
            var methodInfo = setterExpression.Method;
            var matchingCall = calls.Where(call => ArgumentsMatch(expectedArguments, call.GetArguments()) || call.GetMethodInfo() == methodInfo).Count();
            if (matchingCall != count)
            {
                throw new Exception($"Expected to receive call on property setter, but received call null.");
            }

            return instance;
        }

        private static object[] ExtractArgumentsFromExpression<TContext>(this TContext instance, Action<TContext> setterExpression) where TContext : class
        {
            setterExpression(instance);
            return instance.ReceivedCalls().LastOrDefault()?.GetArguments();
        }

        private static bool ArgumentsMatch(object[] expected, object[] actual)
        {
            if (expected.Length != actual.Length)
            {
                return false;
            }

            for (int i = 0; i < expected.Length; i++)
            {
                if (!Equals(expected[i], actual[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
