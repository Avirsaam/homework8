/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4

В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2

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

// returns two dimensional array with replaced entire row 
// at allocated position, with the values from the one-dimensional
// array provided
int[,] PutRowToMatrix (int[,] matrix, int[] rowArray, int rowNumber) 
{
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        matrix[rowNumber, i] = rowArray[i];
    }
    return matrix;
}

/*
------ Not required in this task but could be reused in the future ----

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

// returns two dimensional array with replaced entire row 
// at allocated position, with the values from the one-dimensional
// array provided
int[,] PutColumnToMatrix (int[,] matrix, int[] columnArray, int columnNumber) 
{
    {
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        matrix[i, columnNumber] = columnArray[i];
    }

    return matrix;
    }
}
*/


int[] SortArrayDescending(int[] array)
{   
    for (int i = 0; i < array.Length; i++)
    {
        int indexOfMax = i;

        for (int j = i; j < array.Length; j++)
        {
            if (array[indexOfMax] < array[j]) indexOfMax = j; 
        }
        
        int temp = array[i];
        array[i] = array[indexOfMax];
        array[indexOfMax] = temp;
    }
    
    return array;
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


const int columns = 1, rows = 0;
int[] newMatrixDimensions = {6, 7};

Console.Clear();

int[,] matrix = InitMatrix (rows : newMatrixDimensions[rows],
                            columns: newMatrixDimensions[columns],
                            rndMin: 0,
                            rndMax: 100);


Console.WriteLine("Unsorted:");
PrintMatrix(matrix);

for (int i = 0; i < matrix.GetLength(rows); i++)         // делаем для каждой строки в матрице
{
    PutRowToMatrix(matrix, SortArrayDescending(GetRow(matrix, rowNumber: i)), i);
}

Console.WriteLine("\nRows sorted descending:");
PrintMatrix(matrix);

