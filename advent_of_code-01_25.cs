// 0-99 valid numbers
// rotation with "L" and "R" 
// Input stayed the same between day 1 and 2
var inputLines = await File.ReadAllLinesAsync("day1_input.txt");
// List<string> inputLines = ["L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"];
// List<string> inputLines = ["L150", "L250"];

var currentPosition = 50;
var result = 0;
var fullDialRotations = 0;
bool rotatingLeft = false;

foreach (var line in inputLines)
{
    var direction = line[0];
    rotatingLeft = direction == 'L';
    var steps = int.Parse(line[1..]);

    var remainderSteps = steps % 100;
    fullDialRotations = (steps - remainderSteps) / 100;

    if (rotatingLeft)
    {
        currentPosition -= remainderSteps;
        if (currentPosition < 0)
        {
            if (currentPosition + remainderSteps != 0)
            {
                fullDialRotations++;
            }
            currentPosition += 100; // Adjust dial to be on new looped number
        }
    }

    if (!rotatingLeft)
    {
        var sum = currentPosition + remainderSteps;
        currentPosition = sum % 100;

        if (sum > 100)
        {
            fullDialRotations++;
        }
    }

    if (currentPosition == 0)
    {
        result++;
    }
    result += fullDialRotations;
    fullDialRotations = 0;
    Console.WriteLine("Result: {0} Current Position: {1} Remainder Steps: {2} Total Steps: {3}", result, currentPosition, remainderSteps, steps);
}
Console.WriteLine(result);
