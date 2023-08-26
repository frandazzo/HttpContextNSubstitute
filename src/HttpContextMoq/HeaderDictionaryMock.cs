using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NSubstitute;

namespace HttpContextNSubstitute
{
    public class HeaderDictionaryMock : IHeaderDictionaryMock
    {
        public HeaderDictionaryMock()
        {
            this.Mock = Substitute.For<IHeaderDictionary>();
        }

        public IHeaderDictionary Mock { get; }

        public StringValues this[string key]
        {
            get => this.Mock[key];
            set => this.Mock[key] = value;
        }

        public long? ContentLength
        {
            get => this.Mock.ContentLength;
            set => this.Mock.ContentLength = value;
        }

        public ICollection<string> Keys => this.Mock.Keys;

        public ICollection<StringValues> Values => this.Mock.Values;

        public int Count => this.Mock.Count;

        public bool IsReadOnly => this.Mock.IsReadOnly;

        public void Add(string key, StringValues value) => this.Mock.Add(key, value);

        public void Add(KeyValuePair<string, StringValues> item) => this.Mock.Add(item);

        public void Clear() => this.Mock.Clear();

        public bool Contains(KeyValuePair<string, StringValues> item) => this.Mock.Contains(item);

        public bool ContainsKey(string key) => this.Mock.ContainsKey(key);

        public void CopyTo(KeyValuePair<string, StringValues>[] array, int arrayIndex) => this.Mock.CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator() => this.Mock.GetEnumerator();

        public bool Remove(string key) => this.Mock.Remove(key);

        public bool Remove(KeyValuePair<string, StringValues> item) => this.Mock.Remove(item);

        public bool TryGetValue(string key, out StringValues value) => this.Mock.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.Mock).GetEnumerator();
    }
}