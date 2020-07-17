using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Musicalog_Domain.Entities
{
    [Table("Albums")]
    public class AlbumsDomain
    {
        [Column("ID")]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Artist")]
        public string Artist { get; set; }

        [Column("Label")]
        public string Label { get; set; }

        [Column("AlbumTypeID")]
        public long AlbumTypeId { get; set; }

        [Column("Stock")]
        public int Stock { get; set; }

        public AlbumTypesDomain albumTypesDomain { get;set; }

    }
}
