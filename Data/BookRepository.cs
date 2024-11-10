using GraphQLDemo.Models;

namespace GraphQLDemo.Data
{
    public class BookRepository
    {
        private readonly List<Book> Books = new()
        {
            new Book{
                Id = 1,
                Title = "C# Programming",
                Author = "Houka Tei",
                Publisher = "PAC",
                Price= 100,
                Description = new Description{Detail="A book about C# programming",RecommendedReason="Easy to understand"}
            },
            new Book{
                Id = 2,
                Title = "Java Programming",
                Author = "Baoxia Zheng",
                Publisher = "PAC",
                Price = 888,
                Description = new Description { Detail = "A book about Java programming",RecommendedReason="Friendly for Beginner" }
            },
            new Book{
                Id = 3,
                Title = "Python Programming",
                Author = "Boa Zheng",
                Publisher = "PAC",
                Price= 999,
                Description = new Description { Detail = "A book about Python programming",RecommendedReason=""  }
            },
            new Book
            {
                Id = 4,
                Title = "What is GraphQL",
                Author = "Baoxia Zheng",
                Publisher = "PAC",
                Price= 1000,
                Description = new Description { Detail = "A book about GraphQL" }
            }
        };

        public IEnumerable<Book> GetAllBooks()
        {
            return Books;
        }

        public Book? GetBookById(int id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }

        public int GetNextId()
        {
            return Books.Max(b => b.Id) + 1;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void UpdateBook(int id, Book book)
        {
            var existingBook = GetBookById(id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Publisher = book.Publisher;
                existingBook.Price = book.Price;

                if (book.Description != null)
                {
                    existingBook.Description.Detail = book.Description.Detail;
                    existingBook.Description.RecommendedReason = book.Description.RecommendedReason;
                }
            }
        }

        public bool DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                Books.Remove(book);
                return true;
            }

            return false;
        }

        //    query {
        //      book(id: 1)
        //    {
        //        title
        //        author
        //        publisher
        //        price
        //        description {
        //            detail
        //            recommendedReason
        //        }
        //    }
        //}


        //    query {
        //  books {
        //    id
        //    title
        //    author
        //    publisher
        //    price
        //    description
        //    {
        //        detail
        //      recommendedReason
        //    }
        //}
        //}


        //        mutation {
        //  addBook(book: {
        //        title: "PAC LT",
        //    author: "PAC",
        //    publisher: "PAC",
        //    price: 999,
        //    description:
        //            {
        //            detail: "PACのエンジニアが語る今どきの技術",
        //      recommendedReason: "無駄な話がない"
        //    }
        //        }) {
        //    id
        //    title
        //    author
        //    description
        //        {
        //            detail
        //      recommendedReason
        //        }
        //    }
        //}

        //        mutation {
        //  updateBook(id: 1, book: {
        //        title: "Advanced C# Programming",
        //    author: "Houka Tei",
        //    publisher: "PAC Press",
        //    price: 1500,
        //    description:
        //            {
        //            detail: "C# for advanced users.",
        //      recommendedReason: "Highly recommended for C# professionals."
        //    }
        //        }) {
        //    id
        //    title
        //    author
        //    publisher
        //    price
        //    description
        //        {
        //            detail
        //      recommendedReason
        //        }
        //    }
        //}

        //mutation {
        //  deleteBook(id: 1)
        //}

    }
}
