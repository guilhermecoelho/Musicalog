using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.api.Requests
{
    public class AlbumSaveRequest
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Label { get; set; }
        public int AlbumTypeId { get; set; }
        public int Stock { get; set; }
    }
}
