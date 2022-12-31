// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

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

int[,] FillAnySizeMatrixClockwise(int[,] matrix)
{
    int lowerBoundRows = 0,
        lowerBoundColumns = 0,
        upperBoundRows = matrix.GetUpperBound(0),
        upperBoundColumns = matrix.GetUpperBound(1),
        currentRow = 0,
        currentColumn = 0,
        cycle = 0;

    for (int i = 0; i < matrix.Length; i++)
    {
        int num = i + 1;

        if (
            currentRow >= lowerBoundRows
            && currentRow <= upperBoundRows
            && currentColumn >= lowerBoundColumns
            && currentColumn <= upperBoundColumns
        )
        {
            if (currentRow == lowerBoundRows && currentColumn < upperBoundColumns)
            {
                matrix[currentRow, currentColumn] = num;
                currentColumn++;
            }
            else if (currentColumn == upperBoundColumns && currentRow < upperBoundRows)
            {
                matrix[currentRow, currentColumn] = num;
                currentRow++;
            }
            else if (currentRow == upperBoundRows && currentColumn > lowerBoundColumns)
            {
                matrix[currentRow, currentColumn] = num;
                currentColumn--;
            }
            else if (currentColumn == lowerBoundColumns && currentRow > lowerBoundRows)
            {
                matrix[currentRow, currentColumn] = num;
                currentRow--;
            }

            // Shift bounds

            if (currentColumn == lowerBoundColumns && currentRow == upperBoundRows && i > 0)
            {
                matrix[currentRow, currentColumn] = num;
                lowerBoundRows++;
                upperBoundColumns--;
                cycle++;
            }

            else if (currentColumn == upperBoundColumns && currentRow == lowerBoundRows && cycle > 0)
            {
                matrix[currentRow, currentColumn] = num;
                upperBoundRows--;
                lowerBoundColumns++;
            }
        }
    }

    return matrix;
}

Console.Clear();

int rows = 4, // Change to any number > 0
    columns = 4; // Change to any number > 0

int[,] matrix = new int[rows, columns];
int[,] filledMatrix = FillAnySizeMatrixClockwise(matrix); // The matrix of any size will do
OutputMatrix(filledMatrix);
