namespace mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Player")]
    public partial class Player
    {
        public int Id { get; set; }

        public int? TeamId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        public virtual Team Team { get; set; }
    }
}
