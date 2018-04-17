using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookList_Razor.Model;

namespace BookList_Razor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book book{get;set;}
        [TempData]
        public string Message { get; set; }
       
        
        public void OnGet(int id)
        {
            book = _db.Books.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookInDB = _db.Books.Find(book.Id);
                BookInDB.ISBN = book.ISBN;
                BookInDB.Price = book.Price;
                BookInDB.Author = book.Author;
                BookInDB.Title = book.Title;
                BookInDB.Avaibility = book.Avaibility;
                await _db.SaveChangesAsync();
                Message = "更新成功";
                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}