using GraphQL.Types;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQL.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(x => x.Id).Description("Book id");
            Field(x => x.Title).Description("Book Title");
            Field(x => x.Author).Description("Book Author");
            Field(x => x.Publisher).Description("Book Publisher");
            Field(x => x.Price).Description("Book Price");
            Field(x => x.Description).Description("Book Description");
        }
    }
}
