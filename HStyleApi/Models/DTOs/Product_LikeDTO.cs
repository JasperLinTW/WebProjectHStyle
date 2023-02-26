﻿using HStyleApi.Models.EFModels;

namespace HStyleApi.Models.DTOs
{
	public class Product_LikeDTO
	{
		public int ProductId { get; set; }
		public int MemberId { get; set; }
		public string ProductName { get; set; }
		public int UnitPrice { get; set; }
		public string Images { get; set; }
	}

	public static class Product_LikeEtxs
	{
		public static Product_LikeDTO ToDto(this ProductLike source)
		{
			return new Product_LikeDTO
			{
				ProductId = source.ProductId,
				MemberId = source.MemberId,
				ProductName = source.Product.ProductName,
				UnitPrice = source.Product.UnitPrice,
				Images = source.Product.Imgs.Select(x => x.Path).ToList()[0],
			};
		}
	}
}
