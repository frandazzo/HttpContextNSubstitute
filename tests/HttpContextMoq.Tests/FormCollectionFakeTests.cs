using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Xunit;

namespace HttpContextNSubstitute.Tests;

public class FormCollectionFakeTests
{
    [Fact]
    public void Add_WhenFileWithName_ExpectGetFileName()
    {
        // Assert
        var target = new FormCollectionFake();

        const string fileName = "attachment";
        var file = Substitute.For<IFormFile>();
        file.Name.Returns(fileName);

        // Act
        target.FilesFake.Add(file);

        // Assert
        target.Files.GetFile(fileName).Should().NotBeNull();
    }

    [Fact]
    public void Add_WhenFilesWithSameName_ExpectHaveTwoFiles()
    {
        // Assert
        var target = new FormCollectionFake();

        const string fileName = "attachment";
        var file1 = Substitute.For<IFormFile>();
        file1.Name.Returns(fileName);
        var file2 = Substitute.For<IFormFile>();
        file2.Name.Returns(fileName);

        // Actv
        target.FilesFake.Add(file1);
        target.FilesFake.Add(file2);

        // Assert
        target.Files.GetFiles(fileName)
            .Should().NotBeNull()
            .And.HaveCount(2);
    }
}
