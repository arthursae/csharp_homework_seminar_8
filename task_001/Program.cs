// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

List<int> MergeArrays(List<int> leftPart, List<int> rightPart, bool descendingOrder)
{
    List<int> sortedResult = new List<int>();

    while (leftPart.Count > 0 || rightPart.Count > 0)
    {
        if (leftPart.Count > 0 && rightPart.Count > 0)
        {
            int firstLeft = leftPart.First(),
                firstRight = rightPart.First();

            if (descendingOrder)
            {
                firstLeft = rightPart.First();
                firstRight = leftPart.First();
            }

            if (firstLeft <= firstRight)
            {
                sortedResult.Add(leftPart.First());
                leftPart.Remove(leftPart.First());
            }
            else
            {
                sortedResult.Add(rightPart.First());
                rightPart.Remove(rightPart.First());
            }
        }
        else if (leftPart.Count > 0)
        {
            sortedResult.Add(leftPart.First());
            leftPart.Remove(leftPart.First());
        }
        else if (rightPart.Count > 0)
        {
            sortedResult.Add(rightPart.First());
            rightPart.Remove(rightPart.First());
        }
    }
    return sortedResult;
}

List<int> MergeSort(List<int> unsortedArray)
{
    int length = unsortedArray.Count,
        middle = length / 2;

    if (length <= 1)
        return unsortedArray;

    List<int> leftPart = new List<int>(),
        rightPart = new List<int>();

    for (int i = 0; i < middle; i++)
        leftPart.Add(unsortedArray[i]);

    for (int i = middle; i < length; i++)
        rightPart.Add(unsortedArray[i]);

    leftPart = MergeSort(leftPart);
    rightPart = MergeSort(rightPart);
    return MergeArrays(leftPart, rightPart, true); // Sort in descending order switch = true/false
}

List<int> GetASingleRowByItsIndex(int rowIndex, int[,] matrix)
{
    int rows = matrix.GetLength(0),
        columns = matrix.GetLength(1);

    List<int> singleRow = new List<int>();

    if (rowIndex < rows)
    {
        for (int i = 0; i < columns; i++)
        {
            singleRow.Add(matrix[rowIndex, i]);
        }
    }
    return singleRow;
}

int[,] ConstructSortedMatrix(int[,] unsortedMatrix)
{
    int rows = unsortedMatrix.GetLength(0);
    int columns = unsortedMatrix.GetLength(1);
    int[,] sortedMatrix = new int[rows, columns];
    List<int> singleRow = new List<int>();
    List<int> sortedList = new List<int>();

    for (int i = 0; i < rows; i++)
    {
        singleRow = GetASingleRowByItsIndex(i, unsortedMatrix);
        sortedList = MergeSort(singleRow);

        for (int j = 0; j < columns; j++)
        {
            sortedMatrix[i, j] = sortedList[j];
        }
    }
    return sortedMatrix;
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

int[,] GenerateMatrix(int minDimension, int maxDimension, int minValue, int maxValue)
{
    var rand = new Random();
    int rows = rand.Next(minDimension, maxDimension),
        columns = rand.Next(minDimension, maxDimension);
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

int minDimension = 5,
    maxDimension = 10,
    minValue = 0,
    maxValue = 100;

int[,] unsortedMatrix = GenerateMatrix(minDimension, maxDimension, minValue, maxValue);
int rows = unsortedMatrix.GetLength(0),
    columns = unsortedMatrix.GetLength(1);
Console.WriteLine("Сгенерирован двумерный массив размером " + rows + "×" + columns + ": \n");
OutputMatrix(unsortedMatrix);

// Сортировка слиянием
// Источник: https://academy.yandex.ru/journal/osnovnye-vidy-sortirovok-i-primery-ikh-realizatsii

int[,] sortedMatrix = ConstructSortedMatrix(unsortedMatrix);
Console.WriteLine("Упорядоченные по убыванию элементы каждой строки двумерного массива: \n");
OutputMatrix(sortedMatrix);
