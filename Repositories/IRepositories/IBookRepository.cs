using System.Threading.Tasks;
using crudnetcore.Models;

namespace crudnetcore.Repositories.IRepositories
{
    public interface IBookRepository
    {
        Task CreateBook(Book book);

        Task<Book> GetBook(int id);

        Task<Book> UpdateBook(Book bookIn);

        Task DeleteBook(int id);
    }
}