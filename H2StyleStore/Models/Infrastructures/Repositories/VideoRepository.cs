﻿using H2StyleStore.Models.DTOs;
using H2StyleStore.Models.EFModels;
using H2StyleStore.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
	public class VideoRepository : IVideoRepository
	{
		private readonly AppDbContext _db;

		public VideoRepository(AppDbContext db)
		{
			_db = db;
		}
		public IEnumerable<VideoDto> GetVideos()
		{
			IEnumerable<Video> query = _db.Videos;
			return query.Select(v => v.ToDto());
		}

		public void CreateVideo(CreateVideoDto dto)
		{
			//int.TryParse(dto.VideoCategory, out int catgoryId);


			foreach (string tag in dto.Tags)
			{
				var tags = _db.Tags.Select(t => t.TagName).ToList();
				if (tags.Contains(tag) == true)
				{
					//
					Tag oldTag = _db.Tags.Where(t => t.TagName == tag).FirstOrDefault();
					_db.Tags.Add(oldTag);
				}
				else
				{
					Tag newTag = new Tag { TagName = tag };
					_db.Tags.Add(newTag);
				}
			}

			string path = dto.Image;
			Image image = new Image { Path = "../../Images/VideoImages/" + path };
			_db.Images.Add(image);
			_db.SaveChanges();

			var imageid = _db.Images.Where(i => i.Path == image.Path).FirstOrDefault();
			Video video = new Video()
			{
				Title = dto.Title,
				Description = dto.Description,
				FilePath = "../../Videos/"+dto.FilePath,
				CategoryId = dto.CategoryId,
				ImageId = imageid.Image_Id,
				OnShelffTime = dto.OnShelffTime,
				OffShelffTime = dto.OffShelffTime,
				CreatedTime = DateTime.Now
			};
			_db.Videos.Add(video);

			_db.SaveChanges();
		}

		public IEnumerable<SelectListItem> GetVideoCategories()
		{
			var data = _db.VideoCategories;

			foreach (var item in data)
			{
				yield return new SelectListItem { Value = item.Id.ToString(), Text = item.CategoryName };
			}
		}

		public bool IsExist(string image, string filePath)
		{
			var video = _db.Videos.SingleOrDefault(x => x.Image.Path == image);
			video = _db.Videos.SingleOrDefault(x => x.FilePath == filePath);
			return (video != null);
		}
	}
}