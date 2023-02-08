namespace HcoinForBirth.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Details
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Product_id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int UnitPrice { get; set; }

        public int SubTotal { get; set; }

        public int Quantity { get; set; }

        public int? Discount { get; set; }

        public virtual Order Order { get; set; }
    }
}
