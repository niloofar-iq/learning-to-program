using System;
using System.Collections.Generic;
using System.Linq;

namespace ListsLogicAndIterations.Code
{
	public static class LogicAndInterations
	{
		public static int For_SumTwoListsAndAllValueThatAreNotFour(int[] numberArray, List<int> numberList)
		{
			numberList.AddRange(numberArray.ToList());

			int sum = 0;
			for (int i = 0; i<numberList.Count ; i++)
            {
				if(numberList[i] == 4)
                {
					continue;
                }
				sum += numberList[i];
			}
			return sum;
		}



		public static int ForEach_SumTwoListsAndAllValueThatAreNotFour(List<int> numberList)
		{
			int sum = 0;
            foreach (int number in numberList)
            {
                if (number==4)
				{
					continue;
                }
				sum += number;
            }
			return sum;
		}
		
		public static int DoWhile_SumValuesWhileCurrentValueIsNot4_ThenStop(List<int> numberList)
		{
			int sum = 0;
			int i = 0;
			do
			{
				sum += numberList[i];
				if (numberList[i] == 4)
                {
					break;

				}
				i++;
			}
			while (i< numberList.Count);
			return sum;
		}

		public static int While_SumValuesWhileCurrentValueIsNot4_ThenStop(List<int> numberList)
		{

			int sum = 0;
			int i = 0;

			while(i< numberList.Count)
            {
				sum += numberList[i];
				if(numberList[i] == 4)
                {
					break;
                }
				i++;

			}
			return sum;
		}

		/*
		 * If you have not learned about System.Linq and Lambda expressions, google `C# LINQ Tutorial`...trust me, you will thank me if you learn this early.
		 */
		public static int Linq_SumTwoListsAndAllValueThatAreNotFour(List<int> numberList)
		{
			var ListNoFour = numberList.Where((x) => x != 4);
			var sum = ListNoFour.Sum();
			return sum;
		}
	}
}
 
 
 
 