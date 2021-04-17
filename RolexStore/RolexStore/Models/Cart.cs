namespace RolexStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CartID { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerID { get; set; }

        public int CStateID { get; set; }

        public int? PaymentMethodID { get; set; }

        public virtual CartState CartState { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual CartDetail CartDetail { get; set; }
    }
}
