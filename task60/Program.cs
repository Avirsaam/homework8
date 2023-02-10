/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2

66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/


int [] ShuffleArray(int randomMax, int randomMin)
{    
       
    int[] array = new int[Math.Abs(randomMax - randomMin)];
    
    for (int i = 0; i < array.Length; i++) { array[i] = randomMin++; }

    Random rnd = new Random();

    for (int i = array.Length-1; i > 0; i--)
    {        
        int thisRndRoll = rnd.Next(1, i);
        int tmp = array[thisRndRoll];        
        array[thisRndRoll] = array[i];
        array[i] = tmp;
    }
    
    return array;
}


int[,,] InitMatrix(int height, int width, int depth, int rndMax, int rndMin)
{
    int [] randomNumbersArray = ShuffleArray(randomMax: rndMax, randomMin: rndMin);

    int[,,] matrix = new int[height, width, depth];

    int counter = 0;

    for (int x = 0; x < height; x++)
    {
        for (int y = 0; y < width; y++)
        {
            for (int z = 0; z < depth; z++)
            {
                matrix[x,y,z] = randomNumbersArray[counter++];
            }
        }
    }
    return matrix;
}


Console.Clear();
int[,,] matrix = InitMatrix( height: 2, width:  2, depth:  2, 
                             rndMin: 10, rndMax: 100);


for (int z = 0; z < matrix.GetLength(2); z++)
{
    for (int x = 0; x < matrix.GetLength(0); x++)
    {
        for (int y = 0; y < matrix.GetLength(1); y++)
        {
            Console.Write($"{matrix[x,y,z]}({x},{y},{z}) ");
        }
        Console.WriteLine();
    }    
}


