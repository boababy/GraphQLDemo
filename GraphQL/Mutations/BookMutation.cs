using GraphQL;
using GraphQL.Types;
using GraphQLDemo.Data;
using GraphQLDemo.GraphQL.Inputs;
using GraphQLDemo.GraphQL.Types;
using GraphQLDemo.Models;

namespace GraphQLDemo.GraphQL.Mutations
{
    public class BookMutation : ObjectGraphType
    {
        public BookMutation(BookRepository repository)
        {
            Name = "Mutation";
            Description = "The root mutation for books.";

            Field<BookType>()
                .Name("addBook") // mothod name
                .Description("add book")
                .Argument<NonNullGraphType<BookInputType>>("book")
                .Resolve(context =>
                {
                    var bookInput = context.GetArgument<Book>("book");
                    var newBook = new Book
                    {
                        Id = repository.GetNextId(),
                        Title = bookInput.Title,
                        Author = bookInput.Author,
                        Publisher = bookInput.Publisher,
                        Price = bookInput.Price,
                        Description = new Description
                        {
                            Detail = bookInput.Description?.Detail,
                            RecommendedReason = bookInput.Description?.RecommendedReason
                        }
                    };

                    repository.AddBook(newBook);
                    return newBook;
                });

            // Bookを更新するフィールド
            Field<BookType>()
                .Name("updateBook")
                .Description("Updates an existing book.")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Argument<NonNullGraphType<BookInputType>>("book")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    var bookInput = context.GetArgument<Book>("book");
                    var existingBook = repository.GetBookById(id);
                    if (existingBook == null)
                    {
                        context.Errors.Add(new ExecutionError("Book not found."));
                        return null;
                    }

                    existingBook.Title = bookInput.Title;
                    existingBook.Author = bookInput.Author;
                    existingBook.Publisher = bookInput.Publisher;
                    existingBook.Price = bookInput.Price;
                    existingBook.Description.Detail = bookInput.Description?.Detail;
                    existingBook.Description.RecommendedReason = bookInput.Description?.RecommendedReason;

                    repository.UpdateBook(id, existingBook);
                    return existingBook;
                });

            // Bookを削除するフィールド
            Field<BooleanGraphType>()
                .Name("deleteBook")
                .Description("Deletes a book by its ID.")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(context =>
                {
                    var id = context.GetArgument<int>("id");
                    var success = repository.DeleteBook(id);
                    if (!success)
                    {
                        context.Errors.Add(new ExecutionError("Book not found."));
                    }
                    return success;
                });
        }
    }
}
