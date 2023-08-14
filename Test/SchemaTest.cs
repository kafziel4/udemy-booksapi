using BooksApi.GraphQL;
using BooksApi.Services;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Snapshooter.Xunit;

namespace Test
{
    public class SchemaTest
    {
        [Fact]
        public async Task GenerateSchema_MatchesExistingSnapshot()
        {
            // Arrange
            var schema = await new ServiceCollection()
                .AddSingleton<Repository>()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .BuildSchemaAsync();

            // Act & Assert
            schema.ToString().MatchSnapshot();
        }
    }
}
