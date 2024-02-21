using Newtonsoft.Json;

namespace Statistics
{

	public static class Statistics
	{
		public static int[] source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"))!;

		public static dynamic DescriptiveStatistics()
		{
			Dictionary<string, dynamic> StatisticsList = new Dictionary<string, dynamic>()
			{
				{ "Maximum", Maximum() },
				{ "Minimum", Minimum() },
				{ "Medelvärde", Mean() },
				{ "Median", Median() },
				{ "Typvärde", String.Join(", ", Mode()) },
				{ "Variationsbredd", Range() },
				{ "Standardavvikelse", StandardDeviation() }
			};

			string output =
				$"Maximum: {StatisticsList["Maximum"]}\n" +
				$"Minimum: {StatisticsList["Minimum"]}\n" +
				$"Medelvärde: {StatisticsList["Medelvärde"]}\n" +
				$"Median: {StatisticsList["Median"]}\n" +
				$"Typvärde: {StatisticsList["Typvärde"]}\n" +
				$"Variationsbredd: {StatisticsList["Variationsbredd"]}\n" +
				$"Standardavvikelse: {StatisticsList["Standardavvikelse"]}";

			return output;
		}

		public static int Maximum()
		{
			Array.Sort(Statistics.source);
			Array.Reverse(source);
			int result = source[0];
			return result;

			// Alternate linq solution
			// return Statistics.source.OrderByDescending(a => a).First();
		}

		public static int Minimum()
		{
			Array.Sort(Statistics.source);
			int result = source[0];
			return result;

			// Alternate linq solution
			// return Statistics.source.OrderBy(a => a).First();
		}

		public static double Mean()
		{
			// The total double was -88 from the beginning which resulted in a faulty calculation
			double total = 0;

			for (int i = 0; i < source.LongLength; i++)
			{
				total += source[i];
			}
			return total / source.LongLength;
		}

		public static double Median()
		{
			Array.Sort(Statistics.source);
			int size = source.Length;
			int mid = size / 2;
			int dbl = source[mid];
			return dbl;
		}

		public static int[] Mode()
		{
			// Groups all the sources into keys and how many times they 
			var g = source.ToList().GroupBy(a => a);
			// Int that stores max amount of times a key appears
			int maxCount = g.Max(a => a.Count());
			// Selects all elements that appears most and then converts into a list which is returned
			return g.Where(a => a.Count() == maxCount).Select(a => a.Key).ToList().ToArray();
		}

		public static int Range()
		{
			Array.Sort(Statistics.source);
			source.Last();
			int min = source.First();
			int max = source.Last();

			for (int i = 0; i < source.Length; i++)
				if (source[i] > max)
					max = source[i];

			int range = max - min;
			return range;
		}

		public static double StandardDeviation()
		{
			double average = source.Average();
			double sumOfSquaresOfDifferences = source.Select(val => (val - average) * (val - average)).Sum();
			double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);

			double round = Math.Round(sd, 1);
			return round;
		}
	}
}