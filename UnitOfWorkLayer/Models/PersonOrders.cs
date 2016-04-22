namespace UnitOfWorkLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PersonOrders
    {
        public int id { get; set; }

        public int personId { get; set; }

        [Required]
        public string description { get; set; }

        public int amount { get; set; }

        public string notes { get; set; }

        public virtual Person Person { get; set; }
    }
}
