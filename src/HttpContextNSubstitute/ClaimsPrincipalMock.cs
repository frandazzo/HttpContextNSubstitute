using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Security.Principal;
using HttpContextNSubstitute.Generic;
using NSubstitute;

namespace HttpContextNSubstitute
{
    public class ClaimsPrincipalMock : ClaimsPrincipal, IContextMocks<ClaimsPrincipal>
    {
        private IIdentity _identity;

        public ClaimsPrincipalMock()
        {
            this.Mock = Substitute.For<ClaimsPrincipal>();
            this.Mocks = new MockCollection(this);
            this.IdentityMock = new ClaimsIdentityMock();
        }

        public ClaimsPrincipal Mock { get; }

        public MockCollection Mocks { get; }

        public ClaimsIdentityMock IdentityMock
        {
            get => _identity as ClaimsIdentityMock;
            set
            {
                _identity = value;
                this.Mocks.Add(value);
            }
        }

        public override IEnumerable<Claim> Claims => this.Mock.Claims;

        public override IEnumerable<ClaimsIdentity> Identities => this.Mock.Identities;

        public override IIdentity Identity => _identity;

        public override void AddIdentities(IEnumerable<ClaimsIdentity> identities) => this.Mock.AddIdentities(identities);

        public override void AddIdentity(ClaimsIdentity identity) => this.Mock.AddIdentity(identity);

        public override ClaimsPrincipal Clone() => this.Mock.Clone();

        public override IEnumerable<Claim> FindAll(Predicate<Claim> match) => this.Mock.FindAll(match);

        public override IEnumerable<Claim> FindAll(string type) => this.Mock.FindAll(type);

        public override Claim FindFirst(Predicate<Claim> match) => this.Mock.FindFirst(match);

        public override Claim FindFirst(string type) => this.Mock.FindFirst(type);

        public override bool HasClaim(Predicate<Claim> match) => this.Mock.HasClaim(match);

        public override bool HasClaim(string type, string value) => this.Mock.HasClaim(type, value);

        public override bool IsInRole(string role) => this.Mock.IsInRole(role);

        public override void WriteTo(BinaryWriter writer) => this.Mock.WriteTo(writer);
    }
}
