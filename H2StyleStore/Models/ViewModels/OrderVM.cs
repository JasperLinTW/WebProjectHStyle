﻿using H2StyleStore.Models.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.ViewModels
{
	public class OrderVM
	{
		[DisplayName("訂單編號")]
		public int Order_id { get; set; }

		[DisplayName("會員編號")]
		public int Member_id { get; set; }

		[DisplayName("員工編號")]
		public int Employee_id { get; set; }

		[DisplayName("總額")]
		public int Total { get; set; }

		[DisplayName("付款金額")]
		public int Payment { get; set; }

		[DisplayName("出貨時間")]
		public DateTime? ShippedDate { get; set; }

		[DisplayName("配送方式")]
		public string ShipVia { get; set; }

		[DisplayName("運費")]
		public int Freight { get; set; }

		[Required]
		[StringLength(10)]
		[DisplayName("收件人")]
		public string ShipName { get; set; }

		[Required]
		[StringLength(60)]
		[DisplayName("寄送地址")]
		public string ShipAddress { get; set; }

		[Required]
		[StringLength(10)]
		[DisplayName("收件人電話")]
		public string ShipPhone { get; set; }

		[DisplayName("退貨時間")]
		public DateTime? RequestRefundTime { get; set; }

		[DisplayName("退貨")]
		public bool RequestRefund { get; set; }

		[DisplayName("訂單日期")]
		public DateTime CreatedTime { get; set; }
		[DisplayName("訂單狀態")]
		public int Status { get; set; }

		public IEnumerable<Order_DetailsVM> Order_Details { get; set; }

	}

	public static class OrderDTOExts
	{
		public static OrderVM ToVM(this OrderDTO source)
		{
			return new OrderVM
			{
				Order_id = source.Order_id,
				Member_id = source.Member_id,
				Employee_id = source.Employee_id,
				Total = source.Total,
				Payment = source.Payment,
				ShippedDate = source.ShippedDate,
				ShipVia = source.ShipVia,
				Freight = source.Freight,
				ShipName = source.ShipName,
				ShipAddress = source.ShipAddress,
				ShipPhone = source.ShipPhone,
				RequestRefundTime = source.RequestRefundTime,
				RequestRefund = source.RequestRefund,
				CreatedTime = source.CreatedTime,
				Status = source.Status,
			};
		}
	}
}