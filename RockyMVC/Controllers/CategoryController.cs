﻿using System;
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

		//POST - CREATE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category obj)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(obj);
		}

		//GET - EDIT
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var obj = _db.Categories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		//POST - EDIT
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(obj);
		}

		//GET - DELETE
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var obj = _db.Categories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		//POST - DELETE
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{
			var obj = _db.Categories.Find(id);
			if (obj == null)
				return NotFound();

			_db.Categories.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
