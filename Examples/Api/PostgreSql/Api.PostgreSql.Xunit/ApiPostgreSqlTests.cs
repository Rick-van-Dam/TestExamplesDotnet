using Api.PostgreSql.Sut;
using Api.PostgreSql.Xunit.TestSetup;

namespace Api.PostgreSql.Xunit;

public class ApiPostgreSqlTests
{
    private readonly ApiPostgreSqlSut _sut;

    public ApiPostgreSqlTests(ApiPostgreSqlSut sut)
    {
        _sut = sut;
    }

    [Fact]
    public async Task GetBlogs_ShouldReturnExpectedBlogs()
    {
        //Arrange
        _sut.SeedData(context =>
        {
            context.Blogs.Add(new Blog
            {
                Url = "https://blog.photogrammer.net/"
            });
        });

        //Act
        var result = await _sut.CreateClient().GetFromJsonAsync<Blog[]>("blogs", cancellationToken: TestContext.Current.CancellationToken);

        //Assert
        result.Should().BeEquivalentTo(new[]
        {
            new
            {
                Url = "https://blog.photogrammer.net/"
            }
        });
    }
}
