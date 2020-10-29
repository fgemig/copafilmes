using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace CopaFilmes.Testes.Integracao.Helpers
{
    public static class MockMemoryCache
    {
        public static IMemoryCache GetMemoryCache(object expectedValue)
        {
            var memoryCache = Mock.Of<IMemoryCache>();
            var cacheEntry = Mock.Of<ICacheEntry>();

            var memoryCacheMock = Mock.Get(memoryCache);

            memoryCacheMock
                .Setup(m => m.CreateEntry(It.IsAny<object>()))
                .Returns(cacheEntry);

            return memoryCacheMock.Object;
        }
    }
}
