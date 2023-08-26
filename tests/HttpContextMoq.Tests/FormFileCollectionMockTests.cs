using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Xunit;
using NSubstitute;
using FluentAssertions;

namespace HttpContextMoq.Tests
{
    public class FormFileCollectionMockTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void FormFileCollectionMock_WhenRun_AssertTrue(UnitTest<FormFileCollectionMock> unitTest)
        {
            unitTest.Run(() => new FormFileCollectionMock());
        }

        public static IEnumerable<object[]> Data =>
            new UnitTest<FormFileCollectionMock>[]
            {
                //Class
                new ContextMockUnitTest<FormFileCollectionMock, IFormFileCollection>(),
                //Properties
                new PropertyGetUnitTest<FormFileCollectionMock, IFormFileCollection, IFormFile>(
                    t => t[Fakes.String]
                ),
                new PropertyGetUnitTest<FormFileCollectionMock, IFormFileCollection, IFormFile>(
                    t => t[Fakes.Int]
                ),
                new PropertyGetUnitTest<FormFileCollectionMock, IFormFileCollection, int>(
                    t => t.Count
                ),
                //Methods
                new MethodInvokeUnitTest<FormFileCollectionMock, IFormFileCollection>(
                    t => t.GetEnumerator()
                ),
                new ActionAndAssertUnitTest<FormFileCollectionMock>(
                    t => ((IEnumerable)t).GetEnumerator(),
                    t => t.Mock.As<IEnumerable>().Received(1).GetEnumerator()
                ),
                new MethodInvokeUnitTest<FormFileCollectionMock, IFormFileCollection>(
                    t => t.GetFile(Arg.Any<string>())
                ),
                new MethodInvokeUnitTest<FormFileCollectionMock, IFormFileCollection>(
                    t => t.GetFiles(Arg.Any<string>())
                ),
            }.ToData();
    }
}
