using GraphQL;
using GraphQL.Types;
using GraphQLDemo.Data;
using GraphQLDemo.GraphQL.Types;

namespace GraphQLDemo.GraphQL.Queries
{
    public class BookQuery : ObjectGraphType
    {
        public BookQuery(BookRepository repository)
        {
            Field<ListGraphType<BookType>>("books")
                .Description("List of books")
                .Resolve(context => repository.GetAllBooks())
            ;

            Field<BookType>("book")
                .Description("Get a book by id")
                .Argument<NonNullGraphType<IntGraphType>>(
                "id",
                "Book id"
                )
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    return repository.GetBookById(id);
                });
        }
    }
}