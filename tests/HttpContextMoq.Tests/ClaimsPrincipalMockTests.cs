using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Security.Principal;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace HttpContextMoq.Tests
{
    public class ClaimsPrincipalMockTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ClaimsPrincipalMock_WhenRun_AssertTrue(UnitTest<ClaimsPrincipalMock> unitTest)
        {
            unitTest.Run(() => new ClaimsPrincipalMock());
        }

        public static IEnumerable<object[]> Data =>
            new UnitTest<ClaimsPrincipalMock>[]
            {
                //Class
                new ContextMockUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(),
                //Properties
                new PropertyGetUnitTest<ClaimsPrincipalMock, ClaimsPrincipal, IEnumerable<Claim>>(
                    t => t.Claims
                ),
                new PropertyGetUnitTest<ClaimsPrincipalMock, ClaimsPrincipal, IEnumerable<ClaimsIdentity>>(
                    t => t.Identities
                ),
                new PropertyGetUnitTest<ClaimsPrincipalMock, ClaimsPrincipal, IIdentity>(
                    t => t.Identity, 0
                ),
                new FuncAndAssertResultUnitTest<ClaimsPrincipalMock, IIdentity>(
                    t => t.IdentityMock = new ClaimsIdentityMock(),
                    (t, v) => t.IdentityMock.Should().BeSameAs(v),
                    (t, v) => t.Identity.Should().BeSameAs(v)
                ),
                //Methods
                new MethodInvokeUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(
                    t => t.AddIdentities(Arg.Any<IEnumerable<ClaimsIdentity>>())
                ),
                new MethodInvokeUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(
                    t => t.AddIdentity(Arg.Any<ClaimsIdentity>())
                ),
                new MethodInvokeUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(
                    t => t.Clone()
                ),
                new MethodInvokeUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(
                    t => t.FindAll(Arg.Any<Predicate<Claim>>())
                ),
                new MethodInvokeUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(
                    t => t.FindAll(Arg.Any<string>())
                ),
                new MethodInvokeUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(
                    t => t.FindFirst(Arg.Any<Predicate<Claim>>())
                ),
                new MethodInvokeUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(
                    t => t.FindFirst(Arg.Any<string>())
                ),
                new MethodInvokeUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(
                    t => t.HasClaim(Arg.Any<Predicate<Claim>>())
                ),
                new MethodInvokeUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(
                    t => t.HasClaim(Arg.Any<string>(), Arg.Any<string>())
                ),
                new MethodInvokeUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(
                    t => t.IsInRole(Arg.Any<string>())
                ),
                new MethodInvokeUnitTest<ClaimsPrincipalMock, ClaimsPrincipal>(
                    t => t.WriteTo(Arg.Any<BinaryWriter>())
                ),
            }.ToData();
    }
}
