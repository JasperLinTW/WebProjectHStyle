﻿using H2StyleStore.Models.DTOs;
using System.Collections.Generic;

namespace H2StyleStore.Models.Infrastructures.Repositories
{
    public interface IVideoRepository
    {
        IEnumerable<VideoDto> GetVideos();
        void CreateVideo(CreateVideoDto dto);
        bool IsExist(string image, string filePath);
		CreateVideoDto GetVideoById(int videoId);
		void Update(CreateVideoDto entity);
	}
}