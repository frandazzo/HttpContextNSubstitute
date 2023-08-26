using System.Collections;
using System.Collections.Generic;
using HttpContextNSubstitute.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NSubstitute;

namespace HttpContextNSubstitute
{
    public class QueryCollectionMock : IQueryCollection, IContextMock<IQueryCollection>
    {
        public QueryCollectionMock()
        {
            this.Mock = Substitute.For<IQueryCollection>();
        }

        public IQueryCollection Mock { get; }

        public StringValues this[string key] => this.Mock[key];

        public int Count => this.Mock.Count;

        public ICollection<string> Keys => this.Mock.Keys;

        public bool ContainsKey(string key) => this.Mock.ContainsKey(key);

        public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator() => this.Mock.GetEnumerator();

        public bool TryGetValue(string key, out StringValues value) => this.Mock.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.Mock).GetEnumerator();
    }
}