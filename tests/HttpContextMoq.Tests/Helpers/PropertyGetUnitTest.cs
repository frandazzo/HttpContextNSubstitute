using System;
using System.Linq.Expressions;
using HttpContextNSubstitute.Generic;
using HttpContextNSubstitute.Tests.Utils;

namespace HttpContextNSubstitute.Tests
{
    public class PropertyGetUnitTest<TContextMock, TContext, TProperty> : UnitTest<TContextMock>
        where TContext : class
        where TContextMock : class, IContextMock<TContext>, TContext
    {
        private readonly Expression<Func<TContext, TProperty>> _getterExpression;
        private readonly int _count;

        public PropertyGetUnitTest(Expression<Func<TContext, TProperty>> getterExpression, int count = 1)
        {
            _getterExpression = getterExpression;
            _count = count;
        }

        public override void Run(Func<TContextMock> targetFactory)
        {
            var target = targetFactory.Invoke();

            // Assert
            target.Mock.VerifyGet(_getterExpression);
        }

    }
}
