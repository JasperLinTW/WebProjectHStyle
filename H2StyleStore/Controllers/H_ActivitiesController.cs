﻿using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace H2StyleStore.Controllers
{
	public class H_ActivitiesController : Controller
	{
		private H_ActivityService _hActivitiesService;

		public H_ActivitiesController()
		{
			var db = new AppDbContext();
			IH_ActivityRepository repo = new H_ActivityRepository(db);
			_hActivitiesService = new H_ActivityService(repo);
		}

		// GET: H_Activities
		public ActionResult Index(string activityName)
		{
			ViewBag.ActivityName = activityName;

			var data = _hActivitiesService.GetHActivity().Select(a => a.ToVM());
			if (string.IsNullOrEmpty(activityName) == false) data = data
					.Where(a => a.Activity_Name
					.Contains(activityName));

			return View(data);
		}
		public ActionResult Describe()
		{
			return View();
		}

		//[HttpPut]
		//public async Task<string> PutActivity(int id, H_ActivityDto hDto)
		//{
		//	if (id != hDto.H_Activity_Id) return "欲修改的活動紀錄不存在";

		//	//H_ActivityDto activity = _hActivitiesService.GetHActivity()
		//	//	.Where(a => a.H_Activity_Id == id);



		//	return View();
		//}
	}
}