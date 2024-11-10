using GraphQL.Types;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQL.Inputs
{
    public class DescriptionInputType : InputObjectGraphType<Description>
    {
        public DescriptionInputType()
        {
            Name = "DescriptionInput";
            Field<StringGraphType>("detail");
            Field<StringGraphType>("recommendedReason");
        }
    }
}
