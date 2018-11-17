using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Razor.Model
{
	public class Book
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string Author { get; set; }
		public string Isbn { get; set; }
	}
}
