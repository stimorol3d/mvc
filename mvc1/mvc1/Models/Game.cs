namespace mvc1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        public int Id { get; set; }

        public int Team1_Id { get; set; }

        public int Team2_Id { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime DateStart { get; set; }

        public int? StadiumId { get; set; }

        public virtual Stadium Stadium { get; set; }

        public virtual Team Team { get; set; }

        public virtual Team Team1 { get; set; }
    }
}
