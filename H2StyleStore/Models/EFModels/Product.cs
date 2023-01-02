namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Specs = new HashSet<Spec>();
            Tags = new HashSet<Tag>();
        }

        [Key]
        public int Product_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Product_Name { get; set; }

        public int UnitPrice { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public int Stock { get; set; }

        public DateTime Create_at { get; set; }

        public bool Discontinued { get; set; }

        public int DisplayOrder { get; set; }

        public int Category_Id { get; set; }

        public virtual PCategory PCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Spec> Specs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
