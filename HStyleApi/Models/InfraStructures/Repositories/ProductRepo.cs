﻿using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.EntityFrameworkCore;

namespace HStyleApi.Models.InfraStructures.Repositories
{
	public class ProductRepo
	{
		private readonly AppDbContext _db;
		public ProductRepo(AppDbContext db)
		{
			_db = db;
		}

		public IEnumerable<ProductDto> LoadProducts()
		{
			IEnumerable<Product> data = _db.Products
										.Include(product => product.Category)
										.Include(product => product.Imgs)
										.Include(product => product.Specs)
										.Include(product => product.Tags);

			var  products = data.OrderBy(x => x.DisplayOrder).Select(x => x.ToDto());

			return products;
		}

		public ProductDto GetProduct(int product_id)
		{
			if (_db.Products.Find(product_id) == null)
			{
				throw new Exception("查無此商品");
			}

			IEnumerable<Product> data = _db.Products.Include(product => product.Category)
										.Include(product => product.Imgs)
										.Include(product => product.Specs)
										.Include(product => product.Tags);

			var product = data.FirstOrDefault(x => x.ProductId == product_id).ToDto();
			
			return product;

		}

		public void CreateComment(PCommentPostDTO dto, int orderId, int productId)
		{
			
			ProductComment pcomment = new ProductComment
			{
				OrderId = orderId,
				ProductId = productId,
				CommentContent= dto.CommentContent,
				Score= dto.Score,
				CreatedTime = DateTime.Now,
			};


			_db.ProductComments.Add(pcomment);

			foreach (string path in dto.PcommentImgs)
			{
				Image image = new Image { Path = path, };
				pcomment.PcommentImgs.Add(image);
			}

			_db.SaveChanges();
		}

		public PCommentGetDTO GetComment(int productId, int orderId)
		{
			IEnumerable<Product> data = _db.Products.Include(product => product.Category)
										.Include(product => product.Imgs)
										.Include(product => product.Specs)
										.Include(product => product.Tags);
			var product = data.FirstOrDefault(x => x.ProductId == productId).ToDto();

			var orderDetail = _db.OrderDetails.Where(x => x.OrderId == orderId).FirstOrDefault(x => x.ProductId == productId);

			PCommentGetDTO comment = new PCommentGetDTO
			{
				ProductId = productId,
				OrderId = orderId,
				ProductName = product.Product_Name,
				ProductPhoto = product.Imgs.ToList()[0],
				Color = orderDetail.Color,
				Size= orderDetail.Size,
			};

			return comment;

		}
	}
}
