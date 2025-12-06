// Number ID's are given an inclusive range
// Find the sum of all invalid ID's in range
// Invalid ID = a number IN RANGE that has ANY number inside of number IN RANGE that repeats TWICE
// e.g 11-22 = 2 Invalid = 11, 22
// 99-115 = 1 Invalid = 99

// assumptions: no negative ID numbers

List<string> input = 
[
    "11-22","95-115","998-1012","1188511880-1188511890","222220-222224",
    "1698522-1698528","446443-446449","38593856-38593862","565653-565659",
    "824824821-824824827","2121212118-2121212124"
];
// List<string> input = [.. (await File.ReadAllTextAsync("day2_input.txt")).Split(",")];

var result = 0; // Sum of All Invalid Numbers in each range

foreach (var rangeInput in input)
{
    var numbers = rangeInput.Split("-");
    int startNumber = int.Parse(numbers[0]);
    int endNumber = int.Parse(numbers[1]);
    var tensPlaces = ValidTensPlace(startNumber, endNumber);
    if (tensPlaces.Count == 0) break;

    for (int i = startNumber; i <= endNumber; i++)
    {
        
    }
}

static List<int> ValidTensPlace(int startNumber, int endNumber)
{
    var exponent = 1;
    
    List<int> result = [];

    var tensPlace = Math.Pow(10, exponent);

    while (tensPlace >= startNumber || tensPlace <= endNumber)
    {
        result.Add((int) tensPlace);
        exponent += 2;
    }
    return result;
}