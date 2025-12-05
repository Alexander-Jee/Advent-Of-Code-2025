// 0-99 valid numbers
// rotation with "L" and "R" 
// Input stayed the same between day 1 and 2
var inputLines = await File.ReadAllLinesAsync("day1_input.txt");
// List<string> inputLines = ["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"];
var startNumber = 50;
var result = 0;
var timesDialPastZero = 0;
bool rotatingLeft = false;
foreach (var line in inputLines)
{
    var direction = line[0];
    rotatingLeft = direction == 'L';

    var steps = int.Parse(line[1..]);
    timesDialPastZero = steps / 100;
    steps %= 100;

    if (rotatingLeft)
    {
        startNumber -= steps;
        if (startNumber < 0)
        {
            startNumber += 100;
            ++timesDialPastZero;
        }
    }

    if (!rotatingLeft)
    {
        var originalStartNumber = startNumber;
        var sum = startNumber + steps;
        startNumber = sum % 100;
        if (sum >= 100 || originalStartNumber > startNumber)
        {
            ++timesDialPastZero;
        }
    }
    result += timesDialPastZero;

    timesDialPastZero = 0;
}
Console.WriteLine(result);
