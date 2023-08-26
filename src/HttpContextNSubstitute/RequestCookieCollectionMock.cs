using System.Collections;
using System.Collections.Generic;
using HttpContextNSubstitute.Generic;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace HttpContextNSubstitute
{
    public class RequestCookieCollectionMock : IRequestCookieCollection, IContextMock<IRequestCookieCollection>
    {
        public RequestCookieCollectionMock()
        {
            this.Mock = Substitute.For<IRequestCookieCollection>();
        }

        public IRequestCookieCollection Mock { get; }

        public string this[string key] => this.Mock[key];

        public int Count => this.Mock.Count;

        public ICollection<string> Keys => this.Mock.Keys;

        public bool ContainsKey(string key) => this.Mock.ContainsKey(key);

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => this.Mock.GetEnumerator();

        public bool TryGetValue(string key, out string value) => this.Mock.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.Mock).GetEnumerator();
    }
}