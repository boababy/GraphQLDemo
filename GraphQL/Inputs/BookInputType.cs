using GraphQL.Types;
namespace GraphQLDemo.GraphQL.Inputs
{
    public class BookInputType : InputObjectGraphType
    {
        public BookInputType()
        {
            Name = "BookInput";

            Field<NonNullGraphType<StringGraphType>>("title").Description("The title of the book.");
            Field<NonNullGraphType<StringGraphType>>("Author").Description("The Author of the book.");
            Field<NonNullGraphType<StringGraphType>>("Publisher").Description("The Publisher of the book.");
            Field<NonNullGraphType<IntGraphType>>("Price").Description("The Price of the book.");
            Field<NonNullGraphType<DescriptionInputType>>("Description").Description("The Description of the book.");
        }
    }
}
