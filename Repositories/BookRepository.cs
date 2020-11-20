using System.Threading.Tasks;
using crudnetcore.Models;
using crudnetcore.Repositories.IRepositories;
using MongoDB.Driver;
using crudnetcore.Services;

namespace crudnetcore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;

        public BookRepository(IBooksDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>("Book");
        }

        public async Task CreateBook(Book book)
        {
            await _books.InsertOneAsync(book);
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await _books.Find(book => book.Id == id).FirstOrDefaultAsync();

            return book;
        }

        public async Task<Book> UpdateBook(Book bookIn)
        {
            await _books.ReplaceOneAsync(book => book.Id == bookIn.Id, bookIn);

            var book = await _books.Find(book => book.Id == bookIn.Id).FirstOrDefaultAsync();

            return book;
        }

        public async Task DeleteBook(int id)
        {
            await _books.DeleteOneAsync(book => book.Id == id);
        }
    }
}