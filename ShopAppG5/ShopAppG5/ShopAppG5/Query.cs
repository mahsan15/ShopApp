using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppG5
{
	public class Query
	{
		public string searchLine { get; set; }
		public string apiFilter { get; set; }
		public int priceLowerBound { get; set; }
		public int priceHigherBound { get; set; }

		public Query()
		{
			searchLine = "";
			apiFilter = "";
			priceLowerBound = 0;
			priceHigherBound = int.MaxValue;
		}

		public Query(string search, string api, int lower = 0, int higher = int.MaxValue)
		{
			searchLine = search;
			apiFilter = api;
			if (lower < higher)
			{
				priceLowerBound = lower;
				priceHigherBound = higher;
			}
			else
			{
				priceLowerBound = 0;
				priceHigherBound = int.MaxValue;
			}
		}

	}
}
