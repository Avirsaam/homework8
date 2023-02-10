/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3

Результирующая матрица будет:
18 20
15 18

*/


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

//returns one dimensional array filled with the values
//extracted from the given column of the matrix. 
int[] GetColumn(int[,] matrix, int colNumber)
{
    int [] resultArray = new int[matrix.GetLength(0)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        resultArray[i] = matrix[i, colNumber];
    }    
    //foreach (int i in resultArray) Console.Write($"{i}, "); Console.WriteLine();

    return resultArray;
}


//возвращает скалярное произведение двух векторов
int DotProduct (int [] array1, int [] array2)
{
    int arrayLengh = array1.Length;
    if (array2.Length < arrayLengh) arrayLengh = array2.Length;

    int sum = 0;

    for (int i = 0; i < arrayLengh; i++)
    {
        sum += array1[i] * array2[i];
    }
    return sum;
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


Console.Clear();
const int rows = 0, columns = 1; // это чтобы не запутаться

int [,] matrix1 = {{2,4}, {3,2}};
int [,] matrix2 = {{3,4}, {3,3}};

Console.WriteLine("matrix1:"); PrintMatrix(matrix1);
Console.WriteLine("\nmatrix2:"); PrintMatrix(matrix2);


if (matrix1.GetLength(columns) != matrix2.GetLength(rows))
{
    Console.WriteLine("Матрицы не совместимы!");
    return;        
}
else
{
    int[,] resultMatrix = new int[matrix1.GetLength(rows), matrix2.GetLength(columns)];

    for (int c = 0; c < resultMatrix.GetLength(columns); c++)
    {
        for (int r = 0; r < resultMatrix.GetLength(rows); r++)
        {
            resultMatrix[r,c] = DotProduct(array1: GetRow(matrix1, rowNumber: r),
                                           array2: GetColumn(matrix2, colNumber: c))
                                           ;
        }
    }

    Console.WriteLine("\nПроизведение матриц:"); PrintMatrix(resultMatrix);
}