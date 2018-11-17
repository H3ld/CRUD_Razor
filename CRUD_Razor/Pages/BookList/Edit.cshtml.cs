﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Razor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Razor.Pages.BookList
{
    public class EditModel : PageModel
    {
		private readonly ApplicationDbContext _db;
		
		public EditModel(ApplicationDbContext db)
		{
			_db = db;
		}

		[BindProperty]
		public Book Book { get; set; }

		[TempData]
		public string Message { get; set; }

        public void OnGet(int id)
        {
			Book = _db.Books.Find(id);
        }

		public async Task<IActionResult> OnPost()
		{
			if(ModelState.IsValid)
			{
				var BookFromDb = _db.Books.Find(Book.Id);
				BookFromDb.Name = Book.Name;
				BookFromDb.Author = Book.Author;
				BookFromDb.Isbn = Book.Isbn;

				await _db.SaveChangesAsync();
				Message = "Book has been updated succesfully";

				return RedirectToPage("Index");
			}
			return RedirectToPage();
		}
    }
}