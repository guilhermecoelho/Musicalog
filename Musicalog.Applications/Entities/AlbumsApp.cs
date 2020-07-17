using System;
using System.Collections.Generic;
using System.Text;

namespace Musicalog.Applications.Entities
{
    public class AlbumsApp
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Label { get; set; }
        //public string AlbumType { get; set; }
        public int AlbumTypeId { get; set; }

        private string _albumType { get; set; }
        public string AlbumType
        {
            get
            {
                return  AlbumTypeId == 1 ? "vinyl" : "cd";
            }
            set
            {
                _albumType = AlbumTypeId == 1 ? "vinyl" : "cd";
            }
        }
        public int Stock { get; set; }
    }
}
