﻿using HStyleApi.Models.EFModels;

namespace HStyleApi.Models.DTOs
{
	public class ProductDto
	{
		public int Product_Id { get; set; }

		public string Product_Name { get; set; }

		public int UnitPrice { get; set; }

		public string Description { get; set; }

		public DateTime Create_at { get; set; }

		public bool Discontinued { get; set; }

		public int DisplayOrder { get; set; }

		public string PCategoryName { get; set; }

		public IEnumerable<string> imgs { get; set; }

		public IEnumerable<SpecDto> specs { get; set; }
		public IEnumerable<string> tags { get; set; }
	}

	public static class ProductExts
	{
		public static ProductDto ToDto(this Product source)
		=> new ProductDto
		{
			Product_Id = source.ProductId,
			Product_Name = source.ProductName,
			UnitPrice = source.UnitPrice,
			Description = source.Description,
			Create_at = source.CreateAt,
			Discontinued = source.Discontinued,
			DisplayOrder = source.DisplayOrder,
			PCategoryName = source.Category.PcategoryName,
			imgs = source.Imgs.Select(x => x.Path),
			specs = source.Specs.Select(x => x.ToDto()),
			tags = source.Tags.Select(x => x.TagName),

		};
	}
}
