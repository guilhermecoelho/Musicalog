using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.MVC.Models
{
    public class AlbumsModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Label { get; set; }
        private string _albumType { get; set; }
        public string AlbumType
        {
            get
            {
                return AlbumTypeId == 1 ? "vinyl" : "cd";
            }
            set
            {
                _albumType = AlbumTypeId == 1 ? "vinyl" : "cd";
            }
        }
        public int AlbumTypeId { get; set; }
        public int Stock { get; set; }
    }
}
