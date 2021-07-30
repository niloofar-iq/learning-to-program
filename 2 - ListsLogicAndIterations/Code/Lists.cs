using System;
using System.Collections.Generic;

namespace ListsLogicAndIterations.Code
{
	public static class Lists
	{
		public static List<decimal> BuildList(decimal first, decimal second)
		{
			var list1 = new List<decimal> {
				first , second 
			};
			return list1;
		}

		public static decimal GetValue(List<decimal> list, int position)
		{
			if(position <0 || position >= list.Count)
            {
				return 0;
            }
			return list[position];
		}

		public static void AddValue(List<decimal> list, decimal value)
		{
			list.Add(value);
		}

		public static void AddValue(List<decimal> list, List<decimal> value)
		{
			list.AddRange(value);
		}

		public static void RemoveValue(List<decimal> list, decimal value)
		{
			list.Remove(value);
		}
	}
}