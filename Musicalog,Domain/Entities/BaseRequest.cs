using System;
using System.Collections.Generic;
using System.Text;

namespace Musicalog_Domain.Entities
{
	public class BaseRequest
	{
		const int maxPageSize = 50;
		public int PageNumber { get; set; } = 1;

		private int _pageSize = 10;
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}
		public string SortBy { get; set; }
		public bool? IsAsc { get; set; }
	}
}
