using System;
using FluentAssertions;
using HttpContextNSubstitute.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using NSubstitute;
namespace HttpContextNSubstitute.Samples;

public class RequestServicesSamples
{
    [Fact]
    public void RequestService()
    {
        // Assert
        var context = new HttpContextMock();

        // Act
        context.RequestServicesMock.GetService(typeof(RequestServicesSamples)).Returns(new RequestServicesSamples());

        // Assert
        context.RequestServices.GetRequiredService<RequestServicesSamples>().Should().NotBeNull();
        Assert.Throws<InvalidOperationException>(() => context.RequestServices.GetRequiredService<object>());
    }

    [Fact]
    public void RequestService_ExtensionInstance()
    {
        // Assert
        var context = new HttpContextMock();

        // Act
        context.SetupRequestService(new RequestServicesSamples());

        // Assert
        context.RequestServices.GetRequiredService<RequestServicesSamples>().Should().NotBeNull();
        Assert.Throws<InvalidOperationException>(() => context.RequestServices.GetRequiredService<object>());
    }

    [Fact]
    public void RequestService_ExtensionFactory()
    {
        // Assert
        var context = new HttpContextMock();

        // Act
        context.SetupRequestService(new RequestServicesSamples());

        // Assert
        context.RequestServices.GetRequiredService<RequestServicesSamples>().Should().NotBeNull();
        Assert.Throws<InvalidOperationException>(() => context.RequestServices.GetRequiredService<object>());
    }
}
