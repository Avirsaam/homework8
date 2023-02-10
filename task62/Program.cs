/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07

*/
void PrintMatrix (int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]}"
                        .PadLeft(4 * matrix.GetLength(0)/matrix.GetLength(1), ' ')) //чтобы выглядела поквадратнее
                        ;            
        }
        Console.WriteLine();
    }
}


int[,] InitMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i,j] = 0;
        }                
    }
    return matrix;
}


Console.Clear();
int[] newMatrixDimensions = {17, 15};

int[,] matrix = InitMatrix (rows :   newMatrixDimensions[0],
                            columns: newMatrixDimensions[1]);

Console.WriteLine("Свежеинициализировання матрица:");
PrintMatrix(matrix);

int maxSteps = matrix.GetLength(0) * matrix.GetLength(1);
int thisStep = 0;

int currentX = 0;
int currentY = 0;

int hDistance = matrix.GetLength(1) - 1;
int vDistance = matrix.GetLength(0) - 1;

int xFinish = hDistance;
int yFinish = vDistance;

Directions nowMovingTo = Directions.Right;

matrix[currentY, currentX] = ++thisStep;


while (thisStep < maxSteps)
{
    switch (nowMovingTo)
    {
        case Directions.Right:            
            currentX++;
            if (currentX == xFinish)
            {
                xFinish = xFinish - hDistance;
                hDistance--;
                nowMovingTo = Directions.Down;
            }            
            break;

        case Directions.Left:
            currentX--;
            if (currentX == xFinish)
            {
                xFinish = xFinish + hDistance;
                hDistance--;
                nowMovingTo = Directions.Up;
            }            
            break;

        
        case Directions.Down:
            currentY++;
            if (currentY == yFinish)
            {
                vDistance--;
                yFinish = yFinish - vDistance;                
                nowMovingTo = Directions.Left;
            }            
            break;

        case Directions.Up:
            currentY--;
            if (currentY == yFinish)
            {
                vDistance--;
                yFinish = yFinish + vDistance;
                
                nowMovingTo = Directions.Right;
            }
            break;
    }

    matrix[currentY, currentX] = ++thisStep;
}

Console.WriteLine("\nЗаполненная матрица:");
PrintMatrix(matrix);

enum Directions {Left, Down, Right, Up}

