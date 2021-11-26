using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RockyMVC.Data;
using RockyMVC.Models;

namespace RockyMVC.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Category> objList = _db.Categories;
			return View(objList);
		}

		//GET - CREATE
		public IActionResult Create()
		{
			return View();
		}
	}
}
