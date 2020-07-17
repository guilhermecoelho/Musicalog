using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.API.Entitites
{
    public class Album
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Label { get; set; }
        public string AlbumType { get; set; }

        public int AlbumTypeId { get; set; }
        public int Stock { get; set; }
    }
}
