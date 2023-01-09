﻿using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using H2StyleStore.Models.ViewModels;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _db;
		public ProductRepository(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<ProductDto> GetProducts()
		{
			IEnumerable<Product> query = _db.Products;
				//.Include("PCategory");
			
			query = query.OrderBy(x => x.DisplayOrder);

			return query.Select(x => x.ToDto());
		}

		public IEnumerable<SelectListItem> GetCategories()
		{
			var data = _db.PCategories;

			
			foreach (var item in data)
			{
				yield return new SelectListItem { Value = item.PCategory_Id.ToString(), Text = item.PCategoryName };
				
			}
			
		}

		public bool IsExist(string productName)
		{
			var product = _db.Products.SingleOrDefault(x => x.Product_Name == productName);
			return (product != null);
		}

		public void Create(ProductDto dto)
		{
			int.TryParse(dto.PCategoryName, out int catgoryId);
			Product product = new Product
			{
				Product_Name = dto.Product_Name,
				UnitPrice = dto.UnitPrice,
				Description = dto.Description,
				Create_at = DateTime.Now,
				Discontinued = dto.Discontinued,
				DisplayOrder = dto.DisplayOrder,
				Category_Id = catgoryId,
			};
			_db.Products.Add(product);
			

			
			//b.Images.Add();
			//_db.Tags.Add()
			_db.SaveChanges();


		}
		public void Create(CreateProductDto dto)
		{
			Product product = new Product
			{
				Product_Name = dto.Product_Name,
				UnitPrice = dto.UnitPrice,
				Description = dto.Description,
				Create_at = DateTime.Now,
				Discontinued = dto.Discontinued,
				DisplayOrder = dto.DisplayOrder,
				Category_Id = dto.Category_Id,
			};
			_db.Products.Add(product);

			

			foreach(string tag in dto.tags)
			{
				var tags = _db.Tags.Select(x => x.TagName).ToList();
				if(tags.Contains(tag) == false) 
				{	
					Tag newTag = new Tag { TagName= tag };
					product.Tags.Add(newTag);
				}
				else
				{
					Tag oldTag =_db.Tags.Where(x => x.TagName == tag).FirstOrDefault();
					product.Tags.Add(oldTag);
				}
			}

			foreach (string path in dto.images)
			{
				Image image = new Image	{Path = path,};
				product.Images.Add(image);
			}


			List<Spec> specs= dto.specs.Select(x => new Spec
			{
				Color= x.Color,
				Size= x.Size,
				Stock= x.Stock,
			}).ToList();

			foreach (var spec in specs)
			{
				product.Specs.Add(spec);
			}
			
			
			_db.SaveChanges();

			





			//b.Images.Add();
			//_db.Tags.Add()
			


		}
	}
}