using System;
using HttpContextNSubstitute.Generic;
using NSubstitute;

namespace HttpContextNSubstitute.Tests
{
    public class MethodInvokeUnitTest<TContextMock, TContext> : UnitTest<TContextMock>
        where TContext : class
        where TContextMock : class, IContextMock<TContext>, TContext
    {
        private readonly Action<TContext> _invokeExpression;
        private readonly int _count;
        
        public MethodInvokeUnitTest(Action<TContext> invokeExpression, int count = 1)
        {
            _invokeExpression = invokeExpression;
            _count = count;
        }

        public override void Run(Func<TContextMock> targetFactory)
        {
            // Arrange
            var target = targetFactory.Invoke();

            // Assert
            target.Mock.Received(1).When(_invokeExpression);
        }
    }
}
