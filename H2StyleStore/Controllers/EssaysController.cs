﻿using H2StyleStore.filter;
using H2StyleStore.Models;
using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace H2StyleStore.Controllers
{
	[AuthrizeHelper("1","3")]
	public class EssaysController : Controller
	{

		private EssayService essayService;
		private readonly IEssayRepository _essayRepository;
		private AppDbContext _db = new AppDbContext();

		public EssaysController()
		{
			var db = new AppDbContext();
			_essayRepository = new EssayRepository(db);
			IEssayRepository repo = new EssayRepository(db);
			this.essayService = new EssayService(repo);
		}
		// GET: Products
		public ActionResult Index(int? categoryId, string eTitle)
		{
			ViewBag.Categories = _essayRepository.GetCategoriesSelect(categoryId);
			ViewBag.EssayTitle = eTitle;
			var data = essayService.GetEssays().Select(x => x.ToVM());
			// 若有篩選categoryid
			if (categoryId.HasValue) data = data.Where(p => p.CategoryId == categoryId.Value);

			// 若有篩選 productName
			if (string.IsNullOrEmpty(eTitle) == false) data = data.Where(p => p.ETitle.Contains(eTitle));

			return View(data);
		}

		//public ActionResult UploadEssay()
		//{
		//	ViewBag.PCategoryItems = new EssayRepository(new AppDbContext()).GetCategories();
		//	return View();
		//}

		/// <summary>
		/// create essay
		/// </summary>
		/// <returns></returns>
		public ActionResult NewEssay()
		{
			ViewBag.VideoCategoriesItems = new EssayRepository(new AppDbContext()).GetCategories(null);
			return View();
		}

		[HttpPost]
		public ActionResult NewEssay(CreateEssayVM model, HttpPostedFileBase[] files)
		{

			ViewBag.VideoCategoriesItems = new EssayRepository(new AppDbContext()).GetCategories(null); ;

			//fill Remove, Upload properties value
			bool isDateTime = DateTime.TryParse(Request.Form["Upload"], out DateTime dt1);
			model.UpLoad = dt1;

			bool itDateTime = DateTime.TryParse(Request.Form["Removed"], out DateTime dt2);
			model.Removed = dt2;

			if (files[1] != null)
			{

				string path = Server.MapPath("/images/Essaysimage");
				var helper = new UploadFileHelper();

				if (model.Images == null) { model.Images = new List<string>(); }
				foreach (var file in files)
				{
					if (file == null)
					{
						continue;
					}
					try
					{
						string result = helper.SaveAs(path, file);
						//string OriginalFileName = System.IO.Path.GetFileName(file.FileName);
						string FileName = result;

						model.Images.Add($"../../Images/Essaysimage/{FileName}");
					}
					catch (Exception ex)
					{
						ModelState.AddModelError(string.Empty, "上傳檔案失敗: " + ex.Message);

					}
				}
			}


			try
			{
				CreateEssayDTO essayDTO = model.ToCreateDTO();
				(bool IsSuccess, string ErrorMessage) result = essayService.Create(essayDTO);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}


			if (ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}


			ViewBag.message = "Blog Datails Are Successfully..!";

			return View(model);
		}
		public ActionResult EditEssays(int id)
		{

			var data = essayService.GetEssay(id).ToCreateVM();
			var categories = new EssayRepository(new AppDbContext()).GetCategories(data.CategoryId).ToList();

			ViewBag.VideoCategories = categories;
			return View(data);
		}
		[HttpPost]
		public ActionResult EditEssays(CreateEssayVM model, HttpPostedFileBase[] files)
		{
			ViewBag.VideoCategories = new EssayRepository(new AppDbContext()).GetCategories(null);

			if (files[1] != null)
			{

				string path = Server.MapPath("/images/Essaysimage");
				var helper = new UploadFileHelper();

				if (model.Images == null) { model.Images = new List<string>(); }
				foreach (var file in files)
				{
					if (file == null)
					{
						continue;
					}
					try
					{
						string result = helper.SaveAs(path, file);
						//string OriginalFileName = System.IO.Path.GetFileName(file.FileName);
						string FileName = result;

						model.Images.Add($"../../Images/Essaysimage/{FileName}");
					}
					catch (Exception ex)
					{
						ModelState.AddModelError(string.Empty, "上傳檔案失敗: " + ex.Message);

					}
				}
			}


			try
			{
				CreateEssayDTO essayDTO = model.ToCreateDTO();
				(bool IsSuccess, string ErrorMessage) result = essayService.Edit(essayDTO);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError(string.Empty, ex.Message);
			}


			if (ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}


			return View(model);
		}

		public ActionResult Delete(int id)
		{

			essayService.Delete(id);

			return RedirectToAction("Index");
		}


	}
}