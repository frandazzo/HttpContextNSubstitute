using System.Collections;
using System.Collections.Generic;
using HttpContextNSubstitute.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using NSubstitute;

namespace HttpContextNSubstitute
{
    public class FormCollectionMock : IFormCollection, IContextMocks<IFormCollection>
    {
        private IFormFileCollection _files;

        public FormCollectionMock()
        {
            this.Mock = Substitute.For<IFormCollection>();
            this.Mocks = new MockCollection(this);
            this.FilesMock = new FormFileCollectionMock();
        }

        public IFormCollection Mock { get; }

        public MockCollection Mocks { get; }

        public FormFileCollectionMock FilesMock
        {
            get => _files as FormFileCollectionMock;
            set
            {
                _files = value;
                this.Mocks.Add(value);
            }
        }

        public StringValues this[string key] => this.Mock[key];

        public int Count => this.Mock.Count;

        public IFormFileCollection Files => _files;

        public ICollection<string> Keys => this.Mock.Keys;

        public bool ContainsKey(string key) => this.Mock.ContainsKey(key);

        public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator() => this.Mock.GetEnumerator();

        public bool TryGetValue(string key, out StringValues value) => this.Mock.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.Mock).GetEnumerator();
    }
}