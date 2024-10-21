using GraphQL.Types;
using GraphQLDemo.GraphQL.Queries;
using GraphQLDemo.GraphQL.Mutations;

namespace GraphQLDemo.GraphQL
{
    public class BookSchema : Schema
    {
        public BookSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<BookQuery>();
            Mutation = provider.GetRequiredService<BookMutation>();
        }
    }
}
