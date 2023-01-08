﻿using H2StyleStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.DTOs
{
    public class ImageDto
    {
        public int Image_Id { get; set; }

        public string Path { get; set; }
    }

    public static class ImageExts
    {
        public static string ToDto(this Image source)
        {
            return source.Path;
        }
    }
}