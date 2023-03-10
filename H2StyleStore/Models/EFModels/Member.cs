namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            Addresses = new HashSet<Address>();
            Essays_Comments = new HashSet<Essays_Comments>();
            H_CheckIns = new HashSet<H_CheckIns>();
            H_Source_Details = new HashSet<H_Source_Details>();
            Orders = new HashSet<Order>();
            Essays_Comments1 = new HashSet<Essays_Comments>();
            Essays = new HashSet<Essay>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone_Number { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public bool Gender { get; set; }

        [Column(TypeName = "datetime2")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd HH:mm:ss}",ApplyFormatInEditMode =true)]
        public DateTime Birthday { get; set; }

        public int? Permission_Id { get; set; }

		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
		public DateTime Jointime { get; set; }

        public bool? Mail_verify { get; set; }

        [StringLength(100)]
        public string Mail_code { get; set; }

        public int? Total_H { get; set; }

        [StringLength(100)]
        public string EncryptedPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }

        public virtual Eassy_Follows Eassy_Follows { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Essays_Comments> Essays_Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<H_CheckIns> H_CheckIns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<H_Source_Details> H_Source_Details { get; set; }

        public virtual PermissionsM PermissionsM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Essays_Comments> Essays_Comments1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Essay> Essays { get; set; }
    }
}
