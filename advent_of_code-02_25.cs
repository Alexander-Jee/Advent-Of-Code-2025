// 0-99 valid numbers
// rotation with "L" and "R" 
var inputLines = await File.ReadAllLinesAsync("day1_input.txt");
var startNumber = 50;
var result = 0;
var pointedAtZero = false;
foreach (var line in inputLines)
{
    var direction = line[0];
    var steps = int.Parse(line[1..]);
    steps %= 100;
    if (direction == 'L')
    {
        startNumber -= steps;
        if (startNumber < 0)
        {
            pointedAtZero = true;
            startNumber += 100;
        }
    }
    else
    {
        if ((startNumber + steps) > 100)
        {
            pointedAtZero = true;
        }
        startNumber = (startNumber + steps) % 100;
    }
    
    if (startNumber == 0)
    {
        result++;
    }

    // reset whether or not dial "went past" 0
    pointedAtZero = false;
}
Console.WriteLine(result);
