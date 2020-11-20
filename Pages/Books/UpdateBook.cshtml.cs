using System.Threading.Tasks;
using crudnetcore.Models;
using crudnetcore.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crudnetcore.Pages.Books
{
    public class UpdateModel : PageModel
    {
        public int Id {get; set;}
        
        public string Title {get; set;}

        public string Description {get; set;}  

        private readonly IBookRepository _books;

        public UpdateModel(IBookRepository books)
        {
            _books = books;
        }

        public async Task<IActionResult> OnPost(Book book)
        {
            await _books.UpdateBook(book);

            Title = book.Title;
            Description = book.Description;

            return Page();
        }

    }
}