/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

Console.Write("Введите количество строк: ");
int rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов: ");
int columns = int.Parse(Console.ReadLine()!);

int[,] array = GetRandomMatrix(rows,columns, 0, 10);

Console.WriteLine("Исходная матрица: ");
PrintArray(array);

//функция сортировки
SortRawsArray(array);

Console.WriteLine("Результирующая матрица: ");
PrintArray(array);

//Функция заполнения массива 
int[,] GetRandomMatrix(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m,n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Random rnd = new Random();
            result[i,j] = new Random().Next(minValue, maxValue + 1) ;
        }
    }
    return result;
}

// -----------------Вывод массива-----------------
void PrintArray(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }
}

//функция сортировки
void SortRawsArray(int[,] array)
{
    for(int i = 0; i < array.GetLength(0); i++)
    {
        int [] Raw = new int [array.GetLength(1)];
        for(int j = 0; j < array.GetLength(1); j++)
        {
            Raw[j] = array[i,j];
            
        }
        Raw = SortRaw(Raw);
        for(int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = Raw[j];     
        }        
    }
}

int [] SortRaw(int[] Raw)
{
    int [] SortRaw = new int [Raw.GetLength(0)];
    for(int i = 0; i < Raw.GetLength(0)-1; i++)
    {
        int max = Raw[i];
        int Actual = Raw[i];
        int Pos = i;
        for(int j = i+1; j < Raw.GetLength(0); j++)
        {
            if(max < Raw[j])
            {
                Pos = j;
                max = Raw[j];
            } 
        }
        Raw[i] = Raw[Pos];
        Raw[Pos] = Actual;
    }    
    return Raw;
}