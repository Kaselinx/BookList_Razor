using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookList_Razor.Model;

namespace BookList_Razor.Pages.BookList
{
    public class DetailModel : PageModel
    {
        private ApplicationDbContext _db;
        
        [BindProperty]
        public Book book { get; set; }

        public DetailModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            book = _db.Books.Find(id);
        }
    }
}