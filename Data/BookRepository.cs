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
                Description = "A book about C# programming"
            },
            new Book{
                Id = 2,
                Title = "Java Programming",
                Author = "Baoxia Zheng",
                Description = "A book about Java programming"
            },
            new Book{
                Id = 3,
                Title = "Python Programming",
                Author = "Boa Zheng",
                Description = "A book about Python programming"
            },
            new Book
            {
                Id = 4,
                Title = "What is GraphQL",
                Author = "Baoxia Zheng",
                Description = "A book about GraphQL"
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
                existingBook.Description = book.Description;
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

        //        query {
        //  books {
        //    id
        //    title
        //    author
        //    description
        //  }
        //}

        //query {
        //  book(id: 1) {
        //    id
        //    title
        //    author
        //    description
        //  }
        //}

        //mutation {
        //  addBook(book: { title: "新しい本", author: "新しい著者", description: "新しい説明" }) {
        //    id
        //    title
        //    author
        //    description
        //  }
        //}

        //mutation {
        //  updateBook(id: 1, book: { title: "更新された本", author: "更新された著者", description: "更新された説明" }) {
        //    id
        //    title
        //    author
        //    description
        //  }
        //}

        //mutation {
        //  deleteBook(id: 1)
        //}

    }
}
