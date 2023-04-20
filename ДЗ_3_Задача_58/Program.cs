/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

Console.Write("Введите количество строк 1-й матрицы: ");
int rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов 1-й матрицы: ");
int columns = int.Parse(Console.ReadLine()!);

int[,] array1 = GetRandomMatrix(rows,columns, 0, 10);

Console.Write("Введите количество строк 2-й матрицы: ");
rows = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов 2-й матрицы: ");
columns = int.Parse(Console.ReadLine()!);

int[,] array2 = GetRandomMatrix(rows,columns, 0, 10);

Console.WriteLine("Исходная матрица 1: ");
PrintArray(array1);

Console.WriteLine("Исходная матрица 2: ");
PrintArray(array2);

ValidateInput(array1,array2);

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


int[,] MultiplicationMatrix(int[,] array1, int[,] array2)
{
    int [,] result = new int[array1.GetLength(0),array2.GetLength(1)];
    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            for (int k = 0; k < array2.GetLength(0); k++)
            {
                result[i,j] += array1[i,k] * array2[k,j];
            }
        }
    }
    return result;
}

void ValidateInput(int[,] array1, int[,] array2)
{
    if(array1.GetLength(1)!=array2.GetLength(0)) Console.WriteLine("Матрицы не соответствуют требованиям операции умножения"); 
    else 
    {
        int [,] result = MultiplicationMatrix(array1,array2);
        Console.WriteLine("Результирующая матрица: ");
        PrintArray(result);
    }
}