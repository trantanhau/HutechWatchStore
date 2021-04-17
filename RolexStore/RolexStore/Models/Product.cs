namespace RolexStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            CartDetails = new HashSet<CartDetail>();
        }

        [StringLength(50)]
        public string ProductID { get; set; }

        public int Stock { get; set; }

        public int Price { get; set; }

        public int TypeID { get; set; }

        public int SizeID { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductImg { get; set; }

        public int CollectionID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartDetail> CartDetails { get; set; }

        public virtual Collection Collection { get; set; }

        public virtual Size Size { get; set; }

        public virtual WatchType WatchType { get; set; }
    }
}
