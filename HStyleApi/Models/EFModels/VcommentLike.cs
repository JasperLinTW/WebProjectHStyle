﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HStyleApi.Models.EFModels
{
<<<<<<<< HEAD:HStyleApi/Models/EFModels/VcommentLike.cs
    public partial class VcommentLike
    {
        public int MemberId { get; set; }
        public int CommentId { get; set; }

        public virtual VideoComment Comment { get; set; }
========
    public partial class ProductLike
    {
        public int ProductId { get; set; }
        public int MemberId { get; set; }

        public virtual Product Product { get; set; }
>>>>>>>> marcy:HStyleApi/Models/EFModels/ProductLike.cs
    }
}