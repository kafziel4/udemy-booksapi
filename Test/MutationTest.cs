using BooksApi.GraphQL;
using BooksApi.Services;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;

namespace Test
{
    public class MutationTest
    {
        [Fact]
        public async Task AddAuthor_PerformMutation_NoError()
        {
            // Arrange
            var query = @"mutation addAuthor {
                              addAuthor(input: { name: ""Tolkien"" }) {
                                record {
                                  id
                                  name
                                }
                                error
                              }
                            }";

            var request = QueryRequestBuilder.New()
            .SetQuery(query)
            .Create();

            var graphQlServer = new ServiceCollection()
                .AddSingleton<Repository>()
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

            // Act
            var response = await graphQlServer.ExecuteRequestAsync(request);

            // Assert
            Assert.Null(response.ExpectQueryResult().Errors);
        }
    }
}