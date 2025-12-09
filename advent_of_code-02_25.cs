// Number ID's are given an inclusive range
// Find the sum of all INVALID ID's in range
// Invalid ID = a number IN RANGE that has a TWICE repeating number of number IN RANGE
// e.g 11-22 = 2 Invalid = 11, 22
// e.g. 95 -115 = 1 Invalid = 99
// valid repeating number can not start with 0

// assumptions: no negative ID numbers

// List<string> input = 
// [
//     "95-115"
//     ,"11-22","998-1012","1188511880-1188511890","222220-222224",
//     "1698522-1698528","446443-446449","38593856-38593862","565653-565659",
//     "824824821-824824827","2121212118-2121212124"
// ];
List<string> input = (await File.ReadAllTextAsync("day2_input.txt"))
                    .Split(",")
                    .ToList();

long result = 0; // Sum of All Invalid Numbers in each range

foreach (var rangeInput in input)
{
    var numbers = rangeInput.Split("-");
    long startNumber = long.Parse(numbers[0]);
    long endNumber = long.Parse(numbers[1]);
    for (long numInRange = startNumber; numInRange <= endNumber; numInRange++)
    {
        if (IsIdInvalid(numInRange))
        {
            result += numInRange;
            // Console.WriteLine(numInRange + " has been added to sum");
        }
    }
}

Console.WriteLine(result);

static bool IsIdInvalid(long id)
{
    var numString = id.ToString();
    bool result = false;
    for (int lenOfRepeatNum = 1; lenOfRepeatNum < numString.Length; lenOfRepeatNum++)
    {
        var partIsRepeated = true;
        // Length of ID = n
        // check from 1 to n/2 is a valid size to be split into multiple parts
        if (numString.Length % lenOfRepeatNum == 0)
        {
            var repeatedNum = numString[..lenOfRepeatNum];
            var totalNumOfParts = numString.Length / lenOfRepeatNum;
            // Console.WriteLine(id);
            for (int orderOfPart = 0; orderOfPart < totalNumOfParts; orderOfPart++)
            {
                var startIdx = lenOfRepeatNum * orderOfPart;
                var endIdx = lenOfRepeatNum * (orderOfPart + 1);
                var nextNum = numString[startIdx..endIdx];
                // Console.Write("firstPart: {0} futureParts: {1} \n", repeatedNum, nextNum);
                if (!repeatedNum.Equals(nextNum))
                {
                    // Console.WriteLine("Id: {0} did not have an Invalid ID", id);
                    partIsRepeated = false;
                    break;
                }
            }
        }
        else
        {
            partIsRepeated = false;
        }
        result = partIsRepeated;

        if (result) break;
    }
    return result;
}