using HttpContextNSubstitute.Generic;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace HttpContextNSubstitute
{
    public class ResponseCookiesMock : IResponseCookies, IContextMock<IResponseCookies>
    {
        public ResponseCookiesMock()
        {
            this.Mock = Substitute.For<IResponseCookies>();
        }

        public IResponseCookies Mock { get; }

        public void Append(string key, string value) => this.Mock.Append(key, value);

        public void Append(string key, string value, CookieOptions options) => this.Mock.Append(key, value, options);

        public void Delete(string key) => this.Mock.Delete(key);

        public void Delete(string key, CookieOptions options) => this.Mock.Delete(key, options);
    }
}