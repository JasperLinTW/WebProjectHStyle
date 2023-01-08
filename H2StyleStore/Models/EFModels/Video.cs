namespace H2StyleStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Video
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Video()
        {
            Tags = new HashSet<Tag>();
            //VideoCategory=new VideoCategory();
            //Image=new Image();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string FilePath { get; set; }

        public int CategoryId { get; set; }

        public int ImageId { get; set; }

        public DateTime? OnShelffTime { get; set; }

        public DateTime? OffShelffTime { get; set; }

        public DateTime CreatedTime { get; set; }

        public virtual Image Image { get; set; }

        public virtual VideoCategory VideoCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
