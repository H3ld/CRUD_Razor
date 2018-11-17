using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Razor.Pages.BookList
{
    public class CreateModel : PageModel
    {

		private readonly ApplicationDbContext _db;

		public CreateModel(ApplicationDbContext db) 
		{
			_db = db;
		}

		[BindProperty]
		public Book Book { get; set; }

		public void OnGet()
        {

        }	

		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid) 
			{
				return Page();
			}

			// Adding Book to Context
			_db.Books.Add(Book);

			// Saving Changes in Context to Database asynchronosly
			await _db.SaveChangesAsync();

			// Redirecting IndexPage
			return RedirectToPage("Index");
		}
    }
}