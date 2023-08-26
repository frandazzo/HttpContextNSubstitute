using System;
using System.IO;
using System.Threading.Tasks;
using HttpContextMoq.Generic;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace HttpContextMoq
{
    public class HttpResponseMock : HttpResponse, IContextMocks<HttpResponse>
    {
        private HttpContextMock _httpContextMock;
        private IHeaderDictionary _headers;
        private IResponseCookies _cookies;

        public HttpResponseMock(HttpContextMock httpContextMock)
        {
            this.Mock = Substitute.For<HttpResponse>();
            this.Mocks = new MockCollection(this);
            this.HttpContextMock = httpContextMock;
            this.HeadersMock = new HeaderDictionaryMock();
            this.CookiesMock = new ResponseCookiesMock();
        }

        public HttpResponse Mock { get; }

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
                this._headers = value;
                this.Mocks.Add(value);
            }
        }

        public ResponseCookiesMock CookiesMock
        {
            get => _cookies as ResponseCookiesMock;
            set
            {
                _cookies = value;
                this.Mocks.Add(value);
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

        public override IResponseCookies Cookies => _cookies;

        public override bool HasStarted => this.Mock.HasStarted;

        public override IHeaderDictionary Headers => _headers;

        public override HttpContext HttpContext => this.HttpContextMock;

        public override int StatusCode
        {
            get => this.Mock.StatusCode;
            set => this.Mock.StatusCode = value;
        }

        internal void SetHeaders(IHeaderDictionary headers)
        {
            this._headers = headers;
            this.Mocks.Add(headers);
        }

        public override void OnCompleted(Func<Task> callback) => this.Mock.OnCompleted(callback);

        public override void OnCompleted(Func<object, Task> callback, object state) => this.Mock.OnCompleted(callback, state);

        public override void OnStarting(Func<Task> callback) => this.Mock.OnStarting(callback);

        public override void OnStarting(Func<object, Task> callback, object state) => this.Mock.OnStarting(callback, state);

        public override void Redirect(string location) => this.Mock.Redirect(location);

        public override void Redirect(string location, bool permanent) => this.Mock.Redirect(location, permanent);

        public override void RegisterForDispose(IDisposable disposable) => this.Mock.RegisterForDispose(disposable);
    }
}