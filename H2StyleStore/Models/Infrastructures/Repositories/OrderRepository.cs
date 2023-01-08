﻿using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services.Interfaces;
using H2StyleStore.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly AppDbContext _db;

		public OrderRepository(AppDbContext db)
		{
			_db = db;
		}

		public void Update(OrderDTO entity)
		{
			Order order = _db.Orders.Find(entity.Order_id);

			order.Status = entity.Status;
			order.ShippedDate = entity.ShippedDate;

			_db.SaveChanges();
		}

		public IEnumerable<Order_DetailDTO> FindById(int? id)
		{
			IEnumerable<Order_Details> order_detail = _db.Order_Details;
			var data = order_detail.Select(od => od.ToDTO());
			
			return data;
		}

		public IEnumerable<SelectListItem> GetStatus()
		{

			Dictionary<int, string> source = new Dictionary<int, string>();
			source.Add(0, "待處理");
			source.Add(1, "備貨中");
			source.Add(2, "已出貨");
			source.Add(3, "已結案");
			source.Add(4, "已取消");
			var items = source.Select(x => new SelectListItem
			{
				Value = x.Value,
				Text = x.Value,
			})
			.ToList()
			.Prepend(new SelectListItem { Value = string.Empty, Text = "所有" });

			return items;
		}

		public IEnumerable<OrderDTO> Load()
		{
			IEnumerable<Order> orders = _db.Orders;
			var data = orders.Select(o => o.ToDTO());

			return data;
		}

	}
}