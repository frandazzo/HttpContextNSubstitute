using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using HttpContextNSubstitute.Generic;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace HttpContextNSubstitute
{
    public class ConnectionInfoMock : ConnectionInfo, IContextMock<ConnectionInfo>
    {
        public ConnectionInfoMock()
        {
            this.Mock = Substitute.For<ConnectionInfo>();
        }

        public ConnectionInfo Mock { get; }

        public override X509Certificate2 ClientCertificate
        {
            get => this.Mock.ClientCertificate;
            set => this.Mock.ClientCertificate = value;
        }

        public override string Id
        {
            get => this.Mock.Id;
            set => this.Mock.Id = value;
        }

        public override IPAddress LocalIpAddress
        {
            get => this.Mock.LocalIpAddress;
            set => this.Mock.LocalIpAddress = value;
        }

        public override int LocalPort
        {
            get => this.Mock.LocalPort;
            set => this.Mock.LocalPort = value;
        }

        public override IPAddress RemoteIpAddress
        {
            get => this.Mock.RemoteIpAddress;
            set => this.Mock.RemoteIpAddress = value;
        }

        public override int RemotePort
        {
            get => this.Mock.RemotePort;
            set => this.Mock.RemotePort = value;
        }

        public override Task<X509Certificate2> GetClientCertificateAsync(CancellationToken cancellationToken = default) => this.Mock.GetClientCertificateAsync(cancellationToken);
    }
}