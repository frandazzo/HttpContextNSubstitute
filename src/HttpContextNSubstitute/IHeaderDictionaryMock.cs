using HttpContextNSubstitute.Generic;
using Microsoft.AspNetCore.Http;

namespace HttpContextNSubstitute
{
    public interface IHeaderDictionaryMock : IHeaderDictionary, IContextMock<IHeaderDictionary>
    {
    }
}
