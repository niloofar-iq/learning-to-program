using System;
using System.Collections.Generic;

namespace ListsLogicAndIterations.Code
{
	public static class Dictionarys
	{
		public static Dictionary<Guid, decimal> Build(Guid key, decimal value)
		{
			var dic1 = new Dictionary<Guid, decimal>()
			{
				{ key, value }
			};
			
			return dic1;
		}

		public static decimal GetValue(Dictionary<Guid, decimal> dict, Guid key)
		{
            try
            {
				return dict[key];
			}
            catch(KeyNotFoundException)
            {
				return 0;
            }


		}

		public static void AddValue(Dictionary<Guid, decimal> dict, Guid key, decimal value)
		{
            try
            {
				dict.Add(key, value);

			}
            catch (ArgumentException)
            {

            }

		}
	}
}