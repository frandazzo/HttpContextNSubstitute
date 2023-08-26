using System;
using FluentAssertions;
using HttpContextNSubstitute.Generic;

namespace HttpContextNSubstitute.Tests
{
    public class ContextMockUnitTest<TTarget, TSubTarget> : UnitTest<TTarget>
        where TSubTarget : class
        where TTarget : class, IContextMock<TSubTarget>
    {
        public override void Run(Func<TTarget> targetFactory)
        {
            // Act
            var target = targetFactory.Invoke();

            // Assert
            target.Mock.Should().NotBeNull();
            target.Mock.Should().BeAssignableTo(typeof(TSubTarget));

            if (target is IContextMocks<TSubTarget> contextMocks)
            {
                contextMocks.Mocks.Should().NotBeNull();
                contextMocks.Mocks.Should().BeOfType(typeof(MockCollection));
            }
        }
    }
}
