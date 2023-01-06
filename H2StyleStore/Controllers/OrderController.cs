﻿using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Infrastructures.Repositories;
using H2StyleStore.Models.Services;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Controllers
{
    public class OrderController : Controller
    {
        private OrderService orderService;

		public OrderController()
        {
            var db = new AppDbContext();
            IOrderRepository repo = new OrderRepository(db);
            this.orderService = new OrderService(repo);
        }

        // GET: Order
        public ActionResult Index(string status)
        {
            ViewBag.Status = orderService.GetStatus();

            var data = orderService.Load()
                       .Select(x => x.ToVM());

            if (string.IsNullOrEmpty(status) == false)
            {
				data = data.Where(s => s.Status == status);
			}

			return View(data);
        }

        public ActionResult Details(int? id)
        {
			var data = orderService.FindById(id).Select(x => x.ToVM());
			if (id != null)
			{
				data = data.Where(od => od.Order_id == id);
			}

			return View(data);
        }
    }
}