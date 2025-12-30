// List of digits separated by line ("bank")
// Each digit represents value of jolt
// Each tens place represents a "battery"
// Get largest joltage for each bank
// Can only select 2 digits ("batteries")
// You get value of joltage by appending digits
// e.g 811111111111119 = 89 = largest joltage

int result = 0;

var batteryBanks = await File.ReadAllLinesAsync("day3_input.txt");

foreach (var batteryBank in batteryBanks)
{
    var num1 = (int) char.GetNumericValue(batteryBank[0]);
    var num2 = (int) char.GetNumericValue(batteryBank[1]);
    for (int i = 2; i < batteryBank.Length; i++)
    {
        int nextNum = (int) char.GetNumericValue(batteryBank[i]);
        if (num1 < num2)
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
