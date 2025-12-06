// Number ID's are given an inclusive range
// Find the sum of all invalid ID's in range
// Valid ID = a number IN RANGE that has a TWICE repeating number of number IN RANGE
// e.g 11-22 = 2 Valid = 11, 22
// e.g. 95 -115 = 1 Valid = 99
// valid repeating number can not start with 0

// assumptions: no negative ID numbers

List<string> input = 
[
    "11-22","95-115","998-1012","1188511880-1188511890","222220-222224",
    "1698522-1698528","446443-446449","38593856-38593862","565653-565659",
    "824824821-824824827","2121212118-2121212124"
];
// List<string> input = [.. (await File.ReadAllTextAsync("day2_input.txt")).Split(",")];

var result = 0; // Sum of All Valid Numbers in each range

foreach (var rangeInput in input)
{
    var numbers = rangeInput.Split("-");
    int startNumber = int.Parse(numbers[0]);
    int endNumber = int.Parse(numbers[1]);
    var tensPlaces = ValidTensPlace(startNumber, endNumber);
    if (tensPlaces.Count == 0) break;
    int idxValidTensPlace = 0;
    var currentTensPlace = tensPlaces[idxValidTensPlace];

    for (int i = startNumber; i <= endNumber && idxValidTensPlace < tensPlaces.Count; i++)
    {
        
    }
}

static bool IsIdValid(int number)
{

    return false;
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