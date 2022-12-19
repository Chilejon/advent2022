using Microsoft.Win32;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Collections.Immutable;

//elves();

//rps();

//packing();

cleaning();

void cleaning()
{
	string cleaningData = File.ReadAllText(@"C:\code\Advent2022\Advent2022\Data\day4.txt");

	string[] cleans = cleaningData.Split("\r\n");

	int score = 0;
	int overlapped = 0;

	foreach (string clean in cleans)
	{
		string[] cleansplit = clean.Split(",");
		string[] leftElf = cleansplit[0].Split("-");
		string[] rightElf = cleansplit[1].Split("-");

		var leftElfdiff = int.Parse(leftElf[1]) - int.Parse(leftElf[0]);
		var rightElfdiff = int.Parse(rightElf[1]) - int.Parse(rightElf[0]);

		var leftElfArea = string.Empty;
		var rightElfArea = string.Empty;


		for (int i = 0; i < leftElfdiff; i++)
		{
			leftElfArea = leftElfArea + (int.Parse(leftElf[0]) + i) + "-";
		}

		for (int i = 0; i < rightElfdiff; i++)
		{
			rightElfArea = rightElfArea + (int.Parse(rightElf[0]) + i) + "-";
		}

		if (leftElfArea.Length > 1)
		{
			leftElfArea = leftElfArea.Remove(leftElfArea.Length - 1, 1);
		}
		if (rightElfArea.Length > 1)
		{
			rightElfArea = rightElfArea.Remove(rightElfArea.Length - 1, 1);
		}

		if (rightElfArea.Contains(leftElfArea))
		{
			overlapped++;
			Console.WriteLine("L in R overlap: " + leftElfArea + " " + rightElfArea);
		}

		if (leftElfArea.Contains(rightElfArea))
		{
			overlapped++;
			Console.WriteLine("R in L overlap: " + leftElfArea + " " + rightElfArea);
		}
		



		//leftElfArea = leftElf[0].ToString();
		//if (leftElf[0] != leftElf[0])
		//{
		//	leftElfArea += int.Parse(leftElf[0]) + 1;
		//}
		//rightElfArea = rightElf[0].ToString();

	}


	Console.WriteLine("overlap: " + overlapped);

	var assignedSections = File.ReadLines(@"C:\code\Advent2022\Advent2022\Data\day4.txt").ToList();
	var overlappingSectionsCount = 0;
	assignedSections.ForEach(pair =>
	{
		var sectionRanges = ParseSections(pair).ToImmutableArray();
		if (IsOverlapping(sectionRanges[0], sectionRanges[1])) overlappingSectionsCount++;
	});
	Console.WriteLine($"There are {overlappingSectionsCount} assigned sections that are overlapping.");

	var intersectingSectionsCount = 0;
	assignedSections.ForEach(pair =>
	{
		var sectionRanges = ParseSections(pair).ToImmutableArray();
		if (IsIntersecting(sectionRanges[0], sectionRanges[1])) intersectingSectionsCount++;
	});
	Console.WriteLine($"There are {intersectingSectionsCount} assigned sections that are partially overlapping.");


}

IEnumerable<Range> ParseSections(string assignmentPair)
{
	return assignmentPair.Split(',').Select(GetRange).ToList();
}

Range GetRange(string assignmentPair)
{
	var sections = assignmentPair.Split('-').Select(int.Parse).ToArray();
	return new Range(sections[0], sections[1]);
}

bool IsOverlapping(Range startRange, Range endRange)
{
	return (startRange.Start.Value <= endRange.Start.Value && startRange.End.Value >= endRange.End.Value) || (endRange.Start.Value <= startRange.Start.Value && endRange.End.Value >= startRange.End.Value);
}

bool IsIntersecting(Range startRange, Range endRange)
{
	return startRange.Start.Value <= endRange.End.Value && endRange.Start.Value <= startRange.End.Value;
}

void packing()
{
	string packingData = File.ReadAllText(@"C:\code\Advent2022\Advent2022\Data\day3.txt");

	string[] packs = packingData.Split("\r\n");

	string letterIndex = "0abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

	int score = 0;
	int newScore = 0;

	foreach (string pack in packs)
	{
		string left = pack.Substring(0, pack.Length / 2);
		string right = pack.Substring(pack.Length / 2);
		string duplicate = string.Empty;
		foreach (var item in left)
		{
			if (right.Contains(item.ToString())){
				duplicate = item.ToString();
			} 
		}
		
		score += letterIndex.IndexOf(duplicate);
	}
	Console.WriteLine("score: " + score);

	List<string> listPacks = packs.ToList();
	string[] packArrays;
	string pack1 = string.Empty;
	string pack2 = string.Empty;
	string pack3 = string.Empty;

	IEnumerable<string[]> chunks = listPacks.Chunk(3);

	

	foreach (var item in chunks)
	{
		string tripleicate = string.Empty;
		foreach (var individual in item[0])
		{
			if (item[1].Contains(individual.ToString()) && item[2].Contains(individual.ToString()))
			{
				tripleicate = individual.ToString();
			}
		}

		newScore += letterIndex.IndexOf(tripleicate);


		//Console.WriteLine("chunk: " + item[0]);
		//Console.WriteLine("chunk: " + item[1]);
		//
	}

	Console.WriteLine("newScore: " + newScore);
}




void rps()
{
	string rpsData = File.ReadAllText(@"C:\code\Advent2022\Advent2022\Data\RPS.txt");

	string[] allRps = rpsData.Split("\r\n");

	int score = 0;
	foreach (string row in allRps)
	{
		// ROCK PAPER SCISSORS
		// A	B		C
		// Y	X		Z

		string a = row[0].ToString();
		string b = row[2].ToString();

		//if (a.Equals("A"))
		//{
		//	if (b.Equals("X"))
		//	{
		//		score += 4;
		//	}
		//	if (b.Equals("Y"))
		//	{
		//		score += 8;
		//	}
		//	if (b.Equals("Z"))
		//	{
		//		score += 3;
		//	}
		//}

		//if (a.Equals("B"))
		//{
		//	if (b.Equals("X"))
		//	{
		//		score += 1;
		//	}
		//	if (b.Equals("Y"))
		//	{
		//		score += 5;
		//	}
		//	if (b.Equals("Z"))
		//	{
		//		score += 9;
		//	}
		//}

		//if (a.Equals("C"))
		//{
		//	if (b.Equals("X"))
		//	{
		//		score += 7;
		//	}
		//	if (b.Equals("Y"))
		//	{
		//		score += 2;
		//	}
		//	if (b.Equals("Z"))
		//	{
		//		score += 6;
		//	}
		//}

		if (a.Equals("A"))
		{
			if (b.Equals("X"))
			{
				score += 3;
			}
			if (b.Equals("Y"))
			{
				score += 4;
			}
			if (b.Equals("Z"))
			{
				score += 8;
			}
		}

		if (a.Equals("B"))
		{
			if (b.Equals("X"))
			{
				score += 1;
			}
			if (b.Equals("Y"))
			{
				score += 5;
			}
			if (b.Equals("Z"))
			{
				score += 9;
			}
		}

		if (a.Equals("C"))
		{
			if (b.Equals("X"))
			{
				score += 2;
			}
			if (b.Equals("Y"))
			{
				score += 6;
			}
			if (b.Equals("Z"))
			{
				score += 7;
			}
		}



		//if (b == "Y") {
		//	score += 2;
		//	if (a == "A")
		//	{
		//		score += 3;
		//	}
		//	if (a == "B")
		//	{
		//		score += 0;
		//	}
		//	if (a == "C")
		//	{
		//		score += 6;
		//	}
		//}

		//// ROCK PAPER SCISSORS
		//// A	B		C
		//// Y	X		Z
		//if (b == "X")
		//{
		//	score += 1;
		//	if (a == "A")
		//	{
		//		score += 6;
		//	}
		//	if (a == "B")
		//	{
		//		score += 3;
		//	}
		//	if (a == "C")
		//	{
		//		score += 0;
		//	}
		//}

		//// ROCK PAPER SCISSORS
		//// A	B		C
		//// Y	X		Z
		//if (b == "Z") { 
		//	score += 3;
		//	if (a == "A")
		//	{
		//		score += 0;
		//	}
		//	if (a == "B")
		//	{
		//		score += 6;
		//	}
		//	if (a == "C")
		//	{
		//		score += 3;
		//	}


		//}


		//Console.WriteLine("score: " + score);



	}
	Console.WriteLine("score: " + score);




	Console.WriteLine("Rows: " + allRps.Length);

}





void elves() {

	string elvesData = File.ReadAllText(@"C:\code\Advent2022\Advent2022\Data\CaloriesEachElve.txt");

	string[] elves = elvesData.Split(new string[] { "\r\n\r\n" },
								   StringSplitOptions.RemoveEmptyEntries);

	int upperCalories = 0;
	int elfNumber = 0;
	int upperCaloriesElve = 0;

	List<int> allElvesCalories = new List<int> { };
	List<int> sortedElvesCalories = new List<int> { };



	foreach (var elve in elves)
	{
		elfNumber++;
		int elveCalorie = 0;
		string[] elvesCalories = elve.Split(new string[] { "\r\n" },
								   StringSplitOptions.RemoveEmptyEntries);

		foreach (var item in elvesCalories)
		{
			elveCalorie += Int32.Parse(item);
		}

		allElvesCalories.Add(elveCalorie);



		if (elveCalorie > upperCalories)
		{
			upperCaloriesElve = elfNumber;
			upperCalories = elveCalorie;
		}



	}

	allElvesCalories.Sort();

	int fattyElve1 = 0;
	int fattyElve2 = 0;
	int fattyElve3 = 0;

	fattyElve1 = allElvesCalories[251];
	fattyElve2 = allElvesCalories[250];
	fattyElve3 = allElvesCalories[249];

	int totalFattyCalories = fattyElve1 + fattyElve2 + fattyElve3;


	Console.WriteLine("Number of Elves: " + elves.Length);
	Console.WriteLine("Fatty Elve is: " + upperCaloriesElve + " " + upperCalories);
	Console.WriteLine("Top 3 Fatty Elves is: " + totalFattyCalories);

	//um1 = Convert.ToInt32(Console.ReadLine());
}