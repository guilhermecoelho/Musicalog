using System;
using System.Collections.Generic;
using System.Linq;

namespace Musicalog.MVC.Models
{
    public class AlbumsViewModel
    {
        public List<AlbumsModel> AlbumsModels { get; set; }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public int PageCount()
        {
            PageIndex = PageIndex == 0 ? 1 : PageIndex;

            return Convert.ToInt32(Math.Ceiling(AlbumsModels.Count() / (double)PageSize + 1));
        }

        public string SortBy { get; set; }
        public bool? isAsc { get; set; }


    }
}
