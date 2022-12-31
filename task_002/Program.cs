// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int GetSumOfElementsInASingleRow(int rowIndex, int[,] matrix)
{
    int rows = matrix.GetLength(0),
        columns = matrix.GetLength(1),
        sum = 0;

    if (rowIndex < rows)
    {
        for (int i = 0; i < columns; i++)
        {
            sum += matrix[rowIndex, i];
        }
    }

    return sum;
}

int GetIndexOfTheRowWithTheSmallestSum(int[,] matrix)
{
    int minIndex = 0,
        min = GetSumOfElementsInASingleRow(0, matrix),
        sum = 0,
        rows = matrix.GetLength(0),
        columns = matrix.GetLength(1);

    for (int i = 1; i < rows; i++)
    {
        sum = GetSumOfElementsInASingleRow(i, matrix);

        if (sum < min)
        {
            min = sum;
            minIndex = i;
        }
    }

    return minIndex;
}

void OutputMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0),
        columns = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine("\n");
    }
}

int[,] GenerateMatrix(
    int minRows,
    int maxRows,
    int minColumns,
    int maxColumns,
    int minValue,
    int maxValue
)
{
    var rand = new Random();
    int rows = rand.Next(minRows, maxRows),
        columns = rand.Next(minColumns, maxColumns);
    int[,] dummyMatrix = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            dummyMatrix[i, j] = rand.Next(minValue, maxValue);
        }
    }

    return dummyMatrix;
}

Console.Clear();

int minRows = 6,
    maxRows = 10,
    minColumns = 4,
    maxColumns = 6,
    minValue = 1,
    maxValue = 10;

int[,] matrix = GenerateMatrix(minRows, maxRows, minColumns, maxColumns, minValue, maxValue);
int rows = matrix.GetLength(0),
    columns = matrix.GetLength(1);

Console.WriteLine("Сгенерирован двумерный массив размером " + rows + "×" + columns + ": \n");
OutputMatrix(matrix);
int minIndex = GetIndexOfTheRowWithTheSmallestSum(matrix);
Console.WriteLine("Номер строки с наименьшей суммой элементов -> " + (minIndex + 1));
