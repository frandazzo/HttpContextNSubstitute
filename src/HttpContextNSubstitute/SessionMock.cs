using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HttpContextNSubstitute.Generic;
using Microsoft.AspNetCore.Http;
using NSubstitute;

namespace HttpContextNSubstitute
{
    public class SessionMock : ISession, IContextMock<ISession>
    {
        public ISession Mock => Substitute.For<ISession>();

        public string Id => Mock.Id;

        public bool IsAvailable => Mock.IsAvailable;

        public IEnumerable<string> Keys => Mock.Keys;


        public void Clear() => Mock.Clear();

        public Task CommitAsync(CancellationToken cancellationToken = default) => Mock.CommitAsync(cancellationToken);

        public Task LoadAsync(CancellationToken cancellationToken = default) => Mock.LoadAsync(cancellationToken);

        public void Remove(string key) => Mock.Remove(key);

        public void Set(string key, byte[] value) => Mock.Set(key, value);

        public bool TryGetValue(string key, out byte[] value) => Mock.TryGetValue(key, out value);
    }
}
