using System;
using System.Linq.Expressions;
using HttpContextNSubstitute.Generic;

namespace HttpContextNSubstitute.Tests
{
    public class PropertyGetSetUnitTest<TContextMock, TContext, TProperty> : UnitTest<TContextMock>
        where TContext : class
        where TContextMock : class, IContextMock<TContext>, TContext
    {
        private readonly PropertyGetUnitTest<TContextMock, TContext, TProperty> _getUnitTest;
        private readonly PropertySetUnitTest<TContextMock, TContext> _setUnitTest;
        
        public PropertyGetSetUnitTest(
            Expression<Func<TContext, TProperty>> getterExpression,
            Action<TContext> setterExpression,
            int received = 1)
        {
            _getUnitTest = new PropertyGetUnitTest<TContextMock, TContext, TProperty>(getterExpression, received);
            _setUnitTest = new PropertySetUnitTest<TContextMock, TContext>(setterExpression, received);
        }

        public override void Run(Func<TContextMock> targetFactory)
        {
            _getUnitTest.Run(targetFactory);
            _setUnitTest.Run(targetFactory);
        }
    }
}
