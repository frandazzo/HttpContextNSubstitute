using System.IO;
using System.Threading;
using System.Threading.Tasks;
using HttpContextNSubstitute.Generic;
using Microsoft.AspNetCore.Http;
using NSubstitute;
#if NETCOREAPP
using Microsoft.AspNetCore.Routing;
#endif

namespace HttpContextNSubstitute
{
    public class HttpRequestMock : HttpRequest, IContextMocks<HttpRequest>
    {
        private HttpContextMock _httpContextMock;
        private IHeaderDictionary _headers;

        public HttpRequestMock(HttpContextMock httpContextMock)
        {
            this.Mock = Substitute.For<HttpRequest>();
            this.Mocks = new MockCollection(this);
            this.HttpContextMock = httpContextMock;
            this.HeadersMock = new HeaderDictionaryMock();
            this.QueryMock = new QueryCollectionMock();
            this.CookiesMock = new RequestCookieCollectionMock();
            this.FormMock = new FormCollectionMock();
#if NETCOREAPP
            this.RouteValues = new RouteValueDictionary();
#endif
        }

        public HttpRequest Mock { get; }

        public MockCollection Mocks { get; }

        public HttpContextMock HttpContextMock
        {
            get => _httpContextMock;
            set
            {
                this._httpContextMock = value;
                this.Mocks.Add(value);
            }
        }

        public IHeaderDictionaryMock HeadersMock
        {
            get => _headers as IHeaderDictionaryMock;
            set
            {
                SetHeaders(value);
            }
        }

        public QueryCollectionMock QueryMock
        {
            get => this.Query as QueryCollectionMock;
            set
            {
                this.Query = value;
                this.Mocks.Add(value);
            }
        }

        public RequestCookieCollectionMock CookiesMock
        {
            get => this.Cookies as RequestCookieCollectionMock;
            set
            {
                this.Cookies = value;
                this.Mocks.Add(value);
            }
        }

        public FormCollectionMock FormMock
        {
            get => this.Form as FormCollectionMock;
            set
            {
                this.Form = value;
                this.Mocks.Add(value);
            }
        }

        public FormCollectionFake FormFake
        {
            get => this.Form as FormCollectionFake;
            set
            {
                this.Form = value;
            }
        }

        public override Stream Body
        {
            get => this.Mock.Body;
            set => this.Mock.Body = value;
        }

        public override long? ContentLength
        {
            get => this.Mock.ContentLength;
            set => this.Mock.ContentLength = value;
        }

        public override string ContentType
        {
            get => this.Mock.ContentType;
            set => this.Mock.ContentType = value;
        }

        public override IRequestCookieCollection Cookies { get; set; }

        public override IFormCollection Form { get; set; }

        public override bool HasFormContentType => this.Mock.HasFormContentType;

        public override IHeaderDictionary Headers => _headers;

        public override HostString Host
        {
            get => this.Mock.Host;
            set => this.Mock.Host = value;
        }

        public override HttpContext HttpContext => this.HttpContextMock;

        public override bool IsHttps
        {
            get => this.Mock.IsHttps;
            set => this.Mock.IsHttps = value;
        }

        public override string Method
        {
            get => this.Mock.Method;
            set => this.Mock.Method = value;
        }

        public override PathString Path
        {
            get => this.Mock.Path;
            set => this.Mock.Path = value;
        }

        public override PathString PathBase
        {
            get => this.Mock.PathBase;
            set => this.Mock.PathBase = value;
        }

        public override string Protocol
        {
            get => this.Mock.Protocol;
            set => this.Mock.Protocol = value;
        }

        public override IQueryCollection Query { get; set; }

        public override QueryString QueryString
        {
            get => this.Mock.QueryString;
            set => this.Mock.QueryString = value;
        }

        public override string Scheme
        {
            get => this.Mock.Scheme;
            set => this.Mock.Scheme = value;
        }

#if NETCOREAPP
        public override RouteValueDictionary RouteValues { get; set; }
#endif

        public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default) => this.Mock.ReadFormAsync(cancellationToken);

        internal void SetHeaders(IHeaderDictionary headers)
        {
            this._headers = headers;
            this.Mocks.Add(headers);
        }
    }
}