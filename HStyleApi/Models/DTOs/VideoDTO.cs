﻿using HStyleApi.Models.EFModels;

namespace HStyleApi.Models.DTOs
{
	public class VideoDTO
	{
		public int Id { get; set; }

		public string? Title { get; set; }

		public string? Description { get; set; }

		public string? FilePath { get; set; }

		public int CategoryId { get; set; }

		public int ImageId { get; set; }

		public DateTime? OnShelffTime { get; set; }

		public DateTime? OffShelffTime { get; set; }

		public DateTime CreatedTime { get; set; }

		public string? Image { get; set; }

		public IEnumerable<string>? Tags { get; set; }

		public virtual ICollection<VideoLike> VideoLikes { get; set; }

		public string CategoryName { get; set; }
	}

	public static class VideoExts
	{
		public static VideoDTO ToVideoDTO(this Video source)
		{
			return new VideoDTO()
			{
				Id = source.Id,
				Title = source.Title,
				Description = source.Description,
				FilePath = source.FilePath,
				CategoryId = source.CategoryId,
				ImageId = source.ImageId,
				OnShelffTime = source.OnShelffTime,
				OffShelffTime = source.OffShelffTime,
				CreatedTime = source.CreatedTime,
				Tags = source.Tags.Select(x => x.TagName),
				VideoLikes=source.VideoLikes,
				CategoryName=source.Category.CategoryName
			};
		}
	}
}
