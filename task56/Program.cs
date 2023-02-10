/*
Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

*/

//return sum of all elements in given array
int SumOfArray (int[] array)
{
    int sum = 0;
    for (int i=0; i < array.Length; i++) sum += array[i];

    return sum;
}

//returns one dimensional array filled with the values
//extracted from the given row of the matrix. 
int[] GetRow(int[,] matrix, int rowNumber)
{    
    int [] resultArray = new int[matrix.GetLength(1)];

    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        resultArray[i] = matrix[rowNumber, i];
    }    
   
    return resultArray;
}

int[,] InitMatrix(int rows, int columns, int rndMax, int rndMin)
{
    int[,] matrix = new int[rows, columns];
    
    Random rnd = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i,j] = rnd.Next(rndMin, rndMax);
        }                
    }

    return matrix;
}


void PrintMatrix (int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]}".PadLeft(7, ' '));            
        }
        Console.WriteLine();
    }
}


const int rows = 0, columns = 1; // это чтобы не запутаться
int[] newMatrixDimensions = {8, 3};

Console.Clear();

int[,] matrix = InitMatrix (rows : newMatrixDimensions[rows],
                            columns: newMatrixDimensions[columns],
                            rndMin: 0,
                            rndMax: 100);

PrintMatrix(matrix);

int minSum = 0, minSumRowIndex = 0;

for (int i = 0; i < matrix.GetLength(rows); i++)
{   
    int thisRowSum = SumOfArray(GetRow(matrix, rowNumber: i));
    if (i == 0)
    {
        minSum = thisRowSum; //array could countain negative numbers
    }
    else
    {
        if (thisRowSum < minSum)
        {
            minSum = thisRowSum;
            minSumRowIndex = i;
        }
    }
}

Console.WriteLine($"Номер строки с наименьшей суммой элементов: {minSumRowIndex}");