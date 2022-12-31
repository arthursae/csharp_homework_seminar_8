// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] MultiplyTwoMatrices(int[,] matrixA, int[,] matrixB)
{
    int rowsA = matrixA.GetLength(0),
        rowsB = matrixB.GetLength(0),
        columnsA = matrixA.GetLength(1),
        columnsB = matrixB.GetLength(1);

    int[,] matrixC = new int[rowsA, columnsB]; // The result will have the same number of rows as the 1st matrix, and the same number of columns as the 2nd matrix.

    if (columnsA == rowsB) //NOTE: This condition to be checked before calling this method
    {
        int dotProduct = 0;

        for (int k = 0; k < columnsB; k++)
        {
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < columnsA; j++)
                {
                    dotProduct += matrixA[i, j] * matrixB[j, k];
                }

                matrixC[i, k] = dotProduct;
                dotProduct = 0;
            }
        }
    }

    return matrixC;
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

int[,] GenerateMatrix(int rows, int columns, int minValue, int maxValue)
{
    int[,] dummyMatrix = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            dummyMatrix[i, j] = new Random().Next(minValue, maxValue);
        }
    }

    return dummyMatrix;
}

Console.Clear();

int rowsA = 3,
    columnsA = 4, // The number of columns of the 1st matrix must equal the number of rows of the 2nd matrix
    rowsB = 4, // See the comment above
    columnsB = 5,
    minValue = 1,
    maxValue = 10;

int[,] matrixA = GenerateMatrix(rowsA, columnsA, minValue, maxValue);
int[,] matrixB = GenerateMatrix(rowsB, columnsB, minValue, maxValue);

if (columnsA == rowsB) // Just in case to check the condition
{
    int[,] matrixC = MultiplyTwoMatrices(matrixA, matrixB);
    int rowsC = matrixC.GetLength(0),
        columnsC = matrixC.GetLength(1);

    Console.WriteLine("Матрица А размером " + rowsA + "x" + columnsA + ": \n");
    OutputMatrix(matrixA);
    Console.WriteLine("\n");
    Console.WriteLine("Матрица B размером " + rowsB + "x" + columnsB + ": \n");
    OutputMatrix(matrixB);
    Console.WriteLine("\n");
    Console.WriteLine(
        "Результат умножения матриц А * B ->\n"
            + "матрица C размером "
            + rowsC
            + "x"
            + columnsC
            + ": \n"
    );
    OutputMatrix(matrixC);
}
else
{
    Console.WriteLine(
        "Чтобы можно было умножить две матрицы, количество столбцов первой матрицы должно быть равно количеству строк второй матрицы."
    );
}
