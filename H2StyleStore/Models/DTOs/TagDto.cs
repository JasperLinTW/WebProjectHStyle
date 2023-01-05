﻿using H2StyleStore.Models.EFModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H2StyleStore.Models.DTOs
{
    public class TagDto
    {
        public int Id { get; set; }

        public string TagName { get; set; }
    }
    public static class TagExts
    {
        public static TagDto ToDto(this Tag source)
        {
            return new TagDto()
            {
                Id= source.Id,
                TagName= source.TagName
            };
        }
    }
}