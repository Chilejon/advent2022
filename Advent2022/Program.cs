

using System.Collections;

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
	int elveCalorie	= 0;
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