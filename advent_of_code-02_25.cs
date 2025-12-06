// Number ID's are given an inclusive range
// Find the sum of all invalid ID's in range
// Valid ID = a number IN RANGE that has a TWICE repeating number of number IN RANGE
// e.g 11-22 = 2 Valid = 11, 22
// e.g. 95 -115 = 1 Valid = 99
// valid repeating number can not start with 0

// assumptions: no negative ID numbers

// List<string> input = 
// [
//     "11-22","95-115","998-1012","1188511880-1188511890","222220-222224",
//     "1698522-1698528","446443-446449","38593856-38593862","565653-565659",
//     "824824821-824824827","2121212118-2121212124"
// ];
List<string> input = (await File.ReadAllTextAsync("day2_input.txt"))
                    .Split(",")
                    .ToList();

long result = 0; // Sum of All Valid Numbers in each range

foreach (var rangeInput in input)
{
    var numbers = rangeInput.Split("-");
    long startNumber = long.Parse(numbers[0]);
    long endNumber = long.Parse(numbers[1]);
    // var tensPlaces = ValidTensPlace(startNumber, endNumber);
    // if (tensPlaces.Count == 0) break;
    // int idxValidTensPlace = 0;
    // int currentTensPlace = tensPlaces[idxValidTensPlace];

    for (long numInRange = startNumber; numInRange <= endNumber; numInRange++)
    {
        if (IsIdValid(numInRange))
        {
            result += numInRange;
        }
    }
}

Console.WriteLine(result);

// input only works with ID's with even number of tens places
static bool IsIdValid(long id)
{
    var numString = id.ToString();
    if (numString.Length % 2 != 0) return false;
    int lenOfRepeatedNum = numString.Length / 2;
    string firstHalf = numString[lenOfRepeatedNum..];
    string secondHalf = numString[..lenOfRepeatedNum];

    if (firstHalf.Equals(secondHalf)) return true;
    return false;
}

// most likely unnecessary
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