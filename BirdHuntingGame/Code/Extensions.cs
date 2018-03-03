using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdHuntingGame.Code
{
	public static class Extensions
	{
		static Random RandomTicker = new Random();

		public static int GetRandomInterval()
		{
			return RandomTicker.Next(1, 10);
		}

		public static int GetRandomNumber()
		{
			return RandomTicker.Next(10, 25);
		}


		public static int GetLimitedRandomNumber(int Min, int Max)
		{
			return RandomTicker.Next(Min, Max);
		}
	}
}
