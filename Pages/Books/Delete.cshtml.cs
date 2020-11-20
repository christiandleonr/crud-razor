using System.Threading.Tasks;
using crudnetcore.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crudnetcore.Pages.Books
{
    public class DeleteModel : PageModel
    {
        public int Id {get; set;}
        
        public string Title {get; set;}

        public string Description {get; set;}  

        private readonly IBookRepository _books;

        public DeleteModel(IBookRepository books)
        {
            _books = books;
        }

        public async Task<IActionResult> OnPost(int id)
        {
            var book = await _books.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            await _books.DeleteBook(id);

            Title = book.Title;

            return Page();
        }
    }
}