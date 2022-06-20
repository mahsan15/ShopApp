using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopAppG5
{
	public class Query
	{
		[PrimaryKey, AutoIncrement]
		public int key { get; set; }
		public string searchLine { get; set; }
		public int priceLowerBound { get; set; }
		public int priceHigherBound { get; set; }

		public Query()
		{
			searchLine = "";
			priceLowerBound = 0;
			priceHigherBound = int.MaxValue;
		}

		public Query(string search, int lower = 0, int higher = int.MaxValue)
		{
			searchLine = search;
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
