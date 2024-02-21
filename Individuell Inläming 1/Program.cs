using System.Text.RegularExpressions;

namespace Individuell_Inläming_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// List for testing
			string[] strings = { "adolf", "Adam", "axel", "bertha", "berit", "charles", "david", "Emil", "emilia", "Frank", "filip", "george", "harriet", "ivar", "janne", "karl", "Linda", "liselott", "Malin", "madde", "Nils", "olle", "Per-Anders", "paul", "Q-Bert", "Rasmus", "sture", "Ulla", "Vera", "Weronica", "Xena", "Ymer", "Zilla" };

			//Initiate console
			Console.WriteLine("(Note that program crashes if you don't input anything)");
			Console.Write("Input a first letter you want to sort names by (eg. a, b or c): ");

			// Gets input
			char searchChar = Console.ReadLine()![0];


			// Makes a list using the provided arguments
			List<string> filteredList = FilterList<string>(strings, searchChar);

			// Creates a file 
			WriteFile(filteredList, filteredList[0].ToString()[0]);
		}

		public static List<T> FilterList<T>(string[] input, char filter)
		{
			// Regex for checking input
			Regex regex = new Regex("^[a-zA-Z]+$");
			while (!regex.Match(filter.ToString()).Success)
			{
				Console.Write("Try again (input letter a-z): ");
				filter = Console.ReadLine()![0];
			}

			// Converts the input array into a temporary List of strings for looping through
			List<string> tempList = input.ToList();

			List<T> list = new List<T>();

			// Loops through the temporary list with the filter and adds the objects to the generic list
			foreach (string s in tempList)
			{
				// Checks first letter against filter and if true adds to list
				if (s.ToLower()[0] == filter.ToString().ToLower()[0])
					list.Add((T)Convert.ChangeType(s, typeof(T)));
			}

			// Returns the generic list
			return list;
		}

		public static void WriteFile(List<String> input, char searchChar)
		{
			// Sets working file path to be in base of project under the "names_data" folder
			string path = "..\\..\\..\\names_data";

			// Sets catalogname based on first letter 
			char catalogName = Char.Parse(searchChar.ToString().ToLower());

			// Checks if folder already exists on disk or else it creates it
			if (!Directory.Exists($@"{path}\{catalogName}"))
				Directory.CreateDirectory($@"{path}\{catalogName}");

			// Deletes previous file if existing
			if (File.Exists(@$"{path}\{catalogName}\names.txt"))
				File.Delete(@$"{path}\{catalogName}\names.txt");

			// Sets attributes for streamwriter to work as intended
			FileInfo fi = new FileInfo(@$"{path}\{catalogName}\names.txt");
			FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
			StreamWriter sw = new StreamWriter(fs);

			// Prints all 
			foreach (string s in input)
			{
				sw.WriteLine($"{s}");
			}

			// Closes streamwriter
			sw.Close();

			Console.WriteLine($"Wrote names to file: names_data\\{catalogName}\\names.txt");
		}
	}
}