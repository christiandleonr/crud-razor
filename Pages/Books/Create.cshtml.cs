using System.Threading.Tasks;
using crudnetcore.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using crudnetcore.Models;

namespace crudnetcore.Pages.Books
{
    public class CreateModel : PageModel
    {
        public int Id {get; set;}
        
        public string Title {get; set;}

        public string Description {get; set;}  

        private readonly IBookRepository _books;

        public CreateModel(IBookRepository books)
        {
            _books = books;
        }

        public async Task<IActionResult> OnPost(Book book)
        {
            await _books.CreateBook(book);

            return Page();
        }
    }
}