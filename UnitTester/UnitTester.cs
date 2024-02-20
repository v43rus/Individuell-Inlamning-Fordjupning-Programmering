namespace UnitTester
{
	using Statistics;
	public class UnitTester
	{

		// I remade the data.json file for the Unit Tester with less numbers which i had precalculated using the website
		// https://www.calculator.net/statistics-calculator.html. I did this to have a smaller sample size and using the
		// already calculated numbers i was able to assign value and check against these using the Unit Tester.
		[Fact]
		public void TestStatisticsMaximum()
		{
			//arrange
			int expected = 38;

			//act
			int actual = Statistics.Maximum();

			//assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestStatisticsMinimum()
		{
			//arrange
			int expected = 2;

			//act
			int actual = Statistics.Minimum();

			//assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestStatisticsMean()
		{
			//arrange
			double expected = 22.25;

			//act
			double actual = Statistics.Mean();

			//assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestStatisticsMedian()
		{
			//arrange
			double expected = 23;

			//act
			double actual = Statistics.Median();

			//assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestStatisticsMode()
		{
			//arrange
			int[] expected = { 23 };
			//act
			int[] actual = Statistics.Mode();

			//assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestStatisticsRange()
		{
			//arrange
			int expected = 36;
			//act
			int actual = Statistics.Range();

			//assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestStatisticsStandardDeviation()
		{
			//arrange
			double expected = Math.Round(11.508149286484, 1);
			//act
			double actual = Statistics.StandardDeviation();

			//assert
			Assert.Equal(expected, actual);
		}
	}
}