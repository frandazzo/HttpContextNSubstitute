using System.Collections;
using System.Collections.Generic;
using HttpContextNSubstitute.Generic;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace HttpContextNSubstitute
{
    public class FormFileCollectionMock : IFormFileCollection, IContextMock<IFormFileCollection>
    {
        public FormFileCollectionMock()
        {
            this.Mock = Substitute.For<IFormFileCollection>();
        }

        public IFormFileCollection Mock { get; }

        public IFormFile this[string name] => this.Mock[name];

        public IFormFile this[int index] => this.Mock[index];

        public int Count => this.Mock.Count;

        public IEnumerator<IFormFile> GetEnumerator() => this.Mock.GetEnumerator();

        public IFormFile GetFile(string name) => this.Mock.GetFile(name);

        public IReadOnlyList<IFormFile> GetFiles(string name) => this.Mock.GetFiles(name);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.Mock).GetEnumerator();
    }
}