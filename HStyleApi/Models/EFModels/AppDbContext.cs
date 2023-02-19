﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HStyleApi.Models.EFModels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<EassyFollow> EassyFollows { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Essay> Essays { get; set; }
        public virtual DbSet<EssaysComment> EssaysComments { get; set; }
        public virtual DbSet<HActivity> HActivities { get; set; }
        public virtual DbSet<HCheckIn> HCheckIns { get; set; }
        public virtual DbSet<HSourceDetail> HSourceDetails { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderLog> OrderLogs { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<OrderStatusDescription> OrderStatusDescriptions { get; set; }
        public virtual DbSet<Pcategory> Pcategories { get; set; }
        public virtual DbSet<PcommentsHelpful> PcommentsHelpfuls { get; set; }
        public virtual DbSet<PcommentsImg> PcommentsImgs { get; set; }
        public virtual DbSet<PermissionsE> PermissionsEs { get; set; }
        public virtual DbSet<PermissionsM> PermissionsMs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductComment> ProductComments { get; set; }
        public virtual DbSet<Spec> Specs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<VideoCategory> VideoCategories { get; set; }
        public virtual DbSet<VideoLike> VideoLikes { get; set; }
        public virtual DbSet<VideoView> VideoViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("destination");

                entity.Property(e => e.DestinationCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("destination_category");

                entity.Property(e => e.DestinationName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("destination_name");

                entity.Property(e => e.DestinationThe)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("destination_THE");

                entity.Property(e => e.MemberId).HasColumnName("Member_id");

                entity.Property(e => e.Preset).HasColumnName("preset");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Members");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => new { e.SpecId, e.MemberId });

                entity.ToTable("Cart");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Members");

                entity.HasOne(d => d.Spec)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Spec");
            });

            modelBuilder.Entity<EassyFollow>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("Eassy_Follows");

                entity.Property(e => e.MemberId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Member_Id");

                entity.Property(e => e.EassyId).HasColumnName("Eassy_Id");

                entity.Property(e => e.Ftime)
                    .HasColumnType("datetime")
                    .HasColumnName("FTime");

                entity.HasOne(d => d.Eassy)
                    .WithMany(p => p.EassyFollows)
                    .HasForeignKey(d => d.EassyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eassy_Follows_Essays");

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.EassyFollow)
                    .HasForeignKey<EassyFollow>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eassy_Follows_Members");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EncryptedPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PermissionId)
                    .HasColumnName("Permission_id")
                    .HasDefaultValueSql("((4))");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK_Employees_Employees");
            });

            modelBuilder.Entity<Essay>(entity =>
            {
                entity.Property(e => e.EssayId).HasColumnName("Essay_Id");

                entity.Property(e => e.Econtent)
                    .IsRequired()
                    .HasColumnName("EContent");

                entity.Property(e => e.Etitle)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("ETitle");

                entity.Property(e => e.InfluencerId).HasColumnName("Influencer_Id");

                entity.Property(e => e.UplodTime).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Essays)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Essays_VideoCategories");

                entity.HasOne(d => d.Influencer)
                    .WithMany(p => p.Essays)
                    .HasForeignKey(d => d.InfluencerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Essays_Employees");
            });

            modelBuilder.Entity<EssaysComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("Essays_Comments");

                entity.Property(e => e.CommentId).HasColumnName("Comment_Id");

                entity.Property(e => e.Ccomment)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CComment");

                entity.Property(e => e.Ctime)
                    .HasColumnType("datetime")
                    .HasColumnName("CTime");

                entity.Property(e => e.EssayId).HasColumnName("Essay_Id");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Essay)
                    .WithMany(p => p.EssaysComments)
                    .HasForeignKey(d => d.EssayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Essays_Comments_Essays");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.EssaysComments)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Essays_Comments_Members");
            });

            modelBuilder.Entity<HActivity>(entity =>
            {
                entity.ToTable("H_Activities");

                entity.Property(e => e.HActivityId).HasColumnName("H_Activity_Id");

                entity.Property(e => e.ActivityDescribe)
                    .IsRequired()
                    .HasColumnName("Activity_Describe");

                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Activity_Name");

                entity.Property(e => e.HValue).HasColumnName("H_Value");
            });

            modelBuilder.Entity<HCheckIn>(entity =>
            {
                entity.HasKey(e => e.CheckInHId);

                entity.ToTable("H_CheckIns");

                entity.Property(e => e.CheckInHId).HasColumnName("CheckIn_H_Id");

                entity.Property(e => e.ActivityId).HasColumnName("Activity_Id");

                entity.Property(e => e.CheckInTimes).HasColumnName("CheckIn_Times");

                entity.Property(e => e.LastTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Last_Time");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.HCheckIns)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_H_CheckIns_H_Activities_Categories");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.HCheckIns)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_H_CheckIns_Members");
            });

            modelBuilder.Entity<HSourceDetail>(entity =>
            {
                entity.HasKey(e => e.SourceHId)
                    .HasName("PK_Source_Hs");

                entity.ToTable("H_Source_Details");

                entity.Property(e => e.SourceHId).HasColumnName("Source_H_Id");

                entity.Property(e => e.ActivityId).HasColumnName("Activity_Id");

                entity.Property(e => e.DifferenceH).HasColumnName("Difference_H");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.EventTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Event_Time");

                entity.Property(e => e.MemberId).HasColumnName("Member_Id");

                entity.Property(e => e.Remark).HasMaxLength(500);

                entity.Property(e => e.TotalHSoFar).HasColumnName("Total_H_SoFar");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.HSourceDetails)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_H_Source_Details_H_Activities_Categories");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HSourceDetails)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_H_Source_Details_Employees");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.HSourceDetails)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_H_Source_Details_Members");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId).HasColumnName("Image_Id");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasMany(d => d.Essays)
                    .WithMany(p => p.Imgs)
                    .UsingEntity<Dictionary<string, object>>(
                        "EssaysImg",
                        l => l.HasOne<Essay>().WithMany().HasForeignKey("EssayId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Essays_Imgs_Essays"),
                        r => r.HasOne<Image>().WithMany().HasForeignKey("ImgId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Essays_Imgs_Images"),
                        j =>
                        {
                            j.HasKey("ImgId", "EssayId").HasName("PK_Essays_Img");

                            j.ToTable("Essays_Imgs");

                            j.IndexerProperty<int>("ImgId").HasColumnName("Img_Id");

                            j.IndexerProperty<int>("EssayId").HasColumnName("Essay_Id");
                        });

                entity.HasMany(d => d.Products)
                    .WithMany(p => p.Imgs)
                    .UsingEntity<Dictionary<string, object>>(
                        "ImgsProduct",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Imgs_Products_Products"),
                        r => r.HasOne<Image>().WithMany().HasForeignKey("ImgId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Imgs_Products_Images"),
                        j =>
                        {
                            j.HasKey("ImgId", "ProductId");

                            j.ToTable("Imgs_Products");

                            j.IndexerProperty<int>("ImgId").HasColumnName("Img_Id");

                            j.IndexerProperty<int>("ProductId").HasColumnName("Product_Id");
                        });
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EncryptedPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Jointime).HasColumnType("datetime");

                entity.Property(e => e.MailCode)
                    .HasMaxLength(100)
                    .HasColumnName("Mail_code");

                entity.Property(e => e.MailVerify)
                    .HasColumnName("Mail_verify")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PermissionId).HasColumnName("Permission_Id");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Number");

                entity.Property(e => e.TotalH)
                    .HasColumnName("Total_H")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK_Members_PermissionsM");

                entity.HasMany(d => d.Comments)
                    .WithMany(p => p.Members)
                    .UsingEntity<Dictionary<string, object>>(
                        "EcommentsLike",
                        l => l.HasOne<EssaysComment>().WithMany().HasForeignKey("CommentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EComments_Likes_Essays_Comments"),
                        r => r.HasOne<Member>().WithMany().HasForeignKey("MemberId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EComments_Likes_Members"),
                        j =>
                        {
                            j.HasKey("MemberId", "CommentId");

                            j.ToTable("EComments_Likes");

                            j.IndexerProperty<int>("MemberId").HasColumnName("Member_Id");

                            j.IndexerProperty<int>("CommentId").HasColumnName("Comment_Id");
                        });

                entity.HasMany(d => d.Essays)
                    .WithMany(p => p.Members)
                    .UsingEntity<Dictionary<string, object>>(
                        "Elike",
                        l => l.HasOne<Essay>().WithMany().HasForeignKey("EssayId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Elikes_Essays"),
                        r => r.HasOne<Member>().WithMany().HasForeignKey("MemberId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Elikes_Members"),
                        j =>
                        {
                            j.HasKey("MemberId", "EssayId");

                            j.ToTable("Elikes");

                            j.IndexerProperty<int>("MemberId").ValueGeneratedOnAdd().HasColumnName("Member_Id");

                            j.IndexerProperty<int>("EssayId").HasColumnName("Essay_Id");
                        });
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId).HasColumnName("News_Id");

                entity.Property(e => e.Ncontent)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("NContent");

                entity.Property(e => e.NproductId).HasColumnName("NProduct_Id");

                entity.Property(e => e.Ntitle)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("NTitle");

                entity.Property(e => e.Ntme)
                    .HasColumnType("datetime")
                    .HasColumnName("NTme");

                entity.Property(e => e.PhotoId).HasColumnName("Photo_Id");

                entity.Property(e => e.TagId).HasColumnName("Tag_Id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.MemberId).HasColumnName("Member_id");

                entity.Property(e => e.RequestRefundTime).HasColumnType("datetime");

                entity.Property(e => e.ShipAddress)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.ShipName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ShipPhone)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ShipVia)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.Property(e => e.StatusDescriptionId).HasColumnName("Status_Description_id");

                entity.Property(e => e.StatusId).HasColumnName("Status_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employees");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Members");

                entity.HasOne(d => d.StatusDescription)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusDescriptionId)
                    .HasConstraintName("FK_Orders_Order_StatusDescription");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Order_Status");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("Order_Details");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Orders");
            });

            modelBuilder.Entity<OrderLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("Order_Log");

                entity.Property(e => e.LogId).HasColumnName("Log_id");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_id");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StatusChangedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Status_ChangedTime");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("Order_Status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("Status_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OrderStatusDescription>(entity =>
            {
                entity.HasKey(e => e.DescriptionId)
                    .HasName("PK_Status_Description");

                entity.ToTable("Order_StatusDescription");

                entity.Property(e => e.DescriptionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Description_id");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.StatusId).HasColumnName("Status_id");
            });

            modelBuilder.Entity<Pcategory>(entity =>
            {
                entity.ToTable("PCategories");

                entity.Property(e => e.PcategoryId).HasColumnName("PCategory_Id");

                entity.Property(e => e.PcategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PCategoryName");
            });

            modelBuilder.Entity<PcommentsHelpful>(entity =>
            {
                entity.HasKey(e => new { e.MemberId, e.CommentId });

                entity.ToTable("PComments_Helpful");

                entity.Property(e => e.MemberId).HasColumnName("Member_id");

                entity.Property(e => e.CommentId).HasColumnName("Comment_id");
            });

            modelBuilder.Entity<PcommentsImg>(entity =>
            {
                entity.HasKey(e => e.PcommentImgId);

                entity.ToTable("PComments_Imgs");

                entity.Property(e => e.PcommentImgId).HasColumnName("PComment_img_id");

                entity.Property(e => e.CommentId).HasColumnName("Comment_id");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.PcommentsImgs)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PComments_Imgs_Product_Comments");
            });

            modelBuilder.Entity<PermissionsE>(entity =>
            {
                entity.HasKey(e => e.PermissionMId);

                entity.ToTable("PermissionsE");

                entity.Property(e => e.PermissionMId).HasColumnName("PermissionM_id");

                entity.Property(e => e.Level).HasMaxLength(50);
            });

            modelBuilder.Entity<PermissionsM>(entity =>
            {
                entity.HasKey(e => e.PermissionId);

                entity.ToTable("PermissionsM");

                entity.Property(e => e.PermissionId).HasColumnName("Permission_id");

                entity.Property(e => e.Level).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Product_Name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_PCategories");

                entity.HasMany(d => d.Members)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductLike",
                        l => l.HasOne<Member>().WithMany().HasForeignKey("MemberId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Product_Likes_Members"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Product_Likes_Products"),
                        j =>
                        {
                            j.HasKey("ProductId", "MemberId");

                            j.ToTable("Product_Likes");

                            j.IndexerProperty<int>("ProductId").HasColumnName("Product_id");

                            j.IndexerProperty<int>("MemberId").HasColumnName("Member_id");
                        });
            });

            modelBuilder.Entity<ProductComment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("Product_Comments");

                entity.Property(e => e.CommentId).HasColumnName("Comment_id");

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("Comment_content");

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductComments)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Comments_Orders");
            });

            modelBuilder.Entity<Spec>(entity =>
            {
                entity.ToTable("Spec");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Specs)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Spec_Products");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasMany(d => d.Essays)
                    .WithMany(p => p.Tags)
                    .UsingEntity<Dictionary<string, object>>(
                        "EssaysTag",
                        l => l.HasOne<Essay>().WithMany().HasForeignKey("EssayId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Essays_Tags_Essays"),
                        r => r.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Essays_Tags_Essays_Tags"),
                        j =>
                        {
                            j.HasKey("TagId", "EssayId");

                            j.ToTable("Essays_Tags");

                            j.IndexerProperty<int>("TagId").HasColumnName("Tag_Id");

                            j.IndexerProperty<int>("EssayId").HasColumnName("Essay_Id");
                        });

                entity.HasMany(d => d.Products)
                    .WithMany(p => p.Tags)
                    .UsingEntity<Dictionary<string, object>>(
                        "TagsProduct",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Tags_Products_Products"),
                        r => r.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Tags_Products_Tags"),
                        j =>
                        {
                            j.HasKey("TagId", "ProductId");

                            j.ToTable("Tags_Products");

                            j.IndexerProperty<int>("TagId").HasColumnName("Tag_Id");

                            j.IndexerProperty<int>("ProductId").HasColumnName("Product_Id");
                        });
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OffShelffTime).HasColumnType("datetime");

                entity.Property(e => e.OnShelffTime).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Videos_VideoCategories");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Videos_Images");

                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Videos)
                    .UsingEntity<Dictionary<string, object>>(
                        "TagsVideo",
                        l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Tags_Video_Tags"),
                        r => r.HasOne<Video>().WithMany().HasForeignKey("VideoId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Tags_Video_Videos"),
                        j =>
                        {
                            j.HasKey("VideoId", "TagId");

                            j.ToTable("Tags_Video");
                        });
            });

            modelBuilder.Entity<VideoCategory>(entity =>
            {
                entity.Property(e => e.CategoryDescription).HasMaxLength(200);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<VideoLike>(entity =>
            {
                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.VideoLikes)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoLikes_Videos");
            });

            modelBuilder.Entity<VideoView>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Video)
                    .WithMany()
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VideoViews_Videos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}