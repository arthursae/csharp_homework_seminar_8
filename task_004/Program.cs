// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

void OutputThreeDimensionalArrayValuesAndItsIndicies(int[,,] threeDimensionalArray)
{
    int stacks = threeDimensionalArray.GetLength(0),
        rows = threeDimensionalArray.GetLength(1),
        columns = threeDimensionalArray.GetLength(2);

    for (int s = 0; s < stacks; s++)
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                Console.Write(threeDimensionalArray[s, r, c] + "(" + s + ", " + r + ", " + c + ")\t");
            }
            Console.WriteLine();
        }
    }
}

List<int> GenerateUniqueRandomNumbers(int howManyNumbers, int min, int max)
{
    List<int> numbers = new List<int>();
    int counter = numbers.Count;

    while (numbers.Count < howManyNumbers)
    {
        int randomNumber = new Random().Next(min, max);
        if (numbers.IndexOf(randomNumber) == -1)
            numbers.Add(randomNumber);
    }

    return numbers;
}

int[,,] CreateThreeDimensionalArray(List<int> numbers, int stacks, int rows, int columns)
{
    int[,,] threeDimensionalArray = new int[stacks, rows, columns];
    int counter = 0;

    for (int s = 0; s < stacks; s++)
    {
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                threeDimensionalArray[s, r, c] = numbers[counter];
                counter++;
            }
        }
    }

    return threeDimensionalArray;
}

Console.Clear();

int stacks = 2,
    rows = 2,
    columns = 2,
    items = stacks * rows * columns,
    min = 10,
    max = 100;

List<int> numbers = GenerateUniqueRandomNumbers(items, min, max);
int[,,] threeDimensionalArray = CreateThreeDimensionalArray(numbers, stacks, rows, columns);
OutputThreeDimensionalArrayValuesAndItsIndicies(threeDimensionalArray);
