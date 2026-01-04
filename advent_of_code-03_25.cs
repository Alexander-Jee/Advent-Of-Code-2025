// List of digits separated by line ("bank")
// Each digit represents value of jolt
// Each tens place represents a "battery"
// Get largest joltage for each bank
// Can only select 2 digits ("batteries")
// You get value of joltage by appending digits
// e.g 811111111111119 = 89 = largest joltage

// Part 2 
// You power 12 digits (batteries)
// bank = 234234234234278
// largest jolt = 434234234278

// 23423
// 34234
// 42342
// 42343
// 43434


int result = 0;

// var batteryBanks = await File.ReadAllLinesAsync("day3_input.txt");
List<string> batteryBanks = [
    "987654321111111",
    "811111111111119",
    "234234234234278",
    "818181911112111"
];

foreach (var batteryBank in batteryBanks)
{
    var joltString = batteryBank[..12];
    var num1 = (int) char.GetNumericValue(batteryBank[0]);
    var num2 = (int) char.GetNumericValue(batteryBank[1]);
    var lastNum = (int) char.GetNumericValue(batteryBank[11]);
    for (int i = 12; i < batteryBank.Length; i++)
    {
        int nextNum = (int) char.GetNumericValue(batteryBank[i]);
        if (lastNum < nextNum)
        {
            
        }
        else if (num1 < num2)
        {
            num1 = num2;
            num2 = nextNum;
        }
        else if (num2 < nextNum)
        {
            num2 = nextNum;
        }
    }
    int joltage = num1 * 10 + num2;
    result += joltage;
}
Console.WriteLine(result);
