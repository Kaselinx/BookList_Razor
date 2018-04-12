using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookList_Razor.Model;
using Microsoft.EntityFrameworkCore;

namespace BookList_Razor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private ApplicationDbContext _db;
        public IEnumerable<Book> Books { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        /// <summary>
        /// Delete Data with data item
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var book = _db.Books.Find(Id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            Message = "資料刪除成功";
            return RedirectToPage();
        }
    }
}