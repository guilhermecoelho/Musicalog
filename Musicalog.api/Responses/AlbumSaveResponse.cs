using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.api.Responses
{
    public class AlbumSaveResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Label { get; set; }
        public string AlbumType { get; set; }
        public int Stock { get; set; }
    }
}
