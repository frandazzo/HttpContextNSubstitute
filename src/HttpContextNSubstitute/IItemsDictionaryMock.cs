using System.Collections.Generic;
using HttpContextNSubstitute.Generic;

namespace HttpContextNSubstitute
{
    public interface IItemsDictionaryMock : IDictionary<object, object>, IContextMock<IDictionary<object, object>>
    {
    }
}
