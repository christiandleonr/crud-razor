using System.Threading.Tasks;
using crudnetcore.Models;
using crudnetcore.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crudnetcore.Pages.Books
{
    public class GetModel : PageModel
    {
        public int Id {get; set;}
        
        public string Title {get; set;}

        public string Description {get; set;}  

        private readonly IBookRepository _books;
        
        public GetModel(IBookRepository books)
        {
            _books = books;
        }

        public async Task<IActionResult> OnPost(Book bookIn)
        {
            var book = await _books.GetBook(bookIn.Id);

            if (book == null)
            {
                return NotFound();
            }

            Title = book.Title;
            Description = book.Description;

            return Page();
        }
    }
}