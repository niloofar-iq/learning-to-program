using System;

namespace ListsLogicAndIterations.Code
{
	public static class Arrays
	{
		public static int[] BuildIntArray(int first, int second)
		{ 
			int[] simpleArray = { first, second };
			return simpleArray;
		}

		public static int GetArrayValue(int[] array, int position)
        {
            if (position >= array.Length || position <0)
            {
                return 0;
            }


            return array[position];
		}
	}
}