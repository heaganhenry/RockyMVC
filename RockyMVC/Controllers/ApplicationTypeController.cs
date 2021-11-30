using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RockyMVC.Data;
using RockyMVC.Models;

namespace RockyMVC.Controllers
{
	public class ApplicationTypeController : Controller
	{
		private readonly ApplicationDbContext _db;

		public ApplicationTypeController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<ApplicationType> objList = _db.ApplicationTypes;
			return View(objList);
		}

		//GET - Create
		public IActionResult Create()
		{
			return View();
		}

		//POST - Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(ApplicationType obj)
		{
			_db.ApplicationTypes.Add(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
