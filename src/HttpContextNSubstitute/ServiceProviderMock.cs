using System;
using HttpContextNSubstitute.Generic;
using NSubstitute;

namespace HttpContextNSubstitute
{
    public class ServiceProviderMock : IServiceProvider, IContextMock<IServiceProvider>
    {
        public ServiceProviderMock()
        {
            this.Mock = Substitute.For<IServiceProvider>();
        }

        public IServiceProvider Mock { get; }

        public object GetService(Type serviceType) => this.Mock.GetService(serviceType);
    }
}