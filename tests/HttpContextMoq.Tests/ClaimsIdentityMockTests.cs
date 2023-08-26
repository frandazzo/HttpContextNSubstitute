using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using Xunit;

namespace HttpContextNSubstitute.Tests
{
    public class ClaimsIdentityMockTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ClaimsIdentityMock_WhenRun_AssertTrue(UnitTest<ClaimsIdentityMock> unitTest)
        {
            unitTest.Run(() => new ClaimsIdentityMock());
        }

        public static IEnumerable<object[]> Data =>
            new UnitTest<ClaimsIdentityMock>[]
            {
                //Class
                new ContextMockUnitTest<ClaimsIdentityMock, ClaimsIdentity>(),
                //Properties
                new PropertyGetUnitTest<ClaimsIdentityMock, ClaimsIdentity, string>(
                    t => t.AuthenticationType
                ),
                new PropertyGetUnitTest<ClaimsIdentityMock, ClaimsIdentity, IEnumerable<Claim>>(
                    t => t.Claims
                ),
                new PropertyGetUnitTest<ClaimsIdentityMock, ClaimsIdentity, bool>(
                    t => t.IsAuthenticated
                ),
                new PropertyGetUnitTest<ClaimsIdentityMock, ClaimsIdentity, string>(
                    t => t.Name
                ),
                //Methods
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.AddClaim(Arg.Any<Claim>())
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.AddClaim(Arg.Any < Claim >())
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.AddClaims(Arg.Any<IEnumerable<Claim>>())
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.Clone()
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.FindAll(Arg.Any < Predicate < Claim > >())
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.FindAll(Arg.Any < string >())
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.FindFirst(Arg.Any < Predicate < Claim > >())
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.FindFirst(Arg.Any < string >())
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.HasClaim(Arg.Any < Predicate < Claim > >())
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.HasClaim(Arg.Any < string >(), Arg.Any < string >())
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.RemoveClaim(Arg.Any < Claim >())
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.TryRemoveClaim(Arg.Any < Claim >())
                ),
                new MethodInvokeUnitTest<ClaimsIdentityMock, ClaimsIdentity>(
                    t => t.WriteTo(Arg.Any < BinaryWriter >())
                ),
            }.ToData();
    }
}
