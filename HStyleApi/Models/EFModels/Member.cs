﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HStyleApi.Models.EFModels
{
    public partial class Member
    {
        public Member()
        {
            Addresses = new HashSet<Address>();
            Carts = new HashSet<Cart>();
            CustomerQuestions = new HashSet<CustomerQuestion>();
            EssaysComments = new HashSet<EssaysComment>();
            HCheckIns = new HashSet<HCheckIn>();
            HSourceDetails = new HashSet<HSourceDetail>();
            Orders = new HashSet<Order>();
            Comments = new HashSet<EssaysComment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int? PermissionId { get; set; }
        public DateTime Jointime { get; set; }
        public bool? MailVerify { get; set; }
        public string MailCode { get; set; }
        public int? TotalH { get; set; }
        public string EncryptedPassword { get; set; }

        public virtual PermissionsM Permission { get; set; }
        public virtual EassyFollow EassyFollow { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<CustomerQuestion> CustomerQuestions { get; set; }
        public virtual ICollection<EssaysComment> EssaysComments { get; set; }
        public virtual ICollection<HCheckIn> HCheckIns { get; set; }
        public virtual ICollection<HSourceDetail> HSourceDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<EssaysComment> Comments { get; set; }
    }
}