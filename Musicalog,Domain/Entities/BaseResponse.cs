using System;
using System.Collections.Generic;
using System.Text;

namespace Musicalog_Domain.Entities
{
    public class BaseResponse
    {
        public bool Status { get; set; }

		public int PageNumber { get; set; }

		public int PageSize { get; set; }

		public int totalItens { get; set; }
		
	}
}
