﻿using HStyleApi.Models.DTOs;
using HStyleApi.Models.EFModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace HStyleApi.Models.InfraStructures.Repositories
{
	public class VideoRepository
	{
		private AppDbContext _db;
		private ProductRepo _PRepo;

		public VideoRepository(AppDbContext db)
		{
			_db = db;
		}

		//影片列表：取出所有影片、篩選
		public async Task<IEnumerable<VideoDTO>> GetVideos(string? keyword)
		{
			IEnumerable<Video> data = await _db.Videos.Include(v => v.Image)
															.Include(v => v.Tags)
															.Include(v => v.VideoLikes)
															.Include(v=>v.Category)
															.Include(v => v.VideoView).Where(v=>v.IsOnShelff==true)
															.ToListAsync();

			if (data == null)
			{
				throw new Exception("目前沒有影片");
			}

			if (keyword == null)
			{
				IEnumerable<VideoDTO> videos = data.Select(v => v.ToVideoDTO());
				return videos;
			}
			else
			{
				IEnumerable<VideoDTO> selectVideos = data.Where(v => v.Title.Contains(keyword)||v.Tags.Select(t=>t.TagName).Contains(keyword)).Select(x => x.ToVideoDTO());
				return selectVideos;
			}			
		 }

		//單一影片資訊
		public async Task<IEnumerable<VideoDTO>> GetVideo(int id)
		{
			IEnumerable<VideoDTO> video = await _db.Videos.Where(v => v.Id == id)
												.Include(v => v.Image)
												.Include(v => v.Category)
												.Include(v => v.Tags)
												.Include(v => v.VideoLikes)
												.Include(v => v.VideoView).Where(v => v.IsOnShelff == true).Select(v=>v.ToVideoDTO())
												.ToListAsync();

			if (video == null)
			{
				throw new Exception("找不到這部影片!");
			}

			return video;
		}

		//根據影片推薦相關商品
		public async Task<IEnumerable<ProductDto>> GetRecommendationProduct(int videoId)
		{
			//var video = await _db.Videos.Where(v => v.Id == videoId).ToListAsync();
			//var tags = video.Select(v => v.Tags).ToList();
			//var video = video.Select(v => v.Tags).ToList();
			//var videoTags = _db.Tags.Where(t => t.Id == video).ToListAsync();

			//var products = _db.Products.Include(p => p.Tags).Where(v => v.Tags == tags)
			//										.OrderByDescending(p => p.ProductLikes.Count())
			//										.Take(3).Select(p => p.ToDto()).ToList();

			//IEnumerable<ProductDto> products = await _db.Products.Include(p => p.Imgs)
			//											.Include(p => p.Tags)
			//											.Include(p => p.Category)
			//											.Where(p => p.Tags == videoTags)
			//											.OrderByDescending(p => p.ProductLikes.Count())
			//											.Take(3).Select(p => p.ToDto()).ToArrayAsync();

			//List<int> productsId = new List<int>();

			//foreach (var item in products)
			//{
			//	foreach (var tag in tags)
			//	{
			//		if (item.Tags.Any(x => x.TagName == tag) == true)
			//		{
			//			productsId.Add(item.ProductId);
			//		}
			//	}
			//}
			//return products_id;
			var data = new List<ProductDto> { };//程式碼建置未過，加上此行讓程式能動
			return data;
		}

		//最新影片
		public async Task <IEnumerable<VideoDTO>> GetNews()
		{
			IEnumerable<Video> data = await _db.Videos.Include(v=>v.VideoView). Include(v => v.Category).Include(v => v.Image)
				 										.Include(v => v.Tags)
														.ThenInclude(v => v.Essays)
														.ToListAsync();

			IEnumerable<VideoDTO> news = data.Where(v => v.IsOnShelff == true).OrderByDescending(v => v.Tags.GroupBy(v => v.TagName).Count())
														.OrderByDescending(v => v.OnShelffTime)
														.Take(6).Select(v => v.ToVideoDTO()).ToList();

			return news;
		}

		//使用者收藏的影片
		public async Task <IEnumerable<VideoLikeDTO>> GetLikeVideos(int memberId)
		{
			IEnumerable<VideoLike> data =await _db.VideoLikes.Include(v => v.Video)
																.ThenInclude(v => v.Image)
																.Include(v=>v.Video)
																.ThenInclude(v=>v.Category)
																.Include(v=>v.Video)
																.ThenInclude(v=>v.Tags)
																.Include(v=>v.Video)
																.ThenInclude(v=>v.VideoView)
																.Where(v=>v.MemberId==memberId)
																.ToListAsync();

			IEnumerable<VideoLikeDTO> likeVideos = data.Select(v => v.ToLikeDTO());
																//.Where(v=>v.IsOnShelff==true)

			return likeVideos;
		}

		//收藏影片
		public void PostLike(int memberId, int videoId)
		{
			var data = _db.VideoLikes.Where(v=>v.MemberId==memberId).FirstOrDefault(v => v.VideoId == videoId);
			if (data == null)
			{
				VideoLike like = new VideoLike
				{
					MemberId = memberId,
					VideoId = videoId,
				};
				_db.VideoLikes.Add(like);
			}
			else _db.VideoLikes.Remove(data);

			_db.SaveChanges();
		}

		//瀏覽次數
		public void PostView(int videoId) 
		{
			var data = _db.VideoViews.Find(videoId);
			if (data == null)
			{
				VideoView view = new VideoView()
				{
					VideoId= videoId,
					Views= 1
				};
				_db.VideoViews.Add(view);
			}else
			{
				data.Views++;
			}
			_db.SaveChanges();
		}

		//Get評論
		public async Task<IEnumerable<VideoCommentDTO>> GetComments(int videoId)
		{
			IEnumerable < VideoCommentDTO > data= await _db.VideoComments	
														.Where(v => v.VideoId == videoId)
														.Select(v => v.ToCommentDTO()).ToListAsync();
			return data;
		}

		//Post評論
		public void CreateComment(string comment, int memberId, int videoId)
		{
			if (comment == null||memberId==0||videoId==0) throw new Exception();

			VideoComment videoComment = new VideoComment()
			{
				VideoId=videoId,
				MemberId=memberId,
				CreatedTime=DateTime.Now,
				Comment=comment,
				Like=0
			};
			_db.Add(videoComment);
			_db.SaveChanges();
		}

		public void PostCommentLike(int memberId, int commentId)
		{
			var data = _db.VideoComments.SingleOrDefault(v => v.Id == commentId);

			if (data != null)
			{
				VcommentLike commentlike = new VcommentLike()
				{
					MemberId = memberId,
					CommentId = commentId
				};
				_db.Add(commentlike);
				data.Like++;
			}

			_db.SaveChanges();
		}
	}
}
