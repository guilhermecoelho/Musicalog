using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Musicalog_Domain.Entities
{
    [Table("AlbumTypes")]
    public class AlbumTypesDomain
    {
        [Column("ID")]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [ForeignKey("AlbumTypeId")]
        public ICollection<AlbumsDomain> Albums { get; set; }
    }
}
