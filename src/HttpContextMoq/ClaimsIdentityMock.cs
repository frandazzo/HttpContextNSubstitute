using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using HttpContextNSubstitute.Generic;
using NSubstitute;

namespace HttpContextNSubstitute
{
    public class ClaimsIdentityMock : ClaimsIdentity, IContextMock<ClaimsIdentity>
    {
        public ClaimsIdentityMock()
        {
            this.Mock = Substitute.For<ClaimsIdentity>();
        }

        public ClaimsIdentity Mock { get; }

        public override string AuthenticationType => this.Mock.AuthenticationType;

        public override IEnumerable<Claim> Claims => this.Mock.Claims;

        public override bool IsAuthenticated => this.Mock.IsAuthenticated;

        public override string Name => this.Mock.Name;

        public override void AddClaim(Claim claim) => this.Mock.AddClaim(claim);

        public override void AddClaims(IEnumerable<Claim> claims) => this.Mock.AddClaims(claims);

        public override ClaimsIdentity Clone() => this.Mock.Clone();

        public override IEnumerable<Claim> FindAll(Predicate<Claim> match) => this.Mock.FindAll(match);

        public override IEnumerable<Claim> FindAll(string type) => this.Mock.FindAll(type);

        public override Claim FindFirst(Predicate<Claim> match) => this.Mock.FindFirst(match);

        public override Claim FindFirst(string type) => this.Mock.FindFirst(type);

        public override bool HasClaim(Predicate<Claim> match) => this.Mock.HasClaim(match);

        public override bool HasClaim(string type, string value) => this.Mock.HasClaim(type, value);

        public override void RemoveClaim(Claim claim) => this.Mock.RemoveClaim(claim);

        public override bool TryRemoveClaim(Claim claim) => this.Mock.TryRemoveClaim(claim);

        public override void WriteTo(BinaryWriter writer) => this.Mock.WriteTo(writer);
    }
}
