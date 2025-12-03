// 0-99 valid numbers
// rotation with "L" and "R" 
var inputLines = await File.ReadAllLinesAsync("day1_input.txt");
var startNumber = 50;
var result = 0;
foreach (var line in inputLines)
{
    var direction = line[0];
    var steps = int.Parse(line[1..]);
    steps %= 100;
    if (direction == 'L')
    {
        startNumber -= steps;
        startNumber = startNumber < 0 ? startNumber + 100 : startNumber;
    }
    else
    {
        startNumber = (startNumber + steps) % 100;
    }
    
    if (startNumber == 0)
    {
        result++;
    }
}
Console.WriteLine(result);
