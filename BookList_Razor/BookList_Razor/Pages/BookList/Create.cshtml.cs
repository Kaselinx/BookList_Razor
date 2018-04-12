using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookList_Razor.Model;

namespace BookList_Razor.Pages.BookList
{
    public class CreateModel : PageModel
    {

        private ApplicationDbContext _db;
        [BindProperty]
        public Book book { get; set; }
        [TempData]
        public string Message { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            Message = "新資料增加成功!";
            return RedirectToPage("Index");
        }
    }
}